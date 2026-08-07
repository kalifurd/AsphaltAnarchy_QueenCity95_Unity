# EAST END — LEVEL DESIGN REFERENCE
**Asphalt Anarchy: Queen City '95 — The Phantoms MC primary territory**
**Setting: Cincinnati East End, Hamilton County, Ohio, 1995. Status: design reference, not yet built.**
**Companion docs:** `LevelDesign_PriceHill_Delhi_1995.md`, `LevelDesign_Milford_Batavia_1995.md`, `LevelDesign_Hamilton_Fairfield_1995.md`, `LevelDesign_Newport_1995.md`, `LevelDesign_Queensgate_1995.md`, `LevelDesign_Downtown_OTR_1995.md`, `LevelDesign_Norwood_1995.md` (same conventions).
**Faction canon (Phantoms.asset):** primary territory **East End**; description **"Ghost riders out of the East End's abandoned industrial sprawl. Nobody agrees on how many there are."**; combat style **"Erratic, unpredictable psychological intimidation — fake retreats, sudden attacks."** Read the whole stat block, not just the faceless-rider aesthetic: coordination is the **lowest of any gang in the game (0.2)**, fear threshold is high (0.6 — hard to rattle), defensiveness is moderate (0.6), aggression only moderate (0.5), and `playerRelation` (-0.3) is the *mildest* hostility of any rival faction. Echo responses: low = "erratic and mocking, weaving in and out of view"; mid = "cautious, fake retreats become real ones"; high = **"vanish outright — the legend defers to the bigger legend."** This is not a gang that holds ground through force or discipline. It's a gang that holds ground by never quite being where you think it is — and this doc is built around that reading, same discipline as every companion doc since Newport.

**Technical finding that reinforces the thesis:** unlike Rust Barons (`hasFiniteManpower=true`, `startingManpower=3`, the smallest roster in the game), Phantoms.asset does **not** override `hasFiniteManpower` or `startingManpower` — both sit at script default (`false` / `20`, effectively unlimited reinforcements since the flag is off). Mechanically, in-game, **nobody agrees how many Phantoms there are because the code doesn't cap it either.** That's a real, verifiable fact from `FactionData.cs`, not a narrative flourish layered on top.

---

## 0. How to read this document

- **[R]** — real place/street, real name, use as-is (civic landmarks, streets, parks, infrastructure).
- **[R\*]** — real place, name lightly fictionalized (private businesses we attach club activity to).
- **[F]** — fictional, anchored to real building stock plausible for 1995.
- **[R-generic]** — real street, exact building fronts unverified/interchangeable — same convention prior docs use for their least-verified secondary streets.
- Geography compressed **~5:1**, same as every companion doc. Keep topology exact, scale distances freely.
- **This is not the AbandonedSubway doc.** `TurfNode_AbandonedSubway` (a pre-canon-research guess, built before FactionData verification was standard practice on this project) has already been reassigned to neutral — that conflict is closed, logged in `.notes/Shared Notes.txt` 2026-08-07. This doc proposes the Phantoms' **actual** home ground, a new TurfNode, not a fix to the old one (§6).
- **Canon tension flagged, not resolved here:** `Phantoms.asset.secondaryTerritory` reads `"Lower Price Hill"`, but the Price Hill doc's own §6 text says plainly *"Phantoms: no presence here — their subway node is downtown. At most, a watched rail spur in the yards visible from the clubhouse roof (flavor, not turf)."* Those two statements don't agree, and this doc doesn't invent a resolution — same restraint the Downtown/OTR doc used when it first surfaced this exact tension. Logged again here since this is the Phantoms' own dedicated doc; still an open flag for a human decision.
- **TurfNode_DowntownOverpass's G5** (Columbia Parkway east, through Mount Adams) already names East End as its destination — **received, not redefined** (§2).

---

## 1. Orientation & district thesis

**The thesis: the neighborhood that was hollowed out on purpose, and the gang that fits the hollow exactly.** East End is a real Ohio River neighborhood, and its emptiness in 1995 isn't just Rust Belt decline like Queensgate or Norwood — Columbia Parkway's construction (opened 1938) and later mid-century redevelopment cut directly through East End's riverfront blocks, and the neighborhood never recovered its density afterward. That's real, documented Cincinnati history, not invented backstory, and it deserves the same respect the companion docs give Lower Price Hill's poverty or Newport's economic squeeze: **played straight, people who still live here, not a stage set.** What's left is a scatter of surviving rowhouse blocks, a working parish, and a long riverside stretch of warehouses and rail sidings that emptied out as river-dependent industry declined through the postwar decades — abandoned buildings, but not one single dead giant the way Norwood has GM or Newport has Wiedemann. **Diffuse absence, not one big ruin** — which is exactly the terrain a faceless, uncoordinated, impossible-to-pin-down gang would actually hold.

