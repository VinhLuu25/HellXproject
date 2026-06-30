# Week 1 Plan

## Week 1 Objective

Set up the project foundation and then build toward the first thin end-to-end proof of the game loop, backend connection, and save direction. Each day should leave clear evidence and avoid expanding scope beyond the planned slice.

## Day 1: Project Foundation Only

Deliverables:

- Clean README with vision, loop, scope, stack, repository structure, Week 1 goal, and status.
- Project scope with priorities, P0/P1 features, and non-goals.
- Architecture V0.
- Project process.
- Demo script draft.
- Issue and pull request templates.

No gameplay, backend, dashboard, or Unity scene work belongs in Day 1.

## Day 2: Unity Skeleton

Deliverables:

- Review the existing Unity client structure.
- Confirm the target playable room flow.
- Identify the minimum scripts, scene objects, and UI states needed for the skeleton.
- Record evidence needs for movement, interaction, and visible state feedback.

## Day 3: Backend Skeleton

Deliverables:

- Review the existing backend structure.
- Confirm local setup commands and environment requirements.
- Define the minimum health and proof-of-concept endpoints.
- Identify the first backend tests needed for request and response behavior.

## Day 4: Save Model/API Contract

Deliverables:

- Draft the save data shape for player progress.
- Define the API contract for save and load requests.
- Note validation rules, error cases, and persistence boundaries.
- Align the contract with future Prisma and PostgreSQL work.

## Day 5: Unity-To-Backend Spike

Deliverables:

- Plan the narrowest client-to-backend call needed for the proof of concept.
- Define success and failure UI states.
- Capture the evidence needed to show the call working.
- Keep the spike focused on one clear round trip.

## Day 6: Integration Cleanup/CI Draft

Deliverables:

- Clean up integration notes from the client and backend spike.
- List the checks that should run locally.
- Draft the future CI shape without adding unstable workflows prematurely.
- Update docs with confirmed commands and known gaps.
- Add setup notes and a manual test checklist.

## Day 7: Weekly Review

Deliverables:

- Summarize completed Week 1 work.
- List open risks, decisions, and follow-up tasks.
- Review evidence captured during the week.
- Propose Week 2 priorities based on what is working.

Outputs:

- `docs/week-1-review.md`
- `docs/week-2-plan.md`
