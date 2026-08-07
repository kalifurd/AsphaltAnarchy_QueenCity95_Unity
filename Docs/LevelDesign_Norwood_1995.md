# NORWOOD, OHIO — LEVEL DESIGN REFERENCE
**Asphalt Anarchy: Queen City '95 — Neutral/contested ground, no owning faction**
**Setting: Norwood, Hamilton County, Ohio, 1995. Status: design reference, not yet built.**
**Companion docs:** `LevelDesign_PriceHill_Delhi_1995.md`, `LevelDesign_Milford_Batavia_1995.md`, `LevelDesign_Hamilton_Fairfield_1995.md`, `LevelDesign_Newport_1995.md`, `LevelDesign_Queensgate_1995.md`, `LevelDesign_Downtown_OTR_1995.md` (same conventions).
**No faction canon block here — this is the point.** Unlike every companion doc, Norwood is not primary or secondary territory for any of Rust Barons, Highway Kin, Kentucky Kings, Neon Saints, or OTR Syndicate. It plays the same structural role Price Hill's **Warsaw Ave** and **Anderson Ferry** TurfNodes already play — genuinely neutral, genuinely up for grabs — except this time the *whole district* is that node, not one street inside somebody's home turf.

---

## 0. How to read this document

- **[R]** — real place/street, real name, use as-is (civic landmarks, streets, parks, infrastructure).
- **[R\*]** — real place, name lightly fictionalized (private businesses we attach club/gang activity to — we don't hang crime stories on real family businesses).
- **[F]** — fictional, anchored to real building stock plausible for 1995.
- **[R-generic]** — real street, but exact building fronts on it are unverified/interchangeable; same convention Newport used for its west-side shotgun blocks.
- Geography compressed **~5:1**, same as every companion doc. Keep topology exact, scale distances freely.
- **No TurfNode exists here yet.** §6 proposes two, both `startingFaction = null` (Neutral) — same pattern as `TurfNode_WarsawAve` and `TurfNode_AndersonFerry` in the Price Hill doc. This doc does not propose new *owned* turf; it proposes contested turf, which is a different thing.
- Norwood is small, flat, and self-contained — closer to Newport's footprint and pacing than Price Hill's four-tier sprawl. One real commercial spine, one dead industrial edge, one live industrial anchor, and a residential grid holding its own civic pride the whole time.

### Faction-fit check (flagged, not decided)

The nearest thing to a competing pitch: Rust Barons' whole identity is industrial-scrapper salvage economy, and a 50-acre demolished auto plant is exactly their kind of ground. It was considered and **rejected for this doc** — Queensgate/West End share no border with Norwood (they're on opposite sides of the Mill Creek/uptown corridor), and more importantly, Norwood's actual defining fact (a legally independent city that nobody, cop or gang, fully controls) is a *stronger* generator of contested ground than a thematic echo would be. Recommendation: keep it neutral, per the brief. **If you'd rather use this ground to deepen a Rust Barons secondary claim**, it's a small change (swap `startingFaction` in §6, adjust the framing in §1/§3/§7) — but flagging it here rather than making that call silently, since it cuts against the "island jurisdiction" thesis the rest of this doc is built around.

---

## 1. Orientation & district thesis

**The thesis: a sovereign city the size of a neighborhood, and nobody actually runs it.** Norwood incorporated in 1903 specifically to keep Cincinnati from annexing it, and in 1995 it's still exactly that — its own police department, its own fire department, its own public works, its own school district, completely encircled by a bigger city that has zero jurisdiction the moment you cross the line. That's not flavor text, it's the load-bearing fact of the whole district: **Norwood is an island of separate authority sitting in the middle of the map**, which is precisely why none of the five gangs actually holds it. Cincinnati PD can't chase you past the line without a hand-off; Norwood PD is small, local, and knows every face on Montgomery Road — but they're stretched thin over a city with a hole where its tax base used to be.

That hole has a date: **August 26, 1987 — "Black Wednesday."** GM's Norwood Assembly plant shut down that day, taking 35% of the city's tax base and about 4,000 union jobs with it; the last car off the line was a red Camaro, and everybody in town over thirty has an opinion about it. By 1995 — eight years on, not fresh grief but a still-unhealed wound — most of the 50-acre complex is gone, torn down in a long tax dispute with the city, and what's left along Smith Road and the Norwood Lateral is gravel lots, foundation outlines, and chain-link around nothing. **That ground is the district's real contested territory** — not because anyone's fighting to hold it, but because nobody has, and everybody with an angle (scrap, real estate, a shortcut, a place to not be seen) has driven past it wondering.