The Phantoms don't run East End the way the Rust Barons run their yard or the Kentucky Kings own the bridges. They're not organized enough (coordination 0.2) to hold a fortress, and the neighborhood doesn't have one for them to hold anyway. What they have is **the advantage of a place built to be overlooked** — low sightlines from downtown, no single road that funnels all the traffic, a bluff (Mount Adams, Neon Saints' secondary, light touch only) between here and everywhere else. Riders in unmarked colors on a street nobody's watching read as absence, not threat, right up until they don't.

| Zone | What | Character |
|------|------|-----------|
| The Bluff Approach | Columbia Parkway, descending from Mount Adams | Narrow, curvy, cliff-edge — the only "front door," and it's already hostile terrain. |
| The Flats | Eastern Avenue / Riverside Drive, the rail-and-warehouse strip | Diffuse abandonment — no single dead giant, just block after block of buildings nobody's using. |
| The Remnant Blocks | Surviving rowhouse streets around St. Rose | What's left of the neighborhood the highway didn't take. Lived-in, watchful, quiet. |
| The Bend | Turkey Bottoms / Lunken Airport, the river's eastern curve | Low, flood-prone, foggy off the water — the district's soft eastern edge. |
| The Overlook | Alms Park, up on the Mount Lookout bluff | Not Phantoms ground — the view down into it from a neighborhood that isn't theirs. |

### Schematic (topology only, not to scale)

```
        (received: Downtown/OTR's own G5 — Columbia Pkwy east, through
         Mount Adams [Neon Saints secondary, light touch, not redefined])
                                |
                    COLUMBIA PARKWAY [R] — narrow, curvy, bluff-hugging
                                |  (the only real "front door" in/out)
                    ┌───────────┴───────────┐
              THE OVERLOOK              (descent into the flats)
         Alms Park [R, Mt. Lookout             |
         bluff — not Phantoms ground,     ST. ROSE CHURCH [R] —
         just watches it]                 anchor of THE REMNANT BLOCKS
                                                |
   EASTERN AVE [R] ══════ THE FLATS ══════ RIVERSIDE DRIVE [R] (continues east)
   (warehouses, rail sidings, CSX ex-L&N line, THE ICEHOUSE clubhouse [F])
                                                |
                                  OHIO RIVER ~~~~~~~~~~~~
                                                |
                              (E: THE BEND — Turkey Bottoms / Lunken
                               Airport [R], soft fade toward Columbia-
                               Tusculum and Coney Island, off-map)
```

---

## 2. Road network

### Arterials

| Road | Tag | Runs | Role |
|------|-----|------|------|
| **Eastern Avenue** | [R] | The Flats' core spine, running east from downtown's edge | East End's actual main street — warehouses, rail crossings, the surviving commercial fronts. |
| **Riverside Drive** | [R] | Eastern Avenue's continuation further east, toward Columbia-Tusculum | Where the Flats thin out into the Bend; same road, quieter name change, same convention as Newport's Monmouth/York couplet. |
| **Columbia Parkway** | [R] | The bluff-top road from downtown/Mount Adams, descending into the Flats | **Received, not redefined** — the Downtown/OTR doc's own G5 already names this the route here. Narrow, curvy, genuinely dangerous in period (a real Cincinnati reputation, not invented flavor). |
| **The CSX riverfront line (ex-L&N)** | [R] | Parallel to Eastern Ave/Riverside Dr along the water | Still-live freight in 1995 — same era CSX inherited former L&N riverfront trackage after the 1980s rail mergers. Grade crossings double as chokepoints (§5). |

### Gateways — connections outward

| # | Gateway | Tag | Leads to | Notes |
|---|---------|-----|----------|-------|
| G1 | **Columbia Parkway west, through Mount Adams** | [R] | Downtown/OTR (received) | **Received, not redefined** — this is the Downtown/OTR doc's own G5, arriving. Mount Adams itself stays light-touch, same restraint that doc already committed to. |
| G2 | **Riverside Drive east** | [R] | Columbia-Tusculum, Turkey Bottoms/Lunken Airport, and further east toward Coney Island [R] — off-map, soft fade | The district's quiet eastern exit, river-level the whole way. |
| G3 | **The bluff climb north** | [R-generic] | Mount Lookout / Hyde Park, above Alms Park — off-map, soft fade | Presence implied by the overlook (§4), not built past it — same restraint every companion doc gives its softest edge. |

---

## 3. Sub-area character sheets

