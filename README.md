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
- Poster and video evidence for Milestone 1

### Out of Scope

- Multiple full chapters before the vertical slice is playable
- Overly complex enemy AI before the proof-of-concept works
- Features that delay the Milestone 1 technical proof-of-concept

## Tech Stack

| Layer       | Technology                   |
| ----------- | ---------------------------- |
| Game Client | Unity 2D, C#, WebGL          |
| Backend API | Node.js, TypeScript, Fastify |
| Database    | PostgreSQL                   |
| ORM         | Prisma                       |
| Dashboard   | React                        |
| CI/CD       | GitHub Actions               |

## Repository Structure

```txt
HellXproject/
  client/      # Unity game client
  server/      # Backend API
  dashboard/   # QA/Ops dashboard
  docs/        # Planning, diagrams, testing notes, and evidence
```

## Milestone 1 Objectives

Milestone 1 focuses on proving that Hell X is feasible as both a playable game and a software engineering system.

By the end of Milestone 1, the project should have:

- A public or shareable GitHub repository
- A README that transfers the proposal into the repository
- A regularly updated project log
- A technical proof-of-concept that runs locally
- A poster update with proof-of-concept screenshot
- A short video demo with product footage
- GitHub Issues, Milestones, and Labels for tracking work
- Initial architecture, use case, and sequence diagram drafts
- A testing plan covering unit, integration, and system testing

## Current Milestone Progress

### Completed

- GitHub repository created
- Repository cloned locally
- README structure updated for Milestone 1
- Project scope and proof-of-concept target defined
- Initial software engineering evidence plan drafted
- Unity proof-of-concept skeleton started
- Player movement placeholder implemented
- Interactable object placeholder implemented
- UI status text placeholder implemented

### In Progress

- Unity proof-of-concept skeleton
- Player movement placeholder
- Interactable object placeholder
- UI status text placeholder
- Project log updates
- GitHub Issues, Labels, and Milestones

### Next Immediate Tasks

- Set up backend API proof-of-concept skeleton
- Add `/health` and `/poc/save` endpoints
- Connect Unity client to backend endpoint
- Capture final proof-of-concept screenshot and video footage
- Update poster with proof-of-concept evidence

## Technical Proof of Concept

The minimum technical proof-of-concept for Milestone 1 is:

```txt
Open Unity scene
- Player moves
- Player interacts with an object
- Unity calls backend /health or /poc/save
- Backend returns success
- Unity UI shows "Synced"
```

This proof-of-concept demonstrates that the game client and backend can communicate successfully.

## Software Engineering Evidence

The project will show software engineering evidence through:

- GitHub Issues for task tracking
- GitHub Milestones for grouping work by project phase
- GitHub Labels for categorizing issues and pull requests
- Pull requests for reviewable changes
- Project log updates
- Architecture diagram
- Use case diagram
- Proof-of-concept sequence diagram
- Testing plan
- Git tag for Milestone 1 snapshot

## Testing Plan Summary

### Unit Testing

Planned unit tests include:

- Backend request validation
- Backend save/load logic
- Backend auth/session logic
- Pure gameplay logic where applicable

### Integration Testing

Planned integration tests include:

- Backend API with PostgreSQL
- Unity client calling backend `/health`
- Unity client calling backend `/poc/save`
- Save/load data flow between client and backend

### System Testing

Planned system test flow:

```txt
Open game
- login or mock login
- enter chapter
- interact with object
- save/sync progress
- reload
- resume from saved state
```

## Phase 1 Plan

### README + GitHub Process Foundation

- Update README with Milestone 1 sections
- Create GitHub Milestone 1
- Create labels and issues
- Create project log
- Create diagram placeholders
- Create evidence checklist

### Unity PoC Skeleton

- Create Unity project
- Create first scene
- Add basic player movement
- Add interactable object placeholder
- Add simple UI status text

### Backend/API PoC Skeleton

- Initialize TypeScript backend
- Add Fastify server
- Add `/health` endpoint
- Add `/poc/save` mock endpoint
- Prepare `.env.example`

### Unity to Backend Integration Spike

- Unity sends request to backend
- Backend returns success
- Unity displays `"Synced"`
- Add basic error handling

### Screenshot, Video, and Poster Evidence

- Capture proof-of-concept screenshot
- Record short demo footage
- Update poster with screenshot
- Draft video script

### Testing Plan + Diagrams + Project Log Cleanup

- Update testing plan
- Update architecture diagram
- Update use case diagram
- Update sequence diagram
- Clean project log

### Milestone 1 Packaging

- Final README cleanup
- Final poster update
- Final video demo
- Ensure repository is public or shareable
- Create Git tag `v0.1-m1`

## Challenges Faced

Current challenges include:

- Short timeline before Milestone 1 deadline
- Need to build both product and evidence in parallel
- Need to keep the technical proof-of-concept small enough to finish quickly
- Need to avoid scope creep before the first working demo
- Need to coordinate Unity, backend, documentation, poster, and video work together

## Next Milestone Plan

After Milestone 1, the project will focus on:

- Core gameplay loop
- Real save/load system with persistent database storage
- Puzzle state and inventory
- Journal and lore progression
- Improved horror atmosphere
- More complete testing
- Cleaner architecture and documentation
- Better poster and video polish

## Git Tagging

At the end of Milestone 1, the repository will be tagged with:

```bash
git tag -a v0.1-m1 -m "Milestone 1 technical proof of concept"
git push origin v0.1-m1
```

## Current Status

Milestone 1 foundation and Unity proof-of-concept skeleton are in progress.
