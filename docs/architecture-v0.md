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

Current Week 2 state:

- Main menu and first room scene targets exist.
- Player, interaction, clue, inventory, journal, puzzle, checkpoint, local save, status UI, and backend client scripts exist.
- Unity scene builder has created or updated the Week 2 scene targets.
- Unity play mode and WebGL build verification still need manual editor work.

## Backend API

The backend API owns server-side validation and access to persistent player state. Early API work should focus on health, session direction, save/load direction, and contracts that the Unity client can call consistently.

Current Week 2 state:

- Fastify app exists under `server/`.
- `/health`, `/session/test`, and `/save/current` routes exist.
- Save write/load/reset uses an in-memory test-session store.
- Server build and tests can run locally with npm.

## PostgreSQL

PostgreSQL is the long-term store for player records, sessions, save data, puzzle state, inventory state, journal progress, deaths, settings, and unlocks. Prisma should manage schema and migration work when persistence implementation begins.

Current Week 2 state:

- Prisma schema reflects the save/session contract.
- No migrations or real database writes have been run for Week 2.

## QA/Ops Dashboard

The dashboard is planned as a React surface for inspecting players, sessions, saves, and test data. It should use backend APIs rather than direct database access.

Current Week 1 state:

- Dashboard implementation has not started.

## First End-To-End Target

The first end-to-end target is intentionally narrow:

1. Player opens the Unity WebGL client.
2. Player moves and interacts with an object.
3. Client sends a health or save-style request to the backend.
4. Backend returns a clear success or failure response.
5. Client shows visible sync status.

Current Week 2 target:

1. Run the backend locally.
2. Trigger the Unity-side backend check.
3. Call `/health`, `/session/test`, `PUT /save/current`, and `GET /save/current`.
4. Show either `Save synced: first-room / manual-save` or a clear failure status.

## Architecture Principles

- Keep the vertical slice small and testable.
- Use the backend as the boundary for persistent player state.
- Keep database changes migration-driven.
- Make API contracts explicit before expanding client integration.
- Keep dashboard work separate from gameplay and persistence implementation.
- Prefer visible, reproducible evidence over broad claims.
