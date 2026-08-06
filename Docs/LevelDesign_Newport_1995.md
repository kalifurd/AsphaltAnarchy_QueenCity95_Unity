# NEWPORT, KENTUCKY — LEVEL DESIGN REFERENCE
**Asphalt Anarchy: Queen City '95 — Kentucky Kings territory**
**Setting: Newport, Campbell County, KY, 1995. Status: design reference, not yet built.**
**Companion docs:** `LevelDesign_PriceHill_Delhi_1995.md`, `LevelDesign_Milford_Batavia_1995.md`, `LevelDesign_Hamilton_Fairfield_1995.md` (same conventions).
**Faction canon (KentuckyKings.asset):** primary territory Newport, secondary Covington; "cross-river royalty… all high-speed swagger"; combat style is high-speed drafting and sideswiping **across the river bridges**; low defensiveness — they don't hold ground, they own motion. This doc is built around that. **Covington is adjacent Kings ground across the Licking — off-map here, its own pass if ever needed.**

---

## 0. How to read this document

- **[R]** — real place/street, real name, use as-is (civic landmarks, streets, parks, infrastructure).
- **[R*]** — real place, name lightly fictionalized (private businesses we attach club activity to).
- **[F]** — fictional, anchored to real building stock plausible for 1995.
- Geography **compressed ~5:1**. Keep topology exact, scale distances freely.
- **TurfNode_NewportRiverfront already exists** as the Kings' anchor. This doc maps that node onto the district (§6) — it does **not** propose new turf placement.
- Newport is small and dense — a compact river city, not a sprawl. Fewer road-miles than any district so far, more per block.

---

## 1. Orientation & district thesis

**The thesis: last call in Sin City.** Newport was the original Las Vegas before Las Vegas — casinos, wire rooms, and clubs run wide-open across the river from Cincinnati's law from the '20s until the reform push of the early '60s. The casinos died; **Monmouth Street's strip of clubs and taverns did not**, and by 1995 it's the tail end of that world: the city fathers are shopping redevelopment plans, ordinances are squeezing the adult businesses, legal casino boats are licensed and building just downriver in Indiana, and everyone on the strip can read a calendar. **The Kentucky Kings are the heirs of the old rackets, running out the clock with style.**

And their kingdom was never really the ground — it's **the crossings**. Newport exists because it sits across a state line from a big city: the law changes in the middle of the river, and the Kings' whole culture (per faction canon) is built on the bridges — drafting duels on the spans, goods moved between jurisdictions, the wave goodbye at mid-river.

| Band | What | Character |
|------|------|-----------|
| The riverfront | **Outside the floodwall** — Riverboat Row, the Point | The city walled the river out after '37; the Kings live on the wrong side of the wall. |
| The strip | **Monmouth/York couplet (US 27)** | Neon, doormen, pawn glass — the working remains of Sin City. |
| The neighborhoods | **Mansion Hill east, the west side toward the Licking** | Victorian streets gone to rooming houses; shotgun blocks near the Licking. |
| The industrial south | **Up the Licking toward Wilder** — the dead brewery, the live steel mill | Newport's working spine, half-dark. |
| The hill | **Fort Thomas / Southgate above** (US 27 climbs out) | Old money looking down at the old sin. Southern fade to I-275. |
| The seams | **Three Ohio bridges + the Licking bridges** | The Kings' true territory. State line runs mid-river. |

### Schematic (topology only, not to scale)

