READ ME - Zombie Survival Prototype

Overview
A 2D top-down Unity prototype game where the player must collect coins and avoid zombies. 
Currently, zombies do not deal damage to the player. But there are two types of zombies players would be avoiding: the chaser and walker zombies.

Features:
- Player:
-   Smooth Rigidbody2D movement using acceleration/deceleration.
-   Collects coins on collision (destroys coin).
- Coins:
-   Spawned at random positions on a timer via coroutines.
-   Multiple coin variations selected from a prefab list.
- Enemies:
-   WalkerEnemy: Picks a random direction on spawn and keeps moving.
-   ChaserEnemy: Finds the players and moves toward them every frame.

Systems
- GameManager: spawns coins + zombies on timers.
- EnemyControl: controls both enemy types (tag-based).
- PlayerControl: handles input + movement.

Controls:
WASD/Arrow Keys - movement.

References:
- Coin Prefabs: https://assetstore.unity.com/packages/2d/environments/2d-animated-coin-2d-rpk-22009#publisher
- Zombie Prefab: https://assetstore.unity.com/packages/2d/characters/2d-chibi-boy-zombie-character-animated-ready-for-mobile-68508
