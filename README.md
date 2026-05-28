# HellXproject

Hell X is an online 2D horror vertical slice where players log in, explore a short atmospheric chapter, solve puzzles, survive tension events, and resume progress through cloud save.

## Project Details

Hell X aims to be a real horror game first and a credible software engineering project second.

The player-facing experience focuses on atmosphere, exploration, environmental storytelling, puzzle solving, and tension pacing. The technical system demonstrates authentication, persistent cloud saves, backend-backed game state, testing, deployment, and software engineering discipline.

## Core Player Loop

1. Open the hosted WebGL game.
2. Register or log in.
3. Resume from saved checkpoint.
4. Explore rooms and collect clues.
5. Solve puzzle sequences.
6. Survive danger or tension events.
7. Unlock journal entries, lore, or cosmetics.
8. Finish the vertical slice.

## Scope

### In Scope

- Online Unity WebGL build
- 2D horror chapter
- Login / account session
- Cloud save and resume
- Persistent player data
- Puzzle state, inventory, journal, settings, deaths, and unlocks
- Backend-backed save/load system
- Basic testing, documentation, and deployment discipline


## Tech Stack

| Layer | Technology |
|---|---|
| Game Client | Unity 2D, C#, WebGL |
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
  dashboard/   # QA/Ops dashboard
  docs/        # Planning, diagrams, testing notes, evidence

Future Test
  Open hosted game
login
enter chapter
interact with clue
solve puzzle
save progress
reload
resume from checkpoint