<script>
  import { onMount } from 'svelte';
  import { events } from '../lib/stores/events.js';
  import { showNotification } from '../lib/utils.js';
  import { formatDate, formatCurrency, timeUntilEvent } from '../lib/utils.js';
  import MapView from './MapView.svelte';

  let showMap = {};
  let attendingEvent = null;

  onMount(() => {
    events.loadEvents();
  });

  async function handleAttend(event) {
    if (attendingEvent === event.id) return;
    
    // Validaciones previas
    if (event.attendeesCount >= event.maxAttendees) {
      showNotification('Este evento ya está lleno', 'warning');
      return;
    }
    
    attendingEvent = event.id;
    const result = await events.attendEvent(event.id);
    
    if (result.success) {
      showNotification(result.message || '¡Te has registrado exitosamente!', 'success');
    } else {
      showNotification(result.error, 'error');
    }
    
    attendingEvent = null;
  }

  function toggleMap(eventId) {
    showMap[eventId] = !showMap[eventId];
    showMap = {...showMap};
  }

  function getProgressPercentage(current, max) {
    return Math.min((current / max) * 100, 100);
  }

  function getProgressColor(current, max) {
    const percentage = (current / max) * 100;
    if (percentage >= 90) return '#dc3545'; // Rojo
    if (percentage >= 70) return '#ffc107'; // Amarillo
    return '#28a745'; // Verde
  }
</script>

<div class="container">
  <h2 style="margin-bottom: 2rem;">
    📅 Próximos Eventos
  </h2>

  {#if $events.loading}
    <div class="spinner"></div>
  {:else if $events.error}
    <div class="empty-state">
      <div class="empty-state-icon">⚠️</div>
      <h3>Error al cargar eventos</h3>
      <p>{$events.error}</p>
      <button on:click={() => events.loadEvents()}>
        Reintentar
      </button>
    </div>
  {:else if $events.events.length === 0}
    <div class="empty-state">
      <div class="empty-state-icon">📭</div>
      <h3>No hay eventos próximos</h3>
      <p>Sé el primero en crear un evento increíble</p>
    </div>
  {:else}
    <div class="stats-grid">
      <div class="stat-card">
        <div class="stat-number">{$events.events.length}</div>
        <div class="stat-label">Eventos Disponibles</div>
      </div>
      <div class="stat-card">
        <div class="stat-number">
          {$events.events.filter(e => !e.ticketPrice).length}
        </div>
        <div class="stat-label">Eventos Gratuitos</div>
      </div>
      <div class="stat-card">
        <div class="stat-number">
          {$events.events.reduce((sum, e) => sum + (e.attendeesCount || 0), 0)}
        </div>
        <div class="stat-label">Asistentes Totales</div>
      </div>
    </div>

    <div class="events-grid">
      {#each $events.events as event (event.id)}
        <article class="card event-card">
          <div class="event-card-header">
            <div>
              <h3 style="margin-bottom: 0.5rem;">{event.title}</h3>
              <small style="color: var(--muted-color);">
                Creado por {event.createdBy.name}
              </small>
            </div>
            <span class="event-badge {event.ticketPrice ? '' : 'free'}">
              {event.ticketPrice ? formatCurrency(event.ticketPrice) : 'Gratis'}
            </span>
          </div>

          <p style="color: var(--muted-color); margin-bottom: 1rem;">
            {event.description}
          </p>

          <div class="event-meta">
            <div class="event-meta-item">
              <span>📅</span>
              <span>{formatDate(event.startDate)}</span>
            </div>
            <div class="event-meta-item">
              <span>⏰</span>
              <span>{timeUntilEvent(event.startDate)}</span>
            </div>
          </div>

          <div class="event-meta">
            <div class="event-meta-item">
              <span>📍</span>
              <span>{event.location}</span>
            </div>
          </div>

          <!-- Barra de progreso de capacidad -->
          <div style="margin: 1rem 0;">
            <div style="display: flex; justify-content: space-between; align-items: center; margin-bottom: 0.5rem;">
              <small style="color: var(--muted-color);">
                Capacidad: {event.attendeesCount || 0}/{event.maxAttendees}
              </small>
              <small style="color: var(--muted-color);">
                {Math.round(getProgressPercentage(event.attendeesCount || 0, event.maxAttendees))}%
              </small>
            </div>
            <div style="
              width: 100%;
              height: 8px;
              background: #e9ecef;
              border-radius: 4px;
              overflow: hidden;
            ">
              <div style="
                width: {getProgressPercentage(event.attendeesCount || 0, event.maxAttendees)}%;
                height: 100%;
                background: {getProgressColor(event.attendeesCount || 0, event.maxAttendees)};
                transition: width 0.3s ease;
              "></div>
            </div>
          </div>

          <div style="display: flex; gap: 0.5rem; margin-top: 1rem;">
            <button 
              on:click={() => handleAttend(event)}
              disabled={attendingEvent === event.id || (event.attendeesCount || 0) >= event.maxAttendees}
              class="btn-gradient"
              style="flex: 1;"
              aria-busy={attendingEvent === event.id}
            >
              {#if attendingEvent === event.id}
                Registrando...
              {:else if (event.attendeesCount || 0) >= event.maxAttendees}
                🚫 Evento lleno
              {:else}
                🎟️ Asistir
              {/if}
            </button>

            <button 
              on:click={() => toggleMap(event.id)}
              style="flex: 1;"
            >
              {showMap[event.id] ? '📋 Info' : '🗺️ Mapa'}
            </button>
          </div>

          {#if showMap[event.id]}
            <div style="margin-top: 1rem;">
              <MapView location={event.location} title={event.title} />
            </div>
          {/if}
        </article>
      {/each}
    </div>
  {/if}
</div>

<style>
  .events-grid {
    display: grid;
    grid-template-columns: repeat(auto-fill, minmax(350px, 1fr));
    gap: 1.5rem;
  }

  @media (max-width: 768px) {
    .events-grid {
      grid-template-columns: 1fr;
    }
  }
</style>