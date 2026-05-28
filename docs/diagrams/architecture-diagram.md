# Architecture Diagram

## Architecture v0

```txt
Player
  |
  v
Unity WebGL Client
  |
  | HTTPS API calls
  v
Backend API
  |
  | Prisma ORM
  v
PostgreSQL Database

Backend API
  |
  v
QA/Ops Dashboard

GitHub Actions
  |
  v
Build/Test Pipeline