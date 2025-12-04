namespace Negasus;

class SpecialRooms
{
    static int trapDif = 8 + (Program.currentPlayer.roomsClear / 2);
    static int agiLoss = 0;
    static int strLoss = 0;
    static int intLoss = 0;
    static int brainCheck = 0;
    static string healChoice = "";
    
    //Room for restoring health
    public static void HealingRoom()
    {        
        Program.Typewrite("\nAs you crest the stairs and peer into the room beyond,");
        Program.Typewrite("you are greeted by an elderly butler. He gestures behind him");
        Program.Typewrite("toward crackling fireplace and a comfy looking sofa. When you");
        Program.Typewrite("turn back to the butler, you see with surprise that he has");
        Program.Typewrite("vanished and in his place is a tray bearing a steaming bowl");
        Program.Typewrite("of stew, a carafe of clear, cold water, and a crystal drinking");
        Program.Typewrite("glass. This seems to be as good a place as any to get some rest.");
        Program.Typewrite("\nWill you rest and recover? Y/N");

        WhutFour:
        healChoice = Console.ReadLine().ToUpper();

        if ((healChoice != "Y") && (healChoice != "N"))
        {
            Program.Typewrite("Whut?");
            goto WhutFour;
        }

        else if (healChoice == "Y")
        {
            Program.Typewrite("\nYou eat the stew and sip the cool water as you lounge on the");
            Program.Typewrite("sofa. Within moments your head droops and you drift off to sleep.");
            Program.Typewrite("...");
            Console.ReadKey(true);
            
            Program.Typewrite("\nYou awaken with a start. The fire is now merely embers but you");
            Program.Typewrite("fell as good as new. Your HP has been restored! With renewed vigor,");
            Program.Typewrite("you cross the room and proceed up the stairs.");
            Program.Typewrite("...");
            Console.ReadKey(true);

            Program.currentPlayer.health = Program.currentPlayer.maxHealth;
            Program.currentPlayer.roomsClear += 1;
        }
        
        else if (healChoice == "N")
        {
            Program.Typewrite("\nConfident that your stamina will hold, you politely tell the bowl");
            Program.Typewrite("of stew, 'No thank you'. You dash past the crackling fire place and");
            Program.Typewrite("comfy sofa, leaving behind a very disappointed meal.");
            Program.Typewrite("...");
            Console.ReadKey(true);
        }
    }

    //Trap that damages agility
    public static void TrapRoomPit()
    {
        Program.Typewrite("\nAs you enter the room, you see... Nothing. No angry enemies, no evil");
        Program.Typewrite("Negasus. Just... nothing, save for the exit at the far side. With a");
        Program.Typewrite("shrug you make for the exit, glad to have a break from combat.");
        Program.Typewrite("...");
        Console.ReadKey(true);

        brainCheck = Rolls.rand.Next(1, 21) + Program.currentPlayer.intellect;

        if (brainCheck >= trapDif)
        {
            Program.Typewrite("\nA handful of steps into the room you stop. Ahead on the floor you");
            Program.Typewrite("spot an area where the floor tiles are slightly raised. With a smug");
            Program.Typewrite("grin, you give the area a wide berth and arrive safely at the room's exit.");
            Program.Typewrite("...");
            Console.ReadKey(true);
        }

        else
        {
            Program.Typewrite("\nAs you near the midpoint of the room, you feel a slight shift beneath");
            Program.Typewrite("your leading foot accompanied by a subtle click. Before you have time to");
            Program.Typewrite("utter a curse, the floor falls away beneath you!");
            Program.Typewrite("...");
            Console.ReadKey(true);

            Program.Typewrite("\nFeeling panic grip at your very soul, you shriek as you enter freefall.");
            Program.Typewrite("That is, until you make contact with the ground a couple of seconds later.");
            Program.Typewrite("You land hard on your feet. Though it hurts, you don't think anything is");
            Program.Typewrite("broken... but you also feel like you might not be able to move quite as");
            Program.Typewrite("nimbly as you normally could for a while.");

            agiLoss = Rolls.rand.Next(1, 4);
            Program.currentPlayer.agility -= agiLoss;
            Program.currentPlayer.roomsClear += 1;

            Program.Typewrite($"You lose {agiLoss} agility points.");
            Program.Typewrite("...");
            Console.ReadKey(true);
        }
    }
    

