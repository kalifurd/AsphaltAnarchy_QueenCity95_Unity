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

## 4. SR-28, SR-32, US-50, and SR-22 — the east–west arterial set

**[R]** Four real east-west roads recur across the eastern/northeastern
districts as the game's arterial set:

- **US 50** — the old road (Milford → Day Heights → Perintown →
  Owensville), the Highway Kin's spine corridor.
- **SR 32 (Appalachian Highway)** — the four-lane bypass running
  parallel to US 50 (Eastgate → Batavia bypass → east), the fast/
  patrolled counterpart to the old road.
- **SR 28** — the Miami Township strip (Milford → Mulberry → Goshen),
  the suburbanizing second axis north of the US 50/SR 32 pair.
- **SR-22** — northeast direction. New to this doc; not yet load-bearing
  in a companion doc the way SR-28/32/50 already are in
  `LevelDesign_Milford_Batavia_1995.md`.

SR-28, SR-32, and US-50 are already confirmed and load-bearing in the
Milford/Batavia doc (its own §2/§3 corridor tables and G1-G4 gateways).
SR-22 is added here as the northeast-heading member of the set.

**Reed Hartman Highway was considered and dropped** — it runs north,
not east-west, so it doesn't belong in this arterial set. Noted here so
the same dead end isn't re-walked later.

---

## 5. Map-structure principle — Fallout-4-style anchoring

The overall map is anchored the way Fallout 4 anchors Boston: the
player's home base sits in a corner, and the world radiates outward
from it. **PlayerCrew's home base (Price Hill) sits in the bottom-left
corner of the map**, with everything else built outward from there.

This isn't just a layout convenience — it's meant to **match real
population/traffic density**, not fight it. Density and traffic
naturally increase moving away from Price Hill toward downtown and the
inner-ring districts, then thin out again toward the rural map edges
(Milford/Batavia's US 50 corridor, Hamilton/Fairfield's SR-127/SR-129
boundary). Any future district placement should check itself against
this radiating structure before assuming a location.

---

## 6. Open — northeast and southeast map edges (superseded by §7)

**Resolved 2026-08-14 — see §7 for the confirmed perimeter.** This
section is kept as a historical record of the gap; nothing below is
still open.

~~Not yet defined by real roads the way §3 defines the northwest edge.
The districts nearest those edges —
`LevelDesign_Milford_Batavia_1995.md` (northeast, Highway Kin's eastern
half) and `LevelDesign_Newport_1995.md` (southeast, across the river in
Kentucky) — do not currently have a confirmed real-road boundary line
the way Hamilton/Fairfield's northwest edge now does.~~

~~Do not invent a boundary for either side. This is flagged as open,
not guessed at, until real geography for those edges gets the same
kind of confirmation §1–§3 got here.~~

---

## 7. Map Boundary — the complete perimeter

**[R]** The full real-road boundary line for the playable map, closing
the loop this file's §6 previously left open. This is the map's edge,
not a district's gateway — it doesn't replace or override any
district doc's own gateway (G1/G2/...) tables, which describe how
districts connect to *each other*, not where the world stops. Where
this boundary and a district's gateways use different real roads to
reach the same general area (noted below), that's expected — a map
edge and a playable route are different things — and is flagged rather
than silently reconciled, same discipline as the rest of this file.

### South boundary — the Ohio River and the Kentucky bend

I-275 → **I-471 north** (bypassing Fort Thomas via the mainline) →
**Exit 4 / KY-1120 Memorial Parkway** (Newport–Bellevue) → **E 10th
St** → cross the **Licking River at 11th St** into Covington → **MLK
Jr Blvd** → dead-ends at **I-71**, plus the **Ohio River** itself as
the boundary's western stretch.

**Cross-check — `LevelDesign_Newport_1995.md`:** this route is
distinct from that doc's own G3 (US 27/I-471 south **over the Fort
Thomas hill** to I-275, the district's documented gameplay gateway)
and G2 (4th St over the Licking to Covington). The boundary line here
bypasses Fort Thomas and crosses the Licking at 11th St instead of 4th
St. **Not a contradiction** — Newport's doc already treats Covington
as off-map ("its own pass if ever needed," doc header), and this
boundary just fixes where the *playable map* stops inside/around that
off-map area; it doesn't touch Newport's own gateway routes. But
KY-1120 Memorial Parkway, E 10th St, 11th St bridge, and MLK Jr Blvd
don't appear anywhere in the Newport doc today — worth folding in if
Covington ever gets its own pass.

