import { writable } from 'svelte/store';
import api from '../api.js';

function createEventsStore() {
    const { subscribe, set, update } = writable({
        events: [],
        loading: false,
        error: null
    });

    return {
        subscribe,
        
        loadEvents: async () => {
            update(state => ({ ...state, loading: true, error: null }));
            try {
                const response = await api.get('/events');
                console.log('Eventos cargados:', response.data);
                set({
                    events: response.data || [],
                    loading: false,
                    error: null
                });
            } catch (error) {
                console.error('Error cargando eventos:', error);
                update(state => ({ 
                    ...state, 
                    loading: false, 
                    error: error.response?.data?.message || 'Error al cargar eventos' 
                }));
            }
        },
        
        createEvent: async (eventData) => {
            try {
                console.log('Creando evento:', eventData);
                const response = await api.post('/events', eventData);
                console.log('Evento creado:', response.data);
                
                update(state => ({
                    ...state,
                    events: [response.data, ...state.events]
                }));
                
                return { success: true, data: response.data };
            } catch (error) {
                console.error('Error creando evento:', error);
                return { 
                    success: false, 
                    error: error.response?.data?.message || error.message || 'Error al crear evento' 
                };
            }
        },
        
        attendEvent: async (eventId) => {
            try {
                console.log(`Intentando asistir al evento ${eventId}...`);
                
                const response = await api.post(`/events/${eventId}/attend`);
                console.log('Respuesta de asistencia:', response.data);
                
                // Actualizar el contador de asistentes localmente
                update(state => ({
                    ...state,
                    events: state.events.map(event => 
                        event.id === eventId 
                            ? { 
                                ...event, 
                                attendeesCount: (event.attendeesCount || 0) + 1 
                              }
                            : event
                    )
                }));
                
                return { 
                    success: true,
                    message: response.data.message || 'Asistencia registrada'
                };
            } catch (error) {
                console.error('Error registrando asistencia:', error);
                console.error('Respuesta del servidor:', error.response?.data);
                
                // Extraer el mensaje de error del servidor
                let errorMessage = 'Error al registrar asistencia';
                
                if (error.response?.data?.message) {
                    errorMessage = error.response.data.message;
                } else if (error.response?.data?.error) {
                    errorMessage = error.response.data.error;
                } else if (error.message) {
                    errorMessage = error.message;
                }
                
                return { 
                    success: false, 
                    error: errorMessage
                };
            }
        }
    };
}

export const events = createEventsStore();