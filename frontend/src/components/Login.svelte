<script>
  import { createEventDispatcher } from 'svelte';
  import { auth } from '../lib/stores/auth.js';
  import { showNotification } from '../lib/utils.js';
  
  const dispatch = createEventDispatcher();
  
  let email = '';
  let password = '';
  let loading = false;

  async function handleLogin() {
    if (!email || !password) {
      showNotification('Por favor completa todos los campos', 'error');
      return;
    }

    loading = true;
    const result = await auth.login(email, password);
    
    if (!result.success) {
      showNotification(result.error, 'error');
    } else {
      showNotification('¡Bienvenido a Eventoria!', 'success');
    }
    
    loading = false;
  }

  function handleKeyPress(event) {
    if (event.key === 'Enter') {
      handleLogin();
    }
  }
</script>

<div class="auth-container">
  <div class="auth-card">
    <div class="logo">🎉 Eventoria</div>
    <h2 style="text-align: center; margin-bottom: 2rem;">Iniciar Sesión</h2>
    
    <form on:submit|preventDefault={handleLogin}>
      <label>
        Email
        <input 
          type="email" 
          placeholder="tu@email.com" 
          bind:value={email} 
          disabled={loading}
          on:keypress={handleKeyPress}
          required
        />
      </label>

      <label>
        Contraseña
        <input 
          type="password" 
          placeholder="••••••••" 
          bind:value={password} 
          disabled={loading}
          on:keypress={handleKeyPress}
          required
        />
      </label>

      <button 
        type="submit" 
        class="btn-gradient"
        disabled={loading}
        aria-busy={loading}
      >
        {#if loading}
          Iniciando sesión...
        {:else}
          Iniciar Sesión
        {/if}
      </button>
    </form>
    
    <div style="text-align: center; margin-top: 1.5rem; color: var(--muted-color);">
      ¿No tienes cuenta?
      <a href="#" on:click|preventDefault={() => dispatch('switch')} style="color: var(--primary);">
        Regístrate aquí
      </a>
    </div>
  </div>
</div>