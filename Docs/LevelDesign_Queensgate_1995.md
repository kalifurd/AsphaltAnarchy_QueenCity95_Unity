# QUEENSGATE — LEVEL DESIGN REFERENCE
**Asphalt Anarchy: Queen City '95 — Rust Barons MC territory**
**Setting: Queensgate / lower Mill Creek valley, Cincinnati, 1995. Status: design reference, not yet built.**
**Companion docs:** `LevelDesign_PriceHill_Delhi_1995.md`, `LevelDesign_Milford_Batavia_1995.md`, `LevelDesign_Hamilton_Fairfield_1995.md`, `LevelDesign_Newport_1995.md` (same conventions).
**Faction canon (RustBarons.asset):** primary territory Queensgate, secondary West End; "industrial scrappers running Queensgate's rail yards and scrapyards"; combat style is full-throttle ramming with heavy chains, no subtlety. But read the whole stat block, not just the aesthetic: aggression is very high (0.9) while coordination is low (0.3), defensiveness is low (0.2), and `startingManpower` is only **3** — the smallest roster of any gang in the game. Fear response at high Echo is "frozen with fear — stalling out mid-charge." This is not a large, disciplined army holding a fortress. It's a handful of desperate, reckless locals who fight hard and fast because they have nothing else to fight *with* — and who break when the pressure is real. This doc is built around that reading, not the ramming aesthetic alone.

---

## 0. How to read this document

