// Serviço de atualização automática do status do servidor
class ServerStatusUpdater {
    constructor() {
        this.statusElement = document.getElementById('server-status');
        this.onlineCountElement = document.getElementById('online-count');
        this.updateInterval = 30000; // 30 segundos
        this.isUpdating = false;
        this.init();
    }

    init() {
        // Atualizar imediatamente
        this.updateStatus();
        this.updateOnlineCount();

        // Configurar atualização automática
        setInterval(() => {
            this.updateStatus();
            this.updateOnlineCount();
        }, this.updateInterval);

        // Atualizar quando a página voltar a ficar visível
        document.addEventListener('visibilitychange', () => {
            if (!document.hidden) {
                this.updateStatus();
                this.updateOnlineCount();
            }
        });
    }

    async updateStatus() {
        if (this.isUpdating) return;

        this.isUpdating = true;

        try {
            const response = await fetch('/api/server/status');
            if (response.ok) {
                const status = await response.json();
                this.updateStatusDisplay(status);
            }
        } catch (error) {
            console.log('Erro ao atualizar status do servidor:', error);
        } finally {
            this.isUpdating = false;
        }
    }

    updateStatusDisplay(status) {
        if (!this.statusElement) return;

        // Atualizar texto e classe
        this.statusElement.textContent = status.statusText;
        this.statusElement.className = status.statusClass;

        // Adicionar efeito de transição
        this.statusElement.style.transition = 'all 0.3s ease';

        // Efeito visual baseado no status
        if (status.isOnline) {
            this.statusElement.style.textShadow = '0 0 10px rgba(40, 167, 69, 0.5)';
        } else {
            this.statusElement.style.textShadow = '0 0 10px rgba(220, 53, 69, 0.5)';
        }

        // Remover efeito após animação
        setTimeout(() => {
            this.statusElement.style.textShadow = '';
        }, 1000);
    }

    async updateOnlineCount() {
        try {
            const response = await fetch('/api/server/online-count');
            if (response.ok) {
                const data = await response.json();
                if (this.onlineCountElement) {
                    this.onlineCountElement.textContent = data.count;

                    // Efeito visual
                    this.onlineCountElement.style.transform = 'scale(1.2)';
                    setTimeout(() => {
                        this.onlineCountElement.style.transform = 'scale(1)';
                    }, 200);
                }
            }
        } catch (error) {
            console.log('Erro ao atualizar contador de players online:', error);
        }
    }
}

// Inicializar quando o DOM estiver pronto
document.addEventListener('DOMContentLoaded', () => {
    new ServerStatusUpdater();
}); 