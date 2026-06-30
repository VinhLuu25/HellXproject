# Architecture V0

Architecture V0 defines the intended system shape for the first vertical slice. It is a planning baseline, not a full implementation spec.

## System Shape

```txt
Player
  |
  v
Unity WebGL Client
  |
  v
Backend API
  |
  v
PostgreSQL

QA/Ops Dashboard
  |
  v
Backend API
```

## Unity WebGL Client

The Unity client owns the player-facing horror experience: movement, interaction, room flow, local UI feedback, puzzle beats, inventory state, journal state, and save/load requests. It should stay focused on gameplay presentation and client-side responsiveness.

## Backend API

The backend API owns server-side validation and access to persistent player state. Early API work should focus on health, session direction, save/load direction, and contracts that the Unity client can call consistently.

## PostgreSQL

PostgreSQL is the long-term store for player records, sessions, save data, puzzle state, inventory state, journal progress, deaths, settings, and unlocks. Prisma should manage schema and migration work when persistence implementation begins.

## QA/Ops Dashboard

The dashboard is planned as a React surface for inspecting players, sessions, saves, and test data. It should use backend APIs rather than direct database access.

## First End-To-End Target

The first end-to-end target is intentionally narrow:

1. Player opens the Unity WebGL client.
2. Player moves and interacts with an object.
3. Client sends a health or save-style request to the backend.
4. Backend returns a clear success or failure response.
5. Client shows visible sync status.

## Architecture Principles

- Keep the vertical slice small and testable.
- Use the backend as the boundary for persistent player state.
- Keep database changes migration-driven.
- Make API contracts explicit before expanding client integration.
- Keep dashboard work separate from gameplay and persistence implementation.
- Prefer visible, reproducible evidence over broad claims.
