# Project Project1-SHMUP

[Markdown Cheatsheet](https://github.com/adam-p/markdown-here/wiki/Markdown-Here-Cheatsheet)

### Student Info

-   Name: Andrew
-   Section: 06

## Game Design

-   Camera Orientation: topdown
-   Camera Movement: static / fixed
-   Player Health: The player has a health bar that resets at the end of each round
-   End Condition: The player's health is reduced to zero
-   Scoring: The player can earn points by killing enemies, and by surviving an entire wave

### Game Description
An Asteroids clone, the player has the freedom to move in any direction within the bounds of the screen, but as enemies start to fill the game space and attack the player things get a bit crowded. The player must survive an ever increasing number of enemies each wave for as long as possible, the only true test is how long you'll be able to hold out before the enemy ships destroy you...

### Controls

-   Movement:
   -   Direction: focus on player's cursor
   -   Boost: space bar enables / disables acceleration
-   Fire: Left Mouse Click

## Your Additions
The game has mutiple different enemy types:
    The Exploder: While faster than the others, the exploder cannot fire projectiles. It instead throws itself at the player in order to deal damage.
    The Flotilla: A group that relies on their numbers to catch the player. They sweep from one side of the screen to the next, all the while firing projectiles in a straight line.
    The Artillery: Once they've made their way on screen, they become immobile and focus fire directly at the player, wherever they may be.

Spawning: I designed the enemy spawner to be adaptable to the different types of enemies within the game as well as used in the ramping difficulty of subsequent waves; it randomly selects a side of the game area and spawns however many enemies is required, it then spaces out each enemy evenly across the selected edge.
 
## Sources

Space Patrol Sprite Sheet -
http://freegameassets.blogspot.com/search?q=space+patrol

Pixel Nebula Space Background -
https://pixel-carvel.itch.io/space-background-2?download

HUD Assets - 
https://adwitr.itch.io/pixel-health-bar-asset-pack-2

## Known Issues



### Requirements not completed

_If you did not complete a project requirement, notate that here_

