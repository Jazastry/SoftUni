using System;

namespace BankOfCurtovoConare
{
    public enum CostumerTypes
    {
        Company, Individual
    }

    public class Costumer
    {
        private string name;
        public CostumerTypes CostumerType { get; private set; }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Costumer Name property is null or empty.");
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public Costumer(string name, CostumerTypes costumerType)
        {
            this.Name = name;
            this.CostumerType = costumerType;
        }

        public Costumer() { }

        public override string ToString()
        {
            string costumerDetails = String.Format("{0}\n Account Type : {1}",
                this.Name, this.CostumerType);
            return costumerDetails;
        }
    }
}
