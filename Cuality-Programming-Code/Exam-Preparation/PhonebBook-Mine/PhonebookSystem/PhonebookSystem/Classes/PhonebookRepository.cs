using System;
using System.Collections.Generic;
using System.Linq;
using PhonebookSystem.Classes;
using PhonebookSystem.Contracts;

namespace PhonebookSystem
{
    public class PhonebookRepository : IPhonebookRepository
    {
        private readonly List<PhonebookEntry> entries = new List<PhonebookEntry>();

        public List<PhonebookEntry> Entries
        {
            get { return this.entries; }
        }

        /// <summary>
        /// Adds new Phonebook Entry or if present adds new phones to the existing Entry.
        /// </summary>
        /// <param name="name">Represents name to wich are asigned, added the phone numbers.</param> 
        /// <param name="numbers">Represents the phone numbers, in IEnumerable form.</param>
        /// <returns>Returns true if </returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        public bool AddPhone(string name, IEnumerable<string> numbers)
        {
            var existingEntry = from entry in entries
                where string.Equals(entry.Name, name, StringComparison.OrdinalIgnoreCase)
                select entry;

            int newPhonesCount = numbers.Count();
            bool actionStatus = false;

            if (newPhonesCount <= 10)
            {
                switch (existingEntry.Count())
                {
                    case 0:
                        PhonebookEntry processEntry = new PhonebookEntry(name, numbers);
                        entries.Add(processEntry);
                        actionStatus = true;
                        break;
                    case 1:
                        existingEntry.First().AssignPhones(numbers);
                        break;
                    default:
                        throw new ArgumentException("Duplicated name in the phonebook found: " + name);
                        break;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("numbers","New entry overpopulated phone numbers.");
            }
            return actionStatus;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="phoneNumberString">Input phone-number</param> 
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        public int ChangePhone(string oldEntry, string newEntry)
        {
            IEnumerable<PhonebookEntry> list =
                from entry in entries
                where entry.PhoneNumbers.Contains(oldEntry)
                select entry;
            int numbersChanged = 0;
            foreach (PhonebookEntry entry in list)
            {
                entry.PhoneNumbers.Remove(oldEntry);
                entry.PhoneNumbers.Add(newEntry);
                numbersChanged++;
            }

            return numbersChanged;
        }

        /// <summary>
        /// Lists entries from specified index to specified length.
        /// </summary>
        /// <param name="startIndex"></param> 
        /// <returns>Result filtered entries of PhoneEntry type.</returns>
        /// <remarks></remarks>
        /// <exception cref="System.ArgumentOutOfRangeException">Invalid start index or count.</exception>
        public PhonebookEntry[] ListEntries(int startIndex, int entriesToReturn)
        {
            if (startIndex < 0 || startIndex + entriesToReturn > entries.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid start index or count.");
            }
            entries.Sort();
            PhonebookEntry[] resultEntries = new PhonebookEntry[entriesToReturn];
            int maximalConter = startIndex + entriesToReturn - 1;
            for (int i = startIndex; i <= maximalConter; i++)
            {
                resultEntries[i - startIndex] = entries[i];
            }

            return resultEntries;
        }
    }
}