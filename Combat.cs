namespace Negasus;

class Combat
{
    public static void RandEncounter()
    {        
        EnemyStats.enemyName = EnemyTools.EnemyName();


        Program.Typewrite("\nYou come to the top of the stairs, already feeling like you have");
        Program.Typewrite("been in here for an eternity. Emerging into the room, you");
        Program.Typewrite($"are approached by an angry {EnemyStats.enemyName}!");
        Program.Typewrite("...");
        Console.ReadKey(true);        
        

        //Player turn                    

        while ((Program.currentPlayer.health > 0) && (EnemyStats.enemyHealth > 0))
        {
            if (Program.currentPlayer.health > 0)
            {
            
            //Enemy Def boost resolution
            if (EnemyStats.enemyChoice == 2)
            {
                EnemyStats.enemyDef -= 4;
            }                
                
                Program.Typewrite($"\n{Program.currentPlayer.name}'s HP: {Program.currentPlayer.health} / {Program.currentPlayer.maxHealth}");
                Program.Typewrite($"Defense: {Program.currentPlayer.defense}");

                Program.Typewrite($"\n{EnemyStats.enemyName}'s HP: {EnemyStats.enemyHealth}");
                Program.Typewrite($"Def: {EnemyStats.enemyDef}");
                Program.Typewrite("\nWhat will you do?");
                Console.WriteLine("|~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~|");
                Console.WriteLine("| A: Attack - Deal damage + strength        |");
                Console.WriteLine("| B: Power Attack - Strong but inaccurate   |");
                Console.WriteLine("| C: Defend - + Defense until next turn     |");
                Console.WriteLine("|~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~|");
                WhutTwo:
                Program.currentPlayer.combatChoice = Console.ReadLine().ToUpper();
                
                switch (Program.currentPlayer.combatChoice)
                {
                    case "A":
                        Program.Typewrite($"\n{Program.currentPlayer.name} attacks!");                    
                        Program.currentPlayer.playerAtkRoll = Rolls.rand.Next(1, 21);
                        Program.Typewrite("...");
                        Console.ReadKey(true);
                            
                        if (Program.currentPlayer.playerAtkRoll == 20)
                        {
                            Program.Typewrite($"{Program.currentPlayer.name} rolls {Program.currentPlayer.playerAtkRoll}!");
                            Program.currentPlayer.damage = Rolls.rand.Next(2, 13) + Program.currentPlayer.strength;
                            Program.Typewrite("\nCRITICAL HIT!!");
                            Program.Typewrite($"{Program.currentPlayer.name} deals {Program.currentPlayer.damage} damage!");
                            EnemyStats.enemyHealth -= Program.currentPlayer.damage;
                            Program.Typewrite("...");
                            Console.ReadKey(true);
                        }
                        else if (Program.currentPlayer.playerAtkRoll != 20)
                        {
                            Program.Typewrite($"{Program.currentPlayer.name} rolls {Program.currentPlayer.playerAtkRoll} + {Program.currentPlayer.agility / 2}!");
                            Program.currentPlayer.playerAtkRoll += (Program.currentPlayer.agility / 2);
                                if (Program.currentPlayer.playerAtkRoll >= EnemyStats.enemyDef)
                                {                                
                                    Program.currentPlayer.damage = Rolls.rand.Next(1, 7) + (Program.currentPlayer.strength / 2);
                                    Program.Typewrite($"\n{Program.currentPlayer.name} hits for {Program.currentPlayer.damage} damage!");
                                    EnemyStats.enemyHealth -= Program.currentPlayer.damage;
                                    Program.Typewrite("...");
                                    Console.ReadKey(true);                                    
                                }
                                else
                                {
                                    Program.Typewrite($"\n{Program.currentPlayer.name} misses!");
                                    Program.Typewrite("...");
                                    Console.ReadKey(true);                                   
                                }
                        }
                        break;                   
                        
                    case "B":
                        Program.Typewrite($"\n{Program.currentPlayer.name} makes a mighty attack!");
                        Program.currentPlayer.playerAtkRoll = Rolls.rand.Next(1, 21);
                        Program.Typewrite("...");
                        Console.ReadKey(true);
                            
                        if (Program.currentPlayer.playerAtkRoll == 20)
                        {
                            Program.Typewrite($"{Program.currentPlayer.name} rolls {Program.currentPlayer.playerAtkRoll} + {Program.currentPlayer.agility / 4}!");
                            Program.currentPlayer.damage = Rolls.rand.Next(3, 19) + Program.currentPlayer.strength;
                            Program.Typewrite("\nCRITICAL HIT!!");
                            Program.Typewrite($"{Program.currentPlayer.name} deals {Program.currentPlayer.damage} damage!");
                            EnemyStats.enemyHealth -= Program.currentPlayer.damage;
                            Program.Typewrite("...");
                            Console.ReadKey(true);
                        }
                        else if (Program.currentPlayer.playerAtkRoll != 20)
                        {
                            Program.Typewrite($"{Program.currentPlayer.name} rolls {Program.currentPlayer.playerAtkRoll} + {Program.currentPlayer.agility / 4}!");
                            Program.currentPlayer.playerAtkRoll += (Program.currentPlayer.agility / 4);
                                if (Program.currentPlayer.playerAtkRoll >= EnemyStats.enemyDef)
                                {
                                    Program.currentPlayer.damage = Rolls.rand.Next(2, 13) + Program.currentPlayer.strength;
                                    Program.Typewrite($"\n{Program.currentPlayer.name} clobbers {EnemyStats.enemyName} for {Program.currentPlayer.damage} damage!");
                                    EnemyStats.enemyHealth -= Program.currentPlayer.damage;
                                    Program.Typewrite("...");
                                    Console.ReadKey(true);                                    
                                }
                                else
                                {
                                    Program.Typewrite($"{Program.currentPlayer.name} misses spectacularly!");
                                    Program.Typewrite("...");
                                    Console.ReadKey(true);
                                }
                        }
                        break;
                        
                    case "C":
                        Program.Typewrite($"\n{Program.currentPlayer.name} adopts a defensive stance!");
                        Program.currentPlayer.defense += 4;
                        Program.Typewrite($"+4 defense until your next turn! Current defense: {Program.currentPlayer.defense}");
                        Program.Typewrite("...");
                        Console.ReadKey(true);
                        break;

                    default:
                        Program.Typewrite("Whut?");
                        goto WhutTwo;                       
                }
            }
            //Enemy turn
            if (EnemyStats.enemyHealth > 0)
            {
                EnemyStats.enemyChoice = Rolls.rand.Next(0, 3);

                switch (EnemyStats.enemyChoice)
                {
                    case 0:
                        Program.Typewrite($"\n{EnemyStats.enemyName} attacks!");
                        EnemyStats.enemyAtkRoll = Rolls.rand.Next(1, 21);
                        Program.Typewrite("...");
                        Console.ReadKey(true);
                        
                        if (EnemyStats.enemyAtkRoll == 20)
                        {
                            Program.Typewrite($"{EnemyStats.enemyName} rolls {EnemyStats.enemyAtkRoll}!");
                            EnemyStats.plusPower = Rolls.rand.Next(2, 13) + (Program.currentPlayer.roomsClear);
                            Program.Typewrite("\nCRITICAL HIT!!");
                            Program.Typewrite($"{EnemyStats.enemyName} deals {EnemyStats.power} damage!");
                            Program.currentPlayer.health -= EnemyStats.power;
                            Program.Typewrite("...");
                            Console.ReadKey(true);
                        }
                        else if (EnemyStats.enemyAtkRoll != 20)
                        {
                            EnemyStats.enemyAtkRoll += (Program.currentPlayer.roomsClear / 2);
                            Program.Typewrite($"{EnemyStats.enemyName} rolls {EnemyStats.enemyAtkRoll} + {Program.currentPlayer.roomsClear / 2}!");
                                if (EnemyStats.enemyAtkRoll >= Program.currentPlayer.defense)
                                {
                                    EnemyStats.power = Rolls.rand.Next(1, 7) + (Program.currentPlayer.roomsClear / 2);
                                    Program.Typewrite($"\n{EnemyStats.enemyName} hits for {EnemyStats.power} damage!");
                                    Program.currentPlayer.health -= EnemyStats.power;
                                    Program.Typewrite("...");
                                    Console.ReadKey(true);                                    
                                }
                                else
                                {
                                    Program.Typewrite($"\n{EnemyStats.enemyName} misses!");
                                    Program.Typewrite("...");
                                    Console.ReadKey(true);                                   
                                }
                        }
                        break;                   
                    
                    case 1:
                        Program.Typewrite($"\n{EnemyStats.enemyName} tries a vicious attack!");
                        EnemyStats.enemyAtkRoll = Rolls.rand.Next(1, 21);
                        Program.Typewrite("...");
                        Console.ReadKey(true);
                        
                        if (EnemyStats.enemyAtkRoll == 20)
                        {
                            Program.Typewrite($"{EnemyStats.enemyName} rolls {EnemyStats.enemyAtkRoll}!");
                            EnemyStats.plusPower = Rolls.rand.Next(2, 13) + Program.currentPlayer.roomsClear;
                            Program.Typewrite("\nCRITICAL HIT!!");
                            Program.Typewrite($"{EnemyStats.enemyName} deals {EnemyStats.plusPower} damage!");
                            Program.currentPlayer.health -= EnemyStats.plusPower;
                            Program.Typewrite("...");
                            Console.ReadKey(true);
                        }
                        else if (EnemyStats.enemyAtkRoll != 20)
                        {
                            EnemyStats.enemyAtkRoll += (Program.currentPlayer.roomsClear / 2);
                                if (EnemyStats.enemyAtkRoll >= Program.currentPlayer.defense)
                                {
                                    EnemyStats.plusPower = Rolls.rand.Next(2, 13) + (Program.currentPlayer.roomsClear / 2);
                                    Program.Typewrite($"\n{EnemyStats.enemyName} clobbers {Program.currentPlayer.name} for {EnemyStats.plusPower} damage!");
                                    Program.currentPlayer.health -= EnemyStats.plusPower;
                                    Program.Typewrite("...");
                                    Console.ReadKey(true);                                    
                                }
                                else
                                {
                                    Program.Typewrite($"\n{EnemyStats.enemyName} aimed poorly and missed!");
                                    Program.Typewrite("...");
                                    Console.ReadKey(true);                                   
                                }
                        }
                        break;      
                    
                    case 2:
                        Program.Typewrite($"\n{EnemyStats.enemyName} adopts a defensive stance!");
                        Program.Typewrite("+4 defense until their next turn!");
                        EnemyStats.enemyDef += 4;
                        Program.Typewrite("...");
                        Console.ReadKey(true);
                        break;
                }
            }

            //Player defense boost resolution
            if (Program.currentPlayer.combatChoice == "C")
            {
                Program.currentPlayer.defense -= 4;
            }
        
        }
    
    }