The counterweight to all that absence: **US Playing Card Company on Beech Avenue is still running full production in 1995** — the red-brick anchor that never left, the thing that keeps Norwood from reading as a ghost town. And redevelopment is *starting*, not arrived: Central Parke's office park and Rookwood Pavilion's retail strip are three and two years old respectively in 1995, novel and half-proven, not yet the destination they'll become. **Nothing here is finished** — that's the tone.

| Zone | What | Character |
|------|------|-----------|
| The Plant Site | Demolished GM Norwood Assembly footprint, Smith Rd / the Norwood Lateral | Liminal, up for grabs — gravel, foundations, a highway cut straight through it. |
| The Pike | Montgomery Road through the commercial core | Local storefronts, diners, dive bars, hardware — alive and vacant in the same block. |
| The Works | US Playing Card Co., Beech Ave | The one industry that didn't leave. Working counterpoint, not collapse. |
| The Grid | Bungalow/Foursquare/Victorian residential streets | "Gem of the Highlands" pride, multi-generational families, civic stubbornness. |
| The Edge | Central Parke office park, Rookwood Pavilion | 1990s redevelopment, early and unproven — a novel experiment, not an institution yet. |

### Schematic (topology only, not to scale)

```
              (N: Montgomery Rd -> Kennedy Heights/Silverton, off-map, soft suburban fade)
                                        |
                        THE GRID (bungalows, Foursquares, Victorians)
                         Norwood HS | Norwood City Hall & PD [R]
                                        |
   THE WORKS ══ Beech Ave ══ MONTGOMERY RD "THE PIKE" (US 27 local) ══════════════
   US Playing Card Co [R]              |                              \
   (red brick, live)              civic core / diners / dive bars      \-- (E: Edwards Rd ->
                                        |                                  Oakley/Rookwood/
                        ┌───────────────┴───────────────┐                  Hyde Park, off-map,
                 THE PLANT SITE [R site, demolished]   THE EDGE               soft fade)
                 Smith Rd / gravel lots / foundations   Central Parke [R]
                        │                                Rookwood Pavilion [R]
                 NORWOOD LATERAL (SR-562) [R] ───────────────────┤
                        │                                         │
          (W: Lateral -> I-75 -> Mill Creek corridor,      (S/E: Lateral -> I-71 ->
           toward Queensgate, off-map)                      Downtown/OTR & Uptown,
                                                              received from that doc's G4)
```

---

## 2. Road network

### Arterials

| Road | Tag | Runs | Role |
|------|-----|------|------|
| **Montgomery Road ("The Pike")** | [R] | Diagonal spine through Norwood's commercial core, continuing north toward Kennedy Heights/Silverton, south toward Xavier/Uptown | One of Ohio's oldest roads (an 18th-century turnpike before it was a street) and Norwood's actual main street — storefronts, diners, dive bars, hardware stores, vacant fronts in the same block. |
| **Smith Road** | [R] | East–west along the old plant's southern edge | The industrial ghost street — what used to be shift-change traffic is now gravel lots and a road that goes past nothing for a while. |
| **Norwood Lateral (SR-562)** | [R] | East–west, limited-access, cut through/along the demolished plant's footprint | The district's one real highway — built for GM's traffic, now the fastest way through ground nobody owns. Connects I-71 (east) to I-75 (west). |
| **Beech Avenue** | [R] | Norwood's eastern industrial edge | US Playing Card Co.'s street — red brick, loading docks, the district's one unbroken workday rhythm. |
| **Sherman Avenue** | [R] | North–south, crosses Montgomery near the civic core | Norwood's other spine — city hall, the PD, the post office cluster near here. |
| **Edwards Road** | [R] | Norwood's eastern seam toward Oakley | The road the 1990s redevelopment fronts on — Rookwood Pavilion's address in this era, the district's newest pavement. |

### Gateways — connections outward

