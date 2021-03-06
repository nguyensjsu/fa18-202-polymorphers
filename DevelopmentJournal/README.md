# Project Report - CMPE202 18Fall

## Project - Jeopardy Game

### Team Name
* Polymorphers

### Team Members

* [Jinzhou Tao](https://github.com/adiosray)
* [David Montes](https://github.com/davidpmontes)
* [Siyi Cai](https://github.com/CSIYI)
* [Fei Wang](https://github.com/feiwang6079)

### Project Detail

We've developed a jeopardy game desktop application using C# and unity. The basic game play, load/save game, edit game, sound effect functions are implemented.

## Project Progress

### Burndown Map

![](https://github.com/nguyensjsu/fa18-202-polymorphers/blob/master/DevelopmentJournal/BurndownMap%2011:30:18.png)

### Project Dashboard

![](https://github.com/nguyensjsu/fa18-202-polymorphers/blob/master/DevelopmentJournal/ProjectBoard%2011:30:18.png)

### Code Contribution

![](https://github.com/nguyensjsu/fa18-202-polymorphers/blob/master/DevelopmentJournal/CodeContribution%2011:30:18.png)

## Individual Contributions

### Jinzhou Tao
* GameData: Data structure design and its access api
* GameDataManager: Save/Load gamedata from file and resume it into GameData object
* CreateGame Scene: Create the control panel with code and 
* **Design Pattern**: Memento (for save/load game)

#### David Montes
* Demo: Wireless Controllers
* UI: Screen, Overlays, and UI elements
* Documentation: UI Wireframes
* Demo: Dual screen
* Gamecontrollers: Buzzin logic
* Animation: Fade in and fade out transition between screens.

#### Siyi Cai
* Animation: Create Daily Double Animation
* Music Control: Control Music for the game
* Image Loading: Realize image loading from local disk to the CreateGame Scene and PlayGame Scene
* Timer Control: Realize timer controll logic in the QA Question Panel
* Buzzing System: Realize the control of Buzz-in logics
* **Design Pattern**: State Design Pattern (for timer in the QA Panel)

#### Fei Wang
* CreateGame:  Implement the funtion to create games, storage team and question
* PlayGame:    Implement the funtion to play game, control two screens to display game information
* **Design Pattern**: Observer Design Pattern (Used to modify information to notify two screens)
