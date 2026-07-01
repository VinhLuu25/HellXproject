# Hell X

Hell X is an online 2D horror vertical slice. The project combines a Unity 2D WebGL game client with a TypeScript backend API, save/load flow, persistent data planning, project documentation, and milestone evidence.

## Project Vision

Hell X should feel like a real horror game first: tense, readable, atmospheric, and playable. The engineering goal is to prove that a small playable slice can support session flow, save/resume behavior, backend-backed state, repeatable setup, checks, and a clear review process.

## Current Milestone

The project is currently past Week 2 foundation and vertical-slice setup.

Week 1 established the repository foundation, scope, architecture notes, process docs, server skeleton, client skeleton, save/API contract, and setup discipline.

Week 2 added the first playable-room direction: main menu target, first room target, player movement, clue pickup, inventory/journal state, simple puzzle state, checkpoint payload, backend save/load route, client save/load flow, manual checklist, and review docs.

## Core Player Loop

1. Open the WebGL game build.
2. Start a test session or sign in through the future account flow.
3. Enter the first horror room.
4. Move through the room.
5. Inspect and collect a clue.
6. Store clue state in inventory or journal state.
7. Interact with a puzzle object.
8. Solve the simple puzzle condition.
9. Trigger a checkpoint.
10. Send or prepare save state.
11. Leave, refresh, or return later.
12. Load progress and resume from the checkpoint.

## Demo Target

The current demo target is a thin end-to-end slice:

```txt
Main menu
  -> test session
  -> first room
  -> movement
  -> clue pickup
  -> inventory/journal update
  -> puzzle solved state
  -> checkpoint payload
  -> save/load API call or safe fallback
  -> resume-ready state
```

The slice favors a small complete path over broad unfinished systems.

## User Stories

### Player Stories

### Player Stories

| ID | Story | Acceptance Criteria |
| --- | --- | --- |
| P1 | As a player, I want to open the game and reach a clear main menu so that I know how to start the chapter. | Main menu target exists; title/status/start path is represented; test-session entry is planned or wired. |
| P2 | As a player, I want to enter the first horror room so that I can begin the playable slice. | Chapter01_Room01 target exists; room placeholder objects exist; scene is documented in the manual checklist. |
| P3 | As a player, I want to move a character in a 2D room so that I can explore the space. | Player movement script exists; player placeholder exists or is expected in scene; movement is listed in manual tests. |
| P4 | As a player, I want to interact with objects so that the room feels playable instead of static. | Interaction flow exists; interactable object pattern exists; clue, puzzle, or checkpoint can use it. |
| P5 | As a player, I want to collect a clue so that I can make progress in the room. | Clue pickup script exists; collected clue state is tracked; manual checklist includes clue pickup. |
| P6 | As a player, I want collected clues to appear in inventory or journal state so that my discoveries are remembered. | Inventory state exists; journal state exists; clue data can be stored. |
| P7 | As a player, I want to solve a simple puzzle using discovered information so that the room has an objective. | Puzzle state exists; solved state exists; puzzle can depend on clue or interaction state. |
| P8 | As a player, I want to trigger a checkpoint so that my progress can be saved. | Checkpoint logic exists or is planned; save payload includes room, checkpoint, clue, journal, inventory, puzzle, and position data where available. |
| P9 | As a player, I want the game to recover if the backend is unreachable so that I understand what went wrong. | Client save/load flow has recoverable error handling or documented fallback behavior. |
| P10 | As a player, I want to resume progress later so that refresh or return does not erase the slice state. | Backend save/load path exists for test-session flow; resume behavior is documented as current or planned. |

## Scope

### In Scope

- Unity 2D WebGL client.
- Short 2D horror chapter.
- Main menu and first room target.
- Player movement.
- Interaction flow.
- Clue pickup.
- Inventory and journal state.
- Simple puzzle state.
- Checkpoint payload.
- Test-session save/load flow.
- Backend-backed save/load route.
- PostgreSQL and Prisma planning.
- React QA/Ops dashboard planning.
- Tests, setup docs, architecture notes, project log, review docs, and manual evidence.
  
## Tech Stack

| Layer | Technology |
| --- | --- |
| Game client | Unity 2D, C#, WebGL |
| Backend API | Node.js, TypeScript, Fastify |
| Database | PostgreSQL |
| ORM | Prisma |
| Dashboard | React |
| CI/CD | GitHub Actions |

## Repository Structure

