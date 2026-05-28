# Project Log

This log records our progress, decisions, blockers, and evidence for Hell X.

## Day 1: Milestone 1 Foundation

### Work Done

- Cloned GitHub repository locally
- Started restructuring README for Milestone 1 requirements
- Added Milestone 1 objectives, proof-of-concept target, software engineering evidence, challenges, and next milestone plan
- Planned GitHub Issues, Labels, and Milestones
- Created documentation placeholders for diagrams, testing plan, and evidence checklist

### Decisions

- Milestone 1 will prioritize a small but working technical proof-of-concept
- The minimum PoC will connect Unity client to backend and show a successful sync response
- Product work and evidence work will be tracked in parallel

### Blockers

- Unity and backend PoC are not implemented yet
- Poster and video evidence depend on PoC screenshot/footage

### Next Steps

- Create GitHub Milestone 1
- Create labels and issues
- Set up Unity PoC skeleton
- Set up backend API skeleton

## Day 2: Unity PoC Skeleton

### Work Done

- Created Unity 2D project under `client/`
- Created initial PoC scene
- Added player object
- Added basic player movement
- Added interactable sync object
- Added UI status text
- Added placeholder interaction flow

### Evidence

- Unity scene opens successfully
- Player can move
- Player can interact with sync object
- UI updates when interaction happens
- Screenshot saved in `docs/evidence/day-2-unity-poc-skeleton.png`

### Decisions

- Day 2 focuses only on Unity-side PoC skeleton
- Backend sync will be implemented on Day 3 and integrated on Day 4

### Blockers

- Backend API is not implemented yet
- Real save/sync is not connected yet

### Next Steps

- Create backend API skeleton
- Add `/health` endpoint
- Add `/poc/save` mock endpoint
- Connect Unity to backend in Day 4