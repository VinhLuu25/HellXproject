# Week 3 Plan

## Objective

Turn the Week 2 vertical slice into a verified demo path with stronger playability, clearer save/load evidence, and the first database-backed persistence decision.

## Day By Day Plan

### Day 15: Verify Play Mode Loop

- Open `MainMenu.unity` and `Chapter01_Room01.unity` in Unity.
- Verify start, movement, clue pickup, puzzle solve, checkpoint trigger, and status text.
- Fix only wiring or collider issues found during the verification pass.

### Day 16: Improve Save Load UX

- Add a simple visible save/load test control if needed.
- Show clear success and failure states.
- Keep the test session path and avoid production auth.

### Day 17: Database Persistence Decision

- Choose in-memory continuation or PostgreSQL implementation.
- If PostgreSQL is available, add a migration and a Prisma-backed save store.
- If PostgreSQL is not available, keep the service boundary and document the blocker.

### Day 18: Resume State Restore

- Use loaded save data to restore player position, inventory items, journal entries, puzzle flags, and checkpoint id.
- Keep the restore path limited to `Chapter01_Room01`.

### Day 19: Demo Hardening

- Run backend build and tests.
- Run Prisma validation.
- Run Unity play mode checks.
- Update manual checklist with actual pass/fail results.

### Day 20: WebGL Readiness Pass

- Verify WebGL build settings.
- Produce a build only if Unity is stable and the output path is excluded from commits.
- Record any build blocker without adding build artifacts.

### Day 21: Week 3 Review

- Summarize completed, partial, skipped, and risky work.
- Update demo script and next plan.
- Keep claims limited to checks that actually ran.

## Protected Priorities

- Keep the first room playable.
- Keep save/load contracts explicit.
- Keep commits small and reviewable.
- Keep dependency output and builds out of commits.

## Gameplay Polish Goals

- Improve readable interaction range.
- Improve status messages.
- Verify puzzle and checkpoint trigger order.
- Keep the horror slice focused on one room.

## Backend And Data Goals

- Preserve validated save request and response shapes.
- Decide and implement the next persistence step.
- Keep production auth out of scope.
- Keep database work migration-driven if it starts.

## Integration Goals

- Make client save/load testing reachable without code changes.
- Align client payloads with backend validation.
- Keep recoverable failure states visible when the backend is stopped.

## Test And Demo Goals

- Record exact backend commands run.
- Record exact Unity checks run.
- Keep manual checklist current.
- Avoid claiming WebGL or database persistence until verified.

## Non Goals

- No production auth.
- No dashboard.
- No enemy system.
- No new chapter.
- No binary build output in commits.
