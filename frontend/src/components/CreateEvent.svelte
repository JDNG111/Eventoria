<script>
  import { createEventDispatcher } from 'svelte';
  import { events } from '../lib/stores/events.js';
  import { showNotification } from '../lib/utils.js';

  const dispatch = createEventDispatcher();

  let title = '';
  let description = '';
  let startDate = '';
  let endDate = '';
  let location = '';
  let ticketPrice = '';
  let maxAttendees = 50;
  let isPublic = true;
  let loading = false;

  // Set minimum date to today
  const today = new Date().toISOString().slice(0, 16);

  async function handleCreate() {
    // Validations
    if (!title || !description || !startDate || !endDate || !location || !maxAttendees) {
      showNotification('Todos los campos obligatorios deben estar completos', 'error');
      return;
    }

    if (new Date(startDate) <= new Date()) {
      showNotification('La fecha de inicio debe ser futura', 'error');
      return;
    }

    if (new Date(endDate) <= new Date(startDate)) {
      showNotification('La fecha de fin debe ser posterior a la de inicio', 'error');
      return;
    }

    loading = true;

    const eventData = {
      title,
      description,
      startDate: new Date(startDate).toISOString(),
      endDate: new Date(endDate).toISOString(),
      location,
      ticketPrice: ticketPrice ? parseFloat(ticketPrice) : null,
      maxAttendees: parseInt(maxAttendees),
      isPublic
    };

    const result = await events.createEvent(eventData);
    
    if (result.success) {
      showNotification('¡Evento creado exitosamente!', 'success');
      dispatch('created');
    } else {
      showNotification(result.error, 'error');
    }
    
    loading = false;
  }
</script>

<div class="container">
  <div class="card" style="max-width: 800px; margin: 0 auto;">
    <h2 style="margin-bottom: 2rem;">
       Crear Nuevo Evento
    </h2>
    
    <form on:submit|preventDefault={handleCreate}>
      <div class="grid">
        <label>
          Título del evento *
          <input 
            type="text" 
            placeholder="Ej: Conferencia de Tecnología 2024" 
            bind:value={title} 
            disabled={loading}
            required
          />
        </label>
      </div>

      <label>
        Descripción *
        <textarea 
          placeholder="Describe los detalles del evento..." 
          bind:value={description} 
          disabled={loading}
          rows="4"
          required
        ></textarea>
      </label>

      <div class="grid">
        <label>
          Fecha inicio *
          <input 
            type="datetime-local" 
            bind:value={startDate} 
            min={today}
            disabled={loading}
            required
          />
        </label>

        <label>
          Fecha fin *
          <input 
            type="datetime-local" 
            bind:value={endDate} 
            min={startDate || today}
            disabled={loading}
            required
          />
        </label>
      </div>

      <label>
        Ubicación *
        <input 
          type="text" 
          placeholder="Dirección completa o nombre del lugar" 
          bind:value={location} 
          disabled={loading}
          required
        />
        <small>Ingresa la dirección completa para mostrarla en el mapa</small>
      </label>

      <div class="grid">
        <label>
          Precio del ticket (opcional)
          <input 
            type="number" 
            placeholder="Deja vacío si es gratis" 
            bind:value={ticketPrice} 
            min="0"
            step="1000"
            disabled={loading}
          />
        </label>

        <label>
          Capacidad máxima *
          <input 
            type="number" 
            bind:value={maxAttendees} 
            min="1"
            disabled={loading}
            required
          />
        </label>
      </div>

      <label>
        <input 
          type="checkbox" 
          role="switch"
          bind:checked={isPublic}
          disabled={loading}
        />
        Evento público (visible para todos)
      </label>

      <div class="grid" style="margin-top: 2rem;">
        <button 
          type="submit" 
          class="btn-gradient"
          disabled={loading}
          aria-busy={loading}
        >
          {#if loading}
            Creando evento...
          {:else}
             Crear Evento
          {/if}
        </button>
        
        <button 
          type="button"
          on:click={() => dispatch('created')} 
          disabled={loading}
        >
          Cancelar
        </button>
      </div>
    </form>
  </div>
</div>