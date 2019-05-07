**Space Time Bouncer - AI for a Game**

**Demonstration Videos**



1. [![Space Time Bouncer Demo](http://img.youtube.com/vi/eSxPfe9po7I/0.jpg)](http://www.youtube.com/watch?v=eSxPfe9po7I "Space Time Bouncer Demo")
2. [![Space Time Bouncer - Functionality](http://img.youtube.com/vi/8cTP6jtSlh0/0.jpg)](http://www.youtube.com/watch?v=8cTP6jtSlh0 "Space Time Bouncer - Functionality")

**Game (PC)**



https://drive.google.com/open?id=1AKLM1rZ52s4B9Gi4ojiIprLAEHwBXqXJ
Download the folder, and run "Space Time Bouncer.exe" to play the game

**Objective**



1. To make a 3D game from scratch in Unity Game Engine based on the game “Time Turner” which was also made in Unity. 
2. Make AIs to play the game which we made. A hard coded version and the other with Machine Learning. And compare the two.

[https://play.google.com/store/apps/details?id=com.OnePixelDevelopers.TimeTurner&hl=en_IN](https://play.google.com/store/apps/details?id=com.OnePixelDevelopers.TimeTurner&hl=en_IN)

Time Turner works on the concept that our past imitates our previous actions and we use that to reach previously unreachable spaces in the level world. The past is triggered by collecting the Tesseract.

Additional features included -



*   More interactables like keys and doors and parallel dimension portals, in addition to basic ones like pressure pads, lifts etc.
*   FPS mode, called “Red Mode” like CSGO, COD etc

**Project Timeline**



*   **Game**
    *   Started the game on March 5. Base game is ready to be played with 3 - 4 levels.
    *   Pressure pads, lifts, keys, doors, invisible room added.
    *   Red Mode is also playable and functional. Player and enemy is done. The level (obstacles, walls etc) and goal has to be created.
*   **AI**
    *   Trying the AI currently using Unity’s ML Agents Toolkit. 
    *   The agent or player is able to reach the pressure pad using Reinforcement Learning.
    *   Ideating better ways to give observations to the ML agent so as to get a better trained AI.

**Technical Aspects**



*   **Game**
    *   Movement of the player is done using Vector3.Lerp, velocity in x-z plane and rotation is locked.
    *   Player position is stored once every n frames and once the Tesseract is collected Past Player is moved using Vector3.Lerp again with the stored positions as arguments. Speed is adjusted by trial and error.
*   **AI**
    *   Curriculum Learning is being used. It is basically Reinforcement Learning with particular lessons with increasing difficulty. 
    *   Reinforcement Learning has observations, actions and rewards based on the actions. Basically, the agent _learns_ to choose the right action according to the specified reward, by using the given observations.

**Future Work**



*   **Game**
    *   More levels with increasing difficulty to be made (puzzles can be included).
    *   UI to switch between levels, tutorial, pause, restart, exit game etc has to be added.
    *   Parallel dimension portal to be added. Decide on its features.
    *   For “Red Mode” the level (obstacles, walls etc) and goal has to be created.
    *   Make the game experience and ambience better. Add good lighting and sounds. Custom assets to be made in Blender or Maya to suit the game style.
*   **AI**
    *   Try out Imitation learning from ML Agents.
    *   Try Contextual Bandits.
    *   Try Nav-Mesh and hard coding the waypoints. Essentially hard coding each similar level.
    *   Try level generation using AI.

 


<!-- Docs to Markdown version 1.0β17 -->
