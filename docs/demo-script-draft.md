# Demo Script Draft

## Demo Goal

Show the Week 1 foundation for Hell X: project structure, client skeleton, backend skeleton, save contract, mock backend flow, and the next path toward a playable first-room demo.

## Demo Flow

1. Start at the project README and point to the Week 1 foundation docs.
2. Show the client skeleton structure under `client/`.
3. Show the server skeleton and mock route tests under `server/`.
4. Show the save model and API contract docs.
5. Run or reference the server check commands from setup docs if doing a live technical pass.
6. Show the planned Unity mock flow from `client/README.md`.
7. Close with the Week 1 review and Week 2 plan.

## Local Mock API Beat

For the Week 1 technical demo, run the backend locally and trigger the Unity-side backend check from the first room after scene wiring is verified. The evaluator should see either `Backend ready: first-room / intro` or a clear failure state if the backend is stopped.

## What Evaluator Should Notice

- The project has a clear horror-game vision and limited first slice.
- The repository explains scope, process, architecture, and Week 1 priorities.
- The Unity client is the player-facing layer.
- The backend is the boundary for persistent player state.
- The save/resume path is planned before it grows.
- Current evidence is strongest on repository structure, server tests, contract docs, and mock integration scripts.
- Unity scene wiring and WebGL build verification still need a manual editor pass.