```
                    CINCINNATI (downtown district — across the Ohio)
        ═════════════════ OHIO RIVER ══ state line mid-river ══════════════
   L&N Bridge [R,      Taylor–Southgate Br. [R,        "Big Mac" I-471 br. [R,
   narrow, old]        BRAND-NEW — opened '95]          yellow arches]
        \                    |                              /
         \              THE POINT ─ floodwall ─ RIVERBOAT ROW ─ THE KINGFISH (clubhouse)
          \            [Gen. Taylor Pk]  [gates]           (moored showboat)
   COVINGTON ── 4th St Br. ── NEWPORT CORE                  |
   (Kings' 2nd    over the    │ Monmouth/York strip (US 27) │ I-471 ↓
   ground — off-  LICKING R.  │ courthouse blocks           │
   map)                       │ Mansion Hill (east)         │
                              │ west side (shotgun blocks)  │
                    WIEDEMANN BREWERY [R, dead '83] ─ Licking bank ─ NEWPORT STEEL [R, live]
                              │                                   (toward Wilder)
                    US 27 climbs THE HILL → FORT THOMAS (Tower Park, old money)
                              │
                    SOUTHGATE → I-275 south leg (G3) → airport side → Anderson Ferry
                                                        back door to Price Hill
```

---

## 2. Road network

### Arterials

| Road | Tag | Runs | Role |
|------|-----|------|------|
| **Monmouth St / York St (US 27)** | [R] | One-way couplet north–south through the core, then US 27 climbs the hill to Fort Thomas, Southgate, and I-275 | The strip and the spine. Neon gauntlet in the core, grade climb out the south. |
| **KY 8 / 4th Street** | [R] | East–west: across the Licking to Covington, through the core, east along the river toward Bellevue/Dayton (KY) | The river road; the Licking crossing; the eastern fade through the little river towns. |
| **I-471** | [R] | Cuts through Newport's east side, over the Ohio on the yellow-arched "Big Mac" bridge, south to I-275 | The fast seam — from the strip to the interstate in under a minute, which is the point. |
| **Riverboat Row / riverfront drive** | [R] | Along the Ohio outside the floodwall | The Kings' front porch: moored boats, dock aprons, the wall at your back. |
| **Columbia St / Washington Ave** | [R] | Parallel core streets | Brewery access, the Italian place, back-of-strip service streets. |

### The bridges (the Kings' true territory)

| Bridge | Tag | Crosses | 1995 status | Role |
|--------|-----|---------|-------------|------|
| **Taylor–Southgate Bridge** | [R] | Ohio → downtown Cincinnati | **Brand-new — opened this very year**, on the site of the demolished Central Bridge | The clean new span; the city's pride, the Kings' drag strip. |
| **L&N Bridge** | [R] | Ohio → Cincinnati | Old, narrow, still carrying cars in '95 (nobody calls it "purple" — that's a later life) | The tight span: white-knuckle drafting duels, no room for error or cruisers. |
| **Daniel Carter Beard "Big Mac" Bridge (I-471)** | [R] | Ohio → Cincinnati | Yellow twin arches, interstate speed | The fast span: full-throttle crossings. |
| **4th Street Veterans Memorial Bridge** | [R] | Licking → Covington | Working crossing | The side door to the Kings' secondary ground (off-map). |

**The state line runs mid-river on every Ohio span.** This is the district's core mechanic suggestion (§6): jurisdiction changes at the middle of the bridge, exactly the fact Newport's whole history was built on.

### Gateways — connections outward

