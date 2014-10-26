using System;
using System.Collections.Generic;
using System.Linq;
using TheSlum.Interfaces;

namespace TheSlum
{
    enum HeroType
    {
        Warrior, Mage, Healer
    }
    class AttackCharacter : Character, IAttack
    {
        public HeroType Type { get; private set; }

        public int AttackPoints { get; set; }

        public AttackCharacter(string id, int x, int y, int healthPoints, int defensePoints, Team team, int range, HeroType heroType)
            : base(id, x, y, healthPoints, defensePoints, team, range)
        {
            this.Type = heroType;
            this.AttackPoints = SetAttackPoints();
        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            var enemyTargetList = targetsList
                .Where(tr => tr.Team != this.Team)
                .ToList();

            if (enemyTargetList.LongCount() == 0)
            {
                return null;
            }

            int x1 = this.X;
            int y1 = this.Y;
            object firstTarget = new object();
            object lastTarget = new object();
            double smallestDistance = 0;
            double biggestDistance = 0;

            foreach (Character target in enemyTargetList)
            {
                int x2 = target.X;
                int y2 = target.Y;
                double distanceToTarget = Utils.CalculateDistance(x1, y1, x2, y2);
                if (distanceToTarget < smallestDistance)
                {
                    smallestDistance = distanceToTarget;
                    firstTarget = target;
                }
                else if (distanceToTarget > biggestDistance)
                {
                    biggestDistance = distanceToTarget;
                    lastTarget = target;
                }
            }

            if (this.Type.Equals(HeroType.Warrior))
            {
                if (smallestDistance == 0)
                {
                    return (Character)lastTarget;
                }
                return (Character)firstTarget;
            }
            else
            {
                if (biggestDistance == 0)
                {
                    return (Character) firstTarget;
                }
                return (Character)lastTarget;
            }
        }

        public override void AddToInventory(Item item)
        {
            this.Inventory.Add(item);
        }

        public override void RemoveFromInventory(Item item)
        {
            this.Inventory.Remove(item);
        }

        protected virtual void ApplyItemEffects(Item item)
        {
            this.HealthPoints += item.HealthEffect;
            this.DefensePoints += item.DefenseEffect;
        }

        protected virtual void RemoveItemEffects(Item item)
        {
            this.HealthPoints -= item.HealthEffect;
            this.DefensePoints -= item.DefenseEffect;
            if (this.HealthPoints < 0)
            {
                this.HealthPoints = 1;
            }
        }

        private int SetAttackPoints()
        {
            int attackPoints = 0;
            switch (this.Type)
            {
                case HeroType.Mage:
                    attackPoints = 300;
                    break;
                case HeroType.Warrior:
                    attackPoints = 150;
                    break;
                default:
                    break;
            }
            return attackPoints;
        }

        public override string ToString()
        {
            return String.Format("Name: {0}, Team: {2}, Health: {1}, Defense: {3}",
                this.Id, this.HealthPoints, this.Team.ToString(), this.DefensePoints);
        }
    }
}
