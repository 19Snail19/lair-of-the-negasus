namespace Negasus;

class Items
{
    public static int index;
    public static string[] accessory = ["cowboy hat", "bangle", "keychain"];
    public static string[] artifact = ["Wand of Staves", "Quadforce", ""];
    public static string [] weapons = ["dagger", "broomstick", "RPG"];

    public static void WeapLoot()
    {
        Items.index = Rolls.rand.Next(weapons.Length);

        Program.Typewrite($"\nInside the weapon-shaped box you find the... {weapons[index]}");
        Program.Typewrite("What a shame that I haven't properly coded items into");
        Program.Typewrite("the game yet. At least you have it though.... yay?");
        Program.Typewrite("Stuffing the as-for-now useless weapon into your magical");
        Program.Typewrite("'Sack of Storing', you continue across the room and up");
        Program.Typewrite("the stairs.");
        Program.Typewrite("...");
        Console.ReadKey(true);
    }








}