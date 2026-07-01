# API Contract V0

API contract V0 defines the minimum backend shape for the first save/resume demo path. The contract is intentionally small and uses stable test-session data for the local slice.

## Health

`GET /health`

Purpose: confirm the backend process is reachable.

Success response:

```json
{
  "status": "ok",
  "service": "hellx-backend",
  "timestamp": "2026-01-01T00:00:00.000Z"
}
```

## Test Session

`POST /session/test`

Purpose: create or return a test session for local demo flow without production login.

Success response:

```json
{
  "sessionId": "test-session-001",
  "playerId": "test-player-001",
  "mode": "test"
}
```

## Load Current Save

`GET /save/current`

Purpose: return the current save state for the active test player/session.

Success response:

```json
{
  "playerId": "test-player-001",
  "sessionId": "test-session-001",
  "currentChapter": "chapter-01",
  "currentRoom": "first-room",
  "checkpointId": "intro",
  "position": {
    "x": 0,
    "y": 0
  },
  "inventoryItems": [],
  "collectedClues": [],
  "journalEntries": [],
  "puzzleFlags": {},
  "settingsSnapshot": {},
  "deathCount": 0,
  "retryCount": 0,
  "updatedAt": "2026-01-01T00:00:00.000Z"
}
```

## Write Current Save

`PUT /save/current`

Purpose: accept the current client save state and return the accepted state.

Request body:

```json
{
  "currentChapter": "chapter-01",
  "currentRoom": "first-room",
  "checkpointId": "clue-found",
  "position": {
    "x": 2,
    "y": -1
  },
  "inventoryItems": ["rusted-key"],
  "collectedClues": ["wall-note"],
  "journalEntries": ["entry-001"],
  "puzzleFlags": {
    "fuseBoxOpened": true
  },
  "settingsSnapshot": {
    "volume": 0.8
  },
  "deathCount": 0,
  "retryCount": 1
}
```

Success response: the accepted save state with `playerId`, `sessionId`, and `updatedAt`.

Validation failure:

```json
{
  "error": "invalid_save_state"
}
```

## Reset Test Save

`DELETE /save/current`

Purpose: reset mock save state during local test flow.

Success response:

```json
{
  "status": "reset",
  "save": {
    "playerId": "test-player-001",
    "sessionId": "test-session-001",
    "checkpointId": "intro"
  }
}
```

## Day 4 Boundary

These endpoints are mock contract endpoints. They do not provide production account security, production cloud save, or database writes.

## Week 2 Persistence Status

The save route now writes and reads from an in-memory store owned by the running backend process. Restarting the process resets the save to `intro`.

The Prisma schema is aligned to the save model through `SaveSlot`, but database-backed persistence and migrations are not active in this pass.

## Day 5 Client Spike

The Unity client can call the mock flow in this order:

1. `GET /health`
2. `POST /session/test`
3. `GET /save/current`

The client should show a visible success status when all three requests complete and a visible failure status when any request fails.
