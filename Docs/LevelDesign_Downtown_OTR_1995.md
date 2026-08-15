# DOWNTOWN & OVER-THE-RHINE — LEVEL DESIGN REFERENCE
**Asphalt Anarchy: Queen City '95 — Neon Saints (Downtown) & OTR Syndicate (Over-the-Rhine) territory**
**Setting: the Cincinnati core, 1995. Status: design reference, not yet built.**
**Companion docs:** `LevelDesign_PriceHill_Delhi_1995.md`, `LevelDesign_Milford_Batavia_1995.md`, `LevelDesign_Hamilton_Fairfield_1995.md`, `LevelDesign_Newport_1995.md`, `LevelDesign_Queensgate_1995.md` (same conventions).
**Faction canon (NeonSaints.asset):** primary territory Downtown, secondary Mount Adams; **"corporate-backed, high-tech racers who treat Downtown like their private circuit"**; combat style is precision strikes, electrified batons, coordinated pack surrounds — by far the highest coordination of any gang (0.8) and a low fear threshold (0.3, they don't rattle easily) paired with middling defensiveness (0.4). This is the only faction in the game whose own description says "corporate-backed" outright.
**Faction canon (OTRSyndicate.asset):** primary territory Over-the-Rhine, secondary Pendleton; "alley-runners who know Over-the-Rhine's back streets better than the cops do"; combat style is hit-and-run ambushes, quick strikes then vanish. Moderate aggression and coordination (0.6/0.6), moderate defensiveness (0.5) — organized enough to plan a strike and vanish, not organized enough to hold ground toe-to-toe.
**This doc is built around the contrast between those two canon blocks, not just their turf being adjacent.**

---

## 0. How to read this document

- **[R]** — real place/street, real name, use as-is (civic landmarks, streets, infrastructure).
- **[R\*]** — real place, name lightly fictionalized (private businesses we attach club activity to).
- **[F]** — fictional, anchored to real building stock plausible for 1995.
- Geography compressed ~5:1, same as every companion doc. Keep topology exact, scale distances freely.
- **TurfNode_DowntownOverpass already exists** as the Neon Saints' anchor (position 0,0,-70; `nodeName` "Downtown Overpass"; description **already says** "A Neon Saints stunt run across the Downtown overpasses"; `captureType` Stunt; `startingFaction` currently unassigned/neutral, same open gap as every original node).
- **TurfNode_OTRAlley already exists** as the OTR Syndicate's anchor (position 60,0,60; `nodeName` "OTR Alley"; description **already says** "A narrow alley in Over-the-Rhine, controlled by the OTR Syndicate"; `captureType` Race; `startingFaction` also currently unassigned/neutral). This doc maps onto both — it does **not** propose new turf.
- **This is a two-faction doc**, unlike any companion doc so far — Downtown and OTR sit back-to-back across one real street (Central Parkway) and belong to two factions with almost opposite personalities. Treat them as one district with a hard internal seam, not two separate write-ups glued together.

---

## 1. Orientation & district thesis

**The thesis: the private circuit, and the alley underneath it.** Downtown Cincinnati by day is banks, government buildings, and empty sidewalks after 5pm — which is exactly why the Neon Saints, canonically **corporate-backed**, can treat it as their private circuit at night: wide, clean, well-lit streets with almost no one around to stop them, and (per their canon) the coordination and the batons to make sure it stays that way. One real street over, Over-the-Rhine in 1995 is the opposite of everything Downtown is: dense, poor, half-abandoned 19th-century tenement blocks that the city's postwar money left behind decades ago, worked by a much scrappier gang who know every cut-through the Saints don't bother learning because they never have to walk anywhere.

**The seam is real and it has a name: Central Parkway.** Built in the 1920s over the old Miami and Erie Canal bed, Central Parkway is the literal reason the neighborhood north of it is called "Over-the-Rhine" — 19th-century German immigrants nicknamed the canal "the Rhine," and crossing it to get home became the neighborhood's name. That's not invented flavor; it's the real etymology, and it's a perfect gameplay seam: one street, two entirely different games happening on either side of it.

**Story thread — DECIDED 2026-08-15:** confirmed connected. The Neon Saints' corporate backer is the same laundering operation that runs the Frontage in Queensgate — two ends of one pipeline. The Sky Garage is a **Commercial Real Estate Shell Company / Title Agency front**: buying up downtown commercial strips and multi-family units through shell entities, then mixing illicit cash into legitimate-looking property flips and title transfers. It's the clean, output side of the laundering pipeline — real estate is the classic "final wash" step, taking dirty cash that entered the system as contractor billing in Queensgate (§ tie-in below) and turning it into legitimate-looking property equity. It ties directly to the Neon Saints' own canon "corporate-backed" description and their broader "sanitize the city" identity — precision, coordination, batons, and a clean private circuit are the same instincts as a shell company scrubbing cash: control, polish, no mess. **"corporate-backed" is literally in the Neon Saints' own faction description**, unprompted, the only faction in the game described that way — this decision makes good on that thread rather than inventing it.

| Zone | What | Character |
|------|------|-----------|
| Downtown core | The CBD grid — Fountain Square, the bank towers, government buildings | Empty canyon after dark; the Saints' actual track. |
| The riverfront | Where every other district's gateways converge (Waldvogel Viaduct, the Newport bridges, Roebling Bridge) | The hub. Every companion doc's "downtown" arrow lands here. |
| OTR core | Vine Street's spine, the historic tenement blocks, Findlay Market, Music Hall | Dense, poor, and lived-in — not a ruin. Same guardrail Price Hill gave Lower Price Hill. |
| Pendleton | OTR's eastern edge, blending into it rather than a separate neighborhood | Kept as OTR's extension, not built as its own sub-area. |
| Mount Adams | The Saints' canon secondary, a steep hilltop neighborhood over the river | Light touch this pass — same restraint Newport gave Covington and Queensgate gave the West End. |

### Schematic (topology only, not to scale)

```
                         (N: I-75 north -> Norwood Lateral (SR-562) -> I-71 north -> Avondale/Uptown, off-map, future districts)
                                                |
                    FINDLAY MARKET [R] ---- VINE ST SPINE ---- MUSIC HALL / WASHINGTON PARK [R]
                                                |
                                          OTR CORE (Syndicate)
                                          Italianate tenement blocks, alleys
                                                |
                    ═══════════════ CENTRAL PARKWAY (old canal bed) — THE SEAM ═══════════════
                                                |            \
                                          DOWNTOWN CORE        \-- (west: Queensgate's own G3, received not redefined)
                                          (Neon Saints)          
                                     Fountain Sq / Govt Sq / Skywalk
                                                |
                    ┌───────────────────────────┼───────────────────────────┐
             ROEBLING BRIDGE [R]          THE RIVERFRONT              WALDVOGEL VIADUCT
             -> Covington, KY              (hub — receives PH's G2,   -> (received, not
             (Kings' secondary,             Newport's G1, and QG's     redefined; PH doc's
             off-map, light touch)          G4 all in one place)       own gateway)
                                                |
                                     NEWPORT BRIDGES (3) [R]
                                     -> Newport, KY (received, not redefined; Newport doc's own G1)
                                                |
                                    (E: Columbia Pkwy -> Mount Adams -> East End,
                                     Phantoms' primary territory, off-map, future doc)
```

---

## 2. Road network

### Arterials

| Road | Tag | Runs | Role |
|------|-----|------|------|
| **Vine Street** | [R] | North–south, the OTR–downtown spine, continuing north toward Clifton | The single most important street in the doc — it's the one road that runs through both factions' ground without a seam of its own. |
| **Central Parkway** | [R] | East–west, built over the old canal | The hard internal seam between OTR and Downtown. Also **received, not redefined** — this is the same road the Queensgate doc already uses for its own G3 (arriving from the west) and references the Phantoms' Abandoned Subway node running beneath. |
| **Race Street / Main Street** | [R] | Parallel north–south streets through OTR into downtown | Secondary spine pair; OTR's alley grid hangs off these. |
| **Findlay Street** | [R] | OTR's western edge | Same street name the Queensgate doc already uses further west/south — this is its OTR-adjacent stretch, not a re-claim. |
| **5th / 4th / 3rd Streets** | [R] | East–west through the downtown grid | The bank-tower canyon; the Saints' actual racing lines. |
| **Government Square** | [R] | Downtown transit hub | Dead quiet at night — a strange, wide-open plaza in the middle of the circuit. |
| **The Skywalk** | [R] | Elevated pedestrian bridges linking downtown buildings a level above the street | Real 1970s–90s Cincinnati infrastructure. Foot-only, dismount escape route above street level — same role Price Hill's public stairways play, one story up instead of on a hillside. |

### Gateways — connections outward

| # | Gateway | Tag | Leads to | Notes |
|---|---------|-----|----------|-------|
| G1 | **West via Central Parkway / 8th St corridor** | [R] | **Queensgate** (Rust Barons) | **Received, not redefined** — combines the Price Hill doc's own G1 (which already names "downtown/OTR" as 8th St Viaduct's destination) and the Queensgate doc's own G3 (Central Parkway east). This doc is where both of those arrows land. |
| G2 | **The riverfront hub** | [R] | Waldvogel Viaduct (west, Price Hill's G2), the three Newport bridges (south, Newport's G1), and Queensgate's River Road (Queensgate's G4) | **Received, not redefined**, all three at once — the Cincinnati riverfront is the one physical place every companion doc already points at. This doc doesn't re-describe any of those spans; it's just where they all touch down. |
| G3 | **Roebling Suspension Bridge** | [R] | Covington, KY — Kentucky Kings' canon secondary territory (off-map) | **New gateway**, not claimed by any companion doc — the real 1866 span, distinct from Newport's three bridges further east. Light touch only, same restraint Newport gave Covington from its own side. |
| G4 | **I-75 north, via the Norwood Lateral (SR-562), to I-71 north** | [R] | Avondale, Uptown — off-map, future districts | The fast, anonymous northern exit out of the core. Hands off from I-75 to I-71 via the Norwood Lateral rather than a direct interchange — the real Clifton/Mt. Storm Park I-74/I-75 interchange heads west and is unrelated to this route (see Queensgate's own G2, which already claims the I-75-north-to-Clifton arrow). |
| G5 | **Columbia Parkway east, through Mount Adams** | [R] | East End — the Phantoms' canon **primary** territory (off-map, future doc) | New connector this doc establishes; deliberately not built past Mount Adams' light touch (§3). |

---

## 3. Sub-area character sheets

### 3a. Downtown core
The bank-tower CBD: Fountain Square, the government buildings, 5th/4th/3rd Streets. A real workday-only district in 1995 — full of suits at noon, close to empty by 7pm. That emptiness is the whole gameplay hook: wide, clean, well-lit streets with nobody around to stop a coordinated pack of corporate-backed racers. **Tone: glass and streetlight; the quietest loud place in the game.**

### 3b. The riverfront
Where Downtown meets the Ohio — Riverfront Stadium (Reds/Bengals, already established across the companion docs), the Roebling Bridge, and the landing points for every other district's own river gateways. **Tone: the hub everyone else's map already points to.**

### 3c. OTR core
Vine Street's dense grid of 19th-century Italianate tenements, most of them the genuine real building stock of the neighborhood — some occupied, many derelict, none of it a ruin in the "abandoned wasteland" sense. In 1995 this is one of the poorest, most disinvested neighborhoods in the city, decades before any revitalization — real people, a real functioning market, real churches, alongside real vacancy. **Tone: same guardrail as Price Hill's Lower Price Hill — hard and poor, not cartoonish, not empty.**

### 3d. Pendleton
OTR Syndicate's canon secondary territory, immediately adjacent to OTR's own eastern blocks rather than a separate neighborhood — treated here as OTR core's natural edge, not a built-out sub-area of its own.

### 3e. Mount Adams
The Neon Saints' canon secondary — a steep, narrow-streeted hilltop neighborhood over the river, old money and church spires (Holy Cross-Immaculata's steeple is a real skyline landmark). Kept light this pass: one anchor location (§4), the same restraint Newport gave Covington and Queensgate gave the West End edge.

