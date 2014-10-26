using System;
using System.Collections;
using System.Collections.Generic;

public class Student : IComparable,IComparer
{
    private string firstName;
    private string lastName;
    private int age;
    private int facultyNumber;
    private string phone;
    private string email;
    private List<int> marks;
    private int groupNumber;
    private string groupName;

    public string FirstName
    {
        get { return this.firstName; }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("FirstName property is null or empty.");
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
                throw new ArgumentNullException("LastName property is null or empty.");
            }
            this.lastName = value;
        }
    }

    public int Age
    {
        get { return this.age; }
        set
        {
            if ((value < 1) || (value > 150))
            {
                throw new ArgumentNullException("Age property is not correct.");
            }
            this.age = value;
        }
    }

    public string Phone
    {
        get { return this.phone; }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Phone property is null or empty.");
            }
            this.phone = value;
        }
    }

    public string Email
    {
        get { return this.email; }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Email property is null or empty.");
            }
            this.email = value;
        }
    }

    public List<int> Marks
    {
        get
        {
            return this.marks; 
        }
        set
        {
            foreach (int mark in value)
            {
                if ((mark < 2) || (mark > 6))
                {
                    throw new ArgumentOutOfRangeException("Value from Marks List is not carrect");
                }
            }
            this.marks = value;
        }
    }

    public int GroupNumber
    {
        get { return this.groupNumber; }
        set
        {
            if ((value < 1) || (value > 10))
            {
                throw new ArgumentNullException("GroupNumber property is not correct.");
            }
            this.groupNumber = value;
        }
    }

    public int FacultyNumber { get; private set; }
    public string GroupName { get; private set; }

    public Student(string firstName, string lastName, int age, string phone, string email,
        List<int> marks, int groupNumber, int facultyNumber, string groupName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
        this.Phone = phone;
        this.Email = email;
        this.Marks = marks;
        this.GroupNumber = groupNumber;
        this.FacultyNumber = facultyNumber;
        this.GroupName = groupName;
    }

    public int CompareTo(object obj)
    {
        return this.CompareTo(obj);
    }

    public int Compare(object x, object y)
    {
        return x.ToString().CompareTo(y.ToString());
    }

    public string MarksToString()
    {
        string result = String.Empty;
        marks.ForEach(x => result += String.Format("{0}, ", x));
        return result;
    }

    public override string ToString()
    {
        string marksString = String.Empty;
        Marks.ForEach(x => marksString += x + ", ");

        return String.Format("{0} {1}- age:{2}, phone:{3}, email: {4}, marks: {5}, group number: {6}",
            this.FirstName, this.LastName, this.Age, this.Phone, this.Email, marksString, this.GroupNumber);
    }
}

