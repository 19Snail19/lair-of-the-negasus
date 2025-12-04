namespace Negasus;

class AbilityAssign
{
    public static void InitialAbilities()
    {
        Program.Typewrite("\n'Maybe the DM is right,' you think to yourself as you trudge up the first");
        Program.Typewrite("stairwell of the Negasus's... Negasususus.... the tower.");
        Program.Typewrite("'Assigning some stat points is probably a good call.'");
        Program.Typewrite("...");
        Console.ReadKey(true);

        Program.Typewrite("\nYou are absolutely correct. Assigning stat points is a GREAT call.");
        Program.Typewrite("Since I am lazy and coding is hard, you only have three abilities");
        Program.Typewrite("in this game: Strength, Agility, and Intellect.");
        Program.Typewrite("...");
        Console.ReadKey(true);
        
        Program.Typewrite("\nSTRENGTH represents how swole you are. Higher strength means your attacks deal");
        Program.Typewrite("more damage and you have more max health. It also helps you complete physical");
        Program.Typewrite("challenges outside of combat.");
        Program.Typewrite("...");
        Console.ReadKey(true);

        Program.Typewrite("\nAGILITY represents the gotta go fast mentality. Higher agility makes you harder");
        Program.Typewrite("to hit and more likely to hit in combat. It also helps you do wicked sweet awesome");
        Program.Typewrite("parkour moves when not in combat.");
        Program.Typewrite("...");
        Console.ReadKey(true);

        Program.Typewrite("\nINTELLECT represents how big brain you are. With high intellect you are more");
        Program.Typewrite("observant and cunning. You can more easily detect traps and secret doors.");
        Program.Typewrite("...");
        Console.ReadKey(true);        
        
        Program.Typewrite("\n\nSince I am such a kind and gracious DM, I will give you 5 ability points");
        Program.Typewrite("to do with as you please. Don't spend them all in one place! Or do. I don't care.");

        AbilityReset:
        Program.currentPlayer.abilityPoints = 5;
        Program.Typewrite("\nHow would you like to spend your points? Each selection will increase the");
        Program.Typewrite("selected ability by 1.");

        while (Program.currentPlayer.abilityPoints > 0)
        {   
        Program.Typewrite($"\nYou have {Program.currentPlayer.abilityPoints} points remaining.");
        Console.WriteLine("\n|~~~~~~~~~~~~~~~~|");
        Console.WriteLine("| A: Strength    |");
        Console.WriteLine("| B: Agility     |");
        Console.WriteLine("| C: Intellect   |");
        Console.WriteLine("|~~~~~~~~~~~~~~~~|");
        Console.WriteLine($"Current abilities:\nSTR: {Program.currentPlayer.strength}\nAGI: {Program.currentPlayer.agility}\nINT: {Program.currentPlayer.intellect}");
        WrongAbility:
        string abilityChoice = Console.ReadLine().ToUpper();
        
            if ((abilityChoice == "A") && (Program.currentPlayer.abilityPoints > 0))
            {
                Program.currentPlayer.abilityPoints -= 1;
                Program.currentPlayer.strength += 1;
                Program.currentPlayer.health += 1;
                Program.currentPlayer.maxHealth += 1;
            }
            else if ((abilityChoice == "B") && (Program.currentPlayer.abilityPoints > 0))
            {
                Program.currentPlayer.abilityPoints -= 1;
                Program.currentPlayer.agility += 1;
                Program.currentPlayer.defense += (Program.currentPlayer.agility / 2);
            }
            else if ((abilityChoice == "C") && (Program.currentPlayer.abilityPoints > 0))
            {
                Program.currentPlayer.abilityPoints -= 1;
                Program.currentPlayer.intellect += 1;
            }
            else if ((abilityChoice != "A") && (abilityChoice != "B") && (abilityChoice != "C"))
            {
                Program.Typewrite("Whut?");
                goto WrongAbility;
            }        
        }

        Program.Typewrite($"\nCurrent abilities:\nSTR: {Program.currentPlayer.strength}\nAGI: {Program.currentPlayer.agility}\nINT: {Program.currentPlayer.intellect}");
        WhutOne:
        Program.Typewrite("Would you like to keep these abilities?\nY/N");
        string tempChoice = Console.ReadLine().ToUpper();

        if (tempChoice == "Y")
        {
            Program.Typewrite("\nVery well! Upward to adventure!");
            Program.Typewrite("...");
            Console.ReadKey(true);
        }
        else if (tempChoice == "N")
        {
            Program.Typewrite("Let's start over then, shall we?");
            Program.currentPlayer.abilityPoints = 5;
            Program.currentPlayer.strength = 1;
            Program.currentPlayer.agility = 1;
            Program.currentPlayer.intellect = 1;
            goto AbilityReset;
        }
        else
        {
            goto WhutOne;
        }
    }

}