### 3a. The Bluff Approach — Columbia Parkway
The only real front door: a narrow, curving road cut into the hillside, cliff on one side, no shoulder to speak of, genuinely hazardous even without a chase happening. Everyone arriving from downtown or Mount Adams comes down this one road, which suits the Phantoms fine — they know every blind curve on it and nobody else drives it for fun. **Tone: the last stretch of "normal" Cincinnati before the rules change.**

### 3b. The Flats — Eastern Avenue / Riverside Drive
Block after block of warehouses, cold-storage buildings, and rail sidings that emptied out as river-dependent industry declined through the postwar decades — no single dead giant like Norwood's GM plant, just diffuse abandonment spread over a long riverside stretch. The CSX line still runs live freight down the middle of it. This is the Phantoms' actual ground, and it doesn't look like anybody's ground at all. **Tone: quiet in a way that never quite resolves into empty.**

### 3c. The Remnant Blocks — around St. Rose
What survived Columbia Parkway's construction and the decades of redevelopment after it: a handful of rowhouse streets, a working parish, families who never left. This is real Cincinnati history, not invented tragedy — East End's riverfront community was measurably reduced by mid-century highway and redevelopment projects, the same broad pattern that hit the West End harder and more famously, and it deserves the same treatment the companion docs give every community under pressure: **lived-in, not a ruin.** **Tone: the neighborhood that's still here, watching the Flats the way a family watches a street they used to fill.**

### 3d. The Bend — Turkey Bottoms / Lunken Airport
The river's eastern curve, low and flood-prone, real name "Turkey Bottoms" — Cincinnati's original municipal airport [R] still sits here in 1995, small planes over empty industrial ground, river fog rolling through on cool nights. The Phantoms' favorite exit and the district's best "we were never here" terrain. **Tone: the ghostliest ground in the game, and it isn't even trying.**

### 3e. The Overlook — Alms Park (light touch)
Up on the Mount Lookout bluff above the Flats, a real city park [R] with a clean view down into East End and the river bend. Not Phantoms ground — nobody's ground, really, just the place everyone else in the city looks down from when they wonder what's happening down there. **Tone: the outside world's one clear look in, and it still doesn't tell them much.**

---

## 4. Location list

Priority tiers: **P1** must-build hero (unique model), **P2** identity (heavily-dressed kit), **P3** dressing (kit-bash).

### The Bluff Approach

| P | Location | Tag | Description | Gameplay |
|---|----------|-----|-------------|----------|
| P1 | **Columbia Parkway curves** | [R] | The descent itself — tight bluff-hugging bends, minimal shoulder, a real Cincinnati road with a real reputation for punishing drivers who don't respect it. | Hero terrain: the district's signature vertical chase (§5), a hazard even without pursuers. |
| P3 | **Overlook pull-off** | [R-generic] | A gravel shoulder partway down where the road briefly widens. | Stakeout spot watching the Flats below; meet point that isn't anyone's turf. |

### The Flats

| P | Location | Tag | Description | Gameplay |
|---|----------|-----|-------------|----------|
| P1 | **The Icehouse** (clubhouse) | [F] | A derelict riverside cold-storage/icehouse building, one of a dozen near-identical brick warehouses along the CSX line — deliberately indistinguishable from its neighbors from the street. No sign, no colors, no obvious front door. Even people who know it's there argue about which building it actually is. | Player-facing home base for the faction, but built to *not* read as one. Maps to §6's proposed TurfNode. Multiple unmarked entries, not one defensible front door — mechanically erratic to match the faction. |
| P1 | **The warehouse row** | [R street, F buildings] | The core of Eastern Avenue's abandoned stretch — loading docks, broken skylights, catwalks between buildings close enough to cross. | Hero terrain: erratic multi-path chase geometry (§5), no single chokepoint — the terrain itself is unpredictable, matching the faction's fake-retreat combat style. |
| P2 | **CSX grade crossings** | [R] | Live freight crossings along Eastern Ave, same era CSX inherited the old L&N riverfront line. | Timed-gate hazard, same mechanism as Price Hill's State Ave crossing and Norwood's Beech Ave siding. |
| P3 | **Cold-storage husk row** | [F] | Smaller derelict structures scattered near the Icehouse — the reason nobody agrees which building is the clubhouse. | Ambush spawns; red-herring interiors; reinforces the "nobody agrees how many" canon line mechanically. |

### The Remnant Blocks