    //Trap that damages Strength
    public static void TrapRoomDarts()
    {
        Program.Typewrite("\nAt the top of the stairs, you are not greeted by a room, but rather a long");
        Program.Typewrite("narrow hallway. Not seeing any enemies ahead, you press on.");
        Program.Typewrite("...");
        Console.ReadKey(true);

        brainCheck = Rolls.rand.Next(1, 21) + Program.currentPlayer.intellect;

        if (brainCheck >= trapDif)
        {
            Program.Typewrite("\nYou catch a glimpse of something curious out of the corner of your eye");
            Program.Typewrite("that gives you pause. Upon closer inspection, what you intitially thought");
            Program.Typewrite("was simply decoration along the walls is a cleverly disguised dart trap!");
            Program.Typewrite("Quickly determining the trigger, you are able to bypass the trap and");
            Program.Typewrite("continue on your way.");
            Program.Typewrite("...");
            Console.ReadKey(true);
        }
        
        else
        {
            Program.Typewrite("\nStriding confidently down the hall, you are stopped by a subtle fwhip,");
            Program.Typewrite("followed by a stinging sensation in your right arm. You look down and see");
            Program.Typewrite("a small feathered dart protruding from your bicep. You feel a sudden urge");
            Program.Typewrite("to flee, so you do. You sprint down the hall toward the exit chased by an");
            Program.Typewrite("orchestra of fwhips.");
            Program.Typewrite("...");
            Console.ReadKey(true);

            strLoss = Rolls.rand.Next(1, 4);
            Program.currentPlayer.strength -= strLoss;
            Program.currentPlayer.roomsClear += 1;

            Program.Typewrite("\nYou stop at the foot of the stairwell to catch your breath and assess the");
            Program.Typewrite($"damage. You pluck {strLoss} darts from varous parts of your body and toss");
            Program.Typewrite("them to the ground bitterly. As you turn and begin to ascend the stairs, you");
            Program.Typewrite($"notice that you feel a little weaker than normal. You lose {strLoss} strength points.");
            Program.Typewrite("...");
            Console.ReadKey(true);
        }
    }

    //Trap to reduce Int
    public static void TrapRoomHex()
    {
        Program.Typewrite("\nArriving at the top of the stairs, you peer into the next room. It is empty, other");
        Program.Typewrite("than the pedestal in the center. Atop it sits a polished chrome orb. As you approach,");
        Program.Typewrite("you notice a small switch on the back of the orb.");
        Program.Typewrite("...");
        Console.ReadKey(true);

        brainCheck = Rolls.rand.Next(1, 21) + Program.currentPlayer.intellect;

        if (brainCheck >= trapDif)
        {
            Program.Typewrite("\nYou reach for the switch, but stop short. You feel like you have seen this");
            Program.Typewrite("orb somewhere before. Feeling it is better to err on the side of caution,");
            Program.Typewrite("you wisely choose to ignore the orb and continue across the room and up the");
            Program.Typewrite("stairs.");
            Program.Typewrite("...");
            Console.ReadKey(true);
        }
        
        else
        {
            Program.Typewrite("\nCuriosity overrides your common sense as you reach out and flip the switch.");
            Program.Typewrite("The orb immediately begins emitting visible waves of... confusion? Oh no!");
            Program.Typewrite("It's the Orb of Confusion!");
            Program.Typewrite("...");
            Console.ReadKey(true);

            intLoss = Rolls.rand.Next(1, 4);
            Program.currentPlayer.intellect -= intLoss;
            Program.currentPlayer.roomsClear += 1;

            Program.Typewrite("\nYou stand next to the orb, making dumb sounds and drooling. By some stroke of");
            Program.Typewrite("dumb luck, you take a stumble into the pedestal, knocking the orb to the floor");
            Program.Typewrite("where it shatters. You slowly regain your senses and turn to leave, wiping drool");
            Program.Typewrite("from your chin.");
            Program.Typewrite("...");
            Console.ReadKey(true);

            Program.Typewrite("\nBy the time you reach the stairs and begin to ascend, you have already forgotten");
            Program.Typewrite($"what had happened just moments before... You lose {intLoss} intellect points.");
            Program.Typewrite("...");
            Console.ReadKey(true);
        }
    }

    public static void WeaponRoom()
    {
        Program.Typewrite("\nAs soon as you enter the room your loot senses begin tingle.");
        Program.Typewrite("Your eyes greedily scan the room until... there! A box!");
        Program.Typewrite("You dash over to the box and do a little prospector jig");
        Program.Typewrite("before kneeling to remove the lid.");
        Program.Typewrite("...");
        Console.ReadKey(true);

        Items.WeapLoot();
    }






}