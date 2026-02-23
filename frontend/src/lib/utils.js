// Utility for showing notifications
export function showNotification(message, type = 'info') {
    // Remove existing notifications
    const existing = document.querySelectorAll('.notification');
    existing.forEach(n => n.remove());

    // Create notification element
    const notification = document.createElement('div');
    notification.className = `notification ${type}`;
    
    const icons = {
        success: '✓',
        error: '✗',
        info: 'ℹ',
        warning: '⚠'
    };

    notification.innerHTML = `
        <div style="display: flex; align-items: center; gap: 1rem;">
            <span style="font-size: 1.5rem;">${icons[type] || icons.info}</span>
            <div>
                <strong style="display: block; margin-bottom: 0.25rem;">${type.charAt(0).toUpperCase() + type.slice(1)}</strong>
                <span>${message}</span>
            </div>
        </div>
    `;

    document.body.appendChild(notification);

    // Auto-remove after 5 seconds
    setTimeout(() => {
        notification.style.animation = 'slideInRight 0.3s ease-in reverse';
        setTimeout(() => notification.remove(), 300);
    }, 5000);
}

// Utility for formatting dates
export function formatDate(date) {
    const d = new Date(date);
    const options = {
        year: 'numeric',
        month: 'long',
        day: 'numeric',
        hour: '2-digit',
        minute: '2-digit'
    };
    return d.toLocaleDateString('es-ES', options);
}

// Utility for formatting currency
export function formatCurrency(amount) {
    if (typeof amount !== 'number') {
        amount = parseFloat(amount) || 0;
    }
    
    return new Intl.NumberFormat('es-CO', {
        style: 'currency',
        currency: 'COP',
        minimumFractionDigits: 0,
        maximumFractionDigits: 0
    }).format(amount);
}

// Utility to calculate time until event
export function timeUntilEvent(date) {
    const now = new Date();
    const eventDate = new Date(date);
    const diff = eventDate.getTime() - now.getTime();
    
    const days = Math.floor(diff / (1000 * 60 * 60 * 24));
    const hours = Math.floor((diff % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
    
    if (days > 0) {
        return `En ${days} día${days > 1 ? 's' : ''}`;
    } else if (hours > 0) {
        return `En ${hours} hora${hours > 1 ? 's' : ''}`;
    } else if (diff > 0) {
        return 'Muy pronto';
    } else {
        return 'Ya pasó';
    }
}