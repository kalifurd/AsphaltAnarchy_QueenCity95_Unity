# PRICE HILL / DELHI TOWNSHIP — LEVEL DESIGN REFERENCE
**Asphalt Anarchy: Queen City '95 — Player home district / starting area**
**Setting: Cincinnati west side, 1995. Status: design reference, not yet built.**

---

## 0. How to read this document

- **[R]** — real place/street, real name, use as-is (civic landmarks, streets, parks, churches, schools, infrastructure).
- **[R*]** — real place, name lightly fictionalized. Used for private businesses we attach gang activity to — we don't hang crime stories on real family businesses. The building/location is real; the name and story are ours.
- **[F]** — fictional, but anchored to real building stock that existed in the area (nothing invented that couldn't plausibly be there in 1995).
- Geography is **compressed ~5:1** like the rest of the map. Keep the *topology* (what connects to what, what's above what) exact; scale distances freely.
- Supersedes the earlier open flag proposing Price Hill/Delhi as a neutral/contested TurfNode: this district is now **PlayerCrew home turf and the game's starting area**. Turf suggestions in §6.

---

## 1. Orientation & topology

Price Hill sits on **bluffs west of the Mill Creek valley**. Downtown is east across the valley; the Ohio River bends along the southern base. The district is a **layer cake of four tiers** — this vertical structure is the whole identity of the level and must survive compression:

| Tier | Area | Elevation | Character |
|------|------|-----------|-----------|
| 1 — River | Sedamsville / Riverside strip (River Rd) | Lowest | Narrow river hamlet strip, marinas, rail line |
| 2 — Flats | Lower Price Hill ("8th & State") | Low | Industrial bottoms, poorest, hemmed in by rail yards |
| 3 — Crest | East Price Hill (Warsaw Ave) → West Price Hill (Glenway Ave) | High | Dense pre-war hilltop neighborhoods |
| 4 — Suburb | Delhi Township (Delhi Pike) | High, rolling | Greenhouses, ranch houses, semi-rural |

**Natural boundaries** (all real):
- **East:** Mill Creek valley + Queensgate rail yards — a wide industrial moat between Price Hill and downtown. Crossed only by viaducts.
- **South:** the Ohio River.
- **Between tiers:** steep wooded hillsides, cut by a handful of climbing roads and public stairways.
- **West:** the district fades into Delhi green space — soft boundary toward the outer map.

### Schematic (not to scale — topology only)

```
        (N: Queen City Av → Fairmount/Westwood → I-74 corridor → Hamilton)
                                          |
  (W: Glenway → Western Hills            |        MILL CREEK VALLEY
      → I-275 west leg)                  |     [Queensgate rail yards]
        \                                |               ||
   WEST PRICE HILL ——— Warsaw Av ——— EAST PRICE HILL ====||=== 8th St Viaduct ⇒ QUEENSGATE
   (Glenway Av spine)              (crest, overlooks)    ||                      / downtown
        |         \                    |        \ incline cut (bike-only)
   Rapid Run Pk   Cleves Warsaw Pk   Mt Echo Pk   \      ||
        |               |              |        LOWER PRICE HILL (8th & State)
     Covedale       DELHI TWP       Elberon Av        |
                    (Delhi Pike)        \          State Av
                     |       \           \            |
                    MSJ    Anderson    SEDAMSVILLE == River Rd (US 50) == Waldvogel Viaduct ⇒ downtown riverfront
                    college  Ferry Rd       |
                               |       Boldface Pk
                        ANDERSON FERRY ~~~~ Ohio River ~~~~ (KY side → airport → Newport loop)
```

---

## 2. Road network

### Arterials (drivable spines — build these first)

| Road | Tag | Runs | Role |
|------|-----|------|------|
| **W. 8th Street** | [R] | Lower Price Hill flats → steep climb → East PH crest → West PH → Delhi edge | The backbone. The "8th Street hill" grade between Tier 2 and Tier 3 is a signature climb. |
| **Warsaw Avenue** | [R] | East Price Hill crest, east–west | Main street of East PH: storefronts, churches, the police district house. Merges into Glenway heading west. |
| **Glenway Avenue** | [R] | West Price Hill → Covedale → Western Hills Plaza | The stable commercial spine. Chili parlor, theater, parish blocks. Western out-connector. |
| **State Avenue** | [R] | River Rd up through the Lower PH industrial flats to W. 8th | The vertical of the bottoms. Has a **rail grade crossing** near River Rd (train-blockable — see §4). |
| **River Road (US 50)** | [R] | Waldvogel Viaduct → Sedamsville → Riverside → Anderson Ferry → (west, Sayler Park off-map) | Flat, fast, river-level drag. The district's best pure racing road. |
| **Elberon Avenue** | [R] | Winds from Warsaw Ave down the hillside to Sedamsville / River Rd | Signature descent: tight, steep, tree-shrouded. Chase road. |
| **Delhi Pike / Delhi Avenue** | [R] | West PH edge → Delhi Township center → west | Suburban spine. Greenhouses, IGA strip. |
| **Anderson Ferry Road** | [R] | Drops off the Delhi bluffs to the ferry landing on River Rd | Steep rural descent ending at the river. |

### Secondary streets (kit-bashed housing grid hangs off these)
Sunset Av, Overlook Av, Purcell Av, Considine Av, Grand Av, Rapid Run Rd, Cleves Warsaw Pike, Queen City Av, Matson Pl, Hatmaker St, Neave St, Burns St, St. Michael St — all **[R]**. Use real names on signage; exact alignments are free.

### Gateways — how the district connects outward

Price Hill has **no interstate through it** (period-accurate). Everything funnels through four controllable gateways — which is exactly why it works as defensible home turf:

| # | Gateway | Tag | Leads to | Notes |
|---|---------|-----|----------|-------|
| G1 | **W. 8th Street Viaduct** | [R] | East over the rail yards → **Queensgate district** (existing TurfNode_QueensgateYard / Rust Barons) → downtown/OTR | THE eastern gate. Long, exposed, no exits mid-span. |
| G2 | **Waldvogel Viaduct** (6th St Expressway) | [R] | From River Rd → downtown riverfront → Newport bridges | Southeastern gate, river-level. |
| G3 | **Anderson Ferry** | [R] | Across the Ohio to the Kentucky side (toward the airport; back-door route into KY, eventually Newport loop) | Real ferry, running since 1817. Timed crossing — see §6. |
| G4 | **Glenway west / Queen City Av north** | [R] | Western Hills → I-275 west leg; Fairmount → I-74 corridor → Hamilton | The suburban exits toward Highway Kin country. |

### Vertical connectors (between tiers)

| Connector | Tag | Tiers | Notes |
|-----------|-----|-------|-------|
| 8th Street hill | [R] | 2→3 | Main climb, S-curved grade |
| State Ave | [R] | 1→2 | Industrial climb past the barrel yard |
| Elberon Ave | [R] | 3→1 | The long descent to Sedamsville |
| Anderson Ferry Rd | [R] | 4→1 | Delhi bluffs to ferry |
| **Price Hill Incline right-of-way** | [R] | 2→3, **motorcycle-only** | The incline (1874–1943) is long gone; its overgrown cut between W. 8th at the bottom and Matson Place at the crest survives as a dirt scar. In-game: a steep bike-only dirt shortcut rivals and cops in cars can't follow. Player-knowledge route — you grew up here. |
| Public stairways | [R] | all | Cincinnati's real hillside steps. Foot-only: dismount escapes, no vehicles. 3–4 placed instances. |

---

## 3. Sub-district character sheets

### 3a. Lower Price Hill — "8th & State" (Tier 2)
The roughest ground in the district and the club's home soil. Urban-Appalachian neighborhood — families up from Kentucky and West Virginia since the '40s — packed into brick rowhouses between the hillside and the rail yards. 1995 reality: highest poverty in the city, industry leaving, but a real community with deep loyalty. **Tone: hard, loyal, smells like diesel and creek water. Not a wasteland — people live here and look out the window.**

### 3b. East Price Hill — the crest (Tier 3 east)
Dense Italianate hilltop streets around Warsaw Ave, built for the incline era. German-Catholic old guard aging out, vacancy creeping in block by block, but Warsaw still functions: pawn shop, barbershop, storefront church, District 3 police house. The overlooks along the eastern brow give the postcard view of downtown. **Tone: faded grandeur, block-by-block variance — one street kept, the next boarded.**

### 3c. West Price Hill / Covedale (Tier 3 west)
The stable side. Elder High School parish families, foursquares and bungalows, Friday fish fries, the chili parlor open late on Glenway. Working-class but holding. **Tone: the neighborhood the player's family wanted to move up to and never did.**

### 3d. Sedamsville / Riverside — the river strip (Tier 1)
A one-street hamlet pinched between the hillside and the river. Rowhouses, a closed hillside church, marinas and boat clubs. Pete Rose grew up on Braddock Street here — 1995 flavor: locals still talk about it, bitterly or proudly depending on the bar. **Tone: forgotten, foggy, water-level.**

### 3e. Delhi Township (Tier 4)
Sudden suburbia: ranch houses, ballfields, and the greenhouses — Delhi was the "Floral Paradise of Ohio," acres of family-run glass. Mount St. Joseph college sits quiet on the river bluffs. **Tone: ten minutes and a world away; where the club rides feel loudest because it's so quiet.**

---

## 4. Location list

Priority tiers: **P1** = must-build hero locations (unique models). **P2** = identity locations (unique or heavily-dressed kit). **P3** = dressing (kit-bash).

### Lower Price Hill

| P | Location | Tag | Description | Gameplay |
|---|----------|-----|-------------|----------|
| P1 | **The Incline House** (clubhouse) | [F] | The club's home: a brick former incline-era powerhouse/warehouse at the foot of the incline cut, off State Ave. Barrel-vaulted main hall, fenced yard for bikes, rooftop with a clear view over the rail yards. | Player home base. Safehouse spawn. hasSafehouse=true turf node (§6). Rooftop = rail-yard stakeout. |
| P1 | **St. Michael the Archangel** | [R] | Hulking Gothic church on St. Michael St, parish dwindling in '95. Towers visible from the whole flats. | Landmark/wayfinding. Sanctuary interior scene potential. |
| P1 | **Crown City Barrel Co.** | [R*] | Acres of stacked steel drums and loading docks in the State Ave flats (the real barrel yard was a major LPH employer in this era). | Maze arena: on-foot fights, bike slaloms, catwalk overlooking Queensgate yards. |
| P2 | **Meyer's Carryout** — 8th & State | [F] | Corner store at the neighborhood's crossroads. Barred windows, lottery signs, payphone outside. | Info-hub NPC, mission board flavor, buy point. |
| P2 | **The Bluegrass Room** | [F] | Urban-Appalachian bar a block off 8th. Jukebox, deer head, back room. | Club's drinking spot; fence/contact NPC; brawl scene. |
| P2 | **Oyler School** | [R] | The neighborhood school on Hatmaker St. Schoolyard, chain-link. | Daytime civilian anchor — keeps LPH reading as lived-in, not a ruin. |
| P3 | **Valley Iron & Salvage** | [F] | Scrap row / chop shop under the viaduct approaches. | Bike upgrades/parts vendor tie-in; stolen-bike drop. |
| P3 | 8th St Viaduct underdeck | [R] | Pillared shadow-land beneath the eastern gate. | Camps, hidden collectibles, ambush spawn. |

### East Price Hill

| P | Location | Tag | Description | Gameplay |
|---|----------|-----|-------------|----------|
| P1 | **Incline overlook** (Price Hill House site / Olden View) | [R] | The crest of the dead incline at Matson Place. Best skyline view in the game: Carew Tower, Roebling Bridge, Riverfront Stadium (1995 skyline — see §7). | Cutscene/meet spot. Top of the bike-only incline cut. Vista set-piece. |
| P1 | **Mt. Echo Park** | [R] | Big brow-of-the-hill park: stone pavilion, winding internal park roads, overlooks of the river bend and the KY shore. (Name synergy with the game's Echo system is free flavor — the park is real.) | Race finish, duel ground, pavilion meets, second grand vista. |
| P1 | **Warsaw Ave block** (3200s) | [R street, F businesses] | The functioning heart of East PH: **Warsaw Loan** pawn shop [F], barbershop [F], storefront church [F] — and **CPD District 3** [R], the real police district house at 3201 Warsaw. | Heat system spawn point sits *inside* home turf — cops are neighbors here, not invaders. Pawn shop = fencing. |
| P2 | **St. Lawrence Corner** | [R] | Church + triangle junction where W. 8th meets Warsaw. Bells, steps, bus stop. | Navigation anchor between the two crest spines. |
| P2 | **The Considine vacants** | [F] | A half-burned row of boarded Italianates off Considine Ave — the kind of block East PH was starting to lose in '95. | Rival scout nest; on-foot clear-out; overwatch on Warsaw. |
| P3 | **Dempsey Playground** | [R] | Ballcourts and a field. | Neutral ground; civilian NPCs; pickup-game flavor. |
| P3 | Boarded supermarket on Warsaw | [F] | Dead mid-size grocery, cart corral rusting. | Swap-meet/black-market interior event. |

### West Price Hill / Covedale

| P | Location | Tag | Description | Gameplay |
|---|----------|-----|-------------|----------|
| P1 | **Elder High School + "The Pit"** | [R] | The west side's Catholic powerhouse and its sunken stadium. Friday nights in fall: lights, crowds, traffic. | Scheduled crowd event; high cop presence; player backstory anchor (everybody's cousin played here). |
| P1 | **Crest Hill Chili** | [R*] | 24-hour chili parlor on Glenway (modeled on the real beloved Glenway chili parlour, renamed). Window booths, payphone by the door. | Unofficial truce ground — no colors trouble inside. Meet-the-contact scenes. Late-night save point. |
| P2 | **Covedale Theater** | [R] | Single-screen 1947 movie house, working marquee on Glenway. | Landmark; marquee text = period gags; night light source. |
| P2 | **Western Hills Plaza** (district edge) | [R] | Big 1954 open strip plaza at the western gateway. | Parking-lot meets, drag launches, G4 gateway marker. |
| P3 | **Rapid Run Park** | [R] | Lake and ravine park with internal road. | Scenic ride, dead-drop spot. |
| P3 | St. William parish block | [R] | Glenway church + school block. | Civilian anchor, fish-fry event flavor. |

### Sedamsville / Riverside

| P | Location | Tag | Description | Gameplay |
|---|----------|-----|-------------|----------|
| P2 | **Boldface Park & Sedamsville rows** | [R] | Tucked river hamlet under the hill. Braddock St is Pete Rose's boyhood street — dialogue flavor only. | Quiet haven; hideout when heat is high; foot of Elberon descent. |
| P2 | **Fischer's Marine** | [F] | Marina/boat club on the Riverside stretch. | Smuggling dock — river route for contraband; night mission set. |
| P3 | **Our Lady of Perpetual Help ruin** | [R] | The closed hillside church above Sedamsville (real; closed late '80s). Striking silhouette. | Creepy neutral POI, collectible, sightline over River Rd. |

### Delhi Township

| P | Location | Tag | Description | Gameplay |
|---|----------|-----|-------------|----------|
| P1 | **Witterhaus Greenhouses** | [F name, R trade] | Acres of family-run glass houses off Delhi Pike — Delhi's real signature industry. | Night chase through glass = spectacular hazard; hide-the-stash mission. |
| P2 | **Anderson Ferry landing** | [R] | Ramp, small bait/snack shack, ferry queue. | G3 gateway. Timed-crossing mechanic (§6). Stakeout the queue. |
| P2 | **Delhi Pike strip** | [R street, F businesses] | IGA, hardware, dairy bar. Suburban contrast block. | Shows what "out" looks like; light cop presence, heavy witness presence. |
| P2 | **Mount St. Joseph college** | [R] | Quiet bluff-top campus on Delhi's river edge. | Scenic roads; neutral zone; overlook of the river approach. |
| P3 | **Delhi Park + water tower** | [R] | Ballfields under the landmark water tower. Real-world color: the Delhi Skirt Game, the firefighters' charity softball spectacle, ran every August — one-line NPC flavor. | Landmark/wayfinding for Tier 4; summer crowd event. |
| P3 | **Embshoff Woods** | [R] | Wooded township park on the bluff edge. | Trail riding, buried-stash spot. |

**Hero-building budget:** 10 P1 uniques. Everything else from four housing kits: LPH brick rowhouse, EPH Italianate storefront, WPH foursquare/bungalow, Delhi ranch. Church kit ×2 variants covers the P2/P3 parishes.

---

## 5. Gameplay points of interest

### Chokepoints
| Where | Why it works |
|-------|--------------|
| **8th St Viaduct (G1)** | Long span, no exits — whoever holds both ends owns the eastern approach. Classic roadblock/run-the-gauntlet site. |
| **Waldvogel Viaduct (G2)** | Same logic at river level; cop favorite for spike traps at high heat. |
| **State Ave rail crossing** | Real grade crossing near River Rd. Scriptable freight train = timed gate: cuts pursuit or cuts YOUR escape. |
| **Elberon descent** | Steep, blind, tree-walled curves — a skilled local drops car pursuit here; one bad line drops you off the hillside. |
| **8th Street hill S-curves** | The main climb: heavy bikes vs. gravity, ambush from the stairway landings. |
| **Anderson Ferry queue** | The only southern exit is a boat that leaves when it leaves. Make the ferry or fight on the ramp. |
| **Incline cut** | Bike-only. The ultimate local-knowledge escape — but it spits you out at exactly one place, top or bottom, and anyone who knows that can be waiting. |

### Sight lines / overwatch
| From | Sees |
|------|------|
| Incline overlook (Matson Pl) | Whole Mill Creek basin: both viaducts, the rail yards, downtown skyline |
| Mt. Echo pavilion | River bend, Sedamsville strip, KY shore |
| Clubhouse rooftop | Queensgate yards (Rust Barons' node) and the G1 viaduct approach |
| St. Michael's towers | All of the LPH flats |
| Considine vacants (upper floors) | Warsaw Ave including District 3's front door |
| Delhi water tower | Tier 4 and the ferry road |
| OLPH church ruin | River Road traffic both directions |

### Natural chase routes
1. **River run:** Waldvogel → River Rd flat-out → ferry ramp finish (or blow past toward Sayler Park map edge).
2. **The drop:** Warsaw → Elberon descent → Sedamsville → River Rd. Vertical chase, surface changes.
3. **Main street stop-and-go:** Warsaw Ave with cross-traffic, buses, and a police house mid-route.
4. **Glass run:** Delhi Pike → through the greenhouse lanes → Anderson Ferry Rd descent. Property damage spectacle.
5. **Local-knowledge loop:** 8th St hill up → incline cut down → State Ave → viaduct underdeck. Only the player's crew routes this cleanly.
6. **Barrel maze:** into Crown City Barrel at speed — drum stacks as moving hazards.

### Stakeout spots
Clubhouse roof (rail yards), Considine vacants (Warsaw/District 3), chili parlor window booth (Glenway traffic), ferry queue (everything leaving south), OLPH ruin (River Rd), Mt. Echo pavilion (meets you're not invited to).

---

## 6. Systems tie-ins (SUGGESTIONS — nothing here is wired; needs its own pass)

**TurfNodes (proposed, not created):**
| Node | Faction | captureType | Notes |
|------|---------|-------------|-------|
| TurfNode_InclineHouse | PlayerCrew (start-owned) | — | The clubhouse. hasSafehouse=true, safehouseSpawnPoint at the yard. Player's anchor node. |
| TurfNode_EighthAndState | PlayerCrew (start-owned) | CombatGauntlet | The crossroads. Losing it = losing the flats. |
| TurfNode_WarsawAve | Neutral (no startingFaction) | Race | Contested main street — the "none" starting-faction case the new field supports. |
| TurfNode_AndersonFerry | Neutral | Race | Gateway prize; whoever holds it taxes the southern exit. |

- **Heat system:** District 3 on Warsaw [R] is the natural police spawn origin for this district — pursuit begins *inside* home turf, which is thematically right for Price Hill.
- **Queensgate adjacency:** G1 viaduct physically links home turf to the existing Rust Barons node — natural first-conflict corridor.
- **Highway Kin brush:** their outer-belt patrols touch G4 (Cleves Warsaw / Glenway west) — occasional convoy sightings, not turf overlap.
- **Anderson Ferry:** scripted timed crossing (real ferry, ~every 15 min in-fiction). Board = safe passage + heat decay during crossing; miss it = fight or reroute. KY landing connects toward the airport side of the loop, giving a back-door approach to Kentucky Kings territory.
- **Phantoms:** no presence here — their subway node is downtown. At most, a watched rail spur in the yards visible from the clubhouse roof (flavor, not turf).

---

## 7. Period accuracy — 1995 checklist

- **Skyline from the overlooks:** Carew Tower is the tallest (no Great American Tower until 2011). Riverfront Stadium (Reds/Bengals) sits on the river. Roebling Suspension Bridge. Union Terminal's dome to the north across the valley.
- **No cell phones.** Payphones are gameplay: Meyer's Carryout, chili parlor door, ferry landing, Warsaw Ave, Delhi IGA.
- **The incline is a ruin, not a district brand.** Nobody in 1995 says "Incline District" — that's later marketing. Locals say "the top of the hill," "8th & State," "the Pit," "down Delhi."
- **Radio/TV flavor:** WEBN rock radio, Reds talk (strike hangover from '94–95 — fans are bitter, useful NPC chatter).
- **Transit:** Metro buses on Warsaw and Glenway [R]; essentially none in Delhi.
- **Police:** CPD District 3, 3201 Warsaw Ave [R] — period-correct location.
- **Tone guardrails:** Lower Price Hill and East Price Hill were genuinely high-poverty, high-crime in this era — play it straight, not cartoonish. These are communities under pressure, with kids on stoops and grandmothers at St. Michael's, not a bombed-out free-fire zone. West PH/Delhi contrast is what makes the rough parts read.

---

## 8. Blockout notes for the build

1. **Terrain first.** The four tiers and their five climbing roads are the level. Get elevations blocked before any building placement — every chase and sightline in §5 depends on the vertical.
2. **Compression:** keep tier-to-tier climbs long enough to feel earned (the 8th St hill should take meaningful seconds at speed). Flatten nothing.
3. **Gateways G1–G4** are the district's district-loading/connection points to Queensgate, downtown/Newport, KY-side, and the western/northern outer map respectively.
4. **Kits:** 4 housing kits + 2 church variants + 1 storefront kit cover all P2/P3. 10 unique P1 heroes.
5. **The incline cut needs collision care** — bike-only means physically blocking cars (bollards at both ends, real-world plausible).
6. **Rail is live scenery:** freight movements in the Queensgate yards (visible from clubhouse roof) and the State Ave crossing train are ambient systems worth their own small pass.
7. **Existing scene note:** current TurfNode positions in QueenCity_Main use abstract coordinates (±60–80 unit range). This district will need a real coordinate plan before its proposed nodes (§6) are placed — don't inherit the placeholder spacing.
