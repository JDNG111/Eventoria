# Eventoria

<div align="center">

![Eventoria Banner](https://img.shields.io/badge/Eventoria-Sistema_de_Gesti%C3%B3n_de_Eventos-667eea?style=for-the-badge)

**Una plataforma moderna y elegante para la gestión de eventos**

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![Svelte](https://img.shields.io/badge/Svelte-5.0-FF3E00?style=for-the-badge&logo=svelte&logoColor=white)](https://svelte.dev/)
[![SQLite](https://img.shields.io/badge/SQLite-3.0-003B57?style=for-the-badge&logo=sqlite&logoColor=white)](https://www.sqlite.org/)
[![License](https://img.shields.io/badge/license-MIT-green?style=for-the-badge)](LICENSE)

[Demo](#-características) • [Instalación](#-instalación) • [Documentación](#-uso) • [Contribuir](#-contribución)

![Eventoria Screenshot](https://github.com/user-attachments/assets/fee67c8a-85a4-4f6c-acfa-72ac422f1364)

</div>

---

## 📋 Tabla de Contenidos

- [Descripción](#-descripción)
- [Características](#-características)
- [Tecnologías](#️-tecnologías)
- [Arquitectura](#-arquitectura)
- [Instalación](#-instalación)
- [Uso](#-uso)
- [API](#-api)
- [Capturas de Pantalla](#-capturas-de-pantalla)
- [Roadmap](#-roadmap)
- [Contribución](#-contribución)
- [Licencia](#-licencia)
- [Contacto](#-contacto)

---

## 🎯 Descripción

**Eventoria** es una plataforma completa de gestión de eventos que permite a los usuarios crear, descubrir y asistir a eventos de manera sencilla y eficiente. Con una interfaz moderna y minimalista, Eventoria facilita la organización de eventos de cualquier tipo, desde conferencias hasta reuniones casuales.

### ✨ ¿Por qué Eventoria?

- 🚀 **Rápido y Eficiente**: Carga instantánea y navegación fluida
- 🎨 **Diseño Moderno**: UI minimalista con Pico CSS
- 🗺️ **Mapas Integrados**: Visualiza ubicaciones con OpenStreetMap
- 🔐 **Seguro**: Autenticación JWT y validaciones robustas
- 📱 **Responsive**: Funciona perfectamente en todos los dispositivos
- 🆓 **Open Source**: Código abierto y gratuito

---

## ✨ Características

### 🎫 Gestión de Eventos

- **Crear Eventos**: Crea eventos con título, descripción, fecha, ubicación y más
- **Explorar Eventos**: Descubre eventos próximos con filtros inteligentes
- **Asistencia**: Regístrate en eventos con un solo clic
- **Control de Capacidad**: Límites automáticos de asistentes con barra de progreso visual
- **Eventos Gratuitos o de Pago**: Configura precios para tus eventos

### 🗺️ Mapas y Ubicación

- **Visualización de Mapas**: Integración con Leaflet y OpenStreetMap
- **Geocoding Automático**: Convierte direcciones en coordenadas
- **Navegación**: Enlaces directos a Google Maps para direcciones
- **Marcadores Personalizados**: Marcadores visuales en los mapas

### 👤 Gestión de Usuarios

- **Autenticación Segura**: Sistema de login/registro con JWT
- **Perfiles de Usuario**: Información personalizada de cada usuario
- **Historial de Eventos**: Ver eventos creados y asistencias

### 📊 Estadísticas en Tiempo Real

- **Dashboard de Estadísticas**: Visualiza métricas clave
- **Contador de Asistentes**: Progreso visual de capacidad
- **Eventos Activos**: Cantidad de eventos disponibles
- **Eventos Gratuitos**: Filtros por tipo de evento

### 🔔 Notificaciones

- **Alertas Visuales**: Sistema de notificaciones toast con animaciones
- **Confirmaciones**: Feedback inmediato de acciones
- **Manejo de Errores**: Mensajes claros y descriptivos

---

## 🛠️ Tecnologías

### 🖥️ Backend - Potencia y Robustez con Microsoft .NET

<div align="center">
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/dotnetcore/dotnetcore-original.svg" width="80" height="80" alt=".NET Core"/>
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/csharp/csharp-original.svg" width="80" height="80" alt="C#"/>
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/sqlite/sqlite-original.svg" width="80" height="80" alt="SQLite"/>
</div>

El backend de Eventoria está construido con .NET 8, aprovechando toda la potencia y robustez de la plataforma de Microsoft:

- **[.NET 8](https://dotnet.microsoft.com/)** - El framework de desarrollo más productivo y de alto rendimiento
- **[ASP.NET Core](https://docs.microsoft.com/aspnet/core)** - Web API con soporte nativo para inyección de dependencias
- **[Entity Framework Core](https://docs.microsoft.com/ef/core/)** - ORM moderno con LINQ y migraciones automáticas
- **[SQLite](https://www.sqlite.org/)** - Base de datos embebida, rápida y sin servidor
- **[JWT Bearer](https://jwt.io/)** - Autenticación segura basada en tokens
- **Clean Architecture** - Patrón de arquitectura limpia y mantenible

### 🎨 Frontend - Reactividad Moderna con Svelte

<div align="center">
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/svelte/svelte-original.svg" width="80" height="80" alt="Svelte"/>
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/javascript/javascript-original.svg" width="80" height="80" alt="JavaScript"/>
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/vitejs/vitejs-original.svg" width="80" height="80" alt="Vite"/>
</div>

El frontend utiliza Svelte 5, el framework reactivo que compila a JavaScript puro:

- **[Svelte 5](https://svelte.dev/)** - Framework reactivo con compilación anticipada
- **[Vite](https://vitejs.dev/)** - Build tool ultrarrápida con HMR
- **[Pico CSS](https://picocss.com/)** - Framework CSS minimalista y semántico
- **[Leaflet](https://leafletjs.com/)** - Mapas interactivos con OpenStreetMap
- **[Axios](https://axios-http.com/)** - Cliente HTTP con interceptores

### 🗄️ Base de Datos - SQLite: Ligera y Poderosa

<div align="center">
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/sqlite/sqlite-original-wordmark.svg" width="120" height="120" alt="SQLite"/>
</div>

SQLite es el corazón de almacenamiento de Eventoria, ofreciendo:

- ⚡ **Ultra Rápida**: Sin servidor, sin configuración, acceso directo a archivos
- 📦 **Embebida**: Un solo archivo .db que puedes copiar y versionar
- 🔒 **ACID Compliant**: Transacciones seguras y consistentes
- 📈 **Escalable**: Perfecta para aplicaciones de escritorio y web
- 🌐 **Multiplataforma**: Funciona en Windows, Linux, macOS
- 🎯 **Migraciones Automáticas**: EF Core maneja el esquema por ti

### 📊 Stack Tecnológico Completo

| Capa | Tecnología | Propósito |
|------|-----------|-----------|
| Frontend | Svelte 5 + Vite | UI reactiva y compilación rápida |
| Backend | .NET 8 + ASP.NET Core | API REST robusta y escalable |
| ORM | Entity Framework Core | Abstracción de base de datos |
| Base de Datos | SQLite 3 | Almacenamiento embebido |
| Autenticación | JWT + ASP.NET Identity | Seguridad basada en tokens |
| Mapas | Leaflet + OpenStreetMap | Visualización de ubicaciones |
| Estilos | Pico CSS | Framework minimalista |
| Build Tool | Vite | Desarrollo ultrarrápido |

---

## 🏗️ Arquitectura

```
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
```

### Patrón Clean Architecture

```
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
```

---

## 🚀 Instalación

### Prerrequisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Node.js 18+](https://nodejs.org/)
- [Git](https://git-scm.com/)
- SQLite 3 (opcional, para inspeccionar la BD)

### Clonar el Repositorio

```bash
git clone https://github.com/JDNG111/Eventoria.git
cd Eventoria
```

### Configurar Backend (.NET + SQLite)

```bash
# Navegar a la carpeta del backend
cd backend/Eventoria.Api

# Restaurar dependencias
dotnet restore

# La base de datos SQLite se creará automáticamente
# en /database/eventoria.db al ejecutar

# Ejecutar el backend
dotnet run
```

✅ **¡La magia de SQLite!** No necesitas instalar ni configurar nada. EF Core creará automáticamente el archivo `eventoria.db` con todas las tablas necesarias.

- El backend estará disponible en: `http://localhost:5119`
- Documentación Swagger: `http://localhost:5119/swagger`

### Configurar Frontend (Svelte)

```bash
# Navegar a la carpeta del frontend
cd frontend

# Instalar dependencias
npm install

# Ejecutar en modo desarrollo
npm run dev
```

El frontend estará disponible en: `http://localhost:5173`

---

## 📖 Uso

### Crear una Cuenta

1. Abre `http://localhost:5173`
2. Haz clic en "Regístrate aquí"
3. Completa el formulario con tu nombre, email y contraseña
4. Inicia sesión con tus credenciales

### Crear un Evento

1. Una vez autenticado, haz clic en "Crear Evento"
2. Llena los detalles:
   - **Título**: Nombre del evento
   - **Descripción**: Detalles del evento
   - **Fecha de Inicio/Fin**: Cuándo será el evento
   - **Ubicación**: Dirección completa (se mostrará en el mapa)
   - **Precio**: Opcional, déjalo vacío si es gratis
   - **Capacidad**: Número máximo de asistentes
3. Haz clic en "Crear Evento"

### Asistir a un Evento

1. Explora los eventos disponibles en la página principal
2. Haz clic en el botón "🎟️ Asistir"
3. Verás una confirmación de registro
4. El contador de asistentes se actualizará automáticamente

### Ver Ubicación en el Mapa

1. En cualquier evento, haz clic en "🗺️ Mapa"
2. Se mostrará la ubicación en un mapa interactivo
3. Haz clic en el marcador para ver opciones de navegación

---

## 🔌 API

### Endpoints Principales

#### Autenticación

```http
POST /api/auth/register
Content-Type: application/json

{
  "name": "Juan Pérez",
  "email": "juan@ejemplo.com",
  "password": "password123"
}
```

```http
POST /api/auth/login
Content-Type: application/json

{
  "email": "juan@ejemplo.com",
  "password": "password123"
}
```

#### Eventos

```http
GET /api/events
Authorization: Bearer {token}
```

```http
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
```

```http
POST /api/events/{id}/attend
Authorization: Bearer {token}
```

Para más detalles, consulta la [documentación completa de la API](docs/API.md).

---

## 📸 Capturas de Pantalla

### Dashboard Principal

<img width="824" alt="Dashboard Eventoria" src="https://github.com/user-attachments/assets/fee67c8a-85a4-4f6c-acfa-72ac422f1364" />

---

## 🗺️ Roadmap

### Versión 1.0 (Actual) ✅

- [x] Sistema de autenticación con JWT
- [x] CRUD completo de eventos
- [x] Asistencia a eventos con barra de progreso
- [x] Mapas interactivos con Leaflet
- [x] Notificaciones toast
- [x] Diseño responsive con Pico CSS
- [x] Base de datos SQLite con EF Core

### Versión 1.1 (Próxima)

- [ ] Búsqueda y filtros avanzados
- [ ] Categorías de eventos
- [ ] Sistema de comentarios
- [ ] Compartir en redes sociales
- [ ] Exportar eventos a calendario

### Versión 2.0 (Futuro)

- [ ] Galería de imágenes
- [ ] Sistema de pagos (Stripe/PayPal)
- [ ] Chat en tiempo real con SignalR
- [ ] Notificaciones push
- [ ] Sistema de reseñas
- [ ] Modo oscuro
- [ ] Dockerización completa

---

## 🤝 Contribución

¡Las contribuciones son bienvenidas! Si quieres contribuir:

1. **Fork** el proyecto
2. Crea una **rama** para tu feature (`git checkout -b feature/AmazingFeature`)
3. **Commit** tus cambios (`git commit -m 'Add: nueva característica'`)
4. **Push** a la rama (`git push origin feature/AmazingFeature`)
5. Abre un **Pull Request**

### Guía de Contribución

- Usa commits descriptivos siguiendo [Conventional Commits](https://www.conventionalcommits.org/)
- Escribe pruebas para nuevas funcionalidades
- Actualiza la documentación cuando sea necesario
- Asegúrate de que el código pase todos los tests

---

## 📄 Licencia

Este proyecto está bajo la Licencia MIT. Ver el archivo [LICENSE](LICENSE) para más detalles.

---

## 👨‍💻 Autor

**Julian Navarro**

- GitHub: [@JDNG111](https://github.com/JDNG111)
- Email: navarroestudiante1010@gmail.com

---

## 🙏 Agradecimientos

- [Pico CSS](https://picocss.com/) por el framework CSS minimalista
- [Leaflet](https://leafletjs.com/) por los mapas interactivos
- [Svelte](https://svelte.dev/) por el framework reactivo
- [.NET](https://dotnet.microsoft.com/) por el framework backend robusto
- [SQLite](https://www.sqlite.org/) por la base de datos embebida más confiable

---

<div align="center">

### ⚡ Stack Tecnológico Destacado

<img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/dotnetcore/dotnetcore-original.svg" width="60"/> | <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/svelte/svelte-original.svg" width="60"/> | <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/sqlite/sqlite-original.svg" width="60"/>
:---:|:---:|:---:
**.NET 8** | **Svelte 5** | **SQLite 3**

**⭐ Si te gusta este proyecto, dale una estrella en GitHub ⭐**

Made with ❤️ and three cups of coffee ☕ by [JDNG111](https://github.com/JDNG111)

[⬆ Volver arriba](#-eventoria)

</div>