| # | Gateway | Tag | Leads to | Notes |
|---|---------|-----|----------|-------|
| G1 | **Norwood Lateral east → I-71** | [R] | South to Downtown/OTR and Uptown | **Received, not redefined** — this is the same arrow the Downtown/OTR doc's own G4 already points north along ("I-71/I-75 north — Clifton, Avondale, Uptown, off-map, future districts"). Norwood is that future district; this doc is where that arrow lands. |
| G2 | **Norwood Lateral west → I-75** | [R] | West toward the Mill Creek corridor, Queensgate direction | New connector, not a re-claim of Queensgate's own G2 (which lands further south on the same highway) — a second, independent link between the two industrial-decline districts. |
| G3 | **Montgomery Road north** | [R] | Kennedy Heights, Silverton — off-map, soft suburban fade | Quiet northern exit; presence implied, not built, same restraint every companion doc gives its softest edge. |
| G4 | **Edwards Road east** | [R] | Oakley, Hyde Park, the Rookwood corridor — off-map, future doc territory | New connector this doc establishes. Deliberately light touch — Rookwood Commons and Rookwood Exchange don't exist yet in 1995 (§7), so there's little to build past the edge even in fiction. |

---

## 3. Sub-area character sheets

### 3a. The Plant Site — Smith Road / the Norwood Lateral
Fifty acres of nothing with a highway running through it. Chain-link around demolished foundations, gravel lots where assembly buildings stood, a rail spur that used to feed the line and now just rusts. Locals still call it "the GM" out of habit, eight years after the fact, and the red-Camaro story gets told at the bars up the hill like it happened last month. Nobody's built anything real here yet in '95 — that's the point; it's the one piece of Cincinnati-metro ground in the whole game that is *actively, currently* up for grabs, not owned-and-defended. **Tone: gravel, chain-link, and the particular quiet of a place that used to be loud for three shifts a day.**

### 3b. Montgomery Road — "The Pike"
Norwood's actual main street, functioning the way Warsaw Ave functions in Price Hill but with no clubhouse anchoring it to anybody. Diners that never close, a hardware store, a dive bar with regulars who worked the line, storefront churches, and — in the same block — a couple of dark windows nobody's leased since '88. The city building and the PD sit a few blocks off Montgomery, small-town close the way Newport's city hall sits on Monmouth. **Tone: proud and threadbare in the same breath — a real main street that's had eight years to notice it's carrying more than it should.**

### 3c. Beech Avenue — the Playing Card Works
US Playing Card Company's red-brick complex, still running full production in 1995 — the working counterpoint to the plant site's absence, three-quarters of a mile away as the crow flies. Loading docks, a company water tower, the smell of ink and paper instead of diesel. This is Norwood's "we didn't all die" building, same functional role Newport Steel plays in the Newport doc and Champion/Jungle Jim's-style neutral anchors play elsewhere. **Strictly neutral, no crime attached** — same rule as every real working employer in the companion docs. **Tone: the one place in Norwood where the whistle still blows on schedule.**

### 3d. The Grid — the residential blocks
1910s–20s Craftsman bungalows, Foursquares, and a scattering of older Victorians, packed onto a tight, walkable street grid around Norwood's civic core. Multi-generational families, "Gem of the Highlands" civic pride on full display even with the tax base gone, front porches, corner stores. Norwood High School and the small independent city hall/PD cluster sit here — the visible proof the city still runs itself. **Tone: stubborn, proud, close-knit — a town, not a neighborhood, and everybody here knows the difference.**

### 3e. The Edge — Central Parke & Rookwood Pavilion
Norwood's answer to the hole GM left: an early-'90s office park (Central Parke, 1991–93) and a fledgling retail strip (Rookwood Pavilion, 1993–94) on the district's eastern seam toward Oakley. Clean new asphalt, landscaped setbacks, a kind of pavement Norwood didn't have before — and in 1995 it reads as an experiment that might not stick, not an institution. **Tone: the newest, cleanest ground in the district, and the least sure of itself.**

---

## 4. Location list

Priority tiers: **P1** must-build hero (unique model), **P2** identity (heavily-dressed kit), **P3** dressing (kit-bash).

### The Plant Site

| P | Location | Tag | Description | Gameplay |
|---|----------|-----|-------------|----------|
| P1 | **The GM foundations** | [R site, demolished] | Gravel lots and slab outlines where the assembly buildings stood — the biggest single open space in the district, fenced in irregular sections where the tax dispute stalled different parcels at different times. | The district's contested-ground centerpiece. Open sightlines, unpredictable surface, jump geometry off broken curbs and foundation edges. Maps to §6's proposed neutral TurfNode. |
| P1 | **Norwood Lateral cut** | [R] | The highway trenched through the plant's old footprint — limited access, retaining walls, a handful of on/off ramps. | Hero terrain: high-speed through-run, few entries/exits, the district's fastest chase geometry (§5). |
| P2 | **The old rail spur** | [R] | Rusted freight spur that used to feed the assembly line, now dead-ending in weeds behind the fence line. | Local-knowledge shortcut across the site; quiet approach; flavor hook for the Phantoms (§6) without granting them turf. |
| P3 | **Gate-booth remnant** | [F, plausible] | A single surviving guard booth at one of the old plant entrances, payphone still attached. | Stakeout spot; period payphone (§7); meet point nobody official uses anymore. |

