# Week 2 Plan

## Week 2 Objective

Turn the Week 1 foundation into a small, testable vertical slice path: open the client, enter the first room, move, inspect one clue, trigger one puzzle or checkpoint state, call the backend mock save path, and show a clear resume direction.

## Protected Priorities

- Keep the playable slice small.
- Make every demo claim verifiable.
- Preserve the existing daily commit history.
- Keep production login, production persistence, dashboard work, and deployment out of scope until the core slice is stable.
- Prefer one complete room loop over broad unfinished systems.

## Day 1: Client Scene Wiring

Deliverables:

- Open the Unity client in the editor.
- Verify `MainMenu.unity` and `FirstRoom.unity`.
- Wire player, interaction, status UI, local save, and backend check objects.
- Capture notes on what works and what still needs repair.

## Day 2: First Room Interaction Loop

Deliverables:

- Define one clue and one interactable object.
- Verify the player can approach and inspect the object.
- Show status feedback for the clue interaction.
- Avoid adding additional rooms or broad gameplay systems.

## Day 3: Checkpoint And Resume Shape

Deliverables:

- Connect the local checkpoint placeholder to the first-room interaction.
- Confirm the local stored state can be read back.
- Document the expected handoff to backend save.
- Avoid production cloud save.

## Day 4: Mock Backend Save Round Trip

Deliverables:

- Trigger the mock backend flow from the client.
- Show visible success and failure states.
- Confirm the server tests still pass.
- Keep the route behavior mock-only unless a later task starts persistence.

## Day 5: Evidence And Demo Pass

Deliverables:

- Capture the exact manual demo steps.
- Record what can be shown live.
- Identify missing scene wiring, UI, or server setup issues.
- Do not add video or screenshots unless explicitly requested.

## Day 6: Quality Pass

Deliverables:

- Run server build and tests.
- Run repository hygiene checks.
- Verify docs match actual behavior.
- Confirm what Unity checks were run and what was skipped.

## Day 7: Week 2 Review

Deliverables:

- Summarize what is playable.
- Summarize what is still mocked.
- List evidence captured.
- Decide whether Week 3 starts real persistence, login/session, dashboard, or demo polish.

## Small Vertical Slice Gameplay Goals

- Main menu entry.
- First room entry.
- Player movement.
- One clue interaction.
- One puzzle or checkpoint flag.
- Visible status feedback.
- Local resume direction.

## Backend/Data Goals

- Keep `/health`, `/session/test`, and `/save/current` stable.
- Keep mock route tests passing.
- Decide when to add a real database write path.
- Do not create migrations until the database plan is confirmed.

## Integration Goals

- Confirm Unity can reach the local backend.
- Show success when backend is running.
- Show recoverable failure when backend is stopped.
- Keep the integration narrow.

## Test And Demo Goals

- Server build passes.
- Server tests pass.
- Manual checklist is updated after each verified step.
- Demo script matches what was actually verified.

## Explicit Non-Goals

- Production login.
- Production cloud save.
- Real token security.
- Real database persistence unless separately scoped.
- Dashboard implementation.
- WebGL deployment.
- More rooms.
- Combat, enemies, or large gameplay systems.
