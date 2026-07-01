import { SaveState, SaveStateInput } from "../types/save.js";

const testPlayerId = "test-player-001";
const testSessionId = "test-session-001";

export function createDefaultSave(): SaveState {
  return {
    playerId: testPlayerId,
    sessionId: testSessionId,
    currentChapter: "chapter-01",
    currentRoom: "first-room",
    checkpointId: "intro",
    position: {
      x: 0,
      y: 0
    },
    inventoryItems: [],
    collectedClues: [],
    journalEntries: [],
    puzzleFlags: {},
    settingsSnapshot: {},
    deathCount: 0,
    retryCount: 0,
    updatedAt: "2026-01-01T00:00:00.000Z"
  };
}

export class InMemorySaveStore {
  private currentSave: SaveState = createDefaultSave();

  getCurrent() {
    return this.currentSave;
  }

  write(input: SaveStateInput) {
    this.currentSave = {
      playerId: testPlayerId,
      sessionId: testSessionId,
      ...input,
      updatedAt: new Date().toISOString()
    };

    return this.currentSave;
  }

  reset() {
    this.currentSave = createDefaultSave();
    return this.currentSave;
  }
}
