Eventoria
<div align="center">
https://img.shields.io/badge/Eventoria-Sistema_de_Gesti%C3%B3n_de_Eventos-667eea?style=for-the-badge

Una plataforma moderna y elegante para la gestión de eventos

https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white
https://img.shields.io/badge/Svelte-5.0-FF3E00?style=for-the-badge&logo=svelte&logoColor=white
https://img.shields.io/badge/SQLite-3.0-003B57?style=for-the-badge&logo=sqlite&logoColor=white
https://img.shields.io/badge/license-MIT-green?style=for-the-badge

Demo • Instalación • Documentación • Contribuir

https://via.placeholder.com/800x400/667eea/ffffff?text=Eventoria+Dashboard

</div>
📋 Tabla de Contenidos
Descripción

Características

Tecnologías

Arquitectura

Instalación

Uso

API

Capturas de Pantalla

Roadmap

Contribución

Licencia

Contacto

🎯 Descripción
Eventoria es una plataforma completa de gestión de eventos que permite a los usuarios crear, descubrir y asistir a eventos de manera sencilla y eficiente. Con una interfaz moderna y minimalista, Eventoria facilita la organización de eventos de cualquier tipo, desde conferencias hasta reuniones casuales.

✨ ¿Por qué Eventoria?
🚀 Rápido y Eficiente: Carga instantánea y navegación fluida

🎨 Diseño Moderno: UI minimalista con Pico CSS

🗺️ Mapas Integrados: Visualiza ubicaciones con OpenStreetMap

🔐 Seguro: Autenticación JWT y validaciones robustas

📱 Responsive: Funciona perfectamente en todos los dispositivos

🆓 Open Source: Código abierto y gratuito

✨ Características
🎫 Gestión de Eventos
Crear Eventos: Crea eventos con título, descripción, fecha, ubicación y más

Explorar Eventos: Descubre eventos próximos con filtros inteligentes

Asistencia: Regístrate en eventos con un solo clic

Control de Capacidad: Límites automáticos de asistentes con barra de progreso visual

Eventos Gratuitos o de Pago: Configura precios para tus eventos

🗺️ Mapas y Ubicación
Visualización de Mapas: Integración con Leaflet y OpenStreetMap

Geocoding Automático: Convierte direcciones en coordenadas

Navegación: Enlaces directos a Google Maps para direcciones

Marcadores Personalizados: Marcadores visuales en los mapas

👤 Gestión de Usuarios
Autenticación Segura: Sistema de login/registro con JWT

Perfiles de Usuario: Información personalizada de cada usuario

Historial de Eventos: Ver eventos creados y asistencias

📊 Estadísticas en Tiempo Real
Dashboard de Estadísticas: Visualiza métricas clave

Contador de Asistentes: Progreso visual de capacidad

Eventos Activos: Cantidad de eventos disponibles

Eventos Gratuitos: Filtros por tipo de evento

🔔 Notificaciones
Alertas Visuales: Sistema de notificaciones toast con animaciones

Confirmaciones: Feedback inmediato de acciones

Manejo de Errores: Mensajes claros y descriptivos

🛠️ Tecnologías
🖥️ Backend - Potencia y Robustez con Microsoft .NET
<div align="center"> <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/dotnetcore/dotnetcore-original.svg" width="80" height="80" alt=".NET Core"/> <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/csharp/csharp-original.svg" width="80" height="80" alt="C#"/> <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/sqlite/sqlite-original.svg" width="80" height="80" alt="SQLite"/> </div>
El backend de Eventoria está construido con .NET 8, aprovechando toda la potencia y robustez de la plataforma de Microsoft:

.NET 8 - El framework de desarrollo más productivo y de alto rendimiento

ASP.NET Core - Web API con soporte nativo para inyección de dependencias

Entity Framework Core - ORM moderno con LINQ y migraciones automáticas

SQLite - Base de datos embebida, rápida y sin servidor

JWT Bearer - Autenticación segura basada en tokens

Clean Architecture - Patrón de arquitectura limpia y mantenible

🎨 Frontend - Reactividad Moderna con Svelte
<div align="center"> <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/svelte/svelte-original.svg" width="80" height="80" alt="Svelte"/> <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/javascript/javascript-original.svg" width="80" height="80" alt="JavaScript"/> <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/vitejs/vitejs-original.svg" width="80" height="80" alt="Vite"/> </div>
El frontend utiliza Svelte 5, el framework reactivo que compila a JavaScript puro:

