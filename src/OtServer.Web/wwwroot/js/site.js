// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Efeitos Sombrios para Dungeon Souls
document.addEventListener('DOMContentLoaded', function () {

    // Efeito de partículas sombrias de Mordor
    function createMagicParticles() {
        const particles = ['👁', '🔥', '💀', '⚡', '🌑'];

        function createParticle() {
            const particle = document.createElement('div');
            particle.style.position = 'fixed';
            particle.style.left = Math.random() * 100 + 'vw';
            particle.style.top = '100vh';
            particle.style.fontSize = Math.random() * 16 + 8 + 'px';
            particle.style.color = '#ff6b47';
            particle.style.opacity = Math.random() * 0.4 + 0.2;
            particle.style.pointerEvents = 'none';
            particle.style.zIndex = '-1';
            particle.style.animation = 'floatUp 10s linear forwards';
            particle.innerText = particles[Math.floor(Math.random() * particles.length)];

            document.body.appendChild(particle);

            setTimeout(() => {
                if (particle.parentNode) {
                    particle.parentNode.removeChild(particle);
                }
            }, 10000); // Ajustado para coincidir com a animação
        }

        // Criar partícula a cada 4 segundos (mais espaçado para tema escuro)
        setInterval(createParticle, 4000);
    }

    // CSS para animação das partículas
    const style = document.createElement('style');
    style.textContent = `
        @keyframes floatUp {
            0% {
                transform: translateY(0) rotate(0deg);
                opacity: 0;
            }
            10% {
                opacity: 1;
            }
            90% {
                opacity: 1;
            }
            100% {
                transform: translateY(-100vh) rotate(360deg);
                opacity: 0;
            }
        }
        
        @keyframes rainFall {
            0% {
                transform: translateY(-10px) rotate(10deg);
                opacity: 0;
            }
            10% {
                opacity: 1;
            }
            100% {
                transform: translateY(100vh) rotate(10deg);
                opacity: 0.3;
            }
        }
        
        @keyframes swordSlash {
            0% { transform: rotate(-45deg) scale(0.8); }
            50% { transform: rotate(45deg) scale(1.2); }
            100% { transform: rotate(-45deg) scale(0.8); }
        }
        
        .sword-effect {
            animation: swordSlash 0.5s ease-in-out;
        }
        
        @keyframes goldShine {
            0%, 100% { 
                text-shadow: 0 0 5px #d4af37, 0 0 10px #d4af37; 
            }
            50% { 
                text-shadow: 0 0 20px #ffd700, 0 0 30px #ffd700, 0 0 40px #ffd700; 
            }
        }
        
        .magic-glow {
            animation: goldShine 2s ease-in-out infinite;
        }
    `;
    document.head.appendChild(style);

    // Inicializar partículas
    createMagicParticles();

    // Efeito sonoro simulado (visual) nos botões
    function addSoundEffect(element, effect) {
        element.addEventListener('click', function () {
            // Criar elemento de efeito visual
            const soundBubble = document.createElement('div');
            soundBubble.style.position = 'absolute';
            soundBubble.style.left = '50%';
            soundBubble.style.top = '50%';
            soundBubble.style.transform = 'translate(-50%, -50%)';
            soundBubble.style.fontSize = '20px';
            soundBubble.style.color = '#ff6b47';
            soundBubble.style.pointerEvents = 'none';
            soundBubble.style.zIndex = '1000';
            soundBubble.style.animation = 'floatUp 1s ease-out forwards';
            soundBubble.innerText = effect;

            element.style.position = 'relative';
            element.appendChild(soundBubble);

            setTimeout(() => {
                if (soundBubble.parentNode) {
                    soundBubble.parentNode.removeChild(soundBubble);
                }
            }, 1000);
        });
    }

    // Adicionar efeitos sombrios nos botões
    document.querySelectorAll('.btn-primary').forEach(btn => {
        addSoundEffect(btn, '👁');
        btn.addEventListener('mouseenter', function () {
            this.classList.add('sword-effect');
        });
        btn.addEventListener('animationend', function () {
            this.classList.remove('sword-effect');
        });
    });

    document.querySelectorAll('.btn-warning').forEach(btn => {
        addSoundEffect(btn, '🔥');
    });

    // Efeito especial para elementos com classe glow
    document.querySelectorAll('.glow').forEach(element => {
        element.addEventListener('mouseenter', function () {
            this.classList.add('magic-glow');
        });
        element.addEventListener('mouseleave', function () {
            this.classList.remove('magic-glow');
        });
    });

    // Sistema de frases sombrias das Masmorras
    const dungeonPhrases = [
        "A batalha pelas almas das masmorras te espera!",
        "Os olhos das trevas veem tudo...",
        "Nas profundezas das masmorras, o poder cresce!",
        "Uma alma para governar todas as outras...",
        "A escuridão é sua aliada, guerreiro!",
        "Pelos fogos das forjas sombrias!",
        "O poder das trevas flui através de você!",
        "As almas perdidas observam seus movimentos...",
        "As torres das masmorras se erguem majestosas!",
        "Nas sombras encontramos nossa força!",
        "O Senhor das Masmorras abençoa sua jornada!",
        "Seu destino está selado pela escuridão!",
        "O mal desperta... e você é parte dele!",
        "As masmorras não perdoam os fracos!",
        "O fogo das almas queima em seus olhos!",
        "Você ouve os sussurros das profundezas?",
        "A corrupção corre em suas veias!",
        "As almas perdidas clamam por libertação...",
        "As trevas sussurram seu nome nas masmorras!",
        "A guerra pelas almas começou!",
        "O domínio das trevas é inevitável!",
        "Seus inimigos tremerão diante das masmorras!",
        "O poder absoluto está ao seu alcance!",
        "Junte-se às almas perdidas das trevas!",
        "A luz da esperança se extingue para sempre!"
    ];

    // Mostrar frase sombria aleatória das Masmorras
    function showRandomPhrase() {
        const phrase = dungeonPhrases[Math.floor(Math.random() * dungeonPhrases.length)];

        // Criar toast medieval
        const toast = document.createElement('div');
        toast.style.position = 'fixed';
        toast.style.top = '20px';
        toast.style.right = '20px';
        toast.style.background = 'linear-gradient(135deg, rgba(25, 25, 25, 0.95), rgba(40, 40, 40, 0.95))';
        toast.style.border = '2px solid #d4af37';
        toast.style.borderRadius = '8px';
        toast.style.padding = '15px 20px';
        toast.style.color = '#d4af37';
        toast.style.fontFamily = 'Cinzel, serif';
        toast.style.fontSize = '14px';
        toast.style.zIndex = '10000';
        toast.style.transform = 'translateX(100%)';
        toast.style.transition = 'transform 0.5s ease-in-out';
        toast.style.maxWidth = '300px';
        toast.style.backdropFilter = 'blur(15px)';
        toast.innerHTML = `<strong>💀 Sussurros das Masmorras:</strong><br>${phrase}`;

        document.body.appendChild(toast);

        // Animar entrada
        setTimeout(() => {
            toast.style.transform = 'translateX(0)';
        }, 100);

        // Animar saída
        setTimeout(() => {
            toast.style.transform = 'translateX(100%)';
            setTimeout(() => {
                if (toast.parentNode) {
                    toast.parentNode.removeChild(toast);
                }
            }, 500);
        }, 4000);
    }

    // Primeira frase após 15 segundos, depois a cada 45 segundos (mais espaçado no tema escuro)
    setTimeout(showRandomPhrase, 15000);
    setInterval(showRandomPhrase, 45000);

    // Efeito Corrupção da Alma no botão de login
    function initSoulCorruptionEffect() {
        const soulBtn = document.querySelector('.dragon-devour-btn');
        if (soulBtn) {
            soulBtn.addEventListener('mouseenter', function () {
                // Criar ondas de corrupção
                createCorruptionWaves();

                // Som visual sombrio
                createVisualSound('💀 SOULS...', this);

                // Partículas das trevas
                createDarkSoulParticles(this);
            });

            soulBtn.addEventListener('mouseleave', function () {
                // Restaurar botão após um tempo
                setTimeout(() => {
                    this.style.color = '';
                }, 300);
            });
        }
    }

    function createCorruptionWaves() {
        for (let i = 0; i < 5; i++) {
            setTimeout(() => {
                const soul = document.createElement('div');
                soul.style.position = 'fixed';
                soul.style.fontSize = '20px';
                soul.style.zIndex = '9999';
                soul.style.pointerEvents = 'none';
                soul.style.left = Math.random() * window.innerWidth + 'px';
                soul.style.top = window.innerHeight + 'px';
                soul.textContent = ['💀', '⚡', '🖤', '🌑', '👁'][Math.floor(Math.random() * 5)];
                soul.style.filter = 'drop-shadow(0 0 8px #ff6b47)';

                document.body.appendChild(soul);

                // Animar alma corrompida subindo
                soul.animate([
                    {
                        transform: 'translateY(0px) rotate(0deg) scale(0.8)',
                        opacity: 0.9,
                        filter: 'drop-shadow(0 0 8px #ff6b47)'
                    },
                    {
                        transform: 'translateY(-' + (window.innerHeight + 100) + 'px) rotate(720deg) scale(1.2)',
                        opacity: 0,
                        filter: 'drop-shadow(0 0 20px #8b0000)'
                    }
                ], {
                    duration: 3000,
                    easing: 'ease-out'
                }).onfinish = () => {
                    if (soul.parentNode) {
                        soul.parentNode.removeChild(soul);
                    }
                };
            }, i * 150);
        }
    }

    function createVisualSound(sound, element) {
        const soundBubble = document.createElement('div');
        soundBubble.style.position = 'absolute';
        soundBubble.style.left = '50%';
        soundBubble.style.top = '-30px';
        soundBubble.style.transform = 'translateX(-50%)';
        soundBubble.style.color = '#ff6b47';
        soundBubble.style.fontWeight = 'bold';
        soundBubble.style.fontSize = '12px';
        soundBubble.style.zIndex = '10000';
        soundBubble.style.pointerEvents = 'none';
        soundBubble.textContent = sound;

        element.style.position = 'relative';
        element.appendChild(soundBubble);

        // Animar som
        soundBubble.animate([
            { transform: 'translateX(-50%) translateY(0)', opacity: 1 },
            { transform: 'translateX(-50%) translateY(-20px)', opacity: 0 }
        ], {
            duration: 1000,
            easing: 'ease-out'
        }).onfinish = () => {
            if (soundBubble.parentNode) {
                soundBubble.parentNode.removeChild(soundBubble);
            }
        };
    }

    function createDarkSoulParticles(element) {
        const rect = element.getBoundingClientRect();
        const darkParticles = ['💀', '⚡', '🖤', '🌑', '👁'];

        for (let i = 0; i < 12; i++) {
            setTimeout(() => {
                const particle = document.createElement('div');
                particle.style.position = 'fixed';
                particle.style.left = (rect.left + Math.random() * rect.width) + 'px';
                particle.style.top = (rect.top + Math.random() * rect.height) + 'px';
                particle.style.fontSize = '14px';
                particle.style.zIndex = '9999';
                particle.style.pointerEvents = 'none';
                particle.textContent = darkParticles[Math.floor(Math.random() * darkParticles.length)];
                particle.style.filter = 'drop-shadow(0 0 6px #8b0000)';

                document.body.appendChild(particle);

                // Animar partícula sombria
                particle.animate([
                    {
                        transform: 'scale(0) rotate(0deg)',
                        opacity: 1,
                        filter: 'drop-shadow(0 0 6px #8b0000)'
                    },
                    {
                        transform: 'scale(2) rotate(360deg) translateY(-50px)',
                        opacity: 0,
                        filter: 'drop-shadow(0 0 15px #ff6b47)'
                    }
                ], {
                    duration: 1200,
                    easing: 'ease-out'
                }).onfinish = () => {
                    if (particle.parentNode) {
                        particle.parentNode.removeChild(particle);
                    }
                };
            }, i * 40);
        }
    }

    // Inicializar efeito de corrupção da alma
    initSoulCorruptionEffect();

    // Easter egg: Konami Code medieval
    let konamiCode = [];
    const konamiSequence = [
        'ArrowUp', 'ArrowUp', 'ArrowDown', 'ArrowDown',
        'ArrowLeft', 'ArrowRight', 'ArrowLeft', 'ArrowRight',
        'KeyB', 'KeyA'
    ];

    document.addEventListener('keydown', function (e) {
        konamiCode.push(e.code);
        if (konamiCode.length > konamiSequence.length) {
            konamiCode.shift();
        }

        if (JSON.stringify(konamiCode) === JSON.stringify(konamiSequence)) {
            // Ativar modo épico
            document.body.style.filter = 'hue-rotate(45deg) saturate(1.5) brightness(1.1)';

            // Explosão de partículas
            for (let i = 0; i < 50; i++) {
                setTimeout(() => {
                    const particle = document.createElement('div');
                    particle.style.position = 'fixed';
                    particle.style.left = Math.random() * 100 + 'vw';
                    particle.style.top = Math.random() * 100 + 'vh';
                    particle.style.fontSize = '30px';
                    particle.style.color = '#ffd700';
                    particle.style.pointerEvents = 'none';
                    particle.style.zIndex = '10000';
                    particle.style.animation = 'goldShine 0.5s ease-out forwards';
                    particle.innerText = '👁';

                    document.body.appendChild(particle);

                    setTimeout(() => {
                        if (particle.parentNode) {
                            particle.parentNode.removeChild(particle);
                        }
                    }, 500);
                }, i * 50);
            }

            // Mostrar mensagem especial
            alert('💀 A BATALHA PELAS ALMAS TE ESPERA! 💀\n\n' +
                'O mal desperta... e você é uma das almas perdidas!\n' +
                'As masmorras sussurram seu nome nas trevas!\n' +
                'Bônus das Almas: +25% XP e -50% Death Penalty!');

            // Resetar após 10 segundos
            setTimeout(() => {
                document.body.style.filter = '';
            }, 10000);

            konamiCode = [];
        }
    });

    // Efeito de chuva medieval épica
    function createRainEffect() {
        for (let i = 0; i < 30; i++) {
            setTimeout(() => {
                const raindrop = document.createElement('div');
                raindrop.style.position = 'fixed';
                raindrop.style.left = Math.random() * 100 + 'vw';
                raindrop.style.top = '-10px';
                raindrop.style.width = '2px';
                raindrop.style.height = Math.random() * 20 + 10 + 'px';
                raindrop.style.background = 'linear-gradient(180deg, transparent, rgba(135, 206, 235, 0.6), rgba(176, 196, 222, 0.4))';
                raindrop.style.opacity = Math.random() * 0.7 + 0.3;
                raindrop.style.pointerEvents = 'none';
                raindrop.style.zIndex = '-1';
                raindrop.style.animation = 'rainFall 1.5s linear forwards';
                raindrop.style.transform = 'rotate(10deg)';

                document.body.appendChild(raindrop);

                setTimeout(() => {
                    if (raindrop.parentNode) {
                        raindrop.parentNode.removeChild(raindrop);
                    }
                }, 1500);
            }, i * 50);
        }
    }

    // Efeito de neve medieval ocasional (partículas de gelo)
    function createSnowEffect() {
        if (Math.random() < 0.15) { // 15% de chance
            for (let i = 0; i < 8; i++) { // Ainda menos partículas
                setTimeout(() => {
                    const snowflake = document.createElement('div');
                    snowflake.style.position = 'fixed';
                    snowflake.style.left = Math.random() * 100 + 'vw';
                    snowflake.style.top = '-20px';
                    snowflake.style.fontSize = Math.random() * 8 + 8 + 'px';
                    snowflake.style.color = '#b0c4de';
                    snowflake.style.opacity = Math.random() * 0.3 + 0.1;
                    snowflake.style.pointerEvents = 'none';
                    snowflake.style.zIndex = '-1';
                    snowflake.style.animation = 'floatUp 15s linear forwards reverse';
                    snowflake.innerText = '❄️';

                    document.body.appendChild(snowflake);

                    setTimeout(() => {
                        if (snowflake.parentNode) {
                            snowflake.parentNode.removeChild(snowflake);
                        }
                    }, 15000);
                }, i * 400); // Mais espaçamento entre flocos
            }
        }
    }

    // Efeito de chuva ocasional (mais frequente que neve)
    function startRainStorm() {
        if (Math.random() < 0.9) { // 40% de chance de tempestade
            createRainEffect();
            // Criar várias ondas de chuva
            setTimeout(() => createRainEffect(), 2000);
            setTimeout(() => createRainEffect(), 4000);
            setTimeout(() => createRainEffect(), 6000);
        }
    }

    // Iniciar chuva ocasional
    setTimeout(startRainStorm, 2000); // Primeira chuva após 20 segundos
    setInterval(startRainStorm, 60000); // A cada minuto

    // Ocasionalmente criar efeito de neve (menos frequente no tema escuro)
    setInterval(createSnowEffect, 120000); // A cada 2 minutos

    console.log('💀 Sistema das Trevas de Dungeon Souls inicializado! 💀');
    console.log('🔥 As almas das masmorras vigiam... Tente o código Konami para despertar seu poder...');
    console.log('⚡ As tempestades das masmorras começarão em breve... As trevas se aproximam!');

    // Efeitos especiais para página de Highscores
    if (window.location.pathname.includes('Highscores')) {
        initHighscoresEffects();
    }
});

