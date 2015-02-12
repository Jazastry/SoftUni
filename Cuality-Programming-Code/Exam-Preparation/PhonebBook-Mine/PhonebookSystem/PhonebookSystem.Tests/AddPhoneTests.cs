namespace PhonebookSystem.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Classes;
    using System.Linq;
    using System;

    [TestClass]
    public class PhonebookRepositoryAddPhoneTests
    {

        private PhonebookRepository phonebook;

        [TestInitialize]
        public void InitializePhonebookRepository()
        {
            this.phonebook = new PhonebookRepository();
        }

        [TestMethod]
        public void ShoudAddSingleEntryWithSingleNumberAndName()
        {
            var entry = new PhonebookEntry("Kalina");
            entry.PhoneNumbers.Add("0899 76 15 33");

            Assert.AreEqual(1, entry.PhoneNumbers.Count);
            Assert.AreEqual("Kalina", entry.Name);
        }

        [TestMethod]
        public void ShoudAddSingleEntryWithMaxNumberOfPhones()
        {
            string[] numbersList =
            {
                "0899 76 15 33",
                "(02) 981 22 33",
                "123",
                "(+1) 123 456 789",
                "0883 / 456-789",
                "0888 88 99 00",
                "888-88-99-00",
                "+359 (888) 41-80-12",
                "00359 (888) 41-80-12",
                "+359527734522"
            };
            var entry = new PhonebookEntry("Kalina", numbersList);

            Assert.AreEqual(numbersList.Count(), entry.PhoneNumbers.Count);
            Assert.AreEqual("Kalina", entry.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ShoudThrowExceptionCausedByOverNumberedEntryAddition()
        {
            string[] numbersList =
            {
                "0899 76 15 33",
                "(02) 981 22 33",
                "123",
                "(+1) 123 456 789",
                "0883 / 456-789",
                "0888 88 99 00",
                "888-88-99-00",
                "+359 (888) 41-80-12",
                "00359 (888) 41-80-12",
                "+359527734522",
                "2834769009 987"
            };
            phonebook.AddPhone("Kalina", numbersList);

            //Assert.IsFalse(phonebook.Entries.Count() > 0);
        }

        [TestMethod]
        public void ShoudAddOnlyOnePhoneEntryAfterAddedTwoWithSameName()
        {
            phonebook.AddPhone("Kalina", new[] {"0899 76 15 33"});
            phonebook.AddPhone("Kalina", new[] {"0899 76 15 33"});
            int entriesCount = phonebook.Entries.Count();

            Assert.AreNotEqual(2, entriesCount);
        }

        [TestMethod]
        public void ShoudCreateOnlyOnePhoneEntryAfterAddedTwoEntiesWithSameNameDifferentCases()
        {
            phonebook.AddPhone("Kalina", new[] { "0899 76 15 33" });
            phonebook.AddPhone("kalina", new[] { "0899 76 15 33" });
            int entriesCount = phonebook.Entries.Count();

            Assert.AreNotEqual(2, entriesCount);
        }

        [TestMethod]
        public void ShoudCreateSingleEntyWithTwoPhoneNumbersPerformingMerging()
        {
            string name = "Kalina";
            string phoneFirst = "0899 76 15 33";
            string phoneSecond = "0899 76 15 55";

            phonebook.AddPhone(name, new[] { phoneFirst });
            phonebook.AddPhone(name, new[] { phoneSecond });

            int entryCount = phonebook.Entries.Count();
            var entryPhones = phonebook.Entries.Find(e => e.Name.Equals(name)).PhoneNumbers;

            Assert.AreEqual(2, entryPhones.Count());
            Assert.AreEqual(1, entryCount);
        }
    }
}
