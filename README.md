# Project Name
One Button Time Machine

## Theme
You have a time machine under your fingertips.  
Whenever you press the Space key, you jump between past and present.  
By switching timelines at the right moment, you can avoid incoming disasters and reach a safe future.

## Game Play
Goal:
Follow the trail of coins, dodge obstacles by switching timelines, and reach the end of the level.

Controls:

- Space – Switch between two timelines (past / present → visually also day / night).
- Mouse – Used only for menus (Start, Restart, Main Menu, Quit).

Gameplay Loop:

1. The player character auto-runs forward on the ground.
2. Different obstacles exist in different timelines:
   - Some platforms/obstacles only appear in the “past”.
   - Others only appear in the “present”.
3. Press Space at the right timing to make certain obstacles disappear.
4. Collect coins along the path:
   - Coins act as a visual guide to show a “safe route” through the level.
5. Reach the final goal object:
   - Touching the goal triggers the Win scene.

If you hit an obstacle, you die and are sent to the Game Over screen.


## What did you 

Before this project, I only had very basic experience with C#.  
I heard that writing scripts in C# would make gameplay logic much easier, so I temporarily “crammed” C# by watching tutorials on Bilibili.
However, because my study time was short, I frequently ran into bugs when writing or modifying scripts.  
At first this was very frustrating, but then I discovered something important:  
I could ask friends and roommates who had more experience to help me debug and explain my mistakes.
This saved a lot of time and helped me actually understand how C# work.


## Implementation

One-button core mechanic (Space):
  - Single key controls world switching (time travel).
- Kenney pixel art resources:
  - Basic pixel-style sprites and tiles to create a clean 2D look.
- Multiple sound layers:
  - Background music for:
    - Main Menu
    - Day / Night (past / present) in the game scene
  - Sound effects for:
    - Switching worlds
    - Picking up coins
- Visual switch effects:
  - Background color / sprite changes to indicate past vs. present.
  - Different sets of obstacles appear/disappear with each switch.
- Simple animations:
  - Coins rotate to draw the player’s attention.
- Interactive UI:
  - Start menu with Play / Quit.
  - In-game coin counter.
  - Game Over panel with Restart / Main Menu.
  - Win scene or Win panel triggered when reaching the goal.

## Special Focus
What is your special focus? What did you do for it? How would you rate your own effort? 1-5. (I will agree or disagree with this sentiment, but I want to know what you thought)

## References

## Future Development
+ Platform for only past / present
# Created by: Zhoutong Li