// Efeitos especiais para página de Highscores
function initHighscoresEffects() {
    console.log('⚔️ Página de Highscores das Trevas carregada! Iniciando efeitos sombrios...');

    // Efeito de entrada para as linhas da tabela
    const tableRows = document.querySelectorAll('.table tbody tr');
    tableRows.forEach((row, index) => {
        row.style.opacity = '0';
        row.style.transform = 'translateX(-50px)';

        setTimeout(() => {
            row.style.transition = 'all 0.5s ease';
            row.style.opacity = '1';
            row.style.transform = 'translateX(0)';
        }, index * 100);
    });

    // Efeito especial para o top 3
    setTimeout(() => {
        const topThree = document.querySelectorAll('.table tbody tr:nth-child(-n+3)');
        topThree.forEach((row, index) => {
            row.addEventListener('mouseenter', function () {
                createRankParticles(this, index + 1);
            });
        });
    }, 2000);

    // Contador animado para estatísticas
    animateCounters();

    // Inicializar efeitos de paginação
    initPaginationEffects();
}

function createRankParticles(element, rank) {
    const rect = element.getBoundingClientRect();
    let particle, particleCount;

    switch (rank) {
        case 1:
            particle = '👑';
            particleCount = 8;
            break;
        case 2:
            particle = '⭐';
            particleCount = 6;
            break;
        case 3:
            particle = '💎';
            particleCount = 4;
            break;
        default:
            return;
    }

    for (let i = 0; i < particleCount; i++) {
        setTimeout(() => {
            const sparkle = document.createElement('div');
            sparkle.style.position = 'fixed';
            sparkle.style.left = (rect.left + Math.random() * rect.width) + 'px';
            sparkle.style.top = (rect.top + Math.random() * rect.height) + 'px';
            sparkle.style.fontSize = '16px';
            sparkle.style.zIndex = '9999';
            sparkle.style.pointerEvents = 'none';
            sparkle.textContent = particle;
            sparkle.style.filter = 'drop-shadow(0 0 8px #ff6b47)';

            document.body.appendChild(sparkle);

            // Animar partícula de rank
            sparkle.animate([
                {
                    transform: 'scale(0) rotate(0deg)',
                    opacity: 1,
                    filter: 'drop-shadow(0 0 8px #ff6b47)'
                },
                {
                    transform: 'scale(1.5) rotate(360deg) translateY(-40px)',
                    opacity: 0,
                    filter: 'drop-shadow(0 0 15px #ffd700)'
                }
            ], {
                duration: 1000,
                easing: 'ease-out'
            }).onfinish = () => {
                if (sparkle.parentNode) {
                    sparkle.parentNode.removeChild(sparkle);
                }
            };
        }, i * 80);
    }
}

