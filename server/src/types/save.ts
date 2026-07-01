export type SavePosition = {
  x: number;
  y: number;
};

export type SaveState = {
  playerId: string;
  sessionId: string;
  currentChapter: string;
  currentRoom: string;
  checkpointId: string;
  position: SavePosition;
  inventoryItems: string[];
  collectedClues: string[];
  journalEntries: string[];
  puzzleFlags: string[];
  settingsSnapshot: Record<string, string | number | boolean>;
  deathCount: number;
  retryCount: number;
  updatedAt: string;
};

export type SaveStateInput = Omit<SaveState, "playerId" | "sessionId" | "updatedAt">;

export type TestSession = {
  sessionId: string;
  playerId: string;
  mode: "test";
};
