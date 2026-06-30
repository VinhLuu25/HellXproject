# Hell X Server

The server is a TypeScript Fastify project for the Hell X backend skeleton.

## Local Setup

```bash
cd server
npm install
cp .env.example .env
npm run dev
```

The default local API URL is:

```txt
http://localhost:3000
```

## Environment

`.env.example` contains safe local placeholder values:

```txt
PORT=3000
HOST=0.0.0.0
DATABASE_URL="postgresql://hellx_user:hellx_password@localhost:5432/hellx_dev?schema=public"
```

Do not commit a real `.env` file.

## Scripts

```bash
npm run dev
npm run build
npm run typecheck
npm test
npm run prisma:validate
```

## CI Draft

The server CI draft installs dependencies, builds TypeScript, and runs tests. It does not start PostgreSQL or run migrations.

## Health Endpoint

```txt
GET /health
```

Expected response shape:

```json
{
  "status": "ok",
  "service": "hellx-backend",
  "timestamp": "2026-01-01T00:00:00.000Z"
}
```

## Day 3 Boundary

Day 3 covers only the backend skeleton: Fastify app startup, the health route, Prisma schema setup, local environment example, and a minimal health route test.

Production login, cloud save endpoints, database migrations, client integration, dashboard work, deployment config, and CI are not part of Day 3.

## Week 1 State

The server now includes mock session and save endpoints for contract testing. These endpoints do not write to PostgreSQL.
