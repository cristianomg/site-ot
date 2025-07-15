# 💀 Dungeon Souls - Aplicação Angular 💀

Uma aplicação Angular recriando o layout e funcionalidades do site Dungeon Souls, mantendo o tema medieval sombrio e todas as telas do projeto original.

## 🚀 Como Executar

### Pré-requisitos
- Node.js (versão 18 ou superior)
- npm ou yarn

### Instalação

1. Clone o repositório ou navegue até a pasta do projeto:
```bash
cd dungeon-souls-angular
```

2. Instale as dependências:
```bash
npm install
```

3. Execute a aplicação em modo de desenvolvimento:
```bash
ng serve
```

4. Abra seu navegador e acesse:
```
http://localhost:4200
```

## 🎨 Funcionalidades Implementadas

### ✅ Páginas Criadas
- **Home** - Página inicial com informações do servidor e top players
- **Highscores** - Ranking de jogadores com diferentes categorias
- **Players Online** - Lista de jogadores online
- **Character** - Detalhes de personagens individuais

### ✅ Componentes
- **ServerStatus** - Indicador de status do servidor
- **OnlinePlayers** - Contador de jogadores online
- **Layout Responsivo** - Design adaptável para diferentes dispositivos

### ✅ Características do Design
- **Tema Medieval Sombrio** - Visual inspirado em Mordor
- **Animações CSS** - Efeitos visuais e transições
- **Fontes Google** - Cinzel e Cinzel Decorative
- **Bootstrap** - Framework CSS para layout responsivo

## 🛠️ Tecnologias Utilizadas

- **Angular 18** - Framework principal
- **Bootstrap 5** - Framework CSS
- **TypeScript** - Linguagem de programação
- **CSS3** - Estilos customizados

## 📁 Estrutura do Projeto

```
src/
├── app/
│   ├── components/
│   │   ├── home/                 # Página inicial
│   │   ├── highscores/           # Rankings
│   │   ├── players-online/       # Jogadores online
│   │   ├── character/            # Detalhes do personagem
│   │   ├── server-status/        # Status do servidor
│   │   └── online-players/       # Contador online
│   ├── models/
│   │   └── player.model.ts       # Interfaces e enums
│   ├── services/                 # Serviços (para futuras implementações)
│   ├── app.component.*           # Componente principal
│   ├── app.routes.ts            # Configuração de rotas
│   └── app.config.ts            # Configuração da aplicação
├── styles.css                   # Estilos globais
└── index.html                   # HTML principal
```

## 🎯 Funcionalidades Futuras

- [ ] Integração com API real
- [ ] Sistema de autenticação
- [ ] Chat em tempo real
- [ ] Sistema de guildas
- [ ] Eventos do servidor
- [ ] Sistema de doações

## 🎨 Personalização

A aplicação mantém o mesmo visual sombrio do projeto original, com:
- Gradientes escuros
- Cores laranja-vermelho (#ff6b47)
- Efeitos de glow
- Animações suaves
- Tema medieval consistente

## 📱 Responsividade

O design é totalmente responsivo e funciona em:
- Desktop
- Tablet
- Mobile

## 🔧 Comandos Úteis

```bash
# Executar em modo desenvolvimento
ng serve

# Build para produção
ng build

# Executar testes
ng test

# Lint do código
ng lint
```

## 📄 Licença

Este projeto é uma recriação educacional do site Dungeon Souls para fins de aprendizado e demonstração de habilidades em Angular.

---

**💀 Que as trevas te guiem em sua jornada pelas masmorras! 💀** 