# AI-and-procedural-animation
AI State Machine for enemy monster moving with procedural animation.
Both functionalities were built with C#.

1. Open with Unity.
2. In the "Scenes" folder open the "Maze" scene.

The state machine changes state each time the right conditions are met.

By default the AI roams on the map by picking a random position around it.

If the player gets close to the enemy, the hunt state is on and the monster starts chasing the player.

If the player gets even closer, the attack state is on and the enemy starts attacking the player.

The console indicates the state that the AI is on by printing messages.

The monster moves its limbs using procedural animation.
