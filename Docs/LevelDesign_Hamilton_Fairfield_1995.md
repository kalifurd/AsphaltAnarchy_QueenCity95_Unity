# HAMILTON / FAIRFIELD (BUTLER COUNTY) — LEVEL DESIGN REFERENCE
**Asphalt Anarchy: Queen City '95 — Highway Kin MC western territory**
**Setting: Butler County, Ohio, 1995. Status: design reference, not yet built.**
**Companion docs:** `LevelDesign_PriceHill_Delhi_1995.md`, `LevelDesign_Milford_Batavia_1995.md` (same conventions). This is the **western half** of Highway Kin territory; the eastern half (Milford/Batavia) has its own doc.

---

## 0. How to read this document

- **[R]** — real place/street, real name, use as-is (civic landmarks, streets, parks, infrastructure).
- **[R*]** — real place, name lightly fictionalized (private businesses we attach club activity to).
- **[F]** — fictional, anchored to real building stock plausible for the area in 1995.
- Geography **compressed ~5:1**. Keep topology exact, scale distances freely.
- **TurfNode_Hamilton already exists** as Highway Kin's western anchor. This doc maps that node onto the district (§6) — it does **not** propose new turf placement.
- Hamilton is a real small city (~62k in 1995), so this district reads denser than Milford/Batavia but stays proportional — same location count (~20), more of it vertical brick.

---

## 1. Orientation & district thesis

**The thesis: the company town after the companies.** Hamilton was a working industrial city — "the Safe Capital of the World," paper mills on the river, foundries along the rail line. By 1995 the safe works are dying, half the mill row is dark, and the city has officially spelled its name **"Hamilton!"** since 1986 — an exclamation point bolted on while the jobs left. Meanwhile **Fairfield**, directly south, is booming: new subdivisions, a carnival-sized grocery, strip retail down Dixie Highway. The Kin's western chapter are the men those mills laid off — many of them the same Appalachian migration stock as Lower Price Hill's families, recruited north to Hamilton's factories a generation ago. **Fairfield's prosperity is a moat the Kin cross between their ground and the loop.**

Structure: **three north–south strands and a river**, converging on the mill city at the top, with the I-275 loop across the bottom:

| Strand | What | Character |
|--------|------|-----------|
| East strand | **SR 4 / Dixie Highway** — loop → Fairfield strip → Lindenwald → downtown Hamilton | The strip: car lots, chains, stoplights, witnesses. The watched way in. |
| Middle strand | **US 127 / Pleasant Avenue** — the old residential pike, parallel to Dixie | Quieter, older, house-lined. The known way in. |
| West strand | **SR 128 / Hamilton–Cleves Rd** — the west-bank river road through Ross | Gravel pits and river flats. The back way. |
| The seam | **Great Miami River + Miami Conservancy levees** | High flood levees line the river through the city — gated crest paths, two downtown bridges. |
| The lid | **Downtown Hamilton / the mill row / the CSX main line** | County seat, paper mill steam, and an active freight main line cutting the east side at grade. |

### Schematic (topology only, not to scale)

```
 (N fade: SR 4 toward LeSourdsville's fading amusement park,        (NE: SR 129 two-lane through
  Middletown, the rest of the Rust Belt — off-map)                   Liberty Twp/Bethany to I-75 —
                          |                                          the map's north edge; no Union
                          |                                          Centre boom yet in '95)
                 ┌─── HAMILTON! ────────────────┐
   Champion mill │  courthouse / High St        │══ CSX main line (at-grade crossings)
   row, west bank│  High–Main & Black St bridges│    North End industry → THE VAULT (clubhouse)
   ROSSVILLE     │        GREAT MIAMI R.        │  German Village / Dayton Lane (faded Victorians)
        │        │      [MCD levees, gated      │  Butler Co. fairgrounds
   SR 128 river  │       crest paths]           │        │
   road (back way)│                             │   LINDENWALD (Kin blocks, The Third Shift bar)
        │        └──────────────────────────────┘        │
      ROSS                                        SR 4 Dixie Hwy      US 127 Pleasant Ave
        │                                         (the strip)          (the old pike)
   FERNALD [R — federal fence, no-go]                  │                    │
        │                                          FAIRFIELD ── the moat: new money, cameras, cops
   MIAMITOWN → I-275 west leg (G2)                     │
                                             FOREST FAIR MALL [R] — half-lit giant at the loop
                                                       │
                                        I-275 ══ G1 (→ city / Price Hill) ══ G3 (→ Milford half)
```