function animateCounters() {
    const counters = document.querySelectorAll('.card-body strong');

    counters.forEach(counter => {
        const target = parseInt(counter.textContent.replace(/\D/g, ''));
        if (!isNaN(target) && target > 0) {
            let current = 0;
            const increment = target / 60; // Animar por 1 segundo (60fps)

            const timer = setInterval(() => {
                current += increment;
                if (current >= target) {
                    counter.textContent = target.toLocaleString();
                    clearInterval(timer);
                } else {
                    counter.textContent = Math.floor(current).toLocaleString();
                }
            }, 16); // ~60fps
        }
    });
}

function initPaginationEffects() {
    const paginationLinks = document.querySelectorAll('.pagination-dark .page-link');

    paginationLinks.forEach(link => {
        // Efeito de partículas nos botões de navegação
        link.addEventListener('mouseenter', function () {
            if (!this.parentElement.classList.contains('disabled')) {
                createPaginationParticles(this);
            }
        });

        // Efeito de loading ao clicar
        link.addEventListener('click', function (e) {
            if (!this.parentElement.classList.contains('disabled') &&
                !this.parentElement.classList.contains('active')) {
                createPageTransition();
            }
        });
    });
}

function createPaginationParticles(element) {
    const rect = element.getBoundingClientRect();
    const particles = ['⚡', '💀', '🔥', '👁'];

    for (let i = 0; i < 4; i++) {
        setTimeout(() => {
            const particle = document.createElement('div');
            particle.style.position = 'fixed';
            particle.style.left = (rect.left + Math.random() * rect.width) + 'px';
            particle.style.top = (rect.top + Math.random() * rect.height) + 'px';
            particle.style.fontSize = '12px';
            particle.style.zIndex = '9999';
            particle.style.pointerEvents = 'none';
            particle.textContent = particles[Math.floor(Math.random() * particles.length)];
            particle.style.filter = 'drop-shadow(0 0 6px #ff6b47)';

            document.body.appendChild(particle);

            // Animar partícula de paginação
            particle.animate([
                {
                    transform: 'scale(0) rotate(0deg)',
                    opacity: 1,
                    filter: 'drop-shadow(0 0 6px #ff6b47)'
                },
                {
                    transform: 'scale(1.2) rotate(180deg) translateY(-25px)',
                    opacity: 0,
                    filter: 'drop-shadow(0 0 12px #ff4500)'
                }
            ], {
                duration: 600,
                easing: 'ease-out'
            }).onfinish = () => {
                if (particle.parentNode) {
                    particle.parentNode.removeChild(particle);
                }
            };
        }, i * 30);
    }
}

