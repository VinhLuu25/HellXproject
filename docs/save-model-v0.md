# Save Model V0

Save model V0 defines the shape needed for the first Hell X demo loop. It is a contract draft for the backend, client, and future database work. It does not claim production persistence.

## Player Reference

Each save belongs to a player record. Day 4 uses a stable test player reference so the client and backend can agree on payload shape before real account work begins.

Fields:

- `playerId`: stable player identifier.
- `sessionId`: current test session identifier.

## Session V0

A session represents one playable run or test run. The first version supports a test session so the demo can avoid production login while still proving resume flow shape.

Fields:

- `sessionId`: stable session identifier.
- `playerId`: player reference.
- `mode`: `test` for Day 4.

## Save State V0

Fields:

- `currentChapter`: chapter identifier, starting with `chapter-01`.
- `currentRoom`: room identifier, starting with `first-room`.
- `checkpointId`: latest checkpoint, clue, puzzle, or room state marker.
- `position`: player position with `x` and `y`.
- `inventoryItems`: item identifiers held by the player.
- `collectedClues`: clue identifiers already found.
- `journalEntries`: journal entry identifiers unlocked for the player.
- `puzzleFlags`: named puzzle booleans.
- `settingsSnapshot`: lightweight player settings needed for resume.
- `deathCount`: total deaths in the current save.
- `retryCount`: retries since the current checkpoint.
- `updatedAt`: server-side update timestamp when production persistence exists.

## Demo Resume Flow

1. Create or reuse a test session.
2. Load the current save.
3. Enter the first room.
4. Collect a clue or item.
5. Write the current save after the checkpoint.
6. Reload the page or start a new session.
7. Load the same save shape and restore the known state.

## Day 4 Boundary

Day 4 defines the model and provides mock route behavior only. Real account security, database writes, migrations, and Unity integration come later.
