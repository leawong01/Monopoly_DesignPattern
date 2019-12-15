# Monopoly_DesignPattern
Monopoly_DesignPattern

## Patterns used:   

Factory pattern   
Strategy Pattern   
Singleton Pattern   

## Rules:   

The players (2 to 8) move their pawn on a 40 cells board.   
Each turn the roll 2 dices a move the pawn by the sum of both of them.    
If the player makes a double, he can play again. However, if he makes 3 double in a row, he goes directly to jail.   
To go out of jail, 2 options: he can pay 50euros the next turn or try to make a double.   
If he can’t make a double for 3turns, he pays 50euros, roll the dices and move his pawn.   
If he makes a double, he moves his pawn but don’t play again.   
Each time a player goes through the start cell, he earns 200euros.   
The game will end if all the players but one are bankrupt.  

## Structure of the code:  

9 different classes:  

--> 2 for the strategy pattern: PlayerFactory and Player   
--> 1 for the singleton pattern: Board   
--> 3 for the strategy pattern: DiceRollStrategy, JailRollDice, RegularRollDice   

The Menu class for the game process and all the display code.   
The 2 last are the Cell class that contains all the whereabout about the board’s cells; namely the type, the buying price, the rent and the position of each. The last one is the Dice class that manage the two dices to return the sum and to indicates if the dice roll is or not a double.

## Development of the singleton pattern:  

We use the singleton pattern to create one and only one board for the monopoly game. 
We use the getInstance method as an access point for the single instance of the singleton. If there is no instance, it creates one, and return it and if there is one it returns the existing one.

## Development of the factory pattern:  

This pattern requires at least 2 classes. The first one is the object we want to create, here a player.  
So we develop all the characteristics of a player in this class.   
The second one is the factory class. It’s the class that allows us to declare a new player without have access of the details of the player class.   
We just declare a number that will be the pawn of the player. Indeed, the pawns are in an enumerator and the integer between 1 and 8 is used just to pick a pawn in the list.   
The factory informs then the starting balance and position before instantiating a new player with the GetPlayer() method. 

## Development of the strategy pattern: 

This pattern is used when we several functions are quite similar. 
We first need an interface, here the RollDiceStrategy interface. We define there the common structure of the functions. Our function is the roll dice whether the player is in jail or not. 
Then we create 2 classes, RegularRollDice, the common one, and JailRollDice for when a player is in jail. 
Indeed, the strategy pattern is very convenient since the only difference between the two functions are the information displayed on the terminal and how the pawn will respond to this information, but the process is the same: roll the dices and analyze the result. Is it a double or not?

## Game play: 

At first, when a game is launch, we must provide the number of players (between 2 and 8). Pawns are affiliated and the game can start. 
The name of the player currently playing is indicated at the beginning of each turn. The player rolls the dices and move his pawn according to the result. If he is in jail, he must follow the instructions on the terminal. 
After the pawn’s moving, we display information about the cell where the pawn stopped. 
The player has access to his balance only when he must spend money (taxes cell, going out of jail, …). 
Each time a pawn finishes the loop of the board, the player earns 200€. 
Finally, the game stops when only one player is not bankrupt. Nevertheless, we didn’t program all the functionalities of the game namely the purchase and the rent of each cell, so the players don’t really spend or lose money, so this stopping condition is hard to reach. 
To end this game, like in real life, -because we know no one has ever finish a Monopoly game- you just quit the program. 
