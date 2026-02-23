<script>
  import { onMount } from 'svelte';
  import { auth } from './lib/stores/auth.js';
  import { showNotification } from './lib/utils.js';
  import Login from './components/Login.svelte';
  import Register from './components/Register.svelte';
  import EventList from './components/EventList.svelte';
  import CreateEvent from './components/CreateEvent.svelte';

  let view = 'login'; // 'login', 'register', 'events', 'create'

  onMount(() => {
    auth.checkAuth();
    
    const unsubscribe = auth.subscribe($auth => {
      if ($auth.isAuthenticated && (view === 'login' || view === 'register')) {
        view = 'events';
      }
    });

    return unsubscribe;
  });

  function logout() {
    auth.logout();
    view = 'login';
    showNotification('Sesión cerrada correctamente', 'info');
  }
</script>

<main>
  {#if $auth.isAuthenticated}
    <!-- Header -->
    <div class="hero-section">
      <div class="container">
        <div style="display: flex; justify-content: space-between; align-items: center; flex-wrap: wrap; gap: 1rem;">
          <div>
            <h1 style="margin: 0;">                       Eventoria                        </h1>
            <p style="margin: 0;">Bienvenido, {$auth.user?.name || 'Usuario'}</p>
          </div>
          <button on:click={logout} style="background: rgba(255,255,255,0.2); border: 1px solid white;">
            👋 Cerrar Sesión
          </button>
        </div>
      </div>
    </div>

    <!-- Navigation Tabs -->
    <div class="container">
      <div class="tab-navigation">
        <button 
          class="tab-button {view === 'events' ? 'active' : ''}"
          on:click={() => view = 'events'}
        >
          📋 Eventos
        </button>
        <button 
          class="tab-button {view === 'create' ? 'active' : ''}"
          on:click={() => view = 'create'}
        >
          ➕ Crear Evento
        </button>
      </div>

      <!-- Content -->
      {#if view === 'events'}
        <EventList />
      {:else if view === 'create'}
        <CreateEvent on:created={() => view = 'events'} />
      {/if}
    </div>

    <!-- Footer -->
    <footer style="text-align: center; padding: 2rem; color: var(--muted-color); margin-top: 4rem;">
      <p>
        Hecho con Svelte y .NET
      </p>
    </footer>
  {:else}
    <!-- Auth Views -->
    {#if view === 'login'}
      <Login on:switch={() => view = 'register'} />
    {:else}
      <Register on:switch={() => view = 'login'} />
    {/if}
  {/if}
</main>