---

## 4. Location list

Priority tiers: **P1** must-build hero (unique model), **P2** identity (heavily-dressed kit), **P3** dressing (kit-bash).

### Downtown (Neon Saints)

| P | Location | Tag | Description | Gameplay |
|---|----------|-----|-------------|----------|
| P1 | **The Sky Garage** (clubhouse) | [F] | A private, camera-lit parking structure beneath/attached to a downtown high-rise — clean concrete, reserved spaces, a corporate access badge system the Saints have clearly been given, not stolen. Floor above the garage houses a small title-agency/property-management office suite — the shell company's actual front door. | Maps to **TurfNode_DowntownOverpass** (§6). DECIDED (§1): the building belongs to the commercial real estate shell company/title agency laundering front — the Sky Garage's badge access is the Saints' cut of that arrangement, the physical proof of "corporate-backed." Exact corporate name/ownership still TBD for a later pass. |
| P1 | **Fountain Square** | [R] | The real civic heart of downtown — the 1871 Tyler Davidson Fountain ("The Genius of Water"), open plaza. | Meet spot; night race start/finish line; the one place in the CBD that's genuinely public rather than corporate. |
| P1 | **The overpass stunt run** | [R, generic] | The downtown highway overpasses/interchange the existing node is already named for. | Direct build target for TurfNode_DowntownOverpass's existing Stunt captureType — no new mechanic needed, just the terrain. |
| P2 | **Government Square** | [R] | The real downtown bus transit hub. | Dead-quiet-at-night set piece; wide open plaza racing line; daytime civilian anchor when it needs one. |
| P2 | **The Skywalk network** | [R] | Elevated pedestrian bridges between downtown buildings. | Foot-only escape route one level above the street — dismount required, no vehicles, same role Price Hill's stairways play. |
| P3 | **Bank-tower canyon (5th/4th/3rd St)** | [R] | The dense core of office towers. | Night racing lines; witness-light after hours; contrast anchor to OTR's crowded daytime streets. |

