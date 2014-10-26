namespace StudentClass
{
    using System;
    class TestsStudent
    {
        static void Main()
        {
            Student student = new Student("Ivan", 22);

            student.PropertyChanged += (sender, eventArgs) =>
            {
                Console.WriteLine("Property changed: {0} (from {1} to {2})",
                    eventArgs.PropertyName, eventArgs.OldValue, eventArgs.NewValue);
            };

            student.Age = 33;
            student.Name = "Minka";

        }
    }
}
