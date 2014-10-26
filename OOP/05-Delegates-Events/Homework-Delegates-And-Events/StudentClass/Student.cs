namespace StudentClass
{
    using System;
    public class Student
    {
        private string name = String.Empty;
        private int age = 0;
        private object oldPropertyValue;
        private string changedPropertyName;
        public event ItemChangedEventHandler PropertyChanged;

        public string Name
        {
            get { return this.name; }
            set
            {
                if ((String.IsNullOrEmpty(value)) && (value.Length < 2))
                {
                    throw new ArgumentNullException("Name");
                }
                else
                {
                    oldPropertyValue = this.name;
                    this.name = value;
                    changedPropertyName = "name";
                    OnStudentPropertyChanged(value, oldPropertyValue);
                }
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if ((value < 0) || (value > 120))
                {
                    throw new ArgumentOutOfRangeException("Age");
                }
                else
                {
                    oldPropertyValue = this.age;
                    this.age = value;
                    changedPropertyName = "age";
                    OnStudentPropertyChanged(value, oldPropertyValue);
                }
            }
        }

        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        protected void OnStudentPropertyChanged(object valueChanged, object oldValue)
        {
            if (PropertyChanged != null)
            {
                StudentChangedEventArgs args = new StudentChangedEventArgs(valueChanged, oldValue, changedPropertyName);
                PropertyChanged(this, args);
            }
        }
    }
}