```txt
HellXproject/
  client/      # Unity game client
  server/      # Backend API
  docs/        # Planning, diagrams, testing notes, and evidence
  dashboard/   # Planned QA/Ops dashboard
  .github/     # Issue, pull request, and workflow files
```

## Important Paths

### Client

```txt
client/Assets/Scenes/
client/Assets/Scripts/Player/
client/Assets/Scripts/Interaction/
client/Assets/Scripts/Inventory/
client/Assets/Scripts/Journal/
client/Assets/Scripts/Puzzle/
client/Assets/Scripts/Checkpoint/
client/Assets/Scripts/Save/
client/Assets/Scripts/Network/
client/Assets/Scripts/UI/
client/Assets/Editor/
```

### Server

```txt
server/src/
server/src/routes/
server/src/services/
server/src/types/
server/src/schemas/
server/prisma/schema.prisma
server/test/
```

### Docs

```txt
docs/project-scope.md
docs/week-1-plan.md
docs/week-2-plan.md
docs/week-1-review.md
docs/week-2-review.md
docs/week-3-plan.md
docs/architecture-v0.md
docs/save-model-v0.md
docs/api-contract-v0.md
docs/setup.md
docs/manual-test-checklist.md
docs/demo-script-draft.md
docs/project-log.md
docs/testing-plan.md
```

## Local Setup

Read setup notes first:

```txt
docs/setup.md
```

### Server Checks

```bash
cd server
npm install
npm run build
npm test
```

Run Prisma validation when server dependencies are available:

```bash
cd server
npx prisma validate
```

### Client Setup

Open the Unity project from:

```txt
client/
```

Unity `6000.3.11f1` or a compatible editor is expected.

Client setup notes live in:

```txt
client/README.md
```

## Current Status

### Complete Or In Place

- Week 1 repository foundation.
- Project scope and planning docs.
- Architecture v0.
- Process docs.
- Client skeleton.
- Server skeleton.
- Save model and API contract.
- Mock integration path.
- Week 2 playable-room scripts.
- Main menu and first room scene targets.
- Clue pickup flow.
- Inventory state.
- Journal state.
- Puzzle state.
- Checkpoint/save payload direction.
- Backend save/load/reset route for test-session flow.
- In-memory backend state for current test flow.
- Manual test checklist.
- Week 2 review and Week 3 plan.

### Partial Or Needs Manual Verification

- Unity scene generation and scene wiring.
- Unity play mode verification.
- Full client-to-backend manual run.
- Refresh/resume demo flow.
- WebGL build.
- Database-backed persistence.
- Production session/login flow.
- Dashboard implementation.
- Deployment.

### Known Technical Notes

- Unity batchmode may be blocked by licensing, cache, or import state on local machines.
- Unity scene work should be verified manually in the Unity Editor before demo.
- Current backend persistence is not production database persistence unless explicitly replaced with PostgreSQL-backed storage.
- The current save/load path is intended for test-session vertical-slice validation.

## Definition Of Demo Ready

The project is demo-ready for the current milestone when:

- Unity opens the client project.
- Main menu scene is accessible.
- First room scene is accessible.
- Player movement works in play mode.
- Clue pickup updates state.
- Puzzle state can be solved.
- Checkpoint/save payload can be triggered.
- Backend server starts locally.
- Save/load route works for test-session flow.
- Manual checklist has been run and updated.
- Known skipped checks are documented honestly.

## Supporting Docs

- [Project scope](docs/project-scope.md)
- [Week 1 plan](docs/week-1-plan.md)
- [Week 2 plan](docs/week-2-plan.md)
- [Week 1 review](docs/week-1-review.md)
- [Week 2 review](docs/week-2-review.md)
- [Week 3 plan](docs/week-3-plan.md)
- [Architecture v0](docs/architecture-v0.md)
- [Save model v0](docs/save-model-v0.md)
- [API contract v0](docs/api-contract-v0.md)
- [Setup notes](docs/setup.md)
- [Manual test checklist](docs/manual-test-checklist.md)
- [Demo script draft](docs/demo-script-draft.md)
- [Testing plan](docs/testing-plan.md)
- [Project log](docs/project-log.md)

## Next Work

should focus on:

1. Manually verifying Unity scenes in the Editor.
2. Stabilizing scene wiring.
3. Running the full movement, clue, puzzle, and checkpoint path in play mode.
4. Running backend save/load locally.
5. Connecting the client flow to the backend flow cleanly.
6. Replacing in-memory save behavior with safe PostgreSQL-backed persistence when ready.
7. Preparing a repeatable demo run.