| P | Location | Tag | Description | Gameplay |
|---|----------|-----|-------------|----------|
| P1 | **St. Rose Church** | [R] | The neighborhood's historic Gothic parish, a real East End landmark, congregation smaller than it once was but still active in 1995. | Wayfinding anchor; daytime civilian presence keeps the Remnant Blocks reading as lived-in, not a ruin — same role St. Michael's plays in Lower Price Hill. |
| P2 | **Surviving rowhouse blocks** | [R-generic] | The handful of residential streets that outlasted mid-century redevelopment. | The humanizer — same role Price Hill's West side and Newport's shotgun blocks play; witnesses, families, consequences. |
| P3 | **Corner store & payphone** | [F] | Neighborhood crossroads shop. | Info-hub NPC, period payphone (§7). |

### The Bend

| P | Location | Tag | Description | Gameplay |
|---|----------|-----|-------------|----------|
| P1 | **Lunken Airport perimeter** | [R] | Cincinnati's original municipal airport, still active general aviation in 1995, sitting in the low flood-prone bend real Cincinnatians call "Turkey Bottoms." | Eastern soft-fade gateway (§2 G2); fog-and-quiet atmosphere, small aircraft overhead as ambient flavor, not a mission site. |
| P3 | **Turkey Bottoms river fog** | [environmental, not a location] | Recurring ground fog off the river bend on cool nights — a real, plausible microclimate effect for a low riverside bottom. | Suggested visibility mechanic (§6) — the one district-specific atmospheric system in the doc. |

### The Overlook (light touch)

| P | Location | Tag | Description | Gameplay |
|---|----------|-----|-------------|----------|
| P2 | **Alms Park** | [R] | Mount Lookout bluff-top park with a clean view down into East End and the river bend. | Sightline set piece (§5); not a Phantoms location — the district's one vista from outside looking in. |

