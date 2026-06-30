import { FastifyInstance } from "fastify";
import { TestSession } from "../types/save.js";

const testSession: TestSession = {
  sessionId: "test-session-001",
  playerId: "test-player-001",
  mode: "test"
};

export async function sessionRoutes(app: FastifyInstance) {
  app.post("/session/test", async () => {
    return testSession;
  });
}