| # | Gateway | Tag | Leads to | Notes |
|---|---------|-----|----------|-------|
| G1 | **The three Ohio bridges** | [R] | Downtown Cincinnati district (and from there OTR, Queensgate, Price Hill) | Three parallel crossings with three personalities — new/wide, old/narrow, interstate/fast. The player always has a bridge choice. |
| G2 | **4th St over the Licking** | [R] | Covington — Kings' secondary territory, off-map | Presence implied by traffic and colors, not built. |
| G3 | **US 27 / I-471 south over the hill** | [R] | I-275 south leg → the airport side → **Anderson Ferry back door to Price Hill** (reciprocal of the PH doc's G3) | The southern fade through Fort Thomas/Southgate money. |
| G4 | **KY 8 east** | [R] | Bellevue, Dayton (KY) — little river towns, soft eastern fade | Quiet river-level escape direction. |

---

## 3. Sub-area character sheets

### 3a. The Monmouth strip — what's left of the life
US 27 through the core: club fronts with doormen, taverns, pawn glass, an adult bookstore or two, diners that never close. Every door the Kings either run, protect, or respect. The city building and PD sit right on the same street a few blocks down — everyone knows everyone, which is very Newport. **Tone: neon at street level, dark above the second floor; charm and menace in the same block.**

### 3b. The riverfront — outside the wall
The floodwall (built after the '37 flood) walls the city off from its own river; the streets pass through steel gate openings. On the wrong side: Riverboat Row's moored boats and barges, dock aprons, and the Point at the Licking confluence with the best skyline view in Kentucky. This is TurfNode territory — the Kings' anchor ground. **Tone: water-level kingdom; the city turned its back and the Kings moved in.**

### 3c. The neighborhoods — Mansion Hill and the west side
East of the strip, Mansion Hill's Victorian blocks — Sin City's bosses built these houses; by '95 they're rooming houses and first-wave restorations side by side. West of the strip toward the Licking, shotgun blocks and corner stores. **Tone: faded velvet east, workboots west; both know the Kings by first name.**

### 3d. The industrial south — the Licking bank
The **Wiedemann brewery** [R] — Newport's own beer, closed in '83 — still stands hulking on Columbia Street, cellars and racking halls dark. Further up the Licking toward Wilder, **Newport Steel** [R] still runs — shift whistles, pipe and tube, the district's live employer (**strictly neutral, no crime attached** — same rule as Champion/Ford in the companion docs). **Tone: one dead giant, one living one, same riverbank.**

### 3e. The hill — Fort Thomas and Southgate
US 27 climbs out of the basin past Tower Park's stone army water tower into Fort Thomas — old officer-country money looking down on Newport the way it always has. Southgate strings along toward I-275. **Tone: the view from above; the money that never came downhill after dark, and always came downhill after dark.**

---

## 4. Location list

Priority tiers: **P1** must-build hero (unique model), **P2** identity (heavily-dressed kit), **P3** dressing (kit-bash).

### The riverfront (outside the wall)

| P | Location | Tag | Description | Gameplay |
|---|----------|-----|-------------|----------|
| P1 | **The Kingfish** (clubhouse) | [F] | A retired excursion boat moored at the end of Riverboat Row — the Kings' floating clubhouse. Ballroom on the main deck, book runs out of the purser's office, bikes on the dock apron under the floodwall. The only clubhouse in the game that moves (it doesn't — but nobody's sure it can't). | Kings' home base. Maps to existing **TurfNode_NewportRiverfront** (§6). Gangway = one controllable entrance; top deck = skyline sightline. |
| P1 | **The floodwall & gates** | [R] | The post-'37 wall between city and river, streets threading through steel gate openings. | Hero terrain: the gates are the riverfront's chokepoints (§5); wall-top walkway sightlines. City can close the gates — event lever (§6). |
| P1 | **The Point — General James Taylor Park** | [R] | The Licking confluence: grass, rip-rap, and the full Cincinnati skyline across the water (1995 skyline: Carew Tower tallest, Riverfront Stadium on the shore — same vista rules as the PH doc, opposite bank). | The money-shot vista; meet spot; Riverfest ground zero (§7). |
| P2 | **Riverboat Row** | [R] | The rest of the moored line: floating restaurants and club boats [F names], dock ramps, parking aprons. | Dock-plank chases; gangway fights; who's-dining-with-whom stakeouts. |

### The strip

| P | Location | Tag | Description | Gameplay |
|---|----------|-----|-------------|----------|
| P1 | **Monmouth strip hero block** | [R street, F businesses] | One dense block carrying the whole strip: **The Cadillac Club** [F] (Kings-run door), **The Kentucky Club** [F] tavern, **Silver Slipper Loan** [F] pawn, an adult bookstore [F, signage only], a 24-hour diner [F]. Doormen watch everything. | The social hub: missions, fencing, protection rounds. Friendly-turf awareness — the strip's eyes are the Kings' eyes. |
| P2 | **Newport city building & PD** | [R] | On Monmouth a few blocks down — the law lives on the same street as the life, always has. | Heat origin (§6); the short walk between the clubs and the cells is the district's oldest joke. |
| P2 | **Campbell County Courthouse blocks (York St)** | [R] | 1880s courthouse, bail bonds, lawyers' walk-ups. | Second civic anchor; bail-out pickups; county vs. city seam. |
| P3 | **Pompilio's** | [R] | The old Italian restaurant on Washington Ave — the toothpick scene from that Dustin Hoffman movie was shot here in '88 and they'll tell you about it. **Strictly neutral, no crime attached** (same rule as Jungle Jim's in the Hamilton doc). | Civilian anchor; period color; everyone eats here, including people who shouldn't sit near each other. |

### The neighborhoods

| P | Location | Tag | Description | Gameplay |
|---|----------|-----|-------------|----------|
| P2 | **Mansion Hill blocks** | [R] | The Victorian east side — racket-boss houses gone to rooming houses, first restorations creeping in. | Alley-grid chases; upper-window sightlines; safe rooms in big old houses. |
| P3 | **West side shotgun blocks** | [R-generic] | Working blocks between the strip and the Licking. | The humanizer — Kings' families and civilians; consequences live here (same role as Lindenwald/the trailer court). |

### The industrial south

| P | Location | Tag | Description | Gameplay |
|---|----------|-----|-------------|----------|
| P1 | **Wiedemann brewery** | [R] | Newport's own brewery, closed 1983, the whole complex still standing dark on Columbia St — brewhouse, racking halls, lagering cellars. Club use is our fiction; the building and its death date are real. | The Kings' warehouse: stash cellars, chop floor, interior fight maze, roof over the Licking bank. The district's "dead giant" interior. |
| P2 | **Newport Steel gate row** | [R] | The live mill up the Licking toward Wilder — shift whistles, truck gates. **Economy anchor, strictly neutral.** | Shift-change traffic event (the district's Ford/Champion analog); the contrast that keeps Newport a working town, not a theme park. |
| P3 | **Licking bank yards** | [F/generic] | Scrap and barge tie-ups along the Licking below the brewery. | Back-lot business; water-level stash; quiet route between brewery and 4th St bridge. |

### The hill & fades

| P | Location | Tag | Description | Gameplay |
|---|----------|-----|-------------|----------|
| P2 | **Tower Park / Fort Thomas** | [R] | The old army post grounds and stone water tower above the basin — old money's front porch. | The overlook: all three Ohio bridges and the basin in one view; where deals watch themselves get made. Fort Thomas PD is humorless (§6). |
| P3 | **Bellevue/Dayton KY 8 fade** | [R] | The little river towns strung east — storefronts, church steeples, river glimpses. | Quiet-run scenery; eastern soft exit. |
| P3 | **Southgate strip to I-275** | [R] | US 27 motels and lots toward the loop. | G3 fade. **Tone guardrail:** the Beverly Hills Supper Club fire site ('77) is near this fade — deliberately **not** a location, no gameplay, no reference beyond respectful silence. Locals don't joke about it; neither do we. |

**Hero-building budget:** 6 P1 uniques (Kingfish, floodwall/gates as hero terrain, the Point vista, Monmouth hero block, Wiedemann brewery, plus the three-bridge set treated as one hero terrain system). Kits: Victorian rowhouse kit, shotgun-house kit, strip-storefront kit (neon variants), industrial brick kit.

---

## 5. Gameplay points of interest

### Chokepoints
| Where | Why it works |
|-------|--------------|
| **The floodwall gates** | Steel gate openings are the only ways onto the riverfront — hold or close them and the Kings' ground seals (both a defense and a trap). |
| **The L&N Bridge** | Narrow lanes, old steel — the dueling span. Two bikes wide, no cruiser comfortable. |
| **Taylor–Southgate bridgehead** | Brand-new, wide, and watched — the respectable crossing, with respectable cameras. |
| **The Kingfish gangway** | One plank onto the clubhouse. The most defensible front door in the game. |
| **Monmouth couplet** | One-way pairs mean pursuit routing errors — locals know which block flips you head-on into traffic. |
| **4th St Licking bridge** | The side door to Covington; short, low, easily plugged. |
| **US 27 hill grade** | The climb out — heavy bikes against gravity under Fort Thomas's watchful porches. |

### Sight lines / overwatch
| From | Sees |
|------|------|
| Tower Park (Fort Thomas) | The whole basin: all three Ohio bridges, the strip's neon, the river bend |
| The Kingfish top deck | Riverboat Row, the floodwall gates, the skyline |
| Floodwall walkway | The dock aprons below and the strip's back doors behind |
| Brewery roof | The Licking bank, the 4th St bridge, Covington beyond |
| Mansion Hill upper windows | The strip's length |
| Mid-span, any Ohio bridge | Both states at once — the Kings' favorite view |

### Natural chase routes
1. **The bridge choice:** any run to Cincinnati is a three-way pick — new/wide (fast, watched), old/narrow (slow, unfollowable), interstate (fastest, most committed). The chase is decided at the fork, not on the span.
2. **Strip flip:** down Monmouth against the one-way, back up York — local-knowledge routing that folds pursuit into oncoming traffic.
3. **Wall run:** through one floodwall gate, flat-out down the dock aprons past the boats, out the far gate — the riverfront as a walled drag strip.
4. **Licking slip:** brewery yards → bank lots → under the 4th St bridge → surface in Covington's jurisdiction (off-map hand-wave, on-map heat drop).
5. **Hill climb:** the strip → US 27 grade → Tower Park — trading neon for altitude while Fort Thomas PD wakes up.
6. **Draft duel (faction signature):** scripted Kings encounters on the spans — high-speed drafting and sideswipes bridge-to-bridge, exactly per faction canon. Their turf challenges should *be* this, not a circling arena.
7. **KY 8 river run:** east through Bellevue/Dayton at water level — the quiet way out.

### Stakeout spots
The diner window on Monmouth (the strip's traffic), Kingfish top deck (the river), Tower Park (everything), bail-bonds row on York (who walks), the Point (meets on neutral grass), brewery roof (the Licking and the side door).

---

## 6. Systems tie-ins (SUGGESTIONS — nothing wired here)

- **TurfNode_NewportRiverfront [exists]:** the Kings' anchor node — conceptually it IS Riverboat Row/the Kingfish ground outside the floodwall. Current authored position (70, 0, -40) is abstract placeholder spacing; relocate when the district gets a real coordinate plan, same caveat as every district doc. Its existing Race captureType fits the faction perfectly — make the race a **bridge run**, not a lap.
- **The jurisdiction seam (the district's signature suggestion):** the state line runs mid-river. Suggested rule: Newport-side heat hands off (with a lag, or a cap drop) when the player crosses an Ohio bridge, and Cincinnati-side heat likewise dies at the river — pursuit peels off at mid-span. This is period-true (it's *why* Sin City existed), faction-true (the Kings' whole culture is the crossings), and mechanically legible (the bridge becomes a finish line). Needs its own pass in HeatSystem terms; flag before building — it touches core heat rules.
- **Heat flavors:** Newport PD from the Monmouth city building (small-city — they know the Kings by name; steady, not fast); Campbell County sheriff at the courthouse; Fort Thomas PD on the hill (fast and humorless in their one square mile); OSHP/KSP on I-471. The floodwall gates as a scriptable event (city closes the riverfront).
- **Kings' faction behavior:** their canon low defensiveness (0.3) should read as *mobility, not weakness* — turf response arrives as bridge-speed convoys, not entrenchment. Draft-duel encounters on the spans are their signature set piece (§5 route 6).
- **Newport Steel shift change:** twice-daily traffic event, same mechanism as Champion/Ford in the companion docs.
- **Cross-district closure:** G3 completes the loop the Price Hill doc opened — Anderson Ferry's KY landing routes here via the airport side, giving the two oldest districts a back-door circuit that never touches downtown.

---

## 7. Period accuracy — 1995 checklist

- **The Taylor–Southgate Bridge is brand-new** — opened in 1995 on the old Central Bridge site (demolished '92). Fresh concrete, dedication-plaque energy. The L&N Bridge still carries cars and **nobody calls it purple** — that's a 2000s afterlife.
- **No aquarium, no Levee, no Peace Bell** — the riverfront's family-friendly reinvention is all post-1995. In '95 the riverfront is boats, lots, and wall. The redevelopment *talk* is period-accurate; the buildings are not.
- **The squeeze is real:** the city is actively pressuring the adult businesses through the mid-'90s, and **legal riverboat casinos are licensed and under construction in Indiana** — a year or so out, and everyone on the strip knows it. "Last call" is the accurate mood, not just our fiction.
- **Sin City is living memory, not history** — men in their sixties on Monmouth Street dealt cards in the wide-open years. Dialogue should treat the casino era as *"before the reformers,"* one generation back, not ancient lore.
- **Riverfest (Labor Day)** [R] — the WEBN fireworks launch from barges mid-river; both banks fill shoulder-to-shoulder. The district's one massive annual crowd event — the Point and Riverboat Row are ground zero.
- **No cell phones.** Payphones: the diner on Monmouth, Riverboat Row parking apron, courthouse hall, Tower Park shelter, KY 8 gas stops.
- **Radio/TV:** WEBN across the river, country stations local, Reds games everywhere in summer (Riverfront Stadium is *visible* from the Point).
- **Skyline from the Point:** Carew Tower tallest, Riverfront Stadium on the shore, Roebling Bridge downriver toward Covington — same 1995 skyline rules as the Price Hill doc, opposite bank.
- **Tone guardrails:** Newport '95 is poor and pressured but proud and *funny* — river-city gallows humor, not grimness. The adult-business strip is signage and doormen, not explicit content. And the Beverly Hills fire site stays out of the game entirely (§4) — real grief, no gameplay.

---

## 8. Blockout notes for the build

1. **The bridges are the level.** Build the three Ohio spans first, with genuinely different widths, speeds, and sightlines — the district's core choice is *which bridge*, and it must read at a glance from either bank. The Cincinnati-side landings connect to the downtown district.
2. **The floodwall is the second terrain feature:** a continuous wall with a handful of gate gaps, riverfront drivable on the outside, city grid on the inside. The wall must read as a hard edge from both sides.
3. **Compact grid:** Newport's core is small and tight — resist sprawl. Density of signage and doorways does the work that road-miles did in Clermont/Butler.
4. **The strip at night is the identity shot:** neon layer, wet-street reflections, doormen silhouettes. Budget lighting here over anywhere else in the district.
5. **The Kingfish needs water treatment:** moored-boat physics can be faked (it's a building on a barge), but gangway, dock apron, and water gap must be real colliders — the one-plank entrance is a gameplay promise.
6. **The hill grade to Fort Thomas** is the district's only big vertical — make the climb long enough that altitude feels like leaving the basin's world.
7. **Jurisdiction seam markers:** if §6's heat handoff gets built, mid-span needs a subtle readable marker (state-line sign [R — real signs exist on the bridges]) so the mechanic teaches itself.
8. **Existing scene note:** same caveat as all district docs — current TurfNode positions are abstract placeholders; plan district coordinates before relocating TurfNode_NewportRiverfront (§6).