- **[R]** — real place/street, real name, use as-is (civic landmarks, streets, rail infrastructure).
- **[R\*]** — real place, name lightly fictionalized (private businesses we attach club/story activity to — we don't hang crime stories on real family businesses).
- **[F]** — fictional, anchored to real building stock plausible for a 1995 rail/industrial yard.
- Geography compressed ~5:1, same as every companion doc. Keep topology exact, scale distances freely.
- **TurfNode_QueensgateYard already exists** (position -60,0,60; `nodeName` "Queensgate Yard"; `captureType` CombatGauntlet; `hasSafehouse` **true**; `startingFaction` currently **unassigned/neutral** in the live scene despite the canon fit — same open item as the original-4-nodes gap noted in `project_turf_heat_wiring`). This doc maps onto that node — it does **not** propose new turf.
- **Scale note:** this is deliberately one of the smaller districts. Queensgate is a working rail/scrap bottomland, not a neighborhood — it should read as tight, hard, and functional, not sprawling. Proportional to a 3-person gang's real holdings, not to its aggression stat.

---

## 1. Orientation & district thesis

**The thesis: scrapping in the shadow of someone else's machine.** Queensgate is not really the Rust Barons' territory in the way Price Hill is the player's or Newport is the Kings'. It's a consolidated freight-rail and industrial flat in the Mill Creek valley — built, owned, and still nominally run by railroads and industrial landlords the Barons have no stake in and no leverage over. The Barons don't hold the machine. They hold the gaps in it: the fenced-off scrap corners, the dead spurs, the loading docks nobody locks well enough. Their aggression is what's left when you have no coordination, no defensible ground, and three guys.

**Real history, treated carefully:** Queensgate exists as an industrial flat because the city cleared it. Through the late 1950s into the 1960s, the dense, predominantly Black Kenyon-Barr neighborhood that stood here was demolished under urban renewal to build the rail/industrial park that became Queensgate — one of the largest displacement projects in the city's history. This is real and it is not backstory color to play for grit. It belongs in the doc's period awareness (§7), not in gameplay dressing, dialogue jokes, or "ruins" set decoration. The emptiness of Queensgate in 1995 has a specific, ugly cause, and the game should not pretend otherwise or ignore it.

**Story thread — DECIDED 2026-08-15:** the laundering thread is confirmed. The Frontage is a **Construction/Paving/Demolition Contractor front** — a real, period-accurate laundering mechanism: inflated payrolls (workers who don't exist or don't work), heavy-equipment leasing scams (paper leases on graders/dozers that generate invoices without generating work), and illicit cash mixed into legitimate-looking materials and demolition-contract billing. It ties directly to the Rust Barons' existing industrial identity — a contractor front reads as completely at home fronting a rail yard/scrapyard district, no genre mismatch — and it sits on/adjacent to the already-built rail yard, which is exactly the kind of heavy-materials, heavy-cash-flow site this scheme would want physically close by. The Barons' low coordination and low defensiveness still make sense either way: whether they know, benefit, resist, or are simply irrelevant to the contractor operation remains open (not required for the laundering mechanism itself to be canon), but the *what* is now settled. §4 and §6 updated accordingly.

| Zone | What | Character |
|------|------|-----------|
| The Yard | The working/half-working rail yard core — switching tracks, freight cars, the Barons' anchor scrapyard | Iron, diesel, and noise. TurfNode_QueensgateYard sits here. |
| Scrap Row | The Barons' own chop shops and junk lots, strung along the yard's edge | Their real economy: parts, chains, stolen bikes broken down for scrap. Poor and armed, not organized. |
| The Frontage | A cleaner, corporate-looking construction/paving/demolition contractor yard facing Gest St | Doesn't fit the rest of the district. Fences, cameras, unmarked equipment trucks, a contractor sign. The laundering thread (§1, DECIDED) lives here. |
| The West End edge | Rowhouse blocks where the flat industrial ground gives way to the neighborhood, toward the Barons' canon secondary territory | The humanizer — people actually live one block over from the yard. Kept light this pass (see below), same treatment Newport gave Covington. |

### Schematic (topology only, not to scale)

```
                (N: I-75 corridor -> Northside/Clifton, off-map)
                                    |
                          MILL CREEK / I-75 VALLEY
                                    |
   PRICE HILL (bluffs, west) ===8th St Viaduct=== THE YARD ---- rail spurs ---- (east: dead spurs, underused sidings)
        [existing PH doc G1]            |                              |
                                   SCRAP ROW                    THE FRONTAGE (Gest St)
                                   (Barons' own lots)            [flagged story hook, §6]
                                        |                              |
                              Freeman Ave / Linn St ---- Ezzard Charles Dr ---- UNION TERMINAL [R]
                                        |                              |
                              WEST END EDGE (rowhouses)         Central Pkwy ->
                              [Barons' secondary territory,      downtown / OTR
                               light touch this pass]            (off-map, future doc)
                                        |
                              River Rd east -> downtown riverfront / Waldvogel Viaduct
                              (shared corridor with the PH doc's G2, not re-owned here)
```

---

## 2. Road network

### Arterials

| Road | Tag | Runs | Role |
|------|-----|------|------|
| **Gest Street** | [R] | East–west through the yard's southern edge | The Frontage's face street — where the "clean" salvage operation (§4) would front. |
| **Ezzard Charles Drive** | [R] | East–west, past Union Terminal's rotunda at its west end | The district's one genuinely grand piece of architecture sits at the end of an otherwise working street. |
| **Freeman Avenue** | [R] | North–south, yard's western edge toward the West End | Scrap Row's spine — chop shops and junk lots front onto it. |
| **Linn Street** | [R] | North–south, parallel to Freeman | Secondary yard-edge street, quieter, more dead frontage. |
| **Central Parkway** | [R] | Runs along the district's eastern edge into downtown/Over-the-Rhine | Built over the old canal bed; Queensgate's cleanest, fastest way out toward downtown. |
| **W. 8th Street** | [R] | Continues east off the 8th Street Viaduct into the yard | Receives Price Hill's own G1 connector directly — see below, not redefined here. |
| **I-75** | [R] | North–south along the Mill Creek valley's western flank | The valley's defining infrastructure; the real "Mill Creek Expressway" corridor, locally a traffic chokepoint even in 1995. |
| **River Road** | [R] | Continues east along the riverfront toward downtown | Same road the Price Hill doc uses heading west toward Sedamsville — this is its eastern continuation, not a separate claim. |

### Gateways — how the district connects outward

| # | Gateway | Tag | Leads to | Notes |
|---|---------|-----|----------|-------|
| G1 | **W. 8th Street Viaduct** | [R] | West, back across the valley to **Price Hill** (Incline House / TurfNode_InclineHouse cluster) | **Received, not redefined** — this is the same gateway the Price Hill doc already established as its own G1 ("existing TurfNode_QueensgateYard / Rust Barons"). Queensgate's side of it is the eastern landing: exposed, no cover, first-conflict corridor between the player's home turf and the Barons'. |
| G2 | **I-75 corridor** | [R] | North to Northside/Clifton and the citywide highway network (off-map, future districts) | The district's fast, anonymous exit — trucks and through-traffic, not local knowledge. |
| G3 | **Central Parkway / Ezzard Charles Dr east** | [R] | East into the West End and downtown/Over-the-Rhine (OTR Syndicate ground, off-map — its own future doc) | Soft eastern fade. Presence implied, not built — same restraint Newport used for Covington. |
| G4 | **River Road east** | [R] | Downtown riverfront, toward the Waldvogel Viaduct/Newport bridges | Shares the same road the Price Hill doc already uses for its own G2 — this is Queensgate's frontage on it, not a re-claim of that gateway. |

---

## 3. Sub-area character sheets

### 3a. The Yard
The working core: switching tracks, strings of freight cars (live and dead), a half-collapsed rail-servicing structure the Barons have taken over. TurfNode_QueensgateYard sits here, matching its live description ("a Rust Barons scrapyard and rail depot, heavily defended"). **Tone: iron, diesel, and the sound carries — you can hear trouble here before you see it.**

### 3b. Scrap Row
Freeman Avenue's chop shops and junk lots — this is the Barons' actual economy, such as it is. Stripped bikes, cannibalized parts, chain-link and dogs. Poor, loud, and defended with whatever's on hand rather than anything planned. **Tone: three guys and a blowtorch, not a syndicate.**

### 3c. The Frontage
Gest Street's other face: a fenced, cameras-up construction/paving/demolition contractor yard — graders, a rented paver, stacked equipment on paper leases, a company sign — that looks like it belongs to a company, not a gang, because (per §1, DECIDED) it does. Doesn't fit the rest of the district's texture, and that's the point. **Tone: too clean. The kind of clean that should make a player suspicious without a word of dialogue.**

### 3d. The West End edge
Rowhouse blocks where the yard gives way to actual neighborhood — the Barons' canon secondary territory, per faction data. Kept light this pass: one anchor location (§4), not a built-out sub-district, the same restraint Newport gave Covington. A future pass could expand it if the game needs more Rust Barons ground. **Tone: one block over from the iron, people still live here.**

---

## 4. Location list

Priority tiers: **P1** must-build hero (unique model), **P2** identity (heavily-dressed kit), **P3** dressing (kit-bash).

| P | Location | Tag | Description | Gameplay |
|---|----------|-----|-------------|----------|
| P1 | **The Roundhouse** (clubhouse) | [F] | A half-collapsed rail-servicing roundhouse fragment at the yard's core, roofed enough to squat in — bikes parked on the old turntable pit, a scrap-metal fence dragged around the usable half. | Maps to **TurfNode_QueensgateYard** (§6) — its `hasSafehouse=true` is already set live in-scene, matching this doc's clubhouse role directly, no conflict. CombatGauntlet capture type already fits the Barons' ramming style. |
| P1 | **The working rail yard** | [R, generic] | Switching tracks, sidings, strings of freight cars — some live, some dead and rusting. Treat as one hero terrain system, the way the Newport doc treats its three bridges as one system. | Ties directly to the Price Hill doc's already-established "freight movements in the Queensgate yards, visible from clubhouse roof" and its State Ave crossing train — this is the natural place to actually build that shared rail system. Moving/parked freight cars as cover, hazard, and maze. |
| P1 | **Cincinnati Union Terminal** | [R] | The real Art Deco rail terminal at the west end of Ezzard Charles Drive — half-moon rotunda, the district's one unmistakable landmark, visible over the yards from almost anywhere flat enough to see it. By 1995 it's the Cincinnati Museum Center (History Museum, Natural History & Science, an OMNIMAX theater) with a small working Amtrak platform still inside — period-accurate, not a ruin. | Vista/wayfinding hero — same role the Price Hill overlooks play for the downtown skyline. **No 3D model currently exists in the project for this** (checked; flagging so nobody assumes otherwise) — it's included here as a real, confirmed-accurate landmark to build toward, same as every other unbuilt hero in the companion docs. |
| P1 | **The Frontage — [F, name still TBD, mechanism decided]** | [F] | A fenced, camera'd construction/paving/demolition contractor yard on Gest St that reads as corporate, not gang-run: chain-link with barbed top rail, a guard shack, leased heavy equipment (graders, a paver, a demo excavator) sitting suspiciously idle, unmarked box trucks on a schedule instead of junk on a lot, a contractor sign. | The laundering-front location (§1, DECIDED). Mechanism confirmed: inflated payrolls, heavy-equipment leasing scams, illicit cash mixed into materials/demolition-contract billing. Interior/ownership detail still open — see §6. |
| P2 | **Scrap Row chop shops** | [F] | Freeman Ave's string of junk lots and chop shops — the Barons' real, unglamorous economy. | Fence/parts vendor tie-in (same role as Price Hill's Valley Iron & Salvage); stolen-bike drop; brawl scene. |
| P2 | **8th St Viaduct — Queensgate landing (G1)** | [R] | The eastern end of the same viaduct the Price Hill doc describes from its own (western) side — exposed, elevated, no mid-span cover. | First-conflict corridor with the player's home turf; classic roadblock/gauntlet site from this side too, mirroring the PH doc's own chokepoint note rather than duplicating its underdeck content (that stays PH's). |
| P2 | **West End rowhouse block** | [R-generic] | One anchor block where the yard gives way to actual neighborhood streets — the Barons' canon secondary ground. | Civilian humanizer; consequences live here (same role Newport's west-side shotgun blocks and the Highway Kin docs' trailer-court beats play). Kept to one block this pass, not a full sub-district. |
| P3 | **Central Parkway frontage** | [R] | The clean, fast eastern edge road toward downtown/OTR. | G3 fade; soft eastern boundary; light traffic/witness presence contrast to the yard's emptiness. |
| P3 | **Dead sidings & underused spurs** | [F/generic] | Disused rail spurs east of the main yard, weeds through the ties. | Quiet route, stash spots, collectibles; visual contrast to the still-live core tracks. |

**Hero-building budget:** 4 P1 uniques (Roundhouse, the working yard as one hero terrain system, Union Terminal, the Frontage) — proportionally smaller than every companion doc, matching the note in §0. Kits: industrial-brick/corrugated-shed kit, chain-link/scrapyard-fence kit, rowhouse kit (can likely reuse Price Hill's LPH rowhouse kit rather than authoring a new one — same building stock era).

---

## 5. Gameplay points of interest

### Chokepoints
| Where | Why it works |
|-------|---------------|
| **8th St Viaduct, Queensgate landing (G1)** | Same long-span, no-exits logic the Price Hill doc already flagged from the other side — whoever holds both ends owns the crossing. |
| **The Yard's fence line** | A scrapyard is naturally a maze of one-way-in chokepoints — gates, gaps torn in chain-link, the loading dock. |
| **Rail crossings** | Live tracks through the district double as a scriptable hazard/gate, same mechanism as the Price Hill doc's State Ave crossing — a freight movement can cut a chase either direction. |
| **The Frontage's guard gate** | If built per the story hook, its one controlled entrance is a natural stakeout/infiltration chokepoint distinct in *feel* from the Barons' own scrappy fence gaps — deliberate, not desperate. |
| **I-75 underpasses** | Where the interstate crosses over district streets — classic shadow/ambush geometry, cheap to build, period-plausible. |

### Sight lines / overwatch
| From | Sees |
|------|------|
| The Roundhouse roof | The working yard's full spread; matches the Price Hill doc's own note that the Incline House rooftop sees "Queensgate yards and the G1 viaduct approach" — these are the same sightline from opposite ends. |
| Union Terminal's rotunda approach | Long, open view back across the yard toward the 8th St Viaduct. |
| 8th St Viaduct mid-span | Both the Price Hill bluffs and the Queensgate flat at once. |
| The Frontage's fence line (if built) | Deliberately does NOT see into the Barons' own Scrap Row — that separation is part of what should read as suspicious. |

### Natural chase routes
1. **The viaduct run:** Price Hill ↔ Queensgate over G1 — the district's one guaranteed home-turf-adjacent conflict corridor, already set up by the companion doc.
2. **Yard maze:** into the working rail yard at speed, freight cars as moving hazards and cover, same texture as Price Hill's barrel-yard maze but with trains instead of drums.
3. **Scrap sprint:** Freeman Ave chop-shop row, tight and junk-cluttered, favors local knowledge over speed.
4. **The clean run:** Gest St past the Frontage — wide, fast, watched, a deliberate contrast to Scrap Row's clutter a block away.
5. **East fade:** Central Parkway out toward downtown/OTR — the soft, fast exit when a Baron (or the player) needs to disappear off their own ground.

### Stakeout spots
Roundhouse roof (the whole yard), Union Terminal approach (long sightline back to the viaduct), the Frontage's fence line from Scrap Row's rooftops (watching the "clean" lot without being seen from it), I-75 underpass shadows.

---

## 6. Systems tie-ins (SUGGESTIONS — nothing wired; needs its own pass)

- **TurfNode_QueensgateYard [exists, mapped onto here]:** live-checked before writing this doc — position (-60,0,60), `nodeName` "Queensgate Yard", `captureType` CombatGauntlet, `hasSafehouse=true`, but **`startingFaction` is currently unassigned (neutral)** despite the canon fit, the same open gap the original-4-nodes note in `project_turf_heat_wiring` already flags. This doc doesn't fix that — it's a user decision already on record, not new. Its CombatGauntlet type already suits the Barons' full-throttle-ramming canon with zero changes needed once/if `startingFaction` gets set.
- **Manpower mismatch worth flagging:** `TurfNode.StartCombatGauntlet()` spawns `enemyCount` enemies (default serialized value 5) directly via `EnemyAIManager.SpawnEnemyWave`, without checking `FactionManager.HasFiniteManpower`/`ConsumeManpower` the way `HeatSystem.SpawnReinforcementWave()` does. RustBarons.asset sets `hasFiniteManpower=true` with `startingManpower=3`. If TurfNode_QueensgateYard's `enemyCount` is left at the class default, a single capture attempt could spawn more Rust Barons than their canon roster has — worth a look whenever this node actually gets built/tuned, not something this doc changes.
- **The laundering story thread (§1): DECIDED 2026-08-15.** The Frontage is a construction/paving/demolition contractor front laundering illicit cash through inflated payrolls, heavy-equipment leasing scams, and materials/demolition billing — a real period mechanism, and a natural fit sitting on/adjacent to the already-built rail yard. Still open, and left for a later pass: the Frontage's interior layout, its corporate name/ownership, its guards' faction (if any), and whether/how the Rust Barons interact with it (know, benefit, resist, or irrelevant). Ties to the Downtown/OTR doc's Sky Garage decision (same corporate-backing thread, different end of the pipeline — commercial real estate on the clean/output side, contractor billing here on the cash-generation side).
- **Rail as live scenery:** direct continuation of the Price Hill doc's own note — freight movement in the yards (visible from the Incline House roof) and the State Ave crossing train are the same system this district would actually host and build. One shared rail-scenery pass could cover both docs at once.
- **Heat origin:** no specific real CPD precinct inside Queensgate proper is confirmed here (unlike Price Hill's real District 3 building) — flagging rather than inventing a fake precinct address. Plausible default: yard/rail security at street level plus ordinary citywide dispatch response, not a dedicated local station house. Needs a decision if the district wants its own Price-Hill-style "heat starts on home turf" flavor.
- **Rust Barons' behavior tie-in:** low coordination (0.3) and low defensiveness (0.2) should read as scattered, opportunistic defense — a few vicious individual fighters, not a coordinated garrison. Matches the small hero-building budget and the "gaps in someone else's machine" thesis directly.
- **Queensgate adjacency (reciprocal):** the Price Hill doc already calls G1 "a natural first-conflict corridor" from its side — this doc doesn't need to re-establish that, just confirms it holds from the Queensgate side too.

---

## 7. Period accuracy — 1995 checklist

- **Kenyon-Barr / urban renewal history is real and belongs in tone, not gameplay.** Queensgate is industrial flatland in 1995 because a dense, predominantly Black neighborhood was cleared for it in the late 1950s–60s — one of the city's largest displacement projects. No gameplay content should joke about, romanticize, or use this as "ruins" set dressing. Same category of tone guardrail as the Beverly Hills Supper Club fire in the Newport doc: acknowledge, don't exploit.
- **Union Terminal in 1995** is the Cincinnati Museum Center (opened as such in 1990) — History Museum, Museum of Natural History & Science, an OMNIMAX theater — with a small working Amtrak platform still inside. It is not derelict and not solely a rail building anymore; treat it as a working civic landmark, not a ruin.
- **Rail operators of the era:** Conrail was still the dominant Northeast/Midwest freight carrier through 1999 (the CSX/Norfolk Southern split of Conrail hadn't happened yet in '95) — Conrail-liveried equipment mixed with CSX through-traffic is period-plausible for yard dressing; don't default to modern CSX-only branding.
- **I-75 through the Mill Creek valley** was already a known local traffic chokepoint by the mid-90s — safe, confident period flavor.
- **No cell phones.** Payphones: a yard-office phone booth, Scrap Row corner store, Union Terminal's concourse.
- **Radio/TV:** WEBN, Reds talk (same strike-hangover mood the Price Hill doc notes for '94–95).
- **Tone guardrails:** the Rust Barons are poor and outgunned, not cartoonish thugs — three guys defending scrap because scrap is what they have. Play the aggression as desperation, not menace-for-its-own-sake, consistent with their canon fear response ("frozen with fear, stalling out mid-charge") once real pressure lands.

---

## 8. Blockout notes for the build

1. **The yard is the level.** Rail geometry (tracks, sidings, freight cars, the Roundhouse) should block out before any street-level dressing — this district's identity is industrial infrastructure, not neighborhood blocks.
2. **Keep it small.** This is explicitly not a big-budget district (§0). Resist the urge to pad it out to Price Hill's scale — four P1 heroes, a handful of kit-bashed streets, done.
3. **G1 must match the Price Hill doc's own description of the same viaduct** — don't re-author its length, exposure, or chokepoint logic from this side; build the Queensgate landing to meet it.
4. **The Frontage's mechanism is now confirmed (contractor/paving/demolition front, §1/§6)** — exterior/silhouette can build toward that directly (equipment yard, contractor signage, not generic salvage). Interior layout, ownership name, and Rust Baron interaction still need their own pass before building inside it.
5. **Union Terminal is a vista/landmark, not (yet) an interior location** — no model exists in the project currently (§4); treat it as a skybox/backdrop-scale build until/unless the game wants an interior pass.
6. **Rail is a shared system with the Price Hill doc** — coordinate before building so the freight movement and the State Ave crossing train aren't built twice with different rules.
7. **Existing scene note:** same caveat as every companion doc — TurfNode_QueensgateYard's live position (-60,0,60) is abstract placeholder spacing, not a real coordinate plan. Relocate when the district gets one, same as the rest.
