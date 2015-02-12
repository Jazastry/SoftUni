

namespace PhonebookSystem.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;

    [TestClass]
    public class PhonebookRepositoryChangePhoneTests
    {
        private PhonebookRepository phonebook;

        [TestInitialize]
        public void InitializePhonebookRepository()
        {
            this.phonebook = new PhonebookRepository();
        }

        [TestMethod]
        public void ShoudChangeSpecifiedNumberInAllEnries()
        {
            string oldNumber = "+359 333";
            string newNumber = "+359 444";
            string firstName = "Kalina";
            string secondName = "Boris"; 
            phonebook.AddPhone(firstName, new[] { oldNumber });
            phonebook.AddPhone(secondName, new[] { oldNumber });
            phonebook.ChangePhone(oldNumber, newNumber);
            var firstEntryNumb = phonebook.Entries
                .Find(e => e.Name.Equals(firstName))
                .PhoneNumbers.First();
            var secondEntryNumb = phonebook.Entries
                .Find(e => e.Name.Equals(secondName))
                .PhoneNumbers.First(); 

            Assert.AreEqual(newNumber, firstEntryNumb);
            Assert.AreEqual(newNumber, secondEntryNumb);
        }
    }
}
