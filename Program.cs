namespace Negasus;

class Program
{
    public static Player currentPlayer = new Player();
    
    public static bool towerClimb = true;
    public static int roomSelect = 0;
    
    static void Main(string[] args)
    {
        Start();
        
        Typewrite("");        

        AbilityAssign.InitialAbilities();

        while (towerClimb == true)
        {
            roomSelect = Rolls.rand.Next(1, 101);

            if (roomSelect <=10)
                {
                    SpecialRooms.HealingRoom();
                }
            else if ((roomSelect >= 11) && (roomSelect <= 20))
                {
                    SpecialRooms.WeaponRoom();
                }                                    
            else if ((roomSelect >= 21) && (roomSelect <=30))
                {
                    SpecialRooms.TrapRoomPit();
                }
            else if ((roomSelect >= 31) && (roomSelect <= 40))
                {
                    SpecialRooms.TrapRoomDarts();
                }
            else if ((roomSelect >= 41) && (roomSelect <= 50))
                {
                    SpecialRooms.TrapRoomHex();
                }
            else if (roomSelect >= 51)
                {
                    Combat.RandEncounter();
                }
                    
            if ((currentPlayer.health >0) && (EnemyStats.enemyHealth <= 0))
                    {
                        Combat.RandVictory();
                    }
            else if ((currentPlayer.health <= 0) && (EnemyStats.enemyHealth > 0))
                    {
                        Combat.RandDefeat();
                    }                        
                
        }



    }
    
    public static void Typewrite(string text, int speed = 10)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(speed);
            }
            Console.WriteLine();
        }

    static void Start()
    {        
        string titleArt = System.IO.File.ReadAllText(@".\title.txt");
        Console.WriteLine(titleArt);

        Typewrite("\nPlease enter your name.");
        EnterName:
        currentPlayer.name = Console.ReadLine();
            
            if (currentPlayer.name == "")
            {
                Typewrite("Come on, don't be shy. What is your name?");
                goto EnterName;
            }
            else
            {
                Typewrite($"\nWell met {currentPlayer.name}!");
                Typewrite("Whenever you see an ellipsis just press any key to continue!");
                Typewrite("...");
                Console.ReadKey(true);
            }

        Typewrite("\nNow, it's time for some LORE!");
        Typewrite("Would you like to hear it, or are you gonna break my heart?");
        Console.WriteLine("\n|~~~~~~~~~~~~~~~~~~~~~~~~~~~~~|");
        Console.WriteLine("| A: Stay a while and listen  |");
        Console.WriteLine("| B: Break the DM's heart     |");
        Console.WriteLine("|~~~~~~~~~~~~~~~~~~~~~~~~~~~~~|");
        Lore:
        string choice = Console.ReadLine().ToUpper();

            if (choice == "A")
            {
                Typewrite("\nHokay, strap in friend. It's story time.");
                Typewrite("Long ago, a powerful, angry, and INCREDIBLY insane wizard began to");
                Typewrite("dabble in the forbidden art of slapping critter parts together");
                Typewrite("in order to make even worse critters.");
                Typewrite("...");
                Console.ReadKey(true); 

                Typewrite("\nThis nonsense continued for a few decades, giving rise to many");
                Typewrite("of the creatures we know and loathe today. You know the owlbear?");
                Typewrite("Blame the wizard.");
                Typewrite("...");
                Console.ReadKey(true);

                Typewrite("\nFast forward a few MORE decades. The wizard finally completed his magnum opus.");
                Typewrite("Slapping the tail and bitey bits of a crocodile onto the body of a pegasus,");
                Typewrite("the wizard had created a truly monsterous beast...");
                Typewrite("THE NEGASUS!");
                Typewrite("...");
                Console.ReadKey(true);

                Typewrite("\nBlessed with unnatural intelligence... for some reason... and a deep");
                Typewrite("hatred of player characters, the Negasus decided that, for the sake of a");
                Typewrite("text adventure game, it would slay the wizard and turn his tower");
                Typewrite("into its evil lair.");
                Typewrite("...");
                Console.ReadKey(true);

                Typewrite("\nFrom this warren of suckitude, the Negasus recruited some lackeys and began");
                Typewrite("to terrorize the land. Fields were salted. Homes were burned. Cows were tipped.");
                Typewrite("In order to bring peace to the land again, the king... wait. Where are you going?");
                Typewrite("Don't go in there. That's LITERALLY where the Negasus lives. Are you even");
                Typewrite("listening to me!? We didn't even get to the part about ability points!");
                Typewrite("...");
                Console.ReadKey(true);

            }
            else if (choice == "B")
            {
                Typewrite("\n*Sad DM noises*");
                Typewrite(".... but I didn't even get to give my speech about allocating ability points.");
                Typewrite("...");
                Console.ReadKey(true);
            }
            else
            {
                Typewrite("Whut?");
                goto Lore;
            }

    }

}

