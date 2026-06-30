import { FastifyInstance } from "fastify";
import { saveStateSchema } from "../schemas/save.js";
import { SaveState } from "../types/save.js";

const defaultSave: SaveState = {
  playerId: "test-player-001",
  sessionId: "test-session-001",
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

let currentSave = defaultSave;

export async function saveRoutes(app: FastifyInstance) {
  app.get("/save/current", async () => {
    return currentSave;
  });

  app.put("/save/current", async (request, reply) => {
    const parsed = saveStateSchema.safeParse(request.body);

    if (!parsed.success) {
      return reply.code(400).send({
        error: "invalid_save_state"
      });
    }

    currentSave = {
      playerId: defaultSave.playerId,
      sessionId: defaultSave.sessionId,
      ...parsed.data,
      updatedAt: defaultSave.updatedAt
    };

    return currentSave;
  });

  app.delete("/save/current", async () => {
    currentSave = defaultSave;
    return {
      status: "reset",
      save: currentSave
    };
  });
}