### The riverfront

| P | Location | Tag | Description | Gameplay |
|---|----------|-----|-------------|----------|
| P1 | **Riverfront Stadium** | [R] | The multi-purpose Reds/Bengals stadium, already established across the companion docs' skyline references — this is the doc where it actually sits. | Landmark/wayfinding; crowd-event potential on game days, same category as Elder's "the Pit" in Price Hill or Riverfest in Newport. |
| P2 | **Roebling Suspension Bridge** | [R] | The real 1866 span to Covington — distinct from Newport's three bridges further east. | G3 gateway; light touch only, Kings' secondary ground stays off-map. |

### Over-the-Rhine (OTR Syndicate)

| P | Location | Tag | Description | Gameplay |
|---|----------|-----|-------------|----------|
| P1 | **Uhlrich's** (clubhouse) | [F] | A shuttered 19th-century lager brewery building on the OTR core's edge — brewhouse and lagering cellars dark since long before '95, exactly the kind of real building stock the neighborhood's German-brewing heyday left behind everywhere. The Syndicate uses the surface floors; the real, half-forgotten lagering tunnels beneath the neighborhood are their actual escape network. | Maps to **TurfNode_OTRAlley** (§6). Tunnel network extends "know the back streets better than the cops" literally underground — a second layer beneath the alley chase routes (§5). |
| P1 | **Findlay Market** | [R] | The real public market, continuously operating since 1855 — still open and functioning in 1995 despite the neighborhood around it. | Daytime civilian anchor (keeps OTR reading as lived-in, same role Oyler School plays in Price Hill); info-hub NPC potential; the one place both factions' civilians overlap without trouble. |
| P1 | **Music Hall & Washington Park** | [R] | The real 1878 concert hall and its adjacent park — a genuinely grand building standing amid the neighborhood's decline. | Vista/landmark; night lighting anchor; incongruous-grandeur beat, same function Union Terminal plays for Queensgate. |
| P2 | **The alley grid** | [F/generic] | OTR's dense back-alley network behind the Vine St storefronts — the literal subject of the faction's own canon description. | Direct build target for TurfNode_OTRAlley's existing Race captureType; hit-and-run ambush terrain matching Syndicate combat style exactly. |
| P3 | **Vine St storefront row** | [R street, F businesses] | Mixed occupied/vacant Italianate storefronts along the spine. | Fence/contact NPC potential; the visible face of "poor but lived-in." |

