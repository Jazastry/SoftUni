namespace TravelAgency
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PhonebookEntry : IComparable<PhonebookEntry>
    {
        private SortedSet<string> phoneNumbers;
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }

        public SortedSet<string> PhoneNumbers
        {
            get { return this.phoneNumbers; }
        }

        public int CompareTo(PhonebookEntry other)
        {
            return Name.CompareTo(other.Name);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Clear();
            sb.Append('[');
            sb.Append(Name);
            bool flag = true;
            foreach (string phone in phoneNumbers)
            {
                if (flag)
                {
                    sb.Append(": ");
                    flag = false;
                }
                else
                {
                    sb.Append(", ");
                }
                sb.Append(phone);
            }
            sb.Append(']');

            return sb.ToString();
        }
    }
}
