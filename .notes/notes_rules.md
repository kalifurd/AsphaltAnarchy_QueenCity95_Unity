# Agent Rules — Asphalt Anarchy: Queen City '95

Read this file at the start of every session. It does not change often —
if you think it needs to change, flag that in posting.txt rather than
editing this file directly.

## Dev Notes

Numbered, append new ones at the bottom, don't renumber old ones.

1. **K.I.S.S. FIRST.** Before adding a new system, a new layer, a new
   abstraction — check whether the direct/simple version already does the
   job. Prefer the solution with fewer moving parts, fewer intermediary
   tools, and fewer things that can silently break between two working
   pieces. Complexity has to earn its place, not the other way around.

## The Rules

1. **Append-only in posting.txt.** Never rewrite, edit, or delete anything
   above the "APPEND NEW NOTES BELOW THIS LINE" marker. Only
   `context_extractor.py` is allowed to rewrite that file, and only during
   compaction.

2. **Tag every entry** with one of:
   - `[FLAG]` — blocked, needs a human decision. Never resolved by an
     agent on its own initiative. Carried forward verbatim forever until
     a human clears it.
   - `[DONE]` — finished work. Safe to compress into a summary later.
   - `[NOTE]` — context/fyi. Safe to compress into a summary later.

3. **Hit a problem? `[FLAG]` it, stop working, ask what to do next.**
   Do not guess. Do not work around it silently. Do not skip it and move
   on to something else without flagging it first.

4. **Check OPEN FLAGS before starting anything.** An unresolved flag from
   a prior session still applies until a human clears it — it doesn't
   expire just because a new session started.

5. **Commit before anything non-trivial.** If you're about to make a
   change bigger than a one-line fix, git commit the current state first
   so there's a checkpoint to diff against.

## Key Invariants (don't rediscover these)

- **Unity version: 6000.5.6f1** (Unity 6), not 2022.3 LTS — this was a
  deliberate choice, not an accident. `Rigidbody.velocity` is obsolete on
  this version; use `linearVelocity`. `Rigidbody.angularVelocity` is
  unaffected and still current — don't touch it if you see it.
- **Namespaces:** `AsphaltAnarchy.Core` / `.Vehicle` / `.Combat` / `.Echo`
  / `.Factions` / `.AI` — cross-namespace references need explicit
  `using` directives, this codebase has been bitten by missing ones
  before.
- **6 FactionData assets exist, not 5** — the 5 visible gangs plus a
  `PlayerFaction` reference on `FactionManager` (`playerFaction` field).
  Turf ownership checks compare against this reference, not a
  string-matched "Player" faction name.
- **Tripo3D GLB imports land at a normalized ~1-unit bounding box, not
  real-world meters.** Rescale on import (~2x for a real-world-length
  motorcycle) or physics/camera distances will be wrong.
- **GrabSystem's hijack sequence was fully rewritten** to avoid nesting
  the player's Rigidbody under an enemy bike's Rigidbody. If you're
  touching hijack/grab code, read the current implementation first, don't
  assume the old reparenting approach — it was replaced.
- **Launch Unity (with the MCP bridge running) before starting a Claude
  Code session, not after.** Starting Claude Code first means the
  UnityMCP tools never attach for that session — not even as deferred
  tools — and the only fix is closing and reopening a fresh session once
  Unity's already up. This has hit three sessions in a row; it's a
  startup-order habit now, not a bug to keep working around each time.