### Montgomery Road — the Pike

| P | Location | Tag | Description | Gameplay |
|---|----------|-----|-------------|----------|
| P1 | **The Pike hero block** | [R street, F/R\* businesses] | One dense Montgomery Road block: a 24-hour diner [F], **Higbee's Hardware** [F] (going concern), a dive bar full of ex-line workers [F], a storefront church [F], and two dark vacant fronts nobody's leased since '88. | Social hub in a district with no clubhouse — meets, fencing, info NPCs. Vacant fronts = breakable/enterable interiors for stashes or ambushes. |
| P2 | **Norwood City Hall & PD** | [R] | The small municipal building and its own independent police department, a few blocks off the Pike near Sherman Ave. | The jurisdiction anchor — heat origin, and the mechanical proof Norwood answers to nobody else (§6). |
| P2 | **Post office / Sherman Ave civic cluster** | [R] | Norwood's small civic core around Sherman and Montgomery. | Wayfinding anchor; bail/DMV-adjacent errand flavor. |
| P3 | **The vacant storefront row** | [F] | A short run of dead retail a block off the hero block — the visible edge of the '87 hangover on the Pike itself. | Swap-meet/black-market interior potential; boarded-window sightline cover. |

### Beech Avenue — the Playing Card Works

| P | Location | Tag | Description | Gameplay |
|---|----------|-----|-------------|----------|
| P1 | **US Playing Card Company** | [R] | The red-brick factory complex on Beech Ave — office block, print/press buildings, water tower, loading docks. Full production in 1995. **Strictly neutral, no crime attached.** | Shift-change traffic event (same mechanism as Newport Steel/Champion-Ford in the companion docs); loading-dock chase geometry; the district's one unbroken workday rhythm. |
| P3 | **Beech Ave rail siding** | [R-generic] | Freight siding serving the Works — still live, unlike the plant's dead spur. | Contrast beat with the dead spur across the district; live-train timing hazard. |

### The Grid — residential blocks

