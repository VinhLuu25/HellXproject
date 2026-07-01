import assert from "node:assert/strict";
import test from "node:test";
import { buildApp } from "../src/app.js";

test("POST /session/test returns a test session", async () => {
  const app = await buildApp();

  try {
    const response = await app.inject({
      method: "POST",
      url: "/session/test"
    });

    const body = response.json();

    assert.equal(response.statusCode, 200);
    assert.equal(body.sessionId, "test-session-001");
    assert.equal(body.playerId, "test-player-001");
    assert.equal(body.mode, "test");
  } finally {
    await app.close();
  }
});

test("GET /save/current returns the current save", async () => {
  const app = await buildApp();

  try {
    const response = await app.inject({
      method: "GET",
      url: "/save/current"
    });

    const body = response.json();

    assert.equal(response.statusCode, 200);
    assert.equal(body.currentChapter, "chapter-01");
    assert.equal(body.currentRoom, "first-room");
    assert.equal(body.checkpointId, "intro");
  } finally {
    await app.close();
  }
});

test("PUT /save/current writes a mock save", async () => {
  const app = await buildApp();

  try {
    const response = await app.inject({
      method: "PUT",
      url: "/save/current",
      payload: {
        currentChapter: "chapter-01",
        currentRoom: "first-room",
        checkpointId: "clue-found",
        position: {
          x: 2,
          y: -1
        },
        inventoryItems: ["rusted-key"],
        collectedClues: ["wall-note"],
        journalEntries: ["entry-001"],
        puzzleFlags: {
          fuseBoxOpened: true
        },
        settingsSnapshot: {
          volume: 0.8
        },
        deathCount: 0,
        retryCount: 1
      }
    });

    const body = response.json();

    assert.equal(response.statusCode, 200);
    assert.equal(body.checkpointId, "clue-found");
    assert.deepEqual(body.inventoryItems, ["rusted-key"]);
    assert.equal(body.puzzleFlags.fuseBoxOpened, true);
    assert.equal(body.playerId, "test-player-001");
    assert.equal(body.sessionId, "test-session-001");
    assert.match(body.updatedAt, /^\d{4}-\d{2}-\d{2}T/);

    const loadResponse = await app.inject({
      method: "GET",
      url: "/save/current"
    });

    const loadBody = loadResponse.json();

    assert.equal(loadResponse.statusCode, 200);
    assert.equal(loadBody.checkpointId, "clue-found");
    assert.deepEqual(loadBody.journalEntries, ["entry-001"]);
  } finally {
    await app.close();
  }
});

test("PUT /save/current rejects invalid save state", async () => {
  const app = await buildApp();

  try {
    const response = await app.inject({
      method: "PUT",
      url: "/save/current",
      payload: {
        currentChapter: "",
        currentRoom: "first-room"
      }
    });

    const body = response.json();

    assert.equal(response.statusCode, 400);
    assert.equal(body.error, "invalid_save_state");
  } finally {
    await app.close();
  }
});

test("DELETE /save/current resets the mock save", async () => {
  const app = await buildApp();

  try {
    const response = await app.inject({
      method: "DELETE",
      url: "/save/current"
    });

    const body = response.json();

    assert.equal(response.statusCode, 200);
    assert.equal(body.status, "reset");
    assert.equal(body.save.checkpointId, "intro");
  } finally {
    await app.close();
  }
});
