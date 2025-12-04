namespace Negasus;

    class Player
    {
        public string name;
        public string combatChoice;
        
        public int roomsClear = 0;
        public int gold = 0;
        public int health = 20;
        public int maxHealth = 20; //+ strength
        public int defense = 12; //+ (agility / 2);
        public int damage = 0;
        public int playerAtkRoll = 0; // + agility / 2
        public int strength = 1;
        public int agility = 1;
        public int intellect = 1;
        public int abilityPoints = 0;
    }