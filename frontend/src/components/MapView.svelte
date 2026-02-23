<script>
  import { onMount, onDestroy } from 'svelte';

  export let location = '';
  export let title = 'Evento';
  
  let mapContainer;
  let map;
  let marker;
  let coordinates = null;

  // Geocode location to coordinates
  async function geocodeLocation(locationStr) {
    try {
      const response = await fetch(
        `https://nominatim.openstreetmap.org/search?format=json&q=${encodeURIComponent(locationStr)}`
      );
      const data = await response.json();
      
      if (data && data.length > 0) {
        return {
          lat: parseFloat(data[0].lat),
          lng: parseFloat(data[0].lon)
        };
      }
      
      // Default to Cali, Colombia if geocoding fails
      return { lat: 3.4516, lng: -76.5320 };
    } catch (error) {
      console.error('Error geocoding:', error);
      return { lat: 3.4516, lng: -76.5320 };
    }
  }

  onMount(async () => {
    if (typeof L === 'undefined') {
      console.error('Leaflet no está cargado');
      return;
    }

    // Get coordinates
    coordinates = await geocodeLocation(location);

    // Initialize map
    map = L.map(mapContainer, {
      center: [coordinates.lat, coordinates.lng],
      zoom: 15,
      scrollWheelZoom: false
    });

    // Add OpenStreetMap tiles
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
      attribution: '© OpenStreetMap contributors',
      maxZoom: 19
    }).addTo(map);

    // Add marker
    const customIcon = L.divIcon({
      className: 'custom-marker',
      html: `
        <div style="
          background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
          color: white;
          width: 40px;
          height: 40px;
          border-radius: 50% 50% 50% 0;
          transform: rotate(-45deg);
          display: flex;
          align-items: center;
          justify-content: center;
          box-shadow: 0 4px 8px rgba(0,0,0,0.3);
        ">
          <span style="transform: rotate(45deg); font-size: 20px;">📍</span>
        </div>
      `,
      iconSize: [40, 40],
      iconAnchor: [20, 40]
    });

    marker = L.marker([coordinates.lat, coordinates.lng], {
      icon: customIcon
    }).addTo(map);

    marker.bindPopup(`
      <div style="text-align: center; padding: 0.5rem;">
        <strong>${title}</strong><br>
        <small>${location}</small><br>
        <a href="https://www.google.com/maps/dir/?api=1&destination=${coordinates.lat},${coordinates.lng}" 
           target="_blank" 
           style="color: #667eea; text-decoration: none; margin-top: 0.5rem; display: inline-block;">
          🗺️ Ver en Google Maps
        </a>
      </div>
    `).openPopup();

    // Force map to refresh its size
    setTimeout(() => {
      if (map) map.invalidateSize();
    }, 100);
  });

  onDestroy(() => {
    if (map) {
      map.remove();
      map = null;
    }
  });
</script>

<div class="map-container" bind:this={mapContainer}></div>

<style>
  .map-container {
    height: 300px;
    border-radius: 0.5rem;
    overflow: hidden;
    border: 2px solid rgba(102, 126, 234, 0.2);
  }

  :global(.leaflet-popup-content-wrapper) {
    border-radius: 0.5rem;
  }

  :global(.leaflet-popup-content) {
    margin: 0.5rem;
  }
</style>