# ASPHALT ANARCHY: QUEEN CITY '95
## Unity C# Framework

This is a production-ready C# architecture for the open-world vehicular combat racing game *Asphalt Anarchy: Queen City '95*. It implements the core systems from the GDD using Unity best practices: ScriptableObjects for data, event-driven architecture, and clean separation of concerns.

---

## Project Structure

This is a standard Unity project. Open it via Unity Hub → Add → select this folder (targets Unity 6000.5.6f1).

```
AsphaltAnarchy_QueenCity95_Unity_FIXED/
├── Assets/
│   ├── Scripts/
│   │   ├── Core/
│   │   │   ├── GameManager.cs          # Central state machine, save/load
│   │   │   ├── PlayerStats.cs          # Persistent progression, upgrades
│   │   │   ├── InputManager.cs         # Centralized input handling
│   │   │   ├── WeatherSystem.cs        # Dynamic weather affecting gameplay
│   │   │   ├── RaceManager.cs          # Race events, checkpoints, timing
│   │   │   └── RaceHUD.cs              # HUD wiring stub
│   │   ├── Vehicle/
│   │   │   └── MotorcycleController.cs # Physics-based bike with WheelColliders
│   │   ├── Combat/
│   │   │   ├── WeaponManager.cs        # Melee combat, swing timing, hit detection
│   │   │   ├── GrabSystem.cs           # Grab & Hijack maneuvers
│   │   │   └── EnemyHealth.cs          # Damage, dismount, stun, death
│   │   ├── Echo/
│   │   │   ├── EchoSystem.cs           # Reputation, psychological warfare, Myth Walk
│   │   │   ├── TrafficLight.cs         # Environment reactivity stub
│   │   │   └── PoliceUnit.cs           # Police diversion stub
│   │   ├── Factions/
│   │   │   ├── FactionManager.cs       # Faction relations, territory counts
│   │   │   ├── TurfWarManager.cs       # Turf node claiming, defense events
│   │   │   └── TurfNode.cs             # Individual capturable territory
│   │   └── AI/
│   │       ├── EnemyAI.cs              # Echo-reactive AI with pack tactics
│   │       └── EnemyAIManager.cs       # Spawn pools, global fear updates
│   ├── ScriptableObjects/
│   │   ├── WeaponData.cs               # Melee weapon definitions
│   │   └── FactionData.cs              # Faction/gang definitions
│   ├── Scenes/                         # Add your scenes here
│   ├── Prefabs/                        # Player/enemy bike prefabs
│   └── Materials/
├── Packages/
│   └── manifest.json                   # Package dependencies (ugui, TextMeshPro, physics/vehicle/audio modules, ...)
├── ProjectSettings/
│   ├── ProjectVersion.txt              # Unity 6000.5.6f1
│   ├── TagManager.asset                # Pre-defines Asphalt/WetAsphalt/Brick/MetalGrating/Dirt tags + vehicle layers
│   └── EditorBuildSettings.asset
└── .gitignore
```

---

## Core Systems

### 1. GameManager (State Machine & Persistence)
- Manages `GameState` transitions: Exploring, Racing, Combat, Cutscene, Paused, GameOver
- Handles JSON save/load with `SaveData` serialization
- Broadcasts global events via C# `Action` delegates

### 2. MotorcycleController (Physics Vehicle)
- Uses Unity `WheelCollider` for realistic motorcycle physics
- Speed-sensitive steering and leaning
- Surface detection (Asphalt, WetAsphalt, Brick, MetalGrating, Dirt) with grip multipliers
- Anti-flip torque stabilization
- Nitrous boost integration
- Visual wheel mesh synchronization

### 3. Combat System

#### WeaponManager
- ScriptableObject-driven weapon data (damage, weight, reach, cooldown, dismount chance)
- Speed-modified swing timing (heavier weapons swing slower at high speed)
- High-speed damage multiplier (~120mph+)
- Hit detection with cone-based targeting
- Knockback and dismount chance on impact

#### GrabSystem
- **Grab (F key):** Reach out, grab enemy handlebars, steer them into obstacles. Risk of counter-attack.
- **Hijack (G key):** Jump arc from bike to bike, tackle enemy, steal vehicle. Requires unlock.
- Both use coroutine-based timing windows

#### EnemyHealth
- Health, stun, dismount, and death states
- Ragdoll spawn on dismount
- Scrap loot drops
- Echo point awards on defeat

### 4. Echo System (The Legend)
The centerpiece mechanic. As the player builds reputation:

- **10 Echo Levels:** Points awarded from races, combat, hijacks, stunts, turf claims
- **Living Graffiti:** Echo Tags spawn in claimed territories as notoriety grows
- **Psychological Warfare:** AI fear factor calculated from Echo level and distance
  - Low Echo: Enemies aggressive
  - Mid Echo: Enemies hesitant, make mistakes
  - High Echo: Enemies flee or freeze in terror
