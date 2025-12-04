# StarFox-Style 3D Game – Unity Project (MV Pràctica 3)

**Language:** C# (Unity)  
**README Language:** English

---

## ⭐ Project Summary
This project is a 3D space‑shooter game inspired by **StarFox**, created as part of the *Pràctica 3 – Modelització i Visualització de Dades*.  
It demonstrates Unity scene design, player and enemy scripting, 3D modelling, level management and UI implementation.

The practice focuses heavily on Unity’s editor tools (prefabs, scenes, UI, physics), with scripts controlling gameplay behaviour.  
The game includes 3 levels, multiple enemy types, obstacles, projectiles, power‑ups, a respawn system, and full menu navigation.

---

## 🧩 Technologies & Skills Demonstrated

### **Unity Game Development**
- 3D scenes, prefabs, materials  
- Rigidbody movement  
- Collisions & triggers  
- Particle systems & VFX  
- Camera follow system  
- UI (menus, pause, HUD)  
- Scene transitions & level flow  

### **C# Programming**
- Player controller  
- Projectile system  
- Obstacle & enemy behaviours  
- Power‑ups (Ultimate & Slow Mode)  
- Level manager  
- Respawn and game state control  

### **Teamwork & Project Structure**
- Division of tasks  
- Playtesting & debugging  
- Iteration on game mechanics and balancing  

---

## 📁 Project Structure (Scripts)

```
Scripts/
├── PlayerController.cs           → Player movement and inputs
├── ShootingController.cs         → Projectile firing logic
├── EnemyBehaviour.cs             → Enemy movement and attack patterns
├── ObstacleSpawner.cs            → Spawning obstacles in waves
├── EnemySpawner.cs               → Enemy wave spawning
├── PowerUpUltimate.cs            → Temporary ultimate mode
├── PowerUpSlow.cs                → Global slow‑motion effect
├── Projectile.cs                 → Bullet behaviour and collision logic
├── LevelManager.cs               → Level progression for Lv1, Lv2, Lv3
├── MenuManager.cs                → Main menu & pause menu controls
└── RespawnSystem.cs              → Restart / reset logic after death
```

### Design Philosophy
- Component‑based logic  
- Inspector‑driven parameters  
- Reusable prefabs for obstacles/enemies  
- 3‑stage level progression to showcase all mechanics  

---

## 🔍 Project Details

### **Level Flow**
- **Level 1 — Obstacles**  
  Tests dodging and collision detection  

- **Level 2 — Enemies**  
  Enemy AI behaviour, projectile combat  

- **Level 3 — Combined**  
  Obstacles + enemies to stress‑test all mechanics  

---

### **Player Mechanics**

#### Controls
```
Movement        →  WASD or Arrow Keys  
Shoot           →  Z  
Ultimate        →  X  
Slow Mode       →  C  
Pause Menu      →  ESC  
```

#### Core Abilities
- Smooth movement using rigidbodies  
- Projectile firing  
- Ultimate mode (high‑damage/rapid fire)  
- Slow‑motion effect that reduces obstacle/enemy speed  
- Death + respawn system  

---

## ▶️ How to Run the Project

### 1. Open in Unity
```
Unity Hub → Open project → Select folder
```

### 2. Load Main Scene
```
Assets/Scenes/MainMenu.unity
```

### 3. Play
Click the **Play** button.

---

## ✔ Summary
This project is a complete Unity 3D arcade shooter showcasing:
- Movement, shooting and power‑ups  
- Enemy & obstacle systems  
- Level design and UI menus  
- Collaborative development  
- Combined scripting + editor‑based workflow  

A strong demonstration of Unity game creation and gameplay programming.

