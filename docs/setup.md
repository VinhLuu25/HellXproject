# Setup

## Prerequisites

- Git.
- Node.js and npm.
- Unity `6000.3.11f1` or a compatible editor for client work.
- PostgreSQL for later persistence work. Week 1 mock routes do not require a running database.

## Repository

```bash
git clone <repo-url>
cd HellXproject
```

## Server

```bash
cd server
npm install
cp .env.example .env
npm run build
npm test
npm run dev
```

The default server URL is:

```txt
http://localhost:3000
```

Useful endpoints:

```txt
GET /health
POST /session/test
GET /save/current
PUT /save/current
DELETE /save/current
```

## Client

Open `client/` in Unity. See `client/README.md` for the current scene and script setup.

For the local mock flow:

1. Start the server.
2. Open the client project in Unity.
3. Open `Assets/Scenes/FirstRoom.unity`.
4. Wire `BackendClient`, `BackendStatusController`, `StatusDisplay`, and `LocalSaveStore`.
5. Trigger `BackendStatusController.CheckBackend`.

Expected success status:

```txt
Backend ready: first-room / intro
```

## CI Draft

The current CI draft runs server dependency install, TypeScript build, and server tests. It does not run Unity, PostgreSQL, Prisma migrations, dashboard checks, or WebGL builds.