**Hero-building budget:** 5 P1 uniques (Columbia Parkway curves, the Icehouse, the warehouse row, St. Rose Church, Lunken Airport perimeter). Kits: industrial-brick warehouse kit (heavy reuse potential — deliberately generic/interchangeable per the clubhouse's own concept), rowhouse kit (light reuse of Price Hill/Newport residential kits, same building era), one bluff-road terrain kit for the Parkway curves.

---

## 5. Gameplay points of interest

### Chokepoints
| Where | Why it works |
|-------|--------------|
| **Columbia Parkway curves** | The one real front door — narrow and blind-cornered enough that holding it is a genuine tactic, not just a bottleneck. |
| **CSX grade crossings** | Live freight, scriptable timed gate — same mechanism as Price Hill's State Ave crossing. |
| **Warehouse row gaps** | Not a single chokepoint by design — several narrow gaps between buildings, all viable, which is the point: no one spot controls the Flats. |
| **Lunken perimeter road** | Low, single-feeling lane hugging the airport fence — easy to seal, easy to get lost in the fog trying. |

### Sight lines / overwatch
| From | Sees |
|------|------|
| Alms Park (Mount Lookout bluff) | The whole Flats and the river's eastern bend — the district's one true vista, and it belongs to nobody in it |
| Columbia Parkway pull-off | Straight down into the warehouse row |
| Icehouse roof | The CSX line and the length of Eastern Ave |
| St. Rose steeple | The Remnant Blocks and the edge of the Flats |

### Natural chase routes
1. **The Parkway drop:** Columbia Parkway's curves down from Mount Adams into the Flats — vertical, punishing, the district's signature descent (same structural role as Price Hill's Elberon Ave).
2. **Warehouse maze:** through the row's gaps and catwalks — no clean line, multiple viable paths, built to make pursuers guess wrong the way the faction itself does.
3. **Riverside straight:** Eastern Ave into Riverside Drive, flat and fast along the water.
4. **Rail-grade gauntlet:** CSX crossings as timed gates, same mechanism as every companion doc's live-rail hazard.
5. **Fog run:** into the Bend toward Lunken — reduced visibility, the one district where losing a pursuer is partly the environment's doing, not just the player's.

### Stakeout spots
Overlook pull-off (the Flats from above), Icehouse roof (Eastern Ave and the rail line), St. Rose steps (the Remnant Blocks), Alms Park (the whole district, from outside it).

---

## 6. Systems tie-ins (SUGGESTIONS — nothing wired here)

**TurfNode (proposed, new — not a repair of the old subway node):**
| Node | Faction | captureType | Notes |
|------|---------|-------------|-------|
| TurfNode_EastEndIcehouse | Phantoms (`startingFaction`) | CombatGauntlet | The Icehouse — Phantoms' real home base. `hasSafehouse=true`, same pattern as Price Hill's InclineHouse, Newport's Kingfish, Queensgate's Roundhouse. This is the node that should have existed instead of the old AbandonedSubway guess. |

- **Unlimited-manpower flavor:** since Phantoms.asset leaves `hasFiniteManpower=false` (unlike Rust Barons' hard-capped 3), their `StartCombatGauntlet()` reinforcement waves should feel bottomless compared to Queensgate's — mechanically backing up "nobody agrees how many there are" rather than just narrating it.
- **Fog/visibility system (new, district-specific):** Turkey Bottoms' real flood-plain fog suggests a genuine reduced-visibility zone in the Bend — sightline range reduced, ambient audio-only detection for a stretch. Would be the first environmental-visibility mechanic in the game; flag before building, it's new scope, not a reuse of an existing system.
- **Echo-response tie-in:** the canon high-Echo line ("vanish outright — the legend defers to the bigger legend") suggests Phantoms should be the one faction that actively despawns/retreats rather than fighting harder as player Echo climbs — the opposite tuning curve from every other gang. Needs its own pass in Echo-system terms; flagged, not implemented.
- **Open flag carried forward:** `Phantoms.asset.secondaryTerritory="Lower Price Hill"` vs. the Price Hill doc's own "no real presence here" text (§0) — still unresolved, needs a human decision on which document is wrong, or whether the secondary territory should just be reassigned/cleared.
- **Mount Adams boundary:** stays Neon Saints' secondary per the Downtown/OTR doc — no turf overlap proposed here, same restraint that doc committed to.

---

## 7. Period accuracy — 1995 checklist

- **Columbia Parkway (opened 1938)** is real, and its curvy, cliff-edge reputation is real — no artistic exaggeration needed. Its role in East End's mid-century depopulation is documented Cincinnati history, not invented backstory; treat it with the same weight the companion docs give Lower Price Hill's poverty and Newport's economic squeeze — real, current in living memory, not played for atmosphere alone.
- **Lunken Airport** is Cincinnati's original municipal airport, active general aviation in 1995 (it predates and long outlasted its replacement by CVG across the river) — small planes overhead is period-accurate ambient flavor, not anachronistic.
- **CSX**, not Conrail or Norfolk Southern, is the plausible operator of the former L&N riverfront trackage by 1995 — CSX formed via the 1980s rail mergers that absorbed L&N. Get this right on any signage/rolling-stock detail.
- **No cell phones.** Payphones: the corner store in the Remnant Blocks, the overlook pull-off, St. Rose's front steps.
- **Radio/TV:** same regional mix as every companion doc — WEBN rock radio, Reds strike hangover, useful ambient NPC chatter.
- **Tone guardrail:** East End in '95 is quiet and thinned-out, not derelict theme-park territory — the Remnant Blocks are a real, occupied neighborhood, and the Flats' abandonment is the slow accumulation of postwar industrial decline plus real mid-century redevelopment, not a single dramatic collapse. No invented tragedy layered on top of the real history here.
- **The Phantoms themselves are meant to be genuinely ambiguous** — don't over-clarify their numbers, structure, or membership in any dialogue or mission text. The canon description's uncertainty ("nobody agrees how many there are") is a design constraint, not a placeholder waiting to be resolved.

---

## 8. Blockout notes for the build

1. **Columbia Parkway's descent is the level's spine**, same structural role as Price Hill's 8th St hill or Norwood's Lateral — build the curve geometry first, since every sightline and chase route in §5 depends on it.
2. **The Flats should read as diffuse, not centralized.** Resist the urge to build one obviously-important "dead giant" structure the way Norwood has GM or Newport has Wiedemann — the warehouse row's whole identity is that no single building stands out, including the clubhouse.
3. **The Icehouse needs deliberate camouflage in its own geometry** — same footprint/material language as 2–3 neighboring "husk" buildings nearby, with entrances that don't read as a front door from the street. This is a gameplay promise, not just art direction: players who know the district shouldn't be able to spot the clubhouse from silhouette alone.
4. **Fog system (§6) is new scope** — if built, keep it scoped to the Bend only at first; don't let it bleed into the rest of the district's readability.
5. **Kits:** industrial-brick warehouse kit built for interchangeability (multiple near-identical facades, by design), rowhouse kit (light reuse from Price Hill/Newport), one bluff-road terrain kit for the Parkway.
6. **St. Rose and Alms Park are the only two hard landmarks in the district** — keep the rest of the geometry intentionally underdesigned relative to other companion docs; landmark density is the wrong instinct here.
7. **Existing scene note:** no TurfNode currently represents Phantoms' real territory — `TurfNode_AbandonedSubway` is neutral now (§0), and §6's `TurfNode_EastEndIcehouse` doesn't exist yet either. Same coordinate-plan caveat as every companion doc: don't place it until a real district coordinate plan exists.