function createPageTransition() {
    // Criar overlay de transição
    const overlay = document.createElement('div');
    overlay.style.position = 'fixed';
    overlay.style.top = '0';
    overlay.style.left = '0';
    overlay.style.width = '100%';
    overlay.style.height = '100%';
    overlay.style.background = 'linear-gradient(45deg, rgba(0,0,0,0.8), rgba(139,0,0,0.8))';
    overlay.style.zIndex = '10000';
    overlay.style.display = 'flex';
    overlay.style.alignItems = 'center';
    overlay.style.justifyContent = 'center';
    overlay.style.opacity = '0';
    overlay.style.transition = 'opacity 0.3s ease';
    overlay.innerHTML = `
        <div style="text-align: center; color: #ff6b47;">
            <div style="font-size: 3rem; margin-bottom: 1rem;">💀</div>
            <div style="font-size: 1.2rem; font-weight: bold;">Navegando pelas almas...</div>
            <div style="margin-top: 1rem;">
                <div style="width: 60px; height: 4px; background: #333; border-radius: 2px; overflow: hidden; margin: 0 auto;">
                    <div style="width: 100%; height: 100%; background: linear-gradient(90deg, #ff6b47, #8b0000); animation: loadingBar 1s ease-in-out infinite;"></div>
                </div>
            </div>
        </div>
    `;

    // Adicionar animação de loading
    const style = document.createElement('style');
    style.textContent = `
        @keyframes loadingBar {
            0% { transform: translateX(-100%); }
            100% { transform: translateX(100%); }
        }
    `;
    document.head.appendChild(style);

    document.body.appendChild(overlay);

    // Mostrar overlay
    setTimeout(() => {
        overlay.style.opacity = '1';
    }, 10);

    // Remover overlay após 1 segundo (simula carregamento)
    setTimeout(() => {
        overlay.style.opacity = '0';
        setTimeout(() => {
            if (overlay.parentNode) {
                overlay.parentNode.removeChild(overlay);
            }
            if (style.parentNode) {
                style.parentNode.removeChild(style);
            }
        }, 300);
    }, 800);
}