| P | Location | Tag | Description | Gameplay |
|---|----------|-----|-------------|----------|
| P2 | **Norwood High School** | [R] | Norwood City Schools' flagship — the city's independent district in miniature. | Daytime civilian anchor, keeps the Grid reading as lived-in; scheduled-crowd flavor (same role Elder High plays in the Price Hill doc, smaller scale). |
| P2 | **Bungalow/Foursquare blocks** | [R-generic] | 1910s–20s housing grid around the civic core — porches, alleys, corner stores. | Alley-grid chases; witness-heavy quiet streets; the humanizer (same role Price Hill's West PH plays). |
| P3 | **Corner store & payphone** | [F] | Neighborhood crossroads shop. | Info-hub NPC, period payphone (§7). |

### The Edge — Central Parke & Rookwood Pavilion

| P | Location | Tag | Description | Gameplay |
|---|----------|-----|-------------|----------|
| P1 | **Central Parke office park** | [R] | Low-rise 1991–93 office buildings, landscaped setbacks, parking structures — new pavement, corporate tenants, still filling up in '95. | Clean-lane chase contrast (§5); rooftop/parking-garage sightline over Edwards Rd; corporate-scouting flavor hook for the Neon Saints (§6) without granting turf. |
| P2 | **Rookwood Pavilion** | [R] | The 1993–94 retail strip on Edwards Rd — early, gaining traction, nowhere near the destination it becomes post-2000. **Do not build Rookwood Commons or Rookwood Exchange — they don't exist yet (§7).** | Parking-lot meets; the district's one taste of "the future," deliberately unfinished-feeling. |
| P3 | **Edwards Rd frontage** | [R-generic] | The transitional stretch between the Grid's old housing and the Edge's new pavement. | G4 gateway marker; tone-contrast corridor. |

**Hero-building budget:** 6 P1 uniques (GM foundations, Lateral cut, Pike hero block, US Playing Card Co., Central Parke). Kits: bungalow/Foursquare housing kit, Pike storefront kit (mixed thriving/vacant variants), industrial brick kit (Works + plant remnants), corporate-office/parking-lot kit — the last one is a first for the game, no other district has this texture yet.

---

## 5. Gameplay points of interest

### Chokepoints
| Where | Why it works |
|-------|--------------|
| **Norwood Lateral on/off ramps** | Limited access means limited entries — the district's only genuine highway geometry, and whoever controls a ramp controls a fast exit from the plant site. |
| **The Pike's storefront block** | Narrow, stop-and-go, cross-traffic and pedestrians — pursuit routing errors punish drivers who don't know the block. |
| **Plant site fence gaps** | The old perimeter fencing survives in sections — only a few real ways onto the gravel lots, easy to watch, easy to seal. |
| **Beech Ave rail siding** | Live freight movement — scriptable timed gate, same mechanism as Price Hill's State Ave crossing. |
| **Edwards Rd frontage** | The one road connecting old Norwood to new Norwood — a natural squeeze point between two completely different chase textures. |

### Sight lines / overwatch
| From | Sees |
|------|------|
| GM foundations (high ground / rubble piles) | The whole plant site and the Lateral cut |
| US Playing Card Co. water tower | Beech Ave and the eastern approach to the Grid |
| Norwood City Hall upper floor | The Pike's civic core |
| Central Parke parking structure roof | Edwards Rd and the Rookwood lot |
| Gate-booth remnant | The Lateral ramps |

### Natural chase routes
1. **The Lateral run:** onto SR-562 at speed — the district's one true highway stretch, few exits, fastest way through or out.
2. **Pike stop-and-go:** Montgomery Road's storefront gauntlet, cross-traffic and pedestrians turning speed into risk.
3. **Gravel maze:** through the plant site's foundations and fence gaps — unpredictable surface, broken-curb jumps, no clean lines.
4. **Grid backstreets:** the bungalow alley network — quiet, tight, witness-heavy, a local-knowledge escape with real consequences.
5. **Clean-lane sprint:** Central Parke/Rookwood's new pavement — wide, watched, and a jarring contrast to everywhere else in the district (private security here is a new thing, not police).
6. **Dead-spur slip:** the old rail spur behind the plant fence — quiet, slow, the district's one true stealth route.

### Stakeout spots
Diner window on the Pike (Montgomery traffic), GM foundations high ground (the whole plant site), Central Parke rooftop/garage (the Edge), gate-booth payphone (the Lateral ramps), corner store (the Grid).

---

## 6. Systems tie-ins (SUGGESTIONS — nothing wired here)

**TurfNodes (proposed, both Neutral — same pattern as `TurfNode_WarsawAve`/`TurfNode_AndersonFerry` in the Price Hill doc):**
| Node | Faction | captureType | Notes |
|------|---------|-------------|-------|
| TurfNode_NorwoodPlantSite | Neutral (no startingFaction) | CombatGauntlet | The GM foundations — genuinely contested ground, no clubhouse anchoring it to anyone. This is the district's real prize. |
| TurfNode_MontgomeryPike | Neutral (no startingFaction) | Race | The Pike's hero block — a main-street race with no home team, same shape as Warsaw Ave. |

- **Jurisdiction as heat flavor:** Norwood PD is a real, tiny, separate department from CPD — crossing into or out of Norwood is a genuine jurisdiction change, not fiction. Suggested rule, needing its own pass (same caveat Newport's mid-river mechanic carries): heat could hand off or partially decay at the city line, distinct from the already-implemented gang-scoped `HeatSystem.HandleJurisdictionCrossing()` (which handles faction-vs-faction pursuit handoff, not police jurisdiction) — this would be a police-side sibling mechanic, not a reuse of that code path. Flag before building; it touches core heat rules.
- **US Playing Card Co. shift change:** twice-daily traffic event, same mechanism as Newport Steel/Champion-Ford in the companion docs.
- **Faction brushes (presence without ownership — keeps the ground genuinely contested, not just empty):**
  - **Rust Barons:** the plant site's scrap potential is exactly their economy — occasional scavenging runs via G2, never a claim.
  - **Highway Kin:** the Lateral is a legitimate east-west cut for convoys avoiding downtown — occasional sightings on SR-562, not turf overlap (same restraint as their Price Hill G4 brush).
  - **Neon Saints:** their "corporate-backed" canon line (per the Downtown/OTR doc) makes Central Parke's office tenants a plausible scouting interest — flavor only, no claim.
  - **Phantoms:** no presence, but the plant site's dead rail spur is exactly the kind of forgotten infrastructure their lore gravitates to — a hook, not a claim, same restraint every companion doc gives them.
- **Why nobody commits:** each of those four brushes is real but thin — nobody has the geography, economy, or manpower to actually hold Norwood full-time. That thinness *is* the gameplay: whoever shows up in force on a given night can flip TurfNode_NorwoodPlantSite, and it won't stay flipped.

---

## 7. Period accuracy — 1995 checklist

- **Black Wednesday was August 26, 1987** — eight years gone by 1995, living memory, not history. Ex-line workers in their 40s–50s populate the Pike's bars; the red-Camaro-as-last-car detail is exactly the kind of thing repeated at a bar, not a plaque.
- **Most of the 50-acre plant is demolished, not redeveloped.** No Ohio Business College campus, no GE Aviation presence — those are 2000s+ facts. In 1995 it's gravel, foundations, and fence — a hole, not a replacement.
- **US Playing Card Co. is fully operational** — don't undercut Beech Ave's working-anchor role; the company doesn't wind down for years yet.
- **Central Parke (1991–93) exists; Rookwood Pavilion (1993–94) exists and is gaining traction but is still new and unproven.** **Rookwood Commons (2000) and Rookwood Exchange do not exist in 1995** — do not build or reference them. Retail here is an experiment, not a destination.
- **Norwood's independence is real and load-bearing:** its own PD, fire department, public works, and school district since 1903 incorporation. NPC dialogue can lean on this ("that's Norwood's problem, not ours") without exaggeration.
- **Sensitivity guardrail — the 1990 BASF explosion:** a real chemical explosion on the Norwood/Evanston border in 1990 killed 2 people and injured 90, five years before this setting. **This is not an explorable location, mission site, or set dressing, and never will be.** If referenced at all, it's a single passing line from an NPC ("since the plant blew" — nothing more specific) — never a place the player visits, never a plot device. Same precedent as the Beverly Hills Supper Club fire in the Newport doc: when in doubt, leave it out entirely.
- **No cell phones.** Payphones: the Pike diner, gate-booth remnant, corner store in the Grid, Rookwood Pavilion lot.
- **Radio/TV:** same regional mix as every companion doc — WEBN rock radio, Reds strike hangover (bitter, useful NPC chatter, same as Price Hill/Newport).
- **"Gem of the Highlands"** is the real period civic slogan — earnest, not ironic, even with the tax base gone. Use it as genuine local pride, not a punchline.
- **Tone guardrail:** Norwood in '95 is a town absorbing a real economic hit with real dignity — stubborn and proud, not defeated. The plant site is a wound the city is visibly, slowly working through (the demolition disputes were real and recent), not a wasteland played for atmosphere alone.

---

## 8. Blockout notes for the build

1. **The Lateral is the level's spine.** Build SR-562's cut through the plant site first, with real limited-access geometry (retaining walls, a handful of ramps) — this is the first district in the game that needs a genuine highway interchange, not a surface-street stand-in.
2. **The plant site is open, not maze-like.** Unlike Price Hill's Crown City Barrel or Queensgate's Yard, the GM foundations should read as *emptiness* — wide sightlines, gravel, low scattered obstacles. The contrast with the Pike's tight storefront block is the district's core spatial joke.
3. **Compact grid, flat terrain:** no big vertical story here (unlike Price Hill) — resist adding elevation drama Norwood doesn't have. The Lateral's trench is the district's only real grade change.
4. **Kits:** bungalow/Foursquare housing kit (light reuse of Price Hill's WPH kit is plausible — same building era), Pike storefront kit (thriving/vacant variants in the same kit), industrial brick kit (Works + plant remnants), and a new corporate-office/parking-lot kit for the Edge — this is the first appearance of that texture in the game and shouldn't reuse anything.
5. **The Beech Ave rail siding needs live-train scripting** — same small ambient system as Price Hill's State Ave crossing, contrasted against the plant's dead spur nearby.
6. **BASF site: do not model it, do not signpost it.** No location, no marker, no mission hook tied to the Norwood/Evanston border explosion — confirmed out of scope per §7.
7. **Existing scene note:** same caveat as every companion doc — no TurfNode currently exists for this district, and no district in the project has a real coordinate plan yet. Don't place §6's proposed nodes until that pass happens.