Svelte 5 - Framework reactivo con compilación anticipada

Vite - Build tool ultrarrápida con HMR

Pico CSS - Framework CSS minimalista y semántico

Leaflet - Mapas interactivos con OpenStreetMap

Axios - Cliente HTTP con interceptores

🗄️ Base de Datos - SQLite: Ligera y Poderosa
<div align="center"> <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/sqlite/sqlite-original-wordmark.svg" width="120" height="120" alt="SQLite"/> </div>
SQLite es el corazón de almacenamiento de Eventoria, ofreciendo:

⚡ Ultra Rápida: Sin servidor, sin configuración, acceso directo a archivos

📦 Embebida: Un solo archivo .db que puedes copiar y versionar

🔒 ACID Compliant: Transacciones seguras y consistentes

📈 Escalable: Perfecta para aplicaciones de escritorio y web

🌐 Multiplataforma: Funciona en Windows, Linux, macOS

🎯 Migraciones Automáticas: EF Core maneja el esquema por ti

📊 Stack Tecnológico Completo
Capa	Tecnología	Propósito
Frontend	Svelte 5 + Vite	UI reactiva y compilación rápida
Backend	.NET 8 + ASP.NET Core	API REST robusta y escalable
ORM	Entity Framework Core	Abstracción de base de datos
Base de Datos	SQLite 3	Almacenamiento embebido
Autenticación	JWT + ASP.NET Identity	Seguridad basada en tokens
Mapas	Leaflet + OpenStreetMap	Visualización de ubicaciones
Estilos	Pico CSS	Framework minimalista
Build Tool	Vite	Desarrollo ultrarrápido
🏗️ Arquitectura

Eventoria/
├── backend/                      # 🖥️ Backend .NET 8
│   ├── Eventoria.Api/            # API REST
│   │   ├── Controllers/          # Endpoints
│   │   ├── Services/             # Lógica de negocio
│   │   └── DTOs/                 # Data Transfer Objects
│   ├── Eventoria.Core/           # Entidades del dominio
│   │   └── Entities/             # Modelos de negocio
│   └── Eventoria.Infrastructure/ # 📦 Acceso a datos
│       ├── Data/                 # DbContext
│       └── Repositories/         # Patrón repositorio
└── frontend/                      # 🎨 Frontend Svelte
    └── src/
        ├── components/            # Componentes reutilizables
        ├── lib/
        │   ├── stores/            # Estado global
        │   └── api.js             # Cliente HTTP
        └── App.svelte             # Componente principal
Patrón Clean Architecture

┌─────────────────────────────────────┐
│         📱 Presentation Layer       │
│         (Svelte Frontend)           │
└────────────┬────────────────────────┘
             │
┌────────────▼────────────────────────┐
│          🌐 API Layer                │
│     (ASP.NET Core Controllers)       │
└────────────┬────────────────────────┘
             │
┌────────────▼────────────────────────┐
│       🧠 Application Layer           │
│         (Services)                   │
└────────────┬────────────────────────┘
             │
┌────────────▼────────────────────────┐
│         📦 Domain Layer              │
│    (Core - Entities & Interfaces)    │
└────────────┬────────────────────────┘
             │
┌────────────▼────────────────────────┐
│      💾 Infrastructure Layer         │
│   (EF Core - SQLite Repositories)    │
└─────────────────────────────────────┘
🚀 Instalación
Prerrequisitos
.NET 8 SDK

Node.js 18+

Git

SQLite 3 (opcional, para inspeccionar la BD)

Clonar el Repositorio
bash
git clone https://github.com/JDNG111/Eventoria.git
cd Eventoria
Configurar Backend (.NET + SQLite)
bash
# Navegar a la carpeta del backend
cd backend/Eventoria.Api

# Restaurar dependencias
dotnet restore

# La base de datos SQLite se creará automáticamente
# en /database/eventoria.db al ejecutar

# Ejecutar el backend
dotnet run
✅ ¡La magia de SQLite! No necesitas instalar ni configurar nada. EF Core creará automáticamente el archivo eventoria.db con todas las tablas necesarias.

El backend estará disponible en: http://localhost:5119
Documentación Swagger: http://localhost:5119/swagger

Configurar Frontend (Svelte)
bash
# Navegar a la carpeta del frontend
cd frontend

# Instalar dependencias
npm install

# Ejecutar en modo desarrollo
npm run dev
El frontend estará disponible en: http://localhost:5173

