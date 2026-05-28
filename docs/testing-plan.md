# Testing Plan

## Unit Testing

Unit tests focus on small isolated logic.

Planned examples:

- Backend request validation
- Backend auth/session logic
- Backend save/load logic
- Pure gameplay logic where applicable

## Integration Testing

Integration tests check whether components work together.

Planned examples:

- Backend API + PostgreSQL
- Unity client calling backend `/health`
- Unity client calling backend `/poc/save`
- Save/load data flow between client and backend

## System Testing

System tests validate the full user flow.

Planned Milestone 1 system test:

```txt
Open Unity scene
move player
interact with object
Unity calls backend
backend returns success
Unity shows "Synced"