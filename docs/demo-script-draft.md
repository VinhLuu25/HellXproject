# Demo Script Draft

## Demo Goal

Show the Week 2 playable slice path for Hell X: main menu, first room, movement, clue pickup, simple puzzle state, checkpoint payload, backend save/load contract, and the next path toward verified resume.

## Demo Flow

1. Start at the project README and point to the Week 2 plan.
2. Open `Assets/Scenes/MainMenu.unity` and start the test session.
3. Move the player through `Assets/Scenes/Chapter01_Room01.unity`.
4. Interact with `PuzzleObject` before collecting the clue and show the blocked status.
5. Collect `ClueObject` and show the clue status.
6. Return to `PuzzleObject` and show the solved status.
7. Move into `CheckpointObject` and show the saved checkpoint status if scene wiring is verified.
8. With the backend running, trigger the save/load check and show `Save synced: first-room / manual-save` if scene wiring is verified.
9. Stop the backend and show the recoverable failure status if time allows.
10. Show the save model and API contract docs.
11. Close with `docs/week-2-review.md` and `docs/week-3-plan.md`.

## Local Mock API Beat

For the Week 2 technical demo, run the backend locally and trigger the Unity-side backend check from the first room after scene wiring is verified. The evaluator should see either `Save synced: first-room / manual-save` or a clear failure state if the backend is stopped.

## What Evaluator Should Notice

- The project has a clear horror-game vision and limited first slice.
- The repository explains scope, process, architecture, and Week 1 priorities.
- The Unity client is the player-facing layer.
- The backend is the boundary for persistent player state.
- The save/resume path is planned before it grows.
- Current evidence is strongest on repository structure, Unity scene builder output, server tests, contract docs, and client save/load scripts.
- Unity play mode and WebGL build verification still need a manual editor pass.
