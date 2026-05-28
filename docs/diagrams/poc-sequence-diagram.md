# Proof-of-Concept Sequence Diagram

## PoC Flow

```txt
Player
  |
  | clicks/interacts with object
  v
Unity Client
  |
  | POST /poc/save or GET /health
  v
Backend API
  |
  | validate request
  v
Backend API
  |
  | return success
  v
Unity Client
  |
  | show "Synced"
  v
Player