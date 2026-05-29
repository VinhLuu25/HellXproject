# Backend Setup

## Purpose

The Hell X backend provides API endpoints for health checks, authentication/session handling, cloud save, persistent player progress, telemetry, and future dashboard support.

## Scope

- TypeScript project setup
- Fastify server
- Health endpoint
- CORS configuration
- Environment variable example
- Prisma schema v0
- PostgreSQL connection placeholder

## Local Development

From the repository root:

```bash
cd server
npm install
cp .env.example .env
npm run dev