---

## 2. Road network

### Arterials

| Road | Tag | Runs | Role |
|------|-----|------|------|
| **SR 4 / Dixie Highway** | [R] | I-275 → Fairfield strip → Lindenwald → downtown Hamilton; continues north (fade) | The spine. A stoplight gauntlet through Fairfield's retail moat, then older and rougher block by block as it enters Hamilton. |
| **US 127 / Pleasant Avenue** | [R] | Parallel old pike through Fairfield into Hamilton's south side; southbound it strings toward Cincinnati's own Hamilton Avenue neighborhoods | Two cities, one old road — the surface-street link toward the city if you don't want the loop. |
| **SR 128 / Hamilton–Cleves Rd** | [R] | Down the Great Miami's west bank: Hamilton → Ross → Miamitown → I-275 west leg | The back way. River flats, aggregate pits, no cameras. This district's Round Bottom Rd. |
| **High St / Main St axis + High–Main Bridge** | [R] | East–west through downtown, across the river into Rossville | The city's front door and main river crossing. |
| **Black Street Bridge** | [R] | Second downtown river crossing | The swap option (§5). |
| **SR 4 Bypass** | [R] | Skirts Hamilton's east side | The bypass strand — faster, exposed, sparse. |
| **SR 129** | [R] | East out of Hamilton through Liberty Twp/Bethany to its real confirmed endpoint at **I-75, north of I-275** (two-lane in '95) | The district's north edge — see `RealGeography_Reference.md` §3/§7. Reads as a rural fade in-district, but the road itself is the map boundary, not a soft off-map trail. |
| **I-275** | [R] | The loop across the district's southern lip | Kin patrol ritual; the stitch to the Milford half (G3). |

### Secondary roads (real names for signage; alignments free)
North B St / South B St (the mill row), Fairgrove Ave, Eaton Ave, Millville Ave, Nilles Rd, Winton Rd, Ross-Hanover Rd, New Haven Rd — all **[R]**.

### Gateways — connections outward

| # | Gateway | Tag | Leads to | Notes |
|---|---------|-----|----------|-------|
| G1 | **SR 4 / Dixie at I-275** | [R] | The loop south → I-74/Colerain corridor → toward downtown/Price Hill; Forest Fair Mall squats beside the interchange band | The main gate — and the most-watched mile of the district. |
| G2 | **SR 128 south through Ross → Miamitown → I-275 west leg** | [R] | The western loop, and onward toward Price Hill's western approaches | The Kin's preferred quiet route: river road the whole way, one federal fence to respect (Fernald). |
| G3 | **I-275 eastbound** | [R] | The long ride around the loop to the Milford/Batavia half | Mirror of the Milford doc's G3 — the Outerbelt itself stitches the club's two halves together. |
| G4 | **SR 4 north** | [R] | Past the fairgrounds toward LeSourdsville's fading lakeside amusement park [R — operating but declining in '95] and Middletown — off-map | The Rust Belt continues; soft fade, not a wall. |

---

## 3. Sub-area character sheets

### 3a. Downtown Hamilton — the county's second fist
The Butler County Courthouse — a grand 1880s stone pile with a statue on top — plus jail, sheriff, and city hall, all within blocks of High Street's half-occupied storefronts. An insurance company tower [R-generic] is the one clean-shirt employer left downtown. Every few minutes a CSX freight drags across the east-side grade crossings and cuts the city in half. **Tone: civic marble over thinning commerce; the law is the biggest business in town.**