### West boundary — I-75 to SR-127

**I-75 north to SR-127.**

**Cross-check — this file's own §1 and §3, and
`LevelDesign_Hamilton_Fairfield_1995.md`:** §1 already calls I-75 "the
continuous north–south spine" running "the length of the game's west
side," while §3 names **SR-127** (not I-75) as the confirmed west
edge. This boundary line threading I-75 *into* SR-127 reads as
consistent with both — I-75 carries the southern/middle stretch, SR-127
takes over further north — but flagging that §1 and §3 have never been
explicitly reconciled with each other on this point until now, and
that the Hamilton/Fairfield doc's own §2 arterial table doesn't list
I-75 at all (SR-4, US-127, SR-128, SR-129, I-275 are its named
arterials; I-75 appears exactly once, in its period-accuracy note
about the future Union Centre interchange). That doc's own documented
west edge is SR-128 (the river road), not I-75 or SR-127. Not
contradictory on its face, but the three descriptions (§1, §3, and
Hamilton/Fairfield's own §2) have three different roads in mind for
"west," and none of them has been walked through against the others
before this pass.

### North boundary — Hamilton/Fairfield to I-75

**Hamilton/Fairfield's own route meeting I-75 north of I-275.**

**Cross-check — `LevelDesign_Hamilton_Fairfield_1995.md`:** no road in
that doc's own §2 arterial table is documented as reaching I-75 — its
northward roads are SR-4 (G4, fading toward LeSourdsville/Middletown,
explicitly "soft fade, not a wall") and SR-129 (§2, "east out of
Hamilton toward Liberty Twp," which that doc frames as an *eastern*
rural fade, not a northern one). This file's own §3 already flagged
that exact framing mismatch — SR-129 as "north edge" here vs.
"eastern rural fade" in Hamilton/Fairfield's own text — as an open
note, not a contradiction, back when it was first written. This new
boundary line most likely intends SR-129, but doesn't name it, so
that pre-existing ambiguity is inherited here rather than resolved.
Flagging, not guessing.

### NE corner — capped at the I-275 loop

The northeast corner is deliberately **capped at the I-275 loop**,
for two real-world reasons kept out of the game rather than worked
around: the land-use pattern beyond the loop gets complicated fast,
and **Kings Island** sits out there as trademarked IP — both avoided
by simply not extending the map that far.

The corner is anchored at **Blue Ash**, using its real 1995 identity:
a municipal airport plus a corporate-office-hub character, not the
tech/business-park Blue Ash of later decades.

**Standing rule for every real airport in-bounds** — Blue Ash, Lunken
(East End), and Clermont County Airport (Milford/Batavia, the airport
itself only, **not** the Tri-State Warbird Museum, which is a real
museum but a 2004 arrival and therefore an anachronism for this map):
all three are **roamable, no flight mechanic, no building interiors.**

**Cross-check — `LevelDesign_EastEnd_1995.md`:** Lunken Airport is
already documented there (§3d, §4) as a roamable perimeter with small
aircraft as ambient flavor, not a mission site — consistent with the
no-flight-mechanic rule stated here, though that doc doesn't spell the
rule out explicitly; this section is now the canonical place that
does. **Cross-check — `LevelDesign_Milford_Batavia_1995.md`:** Clermont
County Airport is already documented there (§4) as a small rural
airfield, hangars and wind sock, with an invented [F] tenant running
one hangar — no Tri-State Warbird Museum reference exists in that doc
already, so no fix needed there, just confirming the exclusion holds.
Blue Ash itself doesn't appear in any companion doc yet — genuinely
new ground, not a conflict.

### East boundary — the Milford/Batavia loop closure

**SR-132 runs Goshen → Owensville → Batavia**, but cuts straight
through Owensville's downtown — the boundary **bypasses Owensville's
center** via **SR-132 → US-50 → Benton Rd → back to SR-132** (which
continues to Batavia/SR-32).

Benton Rd's far end connects near **Stonelick-Williams Corner Rd** —
the same real **Stonelick Covered Bridge** already documented in the
Milford/Batavia doc. The loop closes two ways: **Benton Rd junction →
US-50/SR-222 → Batavia**, or **→ SR-132/SR-131 → Miami Township →
Milford proper.**

**Mt. Zion Rd** (near Benton Rd's bottom, connecting to **Dry Run
Rd**) is included as period-accurate for 1995 — it predates the game's
era via its 19th-century cemetery/church origin, even without an exact
paved/unpaved record for that stretch.

Real terrain along Benton Rd — a creek running alongside it and a
steep hill at its end — is flagged as a **high-Heat evasion route**:
real risk/reward terrain, not a free escape.

**Skip the Loveland and Branch Hill I-275 exits** — the boundary
doesn't route through either interchange.

**Cross-check — `LevelDesign_Milford_Batavia_1995.md`:** SR-132,
SR-131, SR-222, and Stonelick Williams Corner Rd are all already
documented there (§2 arterials/secondary roads), and the doc's SR-132
entry ("north–south: Owensville ⇄ Batavia ⇄ south") is consistent with
— if less specific than — this boundary's Goshen extension; not a
contradiction, just an extension worth folding into that doc's own §2
on its next pass. **Benton Rd, Mt. Zion Rd, and Dry Run Rd don't
appear in the Milford/Batavia doc at all** — new roads, not yet
cross-referenced there; flagging for the same future pass, not a
conflict as written today. **On Branch Hill specifically:** that doc's
own §4 already lists "Miamiville & Branch Hill" as a P3 roamable
location ("tiny river hamlets up the Little Miami valley toward
Loveland, strung along the rail-trail," §4, and referenced again in
chase route 9, §5) — this boundary skipping the *I-275 exit* named
for Branch Hill doesn't remove the town itself from the map, it just
means the map edge isn't reached by that interchange. Worth confirming
that's the intended reading (interior road, not the I-275 off-ramp)
since the two statements could otherwise look like they disagree.

---

## 8. Change log

- **2026-08-09:** File created. Documents the I-75 spine, the Norwood
  Lateral handoff to I-71 (used to fix Downtown/OTR's G4 — see
  `LevelDesign_Downtown_OTR_1995.md` and `LevelDesign_Norwood_1995.md`
  G1's matching text), and the SR-127/SR-129 northwest boundary. NE/SE
  edges explicitly left open.
- **2026-08-10:** Added the SR-28/SR-32/US-50/SR-22 east-west arterial
  set (SR-22 new; the other three already load-bearing in
  `LevelDesign_Milford_Batavia_1995.md`) and the Fallout-4-style
  map-structure principle (Price Hill anchored bottom-left, world
  radiating outward to match real density). Reed Hartman Highway
  considered and dropped — runs north, not east-west.
- **2026-08-14:** Added §7, the complete map-boundary perimeter
  (south: I-275/I-471/Newport-Bellevue/Covington/Ohio River; west:
  I-75 to SR-127; north: Hamilton/Fairfield to I-75; NE corner: capped
  at the I-275 loop, anchored at Blue Ash, standing airport rule for
  Blue Ash/Lunken/Clermont County Airport; east: the Milford/Batavia
  loop closure via Benton Rd/Mt. Zion Rd, bypassing Owensville's
  center and the Loveland/Branch Hill I-275 exits) — closes the §6 gap
  this file left open on 2026-08-09. §6 kept as a struck-through
  historical record rather than deleted. Cross-checked against
  `LevelDesign_Newport_1995.md`, `LevelDesign_Hamilton_Fairfield_1995.md`,
  `LevelDesign_Milford_Batavia_1995.md`, and `LevelDesign_EastEnd_1995.md`;
  no hard contradictions found, but several not-yet-cross-referenced
  roads and one inherited ambiguity (SR-129's "north edge" vs. "eastern
  fade" framing, first flagged in §3) are called out inline in §7
  rather than silently resolved.