    //When a random encounter is won.
    public static void RandVictory()
    {
        Program.currentPlayer.roomsClear += 1;
        EnemyStats.enemyHealth = 8 + (Program.currentPlayer.roomsClear * 2);
        EnemyStats.enemyDef = 8 + (Program.currentPlayer.roomsClear / 2);
        
        Program.Typewrite("\nThe enemy falls to your <insert weapon here>!");
        Program.Typewrite("... What? I haven't coded weapons into this game! Sue me!");
        Program.Typewrite("At any rate, you have gained an ability point! Where would");
        Program.Typewrite("you like to dump it?");
        Console.WriteLine("\n|~~~~~~~~~~~~~~~~|");
        Console.WriteLine("| A: Strength    |");
        Console.WriteLine("| B: Agility     |");
        Console.WriteLine("| C: Intellect   |");
        Console.WriteLine("|~~~~~~~~~~~~~~~~|");
        Console.WriteLine($"Current abilities:\nSTR: {Program.currentPlayer.strength}\nAGI: {Program.currentPlayer.agility}\nINT: {Program.currentPlayer.intellect}");

        WhutThree:
        string abilityChoice = Console.ReadLine().ToUpper();

            if (abilityChoice == "A")
            {
                Program.currentPlayer.strength += 1;
                Program.currentPlayer.health += 1;
                Program.currentPlayer.maxHealth += 1;
            }
            else if (abilityChoice == "B")
            {
                Program.currentPlayer.agility += 1;
                Program.currentPlayer.defense += (Program.currentPlayer.agility / 2);
            }
            else if (abilityChoice == "C")
            {
                Program.currentPlayer.intellect += 1;
            }
            else if ((abilityChoice != "A") && (abilityChoice != "B") && (abilityChoice != "C"))
            {
                Program.Typewrite("Whut?");
                goto WhutThree;
            }
    }

    //When a random encounter has been lost.
    public static void RandDefeat()
    {
        Program.towerClimb = false;
        Program.Typewrite($"\n{Program.currentPlayer.name} has fallen! The Negasus will continue to");
        Program.Typewrite("terrorize the land!");
        Program.Typewrite($"\nYou managed to clear {Program.currentPlayer.roomsClear} floors before");
        Program.Typewrite("your untimely demise.");
        //Remove the below code once high score system has been implemented.
        Program.Typewrite("Once I code in the high score system, that will mean something. Until then,");
        Program.Typewrite("just write it down somewhere or tattoo it on your cheek or something so you");
        Program.Typewrite("can brag about it to people who are giving you a weird (scared?) look.");

        Program.Typewrite("Press any key to quit. But don't be a stranger!");
        Console.ReadKey(true);
    }
}