### 3b. The mill row & Rossville — west bank
Champion's paper mill [R — operating in '95, strictly neutral] still steams on North B Street: shift whistles, truck gates, sulfur-sweet air. Around it, the dead half of the industrial riverfront — including the bankrupt safe-works annex the Kin took over (§4). Across the High–Main Bridge, Rossville's old storefront blocks hang on. The flood levees rise between everything and the river. **Tone: one live mill keeping a dead row company.**

### 3c. Lindenwald — the south end
Hamilton's working-class southern neighborhood, shotgun houses and corner bars, bleeding into Fairfield at the city line. This is where the Kin's western families actually live — mill retirees, laid-off safe-makers, their kids. The Third Shift bar (§4) anchors it. **Tone: the human center of the chapter; porch lights and union cards nobody honors anymore.**

### 3d. Fairfield — the moat
Booming 1995 suburbia stacked along Dixie and Pleasant: new subdivisions in phases, strip plazas, a carnival-signed international grocery [R — keep strictly neutral, no crime attached] pulling traffic from three counties. Fairfield PD is well-funded, response is fast, and everybody has a phone by the register. **Tone: everything Hamilton was promised and Fairfield got.**

### 3e. The river road west — Ross and the fence
SR 128 down the west bank: gravel pits, corn flats, the crossroads hamlet of Ross. And then the district's hard edge: **Fernald** [R] — the shuttered uranium feed plant, production halted in '89, now a guarded federal cleanup site behind miles of fence. Even the Kin don't scrap there. **Tone: open country with one place you don't go.**

### 3f. The loop edge — Forest Fair
The giant mall at the district's southern lip [R] — opened '88, developer went under almost immediately, and by '95 it's a half-lit cathedral of vacancy with a full parking structure and a fraction of the shoppers. Decline isn't just the old economy here; the new one is failing too, which is the district's punchline. **Tone: brand-new ruin.**

---

## 4. Location list

Priority tiers: **P1** must-build hero (unique model), **P2** identity (heavily-dressed kit), **P3** dressing (kit-bash).

### Downtown Hamilton