// Função para simular loading épico
function epicLoading(message = "Carregando magia...") {
    const loader = document.createElement('div');
    loader.style.position = 'fixed';
    loader.style.top = '0';
    loader.style.left = '0';
    loader.style.width = '100%';
    loader.style.height = '100%';
    loader.style.background = 'rgba(20, 20, 20, 0.97)';
    loader.style.display = 'flex';
    loader.style.flexDirection = 'column';
    loader.style.justifyContent = 'center';
    loader.style.alignItems = 'center';
    loader.style.zIndex = '999999';
    loader.style.color = '#d4af37';
    loader.style.fontFamily = 'Cinzel, serif';
    loader.innerHTML = `
        <div style="text-align: center;">
            <div style="font-size: 4rem; margin-bottom: 2rem; animation: goldShine 1s ease-in-out infinite;">👁</div>
            <h2 style="margin-bottom: 1rem;">${message}</h2>
            <div style="width: 300px; height: 4px; background: rgba(255, 107, 71, 0.3); border-radius: 2px; overflow: hidden;">
                <div style="width: 0%; height: 100%; background: linear-gradient(90deg, #8b0000, #ff6b47); border-radius: 2px; animation: loading 3s ease-in-out forwards;"></div>
            </div>
        </div>
    `;

    const loadingStyle = document.createElement('style');
    loadingStyle.textContent = `
        @keyframes loading {
            0% { width: 0%; }
            100% { width: 100%; }
        }
    `;
    document.head.appendChild(loadingStyle);

    document.body.appendChild(loader);

    setTimeout(() => {
        loader.style.opacity = '0';
        loader.style.transition = 'opacity 0.5s ease-out';
        setTimeout(() => {
            if (loader.parentNode) {
                loader.parentNode.removeChild(loader);
            }
            if (loadingStyle.parentNode) {
                loadingStyle.parentNode.removeChild(loadingStyle);
            }
        }, 500);
    }, 3000);
}

