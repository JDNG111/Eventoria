<script>
  import { createEventDispatcher } from 'svelte';
  import { auth } from '../lib/stores/auth.js';
  import { showNotification } from '../lib/utils.js';
  
  const dispatch = createEventDispatcher();
  
  let name = '';
  let email = '';
  let password = '';
  let confirmPassword = '';
  let loading = false;

  async function handleRegister() {
    // Validations
    if (!name || !email || !password || !confirmPassword) {
      showNotification('Por favor completa todos los campos', 'error');
      return;
    }

    if (password !== confirmPassword) {
      showNotification('Las contraseñas no coinciden', 'error');
      return;
    }

    if (password.length < 6) {
      showNotification('La contraseña debe tener al menos 6 caracteres', 'error');
      return;
    }

    loading = true;
    const result = await auth.register(name, email, password);
    
    if (result.success) {
      showNotification('¡Registro exitoso! Ahora puedes iniciar sesión', 'success');
      setTimeout(() => dispatch('switch'), 2000);
    } else {
      showNotification(result.error, 'error');
    }
    
    loading = false;
  }
</script>

<div class="auth-container">
  <div class="auth-card">
    <div class="logo">🎉 Eventoria</div>
    <h2 style="text-align: center; margin-bottom: 2rem;">Crear Cuenta</h2>
    
    <form on:submit|preventDefault={handleRegister}>
      <label>
        Nombre completo
        <input 
          type="text" 
          placeholder="Juan Pérez" 
          bind:value={name} 
          disabled={loading}
          required
        />
      </label>

      <label>
        Email
        <input 
          type="email" 
          placeholder="tu@email.com" 
          bind:value={email} 
          disabled={loading}
          required
        />
      </label>

      <label>
        Contraseña
        <input 
          type="password" 
          placeholder="Mínimo 6 caracteres" 
          bind:value={password} 
          disabled={loading}
          required
        />
      </label>

      <label>
        Confirmar contraseña
        <input 
          type="password" 
          placeholder="Repite tu contraseña" 
          bind:value={confirmPassword} 
          disabled={loading}
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
          Registrando...
        {:else}
          Crear Cuenta
        {/if}
      </button>
    </form>
    
    <div style="text-align: center; margin-top: 1.5rem; color: var(--muted-color);">
      ¿Ya tienes cuenta?
      <a href="#" on:click|preventDefault={() => dispatch('switch')} style="color: var(--primary);">
        Inicia sesión aquí
      </a>
    </div>
  </div>
</div>