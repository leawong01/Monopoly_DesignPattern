using System;
namespace ProjetMonopoly
{
    public interface DiceRollStrategy
    {
        int DisplayDiceRoll(Dice dice, Player p, int i);
    }
}
