# AI-and-procedural-animation
AI State Machine for enemy monster moving with procedural animation.

Both functionalities were built with C#.

1. Open the AI_&_Procedural_Animation folder with Unity.
2. In the Scenes folder open the Maze scene.
3. Start the application.

The state machine changes state each time the right conditions are met.

By default the AI roams on the map by picking a random position around it.

If the player gets close to the enemy, the hunt state is on and the monster starts chasing the player.

If the player gets even closer, the attack state is on and the enemy starts attacking the player.

The console indicates the state that the AI is on by printing messages.

The monster's limbs are moving procedurally with C# code.

![Screenshot_37](https://user-images.githubusercontent.com/129271569/229306651-1e28cad5-23ef-4585-9d1f-fa3a72ba14c4.png)