| P | Location | Tag | Description | Gameplay |
|---|----------|-----|-------------|----------|
| P1 | **Butler County Courthouse block** | [R] | Courthouse, jail, sheriff, city hall, bail-bonds row [F] — the county-seat cluster, bigger and grander than Batavia's. | Heat origin (§6): Hamilton PD primary, sheriff secondary. Courthouse square standoff pinch. The statue on the dome is a wayfinding landmark. |
| P2 | **High Street storefronts** | [R street, F businesses] | Half-occupied retail blocks: pawn shop "Safe City Loan" [F], lunch counter [F], the insurance tower [R-generic] as the one polished facade. | Stop-and-go through the civic core; pawn = fencing; witnesses thin after 6 PM. |
| P2 | **CSX grade crossings** | [R] | The active freight main line crossing the east-side streets at grade — long trains, lowered gates, honest-to-god waits. | **Train-block script** (§6): the district's signature pursuit asymmetry. Time it right and the law waits three minutes; time it wrong and you do. |
| P3 | **German Village / Dayton Lane** | [R districts] | Faded Victorian streets — mansions gone to rooming houses by '95. | Dressing with grandeur; upper-window sightlines onto High St. |
| P3 | **Butler County Fairgrounds** | [R] | Grandstand and barns off SR 4/Fairgrove on the east side; fair each July. | Seasonal crowd event; off-season quiet business (lighter touch than Owensville's — that's the Milford half's venue). |

### Mill row & Rossville (west bank)

| P | Location | Tag | Description | Gameplay |
|---|----------|-----|-------------|----------|
| P1 | **The Vault** (clubhouse) | [F] | The Kin's western chapter house: the bankrupt **Herring Bros. Safe & Lock** annex [F — riffing Hamilton's real "Safe Capital" heritage without naming real firms], a brick works on the dead end of the mill row, hard against the levee. The intact walk-in vault is the war room; the loading dock holds the bikes. Club line: *"The Scales weigh it. The Vault keeps it."* | Highway Kin western home base. Maps to existing **TurfNode_Hamilton** (§6). Vault = save/stash room; roof = levee and river sightline. |
| P1 | **Champion mill row** | [R] | The operating paper mill on North B St — steam plume, shift whistles, truck gates — flanked by its dead neighbors. **Economy anchor, keep strictly neutral** (same rule as the Ford plant in the Milford doc). | Skyline landmark (the plume reads for miles); shift-change traffic event; the live/dead contrast IS the district thesis in one street. |
| P2 | **Rossville storefront blocks** | [R] | The west-bank old town across the High–Main Bridge. | Bridgehead pinch; quieter mirror of High St. |
| P2 | **The levees + crest paths** | [R] | Miami Conservancy District flood levees walling the river through the city, with gated gravel maintenance paths on the crests. | **Bike-only route** (this district's incline-cut/rail-trail analog): bollarded gates pass a bike, stop a cruiser. High, exposed, fast — the local-knowledge escape. |
| P3 | **Dead works kit** | [F] | Two or three shuttered factory shells along B St (safe works, foundry, box plant — signage varied). | Interior fights, stash floors, roof routes onto the levee. |

### Lindenwald

| P | Location | Tag | Description | Gameplay |
|---|----------|-----|-------------|----------|
| P2 | **The Third Shift** | [F] | Corner bar by the old mill gates that used to open at 7 AM for night shift getting off. The shifts are gone; the bar stayed. The Kin's public-facing bar, mirror of the Relay. | Info hub, brawl scene, first-contact missions. The 7 AM license is the flavor. |
| P2 | **Lindenwald blocks** | [R] | Shotgun houses and bungalows where the chapter's families live — this district's humanizer, same role as the Milford half's trailer court. | Homes, not hideouts; civilian anchor; consequences live here. |
| P3 | **Dixie car-lot row** | [F/generic] | Used-car lots and dead motor courts where Lindenwald's Dixie frontage shades into Fairfield's. | Plate-swap and vehicle-fence flavor; the seam between old city and new suburb. |

### Fairfield (the moat)

| P | Location | Tag | Description | Gameplay |
|---|----------|-----|-------------|----------|
| P2 | **Dixie Highway strip** | [R road, F/generic tenants] | Fairfield's booming retail gauntlet — plazas, chains, stoplights every quarter mile, and the famous carnival-signed international grocery [R — strictly neutral, traffic anchor only]. | Maximum witness density; heat responds fastest here (§6). Chases entering the moat change character instantly. |
| P3 | **"Stonegate Section 4"** (subdivision under construction) | [F] | New cul-de-sac phases going in off Pleasant/Nilles — framed shells, mud lots, streets that dead-end into field. | Same chase-trap geography as the Milford doc's Phase II — the moat is still being poured. |

### River road west

| P | Location | Tag | Description | Gameplay |
|---|----------|-----|-------------|----------|
| P2 | **Ross crossroads** | [R] | The hamlet where SR 128 meets the Millville/Venice roads — gas, feed store [F], four corners. | Back-way waypoint; quiet meet spot; last stop before the fence. |
| P2 | **Gravel pits on the Great Miami** | [R-generic, F name "Riverbend Aggregate"] | Working aggregate pits along the west bank flats. | Dust, truck traffic, pit-road shortcuts — the back way's hazard set. |
| P1 | **Fernald perimeter** | [R] | The shuttered uranium feed materials plant near Ross — production halted '89, a guarded federal Superfund cleanup in '95: fence line, warning signage, water towers and silos in the distance. **Hard no-go.** | Scripted restricted zone: crossing the fence = instant maximum heat, federal response (§6). A place even outlaws route around — and everyone local has an opinion about. Build as silhouette + fence, not an explorable interior. |

### The loop edge

| P | Location | Tag | Description | Gameplay |
|---|----------|-----|-------------|----------|
| P1 | **Forest Fair Mall** | [R] | The enormous, struggling mall at the loop — opened '88, developer bankrupt by '90, half-lit and under-tenanted in '95. Full parking decks, fractional crowds. | G1 gateway marker; parking-deck spiral chases; half-empty interior meets. The "new ruin" bookend to the dead mill row. |

**Hero-building budget:** 6 P1 uniques (Vault, courthouse block, Champion mill row facade, Fernald fence/silhouette, Forest Fair, plus the High–Main Bridge/levee seam treated as hero terrain). Kits: shotgun-house kit, brick factory-shell kit, strip-plaza kit, Victorian rooming-house kit.

---

## 5. Gameplay points of interest

### Chokepoints
| Where | Why it works |
|-------|--------------|
| **High–Main Bridge** | The main river crossing — hold it and the west bank is cut off. |
| **Black Street Bridge** | The only alternative downtown; the feint option. |
| **CSX grade crossings** | An active main line at street level — a rolling, scriptable wall through the east side. |
| **Courthouse square** | One block, all badges — the standoff stage. |
| **Dixie strip stoplights (the moat)** | Not walls — cameras, witnesses, and 90-second response times. A legal chokepoint like Terrace Park in the Milford doc, but a mile long. |
| **Levee gates** | Bollarded crest-path gates: bike-width gaps, car-proof. |
| **Fernald fence** | Absolute. The one edge in the game that says no to everyone equally. |
| **Forest Fair parking decks** | Spiral ramps with one exit per level — pursuit funnel in either direction. |

### Sight lines / overwatch
| From | Sees |
|------|------|
| Levee crests | The river, both banks, both bridges |
| Courthouse dome statue (landmark) / upper High St windows | The civic core |
| Champion's steam plume | Visible district-wide — the district's weathervane (plume = mill running = shift traffic) |
| The Vault's roof | The mill row and the levee approach |
| Dayton Lane upper windows | High Street's length |
| Forest Fair's empty top deck | The loop interchange band |
| Ross grain leg [F, small] | The river road both directions |

### Natural chase routes
1. **The moat run:** the loop → Dixie strip gauntlet → Lindenwald pinch → downtown. Witness density falls as speed rises — the district in one chase.
2. **Bridge swap:** feint the High–Main, take Black Street — or the reverse; the river only forgives one guess.
3. **Train beat:** cross the CSX gates on the warning bell with the freight closing — pursuit eats the three-minute wall. Miss the beat and it's yours.
4. **Levee run:** gated gravel on the crests, bike-only, exposed to everything and faster than anything below.
5. **Back-way run:** SR 128 south — pit dust, truck gaps, Ross flats — swinging wide around the Fernald fence to Miamitown and the west loop.
6. **Deck spiral:** into Forest Fair's parking structure, up the half-empty levels, out the far ramp.
7. **The loop ritual (westbound):** I-275 toward the Milford half — the club's stitch, same as the eastern doc's route 7, opposite direction.

### Stakeout spots
The Third Shift's window (mill-row traffic), bail-bonds row (who makes bail), levee crest over the bridges (who crosses), Forest Fair top deck (who meets at the loop), Ross four corners (everything using the back way), fairgrounds barns off-season.

---

## 6. Systems tie-ins (SUGGESTIONS — nothing wired here)

- **TurfNode_Hamilton [exists]:** this district's Kin anchor node. Conceptually it lives at **The Vault** (mill-row clubhouse). Current authored position (-80, 0, -80) is abstract placeholder spacing — relocate when this district gets a real coordinate plan, same caveat as every node. No new turf proposed per design direction; downtown, Fairfield, and the river road stay non-turf POIs unless a later pass decides otherwise.
- **Heat system — three flavors in one district:** Hamilton PD + Butler sheriff spawn from the courthouse block (urban, steady); **Fairfield PD on the Dixie moat is the fast tier** (suburban money = response times, mirroring witness density); OSHP on the loop. **Fernald is scripted absolute:** crossing the fence = instant max heat + federal units, no negotiation — a worldbuilding rule, not a difficulty knob.
- **Train-block script (CSX):** scheduled freights cut the east-side crossings for multi-minute intervals. Pursuit AI treats a closed gate as a hard wall; the player can beat the bell at risk. This is the district's covered-bridge-equivalent asymmetry and deserves the same small dedicated pass.
- **Kin convoy behavior:** loop segment + Dixie/128 patrols; convoys between here and the Milford half ride I-275 (G3), and the two clubhouses give the faction a two-anchor patrol circuit spanning the whole Outerbelt — their lore made literal.
- **Champion shift change:** twice-daily traffic event on the west bank, same mechanism as the Ford plant event in the Milford doc.
- **Forest Fair:** natural venue for indoor meets and a possible Race-type deck event later; its half-vacancy is load-bearing atmosphere — don't populate it like a healthy mall.

---

## 7. Period accuracy — 1995 checklist

- **"Hamilton!"** — the exclamation point has been official since 1986. Signage should carry it; locals shouldn't bother saying it. The joke is period-real.
- **The mill is running** — Champion's Hamilton mill operates through the '90s (period-correct); shift whistles and the steam plume are live ambience. The safe industry is in its last years; the city's "Safe Capital of the World" heritage is memory and signage, which is why the [F] Herring Bros. shell rings true.
- **Fairfield is mid-boom, Forest Fair is mid-bust** — both at once, and both true in '95. The mall opened '88 and was in trouble by 1990; build it under-lit.
- **No Union Centre yet:** the I-75/Union Centre interchange and the West Chester office boom arrive in the late '90s — in 1995 the northeastern approach (Beckett Ridge golf-community aside, which does exist) is still largely field. Don't backfill modern Butler County sprawl.
- **Fernald is national news in this era** — production stopped '89, the cleanup and lawsuits ran through the '90s. Locals (and Kin dialogue) have opinions: jobs lost, wells tested, nobody trusts the fence line. Handle straight, not jokey.
- **No cell phones.** Payphones: the Third Shift, High St lunch counter, Ross four corners, Forest Fair concourse, fairgrounds office.
- **Radio/TV flavor:** WEBN reaches; country and AM talk stronger here; Hamilton Big Blue high-school football on Friday nights; Reds broadcasts with Fairfield's own Joe Nuxhall calling — mention-only civic pride, keep the man himself offscreen.
- **Tone guardrails:** same rule as both companion docs. Hamilton's decline and Lindenwald's thinning were real — play them as communities under pressure, not ruin porn. The urban-Appalachian thread (mill recruitment from Kentucky a generation back) connects this district's families to Lower Price Hill's — the game's sociology should feel like one world.

---

## 8. Blockout notes for the build

1. **The levees are the terrain.** This is a flat river city; the MCD levees are its only vertical drama — build them as continuous raised spines with gated crest paths, and make the two bridges read as *gaps in a wall*.
2. **Three-strand structure:** Dixie, Pleasant, and the 128 river road must genuinely parallel each other loop-to-city so every north–south trip is a choice: watched / known / back way. (Same trick as the Milford doc's two corridors, with one more option.)
3. **The moat gradient is the level design:** witness density, lighting, and heat response all step up together as routes pass through Fairfield. Make the gradient legible at speed — signage, light temperature, road quality.
4. **The CSX line needs its own pass:** rolling stock, gate timing, and the pursuit-wall script (§6). It's the district's signature system the way the covered bridge is Milford's.
5. **Live mill / dead row contrast on one street:** North B St should alternate steam and silence within a block — that juxtaposition carries the thesis without a word of dialogue.
6. **Fernald is silhouette only:** fence, signage, distant towers, scripted response. No interior; the point is that nobody goes in.
7. **Forest Fair under-lit:** dead anchor wings, full parking decks, skeleton tenancy. Its emptiness is content.
8. **Existing scene note:** same caveat as both companion docs — current TurfNode positions are abstract placeholders; plan district coordinates before relocating TurfNode_Hamilton (§6).
