using System;
using System.Collections.Generic;
using System.Linq;
using TheSlum.Interfaces;

namespace TheSlum.GameEngine
{
    class MyEngine : Engine
    {
        private const int GameTurns = 4;

        protected List<Character> characterList = new List<Character>();
        protected List<BonusItem> timeoutItems = new List<BonusItem>();

        public virtual void Run()
        {
            ReadUserInput();
            InitializeTimeoutItems();
            for (int i = 0; i < GameTurns; i++)
            {
                foreach (var character in characterList)
                {
                    if (character.IsAlive)
                    {
                        ProcessTargetSearch(character);
                    }
                }
                ProcessItemTimeout(timeoutItems);
            }
            PrintGameOutcome();
        }

        private void ReadUserInput()
        {
            string inputLine = Console.ReadLine();
            while (inputLine != "")
            {
                string[] parameters = inputLine.Split(
                    new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                ExecuteCommand(parameters);
                inputLine = Console.ReadLine();
            }
        }

        public void ProcessItemTimeout(List<BonusItem> timeoutItems)
        {
            for (int i = 0; i < timeoutItems.Count; i++)
            {
                timeoutItems[i].Countdown--;
                if (timeoutItems[i].Countdown == 0)
                {
                    var item = timeoutItems[i];
                    item.HasTimedOut = true;
                    var itemHolder = GetCharacterByItem(item);
                    itemHolder.RemoveFromInventory(item);
                    i--;
                }
            }
        }

        public void InitializeTimeoutItems()
        {
            timeoutItems = characterList
                .SelectMany(c => c.Inventory)
                .Where(i => i is BonusItem)
                .Cast<BonusItem>()
                .ToList();
        }

        protected override void ExecuteCommand(string[] inputParams)
        {
            switch (inputParams[0])
            {
                case "create":
                    CreateCharacter(inputParams);
                    break;
                case "add":
                    AddItem(inputParams);
                    break;
                case "status":
                    PrintCharactersStatus(characterList);
                    break;
                default:
                    break;
            }
        }

        protected override void CreateCharacter(string[] inputParams)
        {
            HeroType heroType = ChangeToHeroType(inputParams[1]);
            string heroId = inputParams[2];
            int x = int.Parse(inputParams[3]);
            int y = int.Parse(inputParams[4]);
            Team team = ConvertToTeam(inputParams[5]);
            int healthPoints = AssignCharacterHealth(heroType);
            int defensePoints = AssignCharacterDefense(heroType);
            int range = AssignCharacterRange(heroType);

            if (heroType.Equals(HeroType.Healer))
            {
                characterList.Add(new HealCharacter(heroId, x, y, healthPoints, defensePoints, team, range));
            }
            else
            {
                characterList.Add(new AttackCharacter(heroId, x, y, healthPoints, defensePoints, team, range, heroType));   
            }
        }

        protected HeroType ChangeToHeroType(string inputWord)
        {
            HeroType resultHeroType;
            if (inputWord.Equals("warrior"))
            {
                resultHeroType = HeroType.Warrior;
            }
            else if (inputWord.Equals("mage"))
            {
                resultHeroType = HeroType.Mage;
            }
            else
            {
                resultHeroType = HeroType.Healer;
            }
            return resultHeroType;
        }
        protected Team ConvertToTeam(string stringParam)
        {
            if (stringParam.Equals("Red"))
            {
                return Team.Red;
            }
            else
            {
                return Team.Blue;
            }
        }


        protected int AssignCharacterHealth(HeroType heroType)
        {
            int health = 0;
            switch (heroType)
            {
                case HeroType.Mage:
                    health = 150;
                    break;
                case HeroType.Warrior:
                    health = 200;
                    break;
                case HeroType.Healer:
                    health = 75;
                    break;
                default:
                    break;
            }
            return health;
        }

        protected int AssignCharacterDefense(HeroType heroType)
        {
            int defense = 0;
            switch (heroType)
            {
                case HeroType.Mage:
                    defense = 50;
                    break;
                case HeroType.Warrior:
                    defense = 100;
                    break;
                case HeroType.Healer:
                    defense = 50;
                    break;
                default:
                    break;
            }
            return defense;
        }

        protected int AssignCharacterRange(HeroType heroType)
        {
            int range = 0;
            switch (heroType)
            {
                case HeroType.Mage:
                    range = 5;
                    break;
                case HeroType.Warrior:
                    range = 2;
                    break;
                case HeroType.Healer:
                    range = 6;
                    break;
                default:
                    break;
            }
            return range;
        }

        protected void AddItem(string[] inputParams)
        {
            string characterIdToAssignItem = inputParams[1];
            string itemId = inputParams[2];
            bool isItem = itemId.Equals("axe") || itemId.Equals("shield");
            bool isBonusItem = itemId.Equals("pill") || itemId.Equals("injection");

            foreach (Character character in characterList)
            {
                if (character.Id.Equals(characterIdToAssignItem) && isItem)
                {
                    character.AddToInventory(AssignItem(itemId));
                }
                else if (character.Id.Equals(characterIdToAssignItem) && isBonusItem)
                {
                    character.AddToInventory(AssignPropertyesToBonusItem(itemId));
                }
            }
        }

        protected MyItem AssignItem(string itemId)
        {
            int healthEffect = 0;
            int defenseEffect = 0;
            int attackEffect = 0;

            switch (itemId)
            {
                case "axe":
                    healthEffect = 0;
                    defenseEffect = 0;
                    attackEffect = 75;
                    break;
                case "shield":
                    healthEffect = 0;
                    defenseEffect = 50;
                    attackEffect = 0;
                    break;

                default:
                    break;
            }

            MyItem currentItem = new MyItem(itemId, healthEffect,
                defenseEffect, attackEffect);
            return currentItem;
        }

        protected BonusItem AssignPropertyesToBonusItem(string bonusItemId)
        {
            int healthEffect = 0;
            int defenseEffect = 0;
            int attackEffect = 0;
            int timeout = 0;
            switch (bonusItemId)
            {
                case "pill":
                    healthEffect = 0;
                    defenseEffect = 0;
                    attackEffect = 100;
                    timeout = 1;
                    break;
                case "injection":
                    healthEffect = 200;
                    defenseEffect = 0;
                    attackEffect = 0;
                    timeout = 3;
                    break;
                default:
                    break;
            }

            BonusItem currentBonusItem = new BonusItem(bonusItemId, healthEffect,
                defenseEffect, attackEffect, timeout);
            timeoutItems.Add(currentBonusItem);
            return currentBonusItem;
        }

        protected void ProcessTargetSearch(Character currentCharacter)
        {
            var availableTargets = characterList
                .Where(t => IsWithinRange(currentCharacter.X, currentCharacter.Y, t.X, t.Y, currentCharacter.Range))
                .ToList();
            var availableTargetsAlive = availableTargets
                .Where(tar => tar.IsAlive)
                .ToList();
            if (availableTargetsAlive.Count == 0)
            {
                return;
            }
            var target = currentCharacter.GetTarget(availableTargetsAlive);
            if (target == null)
            {
                return;
            }
            ProcessInteraction(currentCharacter, target);
        }

        protected void ProcessInteraction(Character currentCharacter, Character target)
        {
            if (currentCharacter is IHeal)
            {
                target.HealthPoints += (currentCharacter as IHeal).HealingPoints;
            }
            else if (currentCharacter is IAttack)
            {
                target.HealthPoints -= (currentCharacter as IAttack).AttackPoints - target.DefensePoints;
                if (target.HealthPoints <= 0)
                {
                    target.IsAlive = false;
                }
            }
        }

        protected bool IsWithinRange(int attackerX, int attackerY,
            int targetX, int targetY, int range)
        {
            double distance = Math.Sqrt(
                (attackerX - targetX) * (attackerX - targetX) +
                (attackerY - targetY) * (attackerY - targetY)
                );
            return distance <= (double)range;
        }

        protected Character GetCharacterById(string characterId)
        {
            return characterList.FirstOrDefault(x => x.Id == characterId);
        }

        protected Character GetCharacterByItem(Item item)
        {
            return characterList.FirstOrDefault(x => x.Inventory.Contains(item));
        }

        protected void PrintCharactersStatus(IEnumerable<Character> characters)
        {
            foreach (var character in characters)
            {
                Console.WriteLine(character.ToString());
            }
        }

        protected void PrintGameOutcome()
        {
            var charactersAlive = characterList.Where(c => c.IsAlive);
            var redTeamCount = charactersAlive.Count(x => x.Team == Team.Red);
            var blueTeamCount = charactersAlive.Count(x => x.Team == Team.Blue);
            if (redTeamCount == blueTeamCount)
            {
                Console.WriteLine("Tie game!");
            }
            else
            {
                string winningTeam = redTeamCount > blueTeamCount ? "Red" : "Blue";
                Console.WriteLine(winningTeam + " team wins the game!");
            }
            var aliveCharacters = characterList.Where(c => c.IsAlive);
            PrintCharactersStatus(aliveCharacters);
        }
    }
}