📖 Uso
Crear una Cuenta
Abre http://localhost:5173

Haz clic en "Regístrate aquí"

Completa el formulario con tu nombre, email y contraseña

Inicia sesión con tus credenciales

Crear un Evento
Una vez autenticado, haz clic en "Crear Evento"

Llena los detalles:

Título: Nombre del evento

Descripción: Detalles del evento

Fecha de Inicio/Fin: Cuándo será el evento

Ubicación: Dirección completa (se mostrará en el mapa)

Precio: Opcional, déjalo vacío si es gratis

Capacidad: Número máximo de asistentes

Haz clic en "Crear Evento"

Asistir a un Evento
Explora los eventos disponibles en la página principal

Haz clic en el botón "🎟️ Asistir"

Verás una confirmación de registro

El contador de asistentes se actualizará automáticamente

Ver Ubicación en el Mapa
En cualquier evento, haz clic en "🗺️ Mapa"

Se mostrará la ubicación en un mapa interactivo

Haz clic en el marcador para ver opciones de navegación

🔌 API
Endpoints Principales
Autenticación
http
POST /api/auth/register
Content-Type: application/json

{
  "name": "Juan Pérez",
  "email": "juan@ejemplo.com",
  "password": "password123"
}
http
POST /api/auth/login
Content-Type: application/json

{
  "email": "juan@ejemplo.com",
  "password": "password123"
}
Eventos
http
GET /api/events
Authorization: Bearer {token}
http
POST /api/events
Authorization: Bearer {token}
Content-Type: application/json

{
  "title": "Conferencia Tech 2024",
  "description": "Evento de tecnología",
  "startDate": "2024-12-01T10:00:00Z",
  "endDate": "2024-12-01T18:00:00Z",
  "location": "Centro de Convenciones, Cali",
  "ticketPrice": 50000,
  "maxAttendees": 100,
  "isPublic": true
}
http
POST /api/events/{id}/attend
Authorization: Bearer {token}
Para más detalles, consulta la documentación completa de la API.

📸 Capturas de Pantalla
Dashboard Principal
<img width="824" height="863" alt="image" src="https://github.com/user-attachments/assets/fee67c8a-85a4-4f6c-acfa-72ac422f1364" />


🗺️ Roadmap
Versión 1.0 (Actual) ✅
Sistema de autenticación con JWT

CRUD completo de eventos

Asistencia a eventos con barra de progreso

Mapas interactivos con Leaflet

Notificaciones toast

Diseño responsive con Pico CSS

Base de datos SQLite con EF Core

Versión 1.1 (Próxima)
Búsqueda y filtros avanzados

Categorías de eventos

Sistema de comentarios

Compartir en redes sociales

Exportar eventos a calendario

Versión 2.0 (Futuro)
Galería de imágenes

Sistema de pagos (Stripe/PayPal)

Chat en tiempo real con SignalR

Notificaciones push

Sistema de reseñas

Modo oscuro

Dockerización completa

🤝 Contribución
¡Las contribuciones son bienvenidas! Si quieres contribuir:

Fork el proyecto

Crea una rama para tu feature (git checkout -b feature/AmazingFeature)

Commit tus cambios (git commit -m 'Add: nueva característica')

Push a la rama (git push origin feature/AmazingFeature)

Abre un Pull Request

Guía de Contribución
Usa commits descriptivos siguiendo Conventional Commits

Escribe pruebas para nuevas funcionalidades

Actualiza la documentación cuando sea necesario

Asegúrate de que el código pase todos los tests

📄 Licencia
Este proyecto está bajo la Licencia MIT. Ver el archivo LICENSE para más detalles.

👨‍💻 Autor
Julian Navarro

GitHub: @JDNG111

Email: navarroestudiante1010@gmail.com

🙏 Agradecimientos
Pico CSS por el framework CSS minimalista

Leaflet por los mapas interactivos

Svelte por el framework reactivo

.NET por el framework backend robusto

SQLite por la base de datos embebida más confiable

<div align="center">
⚡ Stack Tecnológico Destacado
<img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/dotnetcore/dotnetcore-original.svg" width="60"/>	<img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/svelte/svelte-original.svg" width="60"/>	<img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/sqlite/sqlite-original.svg" width="60"/>
.NET 8	Svelte 5	SQLite 3
⭐ Si te gusta este proyecto, dale una estrella en GitHub ⭐

Made with ❤️ and three cups of coffee ☕ by JDNG111

⬆ Volver arriba

</div>
