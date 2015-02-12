using System;

namespace Methods
{
    class Student
    {
        private string firstName;
        private string lastName;
        private string otherInfo; 

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("FirstName","Name have to be valid char string !");
                }
                this.firstName = value;
            }
        }
        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("LastName","Name have to be valid char string !");
                }
                this.lastName = value;
            }
        }

        public DateTime DateOfBirth { get; private set; }

        public string OtherInfo
        {
            get { return this.otherInfo; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("OtherInfo", "Other Info have to be valid char sequence !");
                }
                this.otherInfo = value;
            }
        }

        public Student(string firstName, string lastName, DateTime dateOfBirth, string otherInfo)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            OtherInfo = otherInfo;
        }

        public bool IsOlderThan(Student secondStudent)
        {
            DateTime firstStudentDate = this.DateOfBirth;
            DateTime secondStudentDate = secondStudent.DateOfBirth;

            return firstStudentDate > secondStudentDate;
        }
    }
}