**Hero-building budget:** 8 P1 uniques across both factions (Sky Garage, Fountain Square, the overpass terrain, Riverfront Stadium, Uhlrich's, Findlay Market, Music Hall/Washington Park as one entry) — proportionate to covering two full primary territories in one doc, larger than Queensgate's deliberately small budget but not padded past what two factions' real ground needs. Kits: downtown high-rise/office kit, OTR Italianate rowhouse/storefront kit (period-vacant and period-occupied variants), brewery-industrial kit (shared with Queensgate's industrial-brick kit where plausible).

---

## 5. Gameplay points of interest

### Chokepoints
| Where | Why it works |
|-------|---------------|
| **Central Parkway crossings** | Every route between the two factions' ground funnels through a handful of crossings over the old canal bed — natural border checkpoints. |
| **The Sky Garage's access gate** | One corporate-badge entrance — the most controlled, least "gang" chokepoint in the game, deliberately. |
| **Uhlrich's tunnel mouths** | Multiple hidden entrances to the same underground network — a chokepoint that's actually a trap for anyone who doesn't already know where they lead. |
| **OTR's alley mouths** | Dozens of narrow entrances off Vine St — favors ambush over pursuit, exactly per Syndicate canon. |
| **The Skywalk stairheads** | Foot-only funnels between street level and the elevated walkway — dismount chokepoints one story up. |
| **Government Square at night** | Wide open, well-lit, and empty — a chokepoint by absence: nowhere to hide, everywhere to be seen. |