- **Myth Walk (Max Level):** Environment assists player — traffic lights turn green, police diverted, silent convoys block pursuers

### 5. Faction & Turf War System

#### FactionData (ScriptableObject)
- Defines each of the 5 gangs: Neon Saints, Rust Barons, OTR Syndicate, Kentucky Kings, Phantoms
- Personality stats: aggression, coordination, fear threshold, defensiveness
- Echo response descriptions per fear level
- Territory assignments and bike/rider prefabs

#### FactionManager
- Dynamic relation tracking (-1 to +1 scale)
- Hostile faction detection
- Save/load serialization

#### TurfWarManager & TurfNode
- Turf Nodes claimable via Race, Combat Gauntlet, or Stunt challenges
- Dynamic defense events: factions attempt to reclaim lost nodes
- Safehouse unlocks on capture
- Territory count tracking per faction

### 6. Enemy AI
- **6 AI States:** Patrol, Chase, Attack, Flee, Frozen, Hesitant
- **Faction-Specific Combat:**
  - Neon Saints: Coordinated pack surrounds
  - Rust Barons: Full-throttle ramming
  - OTR Syndicate: Hit-and-run alley tactics
  - Kentucky Kings: High-speed drafting and sideswiping
  - Phantoms: Erratic, unpredictable psychological intimidation
- **Pack Tactics:** Leaders coordinate flanking; members follow
- **Echo Reactivity:** Fear level drives state transitions in real-time
- **Grab Response:** AI can counter-grab, causing player balance loss

### 7. Weather System
- 6 weather states: Clear, LightRain, HeavyRain, RiverMist, Fog, Storm
- Affects surface grip (wet asphalt = 0.7x multiplier)
- Dynamic fog density and visibility range
- Time-of-day cycle with sun rotation
- Ambient audio switching
- `ForceStormForFinalConfrontation()` for Act 3 climax

---

## Setup Instructions

### 1. Scene Setup
1. Create a new Unity scene
2. Add a ground plane with collider, tagged appropriately ("Asphalt", "WetAsphalt", etc.)
3. Create a Player GameObject:
   - Add `Rigidbody` (mass ~300, drag 0.5, angular drag 3)
   - Add `MotorcycleController` script
   - Add two child GameObjects with `WheelCollider` components (Front, Rear)
   - Add `PlayerStats`, `WeaponManager`, `GrabSystem`
   - Tag as "Player"

### 2. Weapon ScriptableObjects
1. In Project window: `Create > Asphalt Anarchy > Weapon`
2. Create weapons:
   - **Baseball Bat:** damage 25, weight 2, reach 2, cooldown 0.8s
   - **Heavy Chain:** damage 35, weight 5, reach 2.5, cooldown 1.2s, highSpeedMult 3.0
   - **Electrified Baton:** damage 20, weight 1.5, reach 1.8, stun 1s, electrified true

### 3. Faction ScriptableObjects
1. `Create > Asphalt Anarchy > Faction`
2. Create all 5 factions with unique colors, territories, and AI personalities

### 4. Turf Nodes
1. Create empty GameObjects in the scene
2. Add `TurfNode` script
3. Assign capture type, difficulty, rewards
4. Add trigger colliders for enter/exit detection

### 5. Enemy Prefabs
1. Duplicate player bike setup
2. Add `EnemyAI`, `EnemyHealth` scripts
3. Assign faction data
4. Create prefabs for each faction's bike style
5. Assign to `EnemyAIManager` spawn pools

### 6. UI
1. Create Canvas with RaceHUD, health bar, speedometer, Echo meter
2. Wire up to script events (OnHealthChanged, OnEchoPointsChanged, etc.)

---

## Key Design Patterns

- **Event-Driven Architecture:** C# `Action` delegates decouple systems (e.g., `OnEchoLevelUp`, `OnEnemyDied`)
- **ScriptableObjects:** Designer-friendly data for weapons, factions, and any expandable content
- **State Machines:** `GameState` enum + `AIState` enum with explicit transitions
- **Component-Based:** Each behavior is a separate MonoBehaviour for mix-and-match enemies
- **Serializable Data:** All persistent state uses `[System.Serializable]` classes for JSON save/load

---

## Extension Points

- **Stunt System:** Add `StuntManager` that listens to bike airtime, wheelies, jumps
- **Police System:** Expand `PoliceUnit` with pursuit AI, roadblocks, helicopter tracking
- **Upgrade Shop:** UI that calls `PlayerStats.UpgradeEngine()`, etc.
- **Narrative System:** `DialogueManager` triggered by Echo level milestones
- **Audio Manager:** Dynamic soundtrack shifting based on speed, combat, Echo level
- **Save System:** Replace JSON with encrypted binary or cloud save

---

*"The city remembers what the law wants to forget."*
