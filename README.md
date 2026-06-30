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

## Week 1 Goal

Week 1 should turn the repository into a clear project foundation before adding new product work. The week starts with scope, process, architecture, and demo planning, then moves through the Unity skeleton, backend skeleton, save model/API contract, client-to-backend spike, integration cleanup, and weekly review.

## Current Status

- Branch: `week-1/foundation`.
- Day 1 foundation files are being aligned with the Week 1 roadmap.
- Existing Unity proof-of-concept work and backend skeleton work remain in place.
- No gameplay, backend, dashboard, or Unity scene changes are part of Day 1.

## Supporting Docs

- [Project scope](docs/project-scope.md)
- [Week 1 plan](docs/week-1-plan.md)
- [Architecture V0](docs/architecture-v0.md)
- [Project process](docs/process.md)
- [Demo script draft](docs/demo-script-draft.md)
- [Testing plan](docs/testing-plan.md)
- [Project log](docs/project-log.md)
