namespace PhonebookSystem.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PhonebookEntry : IComparable<PhonebookEntry>
    {
        private SortedSet<string> phoneNumbers = new SortedSet<string>();
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
            get { return phoneNumbers; }
            set { AssignPhones(value); }

        }

        public PhonebookEntry(string name, IEnumerable<string> numbers)
        {
            this.Name = name;
            AssignPhones(numbers);
        }

        public PhonebookEntry(string name)
        {
            this.Name = name;
            this.phoneNumbers = new SortedSet<string>();
        }

        public PhonebookEntry()
        {
        }

        public int CompareTo(PhonebookEntry other)
        {
            return String.Compare(Name, other.Name, StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.Append('[');
            result.Append(Name);
            bool flag = true;
            foreach (string phone in PhoneNumbers)
            {
                if (flag)
                {
                    result.Append(": ");
                    flag = false;
                }
                else
                {
                    result.Append(", ");
                }

                result.Append(phone);
            }
            result.Append(']');

            return result.ToString();
        }

        internal void AssignPhones(IEnumerable<string> numbers)
        {
            foreach (string number in numbers)
            {
                PhoneNumbers.Add(number);
            }
        }
    }
}
