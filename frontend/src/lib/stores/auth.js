import { writable } from 'svelte/store';
import api from '../api.js';
import { jwtDecode } from 'jwt-decode';

function createAuthStore() {
    const { subscribe, set } = writable({
        user: null,
        token: null,
        isAuthenticated: false
    });

    function extractUserFromToken(token) {
        try {
            const decoded = jwtDecode(token);
            return {
                id: decoded.nameid || decoded.sub || '0',
                name: decoded.unique_name || decoded.name || 'Usuario',
                email: decoded.email || ''
            };
        } catch (e) {
            return null;
        }
    }

    return {
        subscribe,
        login: async (email, password) => {
            try {
                const response = await api.post('/auth/login', { email, password });
                const { token } = response.data;
                localStorage.setItem('token', token);
                const userData = extractUserFromToken(token);
                set({ user: userData, token, isAuthenticated: true });
                return { success: true };
            } catch (error) {
                return { 
                    success: false, 
                    error: error.response?.data?.message || 'Error al iniciar sesión' 
                };
            }
        },
        register: async (name, email, password) => {
            try {
                await api.post('/auth/register', { name, email, password });
                return { success: true };
            } catch (error) {
                return { 
                    success: false, 
                    error: error.response?.data?.message || 'Error al registrar' 
                };
            }
        },
        logout: () => {
            localStorage.removeItem('token');
            set({ user: null, token: null, isAuthenticated: false });
        },
        checkAuth: () => {
            const token = localStorage.getItem('token');
            if (token) {
                const userData = extractUserFromToken(token);
                if (userData) {
                    set({ user: userData, token, isAuthenticated: true });
                } else {
                    localStorage.removeItem('token');
                }
            }
        }
    };
}

export const auth = createAuthStore();