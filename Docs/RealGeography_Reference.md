# REAL GEOGRAPHY — CROSS-DISTRICT REFERENCE
**Asphalt Anarchy: Queen City '95 — backbone roads and map-edge boundaries**
**Status: reference note, not a level design doc. No locations, no factions, no P1/P2/P3 lists — just the real roads that keep recurring across companion docs, written down once instead of re-derived from chat history every time a new district touches them.**

---

## Why this file exists

Several companion docs already reference the same real backbone roads
independently (I-75, the Norwood Lateral, I-71, SR 129/US 127) and have
occasionally gotten a detail wrong doing it from memory alone — see the
Downtown/OTR doc's G4 fix (2026-08-09), which had routed through a real
but unrelated Clifton/I-74 interchange before being corrected. This
file is the confirmed backbone, kept short, for any future doc to check
against before inventing or re-deriving a route.

Same tagging convention as every companion doc: **[R]** real
road/place, name kept as-is.

---

## 1. I-75 — the continuous north–south spine

**[R]** I-75 runs the length of the game's west side as one continuous
real corridor, not a series of unrelated district-local highways:

- **South end:** Queensgate/Downtown, running along the Mill Creek
  valley's western flank (`LevelDesign_Queensgate_1995.md` §2; its own
  G2 already claims the "I-75 corridor north to Northside/Clifton"
  arrow).
- **Middle:** continues north through the Norwood Lateral interchange
  area (see §2 below) — this is where a district needing to reach
  Norwood, Avondale, or Uptown hands off east onto SR-562, not where
  it continues straight north.
- **North end:** straight run further north into the already-documented
  Hamilton/Fairfield district (`LevelDesign_Hamilton_Fairfield_1995.md`).

**Do not confuse this spine with the real Clifton/Mt. Storm Park
I-74/I-75 interchange.** That interchange is real and does exist, but
it heads *west* out of the I-75 corridor (toward Indiana via I-74) and
has no relationship to the Avondale/Uptown/Norwood route below — a
mistake already made once and corrected in the Downtown/OTR doc's G4.

---

## 2. The Norwood Lateral (SR-562) — the real east–west branch

**[R]** The Norwood Lateral is the real east-west connector off the
I-75 spine, already the spine feature of `LevelDesign_Norwood_1995.md`
(its own G1/G2 gateways). Confirmed real route for reaching
Avondale/Uptown from the south:

**I-75 north → Norwood Lateral (SR-562) east → I-71 north → Avondale
/ Uptown.**

This is the corridor the Downtown/OTR doc's G4 now describes (corrected
2026-08-09) and the same arrow Norwood's own G1 ("Norwood Lateral east
→ I-71, South to Downtown/OTR and Uptown") already receives from the
opposite direction. Any future district gateway that needs to reach
Avondale, Uptown, or Norwood itself from the south should route through
here, not through a direct I-71 connection off Downtown/OTR (no such
direct real connection is used by any doc) and not through the
Clifton/I-74 interchange (§1).

---

## 3. SR-127 and SR-129 — the northwest map-boundary lines

**[R]** These two real state routes are the confirmed edge of the
game's map on the northwest side:

- **SR-127** — the west edge, running the Fairfield/Lindenwald/Mt.
  Healthy corridor. (Note: `LevelDesign_Hamilton_Fairfield_1995.md`
  currently refers to this same real corridor as "US 127 / Pleasant
  Avenue" — same road, doc uses the US-route name rather than the
  state-route name; not a contradiction, just a naming variant worth
  knowing if the two need to be reconciled later.)
- **SR-129** — the north edge, running the Hamilton/Princeton/Bethany
  corridor. (Note: `LevelDesign_Hamilton_Fairfield_1995.md` currently
  describes its own SR 129 reference as an "eastern rural fade" toward
  Liberty Township, a different emphasis than "north edge" — likely
  the same real route doing double duty on two sides of Hamilton, not
  a contradiction, but flagging the difference in framing rather than
  silently reconciling it.)

**Beckett Ridge and Union Centre — already correctly placed.**
Hamilton/Fairfield's own doc already notes Beckett Ridge exists in
1995 (a golf community) but Union Centre's I-75 interchange/office boom
doesn't arrive until the late '90s. Both sit south of the SR-127/SR-129
boundary line described here, so **nothing already built in that doc
needs to move** — this reference just confirms the boundary those
locations already sit inside.

---

## 4. Open — northeast and southeast map edges

**Not yet defined by real roads the way §3 defines the northwest edge.**
The districts nearest those edges —
`LevelDesign_Milford_Batavia_1995.md` (northeast, Highway Kin's eastern
half) and `LevelDesign_Newport_1995.md` (southeast, across the river in
Kentucky) — do not currently have a confirmed real-road boundary line
the way Hamilton/Fairfield's northwest edge now does.

**Do not invent a boundary for either side.** This is flagged as open,
not guessed at, until real geography for those edges gets the same
kind of confirmation §1–§3 got here.

---

## 5. Change log

- **2026-08-09:** File created. Documents the I-75 spine, the Norwood
  Lateral handoff to I-71 (used to fix Downtown/OTR's G4 — see
  `LevelDesign_Downtown_OTR_1995.md` and `LevelDesign_Norwood_1995.md`
  G1's matching text), and the SR-127/SR-129 northwest boundary. NE/SE
  edges explicitly left open.
