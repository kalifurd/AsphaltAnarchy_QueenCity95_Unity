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
- **7 FactionData assets exist, not 5 or 6** — 6 gangs (Rust Barons,
  OTR Syndicate, Neon Saints, Kentucky Kings, Phantoms, Highway Kin)
  plus a `PlayerFaction` reference on `FactionManager` (`playerFaction`
  field, points at PlayerCrew.asset). Turf ownership checks compare
  against this reference, not a string-matched "Player" faction name.
  (This invariant went stale once before, when Highway Kin was added as
  a real 6th gang on 2026-08-06 — worth double-checking this line is
  still accurate if another faction is ever added.)
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
- **Rival faction territory/spawn placement needs real separation, not
  just narrative rivalry.** Factions can be close rivals in lore without
  their turf nodes or spawn points sitting immediately adjacent on the
  map — nobody should be able to walk out of their own clubhouse into an
  active rival encounter. No coordinate plan exists yet for any district
  (every level design doc has placeholder/no coordinates so far), so
  this has to be an explicit check once real district coordinates get
  assigned, not something that happens to work out. Flagged first when
  Enemy_NeonSaints' spawn point turned out to sit ~15 units from the new
  Price Hill InclineHouse cluster.
- **The Tripo DCC Bridge Unity plugin has a fragile, easy-to-lose fix.**
  Its bundled websocket-sharp.dll negotiates compression by default,
  which silently breaks large file-transfer frames — the connection
  looks fully healthy (handshake succeeds, ping/pong works) but the
  actual model data never arrives. Fixed once in WebSocketSharpServer.cs
  (IgnoreExtensions=true on the service initializer, plus wiring the
  server's Log to the plugin's own log output) — but it's a local file:
  package, not git-tracked, and re-downloading a fresh copy from
  Tripo.ai silently overwrites the fix. This already happened once
  (2026-08-06) and had to be reapplied. If Tripo transfers start
  silently failing again despite showing "connected," check
  Packages/manifest.json for the current plugin path and reapply this
  fix before assuming it's a Tripo.ai service outage — full details in
  project_tripo_dcc_bridge_websocket_fix.md.
- **FactionData display names carry a "The " prefix that doesn't match
  their asset/lookup names.** PlayerCrew's actual in-game display name
  is "The Renegades"; Rust Barons reads as "The Rust Barons," Neon
  Saints as "The Neon Saints," etc. This has already caused at least
  two sessions to avoid `FactionManager.GetFactionByName()` in favor of
  pulling the reference straight off `GetAllFactions()`, since a plain
  unprefixed name won't match. Worth fixing at the root (either strip
  the prefix in the lookup or standardize on it) rather than continuing
  to route around it session after session.
- **HeatSystem auto-clears after 8 seconds with no active pursuer —
  this can race a slow test cadence and look like a false negative.**
  When testing jurisdiction-crossing triggers (or anything else reading
  heat state right after it changes), a check that runs slower than
  that 8-second window can read a value that's already auto-cleared
  back to null/0, making a trigger that actually fired correctly look
  like it didn't. Confirmed on the L&N Bridge test — a tight-cadence
  retest showed the real result was correct the whole time. Likely
  explains an inconclusive reading during the earlier Taylor-Southgate
  test too. If a heat/jurisdiction test result looks wrong, re-check
  with a faster read cadence before assuming the trigger itself failed.
User Addition- - **Vertical elevation convention:** hero terrain relief (hills, bluffs,
  anything the player visibly climbs or descends as a route — InclineCut_Stub,
  AndersonFerryRd_Stub) uses real-world meters directly as Unity units,
  uncompressed. Structural clearance (bridge decks, overpasses — anything
  sized to read as proportionate to the compressed world around it) applies
  the same 5:1 compression used for horizontal distances. This split existed
  implicitly before 2026-08-10 (Price Hill went uncompressed, Newport's 3
  bridges went compressed) without ever being decided as a rule — now a
  standing invariant, not a coincidence.