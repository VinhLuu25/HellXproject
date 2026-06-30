import { z } from "zod";

export const saveStateSchema = z.object({
  currentChapter: z.string().min(1),
  currentRoom: z.string().min(1),
  checkpointId: z.string().min(1),
  position: z.object({
    x: z.number(),
    y: z.number()
  }),
  inventoryItems: z.array(z.string()),
  collectedClues: z.array(z.string()),
  journalEntries: z.array(z.string()),
  puzzleFlags: z.record(z.string(), z.boolean()),
  settingsSnapshot: z.record(z.string(), z.union([z.string(), z.number(), z.boolean()])),
  deathCount: z.number().int().min(0),
  retryCount: z.number().int().min(0)
});

export type SaveStateInput = z.infer<typeof saveStateSchema>;