### Sight lines / overwatch
| From | Sees |
|------|------|
| Any downtown high-rise rooftop | The whole CBD grid and the riverfront beyond it. |
| Music Hall's steps | The length of Washington Park and toward Vine St. |
| Mount Adams (if built) | The classic Cincinnati basin vista — downtown, the riverfront, both banks — same "money looking down" role Newport gave Fort Thomas. |
| Uhlrich's roof | OTR's alley grid and the Central Parkway seam. |
| The Skywalk | Street-level Downtown traffic from one story up. |

### Natural chase routes
1. **The private circuit:** a clean, fast loop through the empty downtown grid at night — the Saints' signature encounter, precision pack tactics per canon.
2. **The seam crossing:** Vine St or any Central Parkway crossing — the one route that visibly changes character mid-chase, clean towers to crowded alleys in one block.
3. **Alley-and-vanish:** OTR's back-alley grid — hit, run, disappear, exactly the Syndicate's canon combat style, not a circling arena.
4. **The tunnel drop:** Uhlrich's cellars into the old lagering tunnels — a literal underground escape layer, unique to this district.
5. **Skywalk run:** foot-only escape one level above a downtown chase — dismount required, cars/bikes can't follow.
6. **The bridge choice:** riverfront hub south to the Newport bridges or west to Roebling — same "which bridge" decision-at-the-fork logic the Newport doc already established, now from the Ohio side.

### Stakeout spots
Fountain Square (who's meeting who downtown), Music Hall steps (Vine St traffic), Findlay Market (OTR's actual daytime crowd), the Skywalk (street level from above), Uhlrich's roof (the alley grid and the seam).

---

## 6. Systems tie-ins (SUGGESTIONS — nothing wired; needs its own pass)

