using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSlum.Interfaces;

namespace TheSlum
{
    class HealCharacter : Character, IHeal
    {
        private int healingPoints = 60;

        public int HealingPoints
        {
            get { return this.healingPoints; }
            set { this.healingPoints = value; }
        }

        public HealCharacter(string id, int x, int y, int healthPoints, int defensePoints, Team team, int range)
            : base(id, x, y, healthPoints, defensePoints, team, range) { }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            var teamMatesList = targetsList
                .Where(tr => tr.Team.Equals(this.Team))
                .Where(t => !t.Id.Equals(this.Id))
                .OrderBy(friend => friend.HealthPoints)
                .ToArray();
            object weekestFriend = teamMatesList[0];

            return (Character)weekestFriend;
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

        public override string ToString()
        {
            return String.Format("Name: {0}, Team: {2}, Health: {1}, Defense: {3}",
                this.Id, this.HealthPoints, this.Team.ToString(), this.DefensePoints);
        }

    }
}
