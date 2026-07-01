# Hell X

Hell X is an online 2D horror vertical slice. The project combines a Unity 2D WebGL game client with a backend API, persistent player data, cloud save, project documentation, and milestone evidence.

## Project Vision

Hell X should feel like a real horror game first: tense, readable, and focused on atmosphere. The engineering goal is to prove that a small playable slice can support account/session flow, save/resume behavior, backend-backed state, and a clear review process.

## Core Player Loop

1. Open the hosted WebGL build.
2. Register or log in.
3. Resume from a saved checkpoint.
4. Explore rooms and collect clues.
5. Solve puzzle sequences.
6. Survive danger or tension events.
7. Unlock journal entries, lore, or cosmetics.
8. Finish the vertical slice.

## Scope

- Unity 2D WebGL client.
- Short 2D horror chapter.
- Login and account session flow.
- Cloud save and resume flow.
- Persistent player data.
- Puzzle state, inventory, journal, settings, deaths, and unlocks.
- Backend-backed save/load system.
- PostgreSQL data storage managed through Prisma.
- React QA/Ops dashboard planning.
- Tests, documentation, diagrams, project log, and milestone evidence.

## Out Of Scope

- Blockchain features.
- NFT features.
- Wallet login.
- Smart contracts.
- Marketplace systems.
- Tokenomics.

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
  .github/     # Issue and pull request templates
  dashboard/   # Planned QA/Ops dashboard
```

## Week 2 Goal

Week 2 turns the foundation into a first playable room slice: main menu, first room, player movement, clue pickup, inventory and journal state, simple puzzle state, checkpoint payload, backend save/load route, client save/load flow, and review docs.

## Local Setup

Read [setup notes](docs/setup.md) before running the project locally.

Server checks:

```bash
cd server
npm install
npm run build
npm test
```

Client setup starts in `client/README.md`. Unity `6000.3.11f1` or a compatible editor is expected for opening the client project.

## Current Status

- Week 1 foundation is in place.
- Week 2 playable room loop scripts and scene targets are in place.
- Backend save write/load/reset is validated and backed by in-memory test-session state.
- Unity scene builder completed for the Week 2 scene targets after the Day 10 retry failed.
- Manual Unity play mode, WebGL build output, production login, production persistence, dashboard work, and deployment are not complete.

## Supporting Docs

- [Project scope](docs/project-scope.md)
- [Week 1 plan](docs/week-1-plan.md)
- [Architecture V0](docs/architecture-v0.md)
- [Project process](docs/process.md)
- [Setup notes](docs/setup.md)
- [Manual test checklist](docs/manual-test-checklist.md)
- [Demo script draft](docs/demo-script-draft.md)
- [Week 1 review](docs/week-1-review.md)
- [Week 2 plan](docs/week-2-plan.md)
- [Week 2 review](docs/week-2-review.md)
- [Week 3 plan](docs/week-3-plan.md)
- [Testing plan](docs/testing-plan.md)
- [Project log](docs/project-log.md)
