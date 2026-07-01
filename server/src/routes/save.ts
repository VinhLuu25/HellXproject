import { FastifyInstance } from "fastify";
import { saveStateSchema } from "../schemas/save.js";
import { InMemorySaveStore } from "../services/saveStore.js";

export async function saveRoutes(app: FastifyInstance) {
  const saveStore = new InMemorySaveStore();

  app.get("/save/current", async () => {
    return saveStore.getCurrent();
  });

  app.put("/save/current", async (request, reply) => {
    const parsed = saveStateSchema.safeParse(request.body);

    if (!parsed.success) {
      return reply.code(400).send({
        error: "invalid_save_state"
      });
    }

    return saveStore.write(parsed.data);
  });

  app.delete("/save/current", async () => {
    const currentSave = saveStore.reset();
    return {
      status: "reset",
      save: currentSave
    };
  });
}
