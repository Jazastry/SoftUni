namespace PhonebookSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;

    public class Phonebook
    {
        private const string DefaultCountryCode = "+359";
        private const string ListCommand = "List";
        private const string ChangePhoneCommand = "ChangePhone";
        private const string AddPhoneCommand = "AddPhone";
        private const string PhoneCreatedMessage = "Phone entry created";
        private const string PhoneMergedMessage = "Phone entry merged";
        private static readonly IPhonebookRepository repository = new PhonebookRepository();
        private static readonly StringBuilder output = new StringBuilder();

        private static void Main()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End" || input == null)
                {
                    break;
                }

                int indexOfOpeningBracket = input.IndexOf('(');
                string inputCommand = input.Substring(0, indexOfOpeningBracket);
                int numbersStartIndex = indexOfOpeningBracket + 1;
                int dataLength = input.Length - indexOfOpeningBracket - 2;
                string dataString = input.Substring(numbersStartIndex, dataLength);
                string[] entryData = dataString.Split(',');
                for (int j = 0; j < entryData.Length; j++)
                {
                    entryData[j] = entryData[j].Trim();
                }

                switch (inputCommand)
                {
                    case  AddPhoneCommand:
                        ExecuteCommand(AddPhoneCommand, entryData);
                        break;
                    case ChangePhoneCommand:
                        ExecuteCommand(ChangePhoneCommand, entryData);
                        break;
                    case ListCommand:
                        ExecuteCommand(ListCommand, entryData);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Invalid Input Command.");
                        break;
                }
            }
            Console.Write(output);
        }

        private static void ExecuteCommand(string inputCommand, string[] entryData)
        {
            switch (inputCommand)
            {
                case AddPhoneCommand:
                    string name = entryData[0];
                    List<string> numbers = entryData.Skip(1).ToList();
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        numbers[i] = ConvertToCanonical(numbers[i]);
                    }

                    bool actionPerformed = repository.AddPhone(name, numbers);
                    if (actionPerformed)
                    {
                        AddToOutput(PhoneCreatedMessage);
                    }
                    else
                    {
                        AddToOutput(PhoneMergedMessage);
                    }
                    break;
                case ChangePhoneCommand:
                    AddToOutput("" + repository.ChangePhone(ConvertToCanonical(entryData[0]),
                        ConvertToCanonical(entryData[1])) + " numbers changed");
                    break;
                case ListCommand:
                    try
                    {
                        var entries = repository.ListEntries(int.Parse(entryData[0]), int.Parse(entryData[1]));
                        foreach (var entry in entries)
                        {
                            AddToOutput(entry.ToString());
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        AddToOutput("Invalid range");
                    }
                    break;
                default:
                    throw new ArgumentException("Invalid Input Command.");
                    break;
            }
        }

        /// <summary>
        /// Converts input phone string to its canonical variant.
        /// </summary>
        /// <param name="phoneNumberString">Phone number string.</param> 
        /// <returns>Converted phone string.</returns>
        private static string ConvertToCanonical(string phoneNumberString)
        {
            var resultNumber = new StringBuilder();

            resultNumber.Clear();
            foreach (char character in phoneNumberString)
            {
                if (char.IsDigit(character) || (character == '+'))
                {
                    resultNumber.Append(character);
                }
            }
            if (resultNumber.Length >= 2 && resultNumber[0] == '0' && resultNumber[1] == '0')
            {
                resultNumber.Remove(0, 1);
                resultNumber[0] = '+';
            }
            while (resultNumber.Length > 0 && resultNumber[0] == '0')
            {
                resultNumber.Remove(0, 1);
            }
            if (resultNumber.Length > 0 && resultNumber[0] != '+')
            {
                resultNumber.Insert(0, DefaultCountryCode);
            }

            return resultNumber.ToString();
        }

        private static void AddToOutput(string text)
        {
            output.AppendLine(text);
        }
    }
}