- **TurfNode_DowntownOverpass [exists, mapped onto here]:** live-checked before writing — position (0,0,-70), description already reads "A Neon Saints stunt run across the Downtown overpasses," `captureType` Stunt (fits the Saints' precision/coordination canon with zero changes needed), `startingFaction` currently unassigned/neutral — same pre-existing gap the other original nodes carry, not new, not fixed by this doc.
- **TurfNode_OTRAlley [exists, mapped onto here]:** position (60,0,60), description already reads "A narrow alley in Over-the-Rhine, controlled by the OTR Syndicate," `captureType` Race (fits "alley-runners" directly), `startingFaction` also currently unassigned/neutral.
- **The corporate-backing thread (§1): DECIDED 2026-08-15.** NeonSaints.asset's own "corporate-backed" description is now tied directly to the laundering pipeline: the Sky Garage is a commercial real estate shell company/title agency front, buying up downtown commercial strips and multi-family units and mixing illicit cash into legitimate property flips — the clean/output end of the same operation whose cash-generation end is the Queensgate Frontage's construction/paving/demolition contractor front (see `LevelDesign_Queensgate_1995.md` §1/§6). Still open for a later pass: the shell company's name, the exact chain connecting the two locations in-fiction, and whether/how the Neon Saints themselves know they're a laundering asset vs. just a bought-and-paid-for tenant.
- **Phantoms adjacency, not built here:** TurfNode_AbandonedSubway ("the Phantoms' lair in the abandoned Cincinnati subway tunnels beneath Central Parkway," `startingFaction=Phantoms`, already assigned) sits physically under this doc's own Central Parkway seam. Deliberately not redefined or expanded — Phantoms' subway is its own listed future doc. **Worth flagging:** PhantomsAsset's `secondaryTerritory` is listed as **Lower Price Hill**, which reads slightly differently than the Price Hill doc's own text ("Phantoms: no presence here... at most a watched rail spur") — not a contradiction this doc needs to resolve, just noting the canon field plainly since it surfaced while researching this doc.
- **Heat origin:** Cincinnati Police District 1 historically covers the downtown/OTR core — plausible heat-spawn origin, but flagging that this doc doesn't have a verified exact address the way Price Hill confidently cites District 3's, so treat the precinct's exact location as unconfirmed until someone checks it, not as pinned fact.
- **Mount Adams / Pendleton / Covington:** all three kept intentionally light (§3d, §3e, G3) — same restraint pattern as every companion doc's secondary-territory treatment. Any of the three could get its own expansion pass later without conflicting with anything built here.
- **Downtown-at-night as a system:** the Saints' "private circuit" only works as a gameplay space if Downtown is authored to actually empty out after a certain hour — a time-of-day/witness-density system (civilian NPC counts dropping sharply post-5pm) would make the thesis playable, not just descriptive. Flagging as a suggestion; not a small system to bolt on casually.

---

## 7. Period accuracy — 1995 checklist

- **Over-the-Rhine in 1995 is pre-revitalization** — decades before the 2010s+ wave of investment the neighborhood is known for today. In '95 it reads as genuinely poor and disinvested, not "up and coming." Same tone guardrail as Price Hill's Lower Price Hill: hard and struggling, not a wasteland, not a punchline.
- **The canal-to-Rhine etymology is real history**, not invented flavor (§1) — safe to use directly in dialogue/signage.
- **The Skywalk system** was real 1970s–90s downtown Cincinnati infrastructure, still active in 1995.
- **Skyline consistency:** Carew Tower tallest (no Great American Tower until 2011), Riverfront Stadium on the shore, Roebling Suspension Bridge — same facts the Price Hill and Newport docs already establish; this is simply the district where they physically are, not another vista of them.
- **Findlay Market** has operated continuously since 1855 — safe to treat as fully open and functioning in '95.
- **Music Hall**, opened 1878, is real and still the symphony/opera home in 1995.
- **No cell phones.** Payphones: Fountain Square, Findlay Market, Government Square, a diner on Vine St.
- **Radio/TV:** WEBN, Reds/Bengals talk (Riverfront Stadium hosts both in this era).
- **Tone guardrails:** Downtown's emptiness-after-dark is corporate/institutional, not decayed — clean and quiet, not abandoned. OTR's poverty is real and specific to this period; don't dress it as either a ruin or a punchline.

---

## 8. Blockout notes for the build

1. **Central Parkway is the level's spine feature.** Build the seam first — it's what makes the two factions' halves read as genuinely different places one street apart.
2. **Downtown needs a day/night witness-density plan before its core mechanic works** (§6) — the empty-circuit thesis is authored, not automatic; block out the geometry, but flag the day/night system as its own follow-up.
3. **OTR's alley grid should be denser and narrower than Downtown's blocks** — the contrast in street width alone should telegraph "you just crossed the seam" before any signage does.
4. **Uhlrich's tunnels need collision care**, same category of note as Price Hill's incline cut — an underground network needs real, tested colliders before it's fun rather than confusing.
5. **The riverfront hub (G2) shouldn't be built as new geometry redefining Waldvogel Viaduct or the Newport bridges** — it's a landing/convergence point for spans the other docs already own; build the Cincinnati-side approach, not the bridges themselves.
6. **Kits:** reuse Price Hill's Italianate/storefront kits where period and building type genuinely match OTR's stock, rather than authoring near-duplicates from scratch.
7. **Existing scene note:** same caveat as every companion doc — TurfNode_DowntownOverpass (0,0,-70) and TurfNode_OTRAlley (60,0,60) are both abstract placeholder positions, not a real coordinate plan. Relocate both when the district gets one.
