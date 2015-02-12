using System;
using System.Linq;
using System.Collections.Generic;

public class Student
{
    private string firstName;
    private string lastName;
    private IList<Exam> exams = null;
    public Student(string firstName, string lastName, IList<Exam> exams = null)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams;
    }

    public string FirstName 
    {
        get { return this.firstName; }
        set
        {
            if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(String.Format("Student First Name {0} can" +
                                                              " not be null or empty string !", value));
            }
            else
            {
                this.firstName = value;
            }
        } 
    }

    public string LastName
    {
        get { return this.lastName; }
        set
        {
            if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(String.Format("Student Last Name {0} can" +
                                                              " not be null or empty string !", value));
            }
            else
            {
                this.lastName = value;
            }
        }
    }
    public IList<Exam> Exams { get; private set; }

    public IList<ExamResult> CheckExams()
    {
        if (this.Exams == null || this.Exams.Count == 0)
        {
            throw new ArgumentNullException("CheckExam", "Exams value is null, to do " +
                "check over Exams have to contain multiple values!");
        }

        IList<ExamResult> results = new List<ExamResult>();

        for (int i = 0; i < this.Exams.Count; i++)
        {
            results.Add(this.Exams[i].Check());
        }

        return results;
    }

    public double CalcAverageExamResultInPercents()
    {
        if (this.Exams == null || this.Exams.Count == 0)
        {
            throw new ArgumentNullException(String.Format("Cannot calculate average on missing exams !"));
        }

        double[] examScore = new double[this.Exams.Count];
        IList<ExamResult> examResults = CheckExams();
        for (int i = 0; i < examResults.Count; i++)
        {
            examScore[i] = 
                ((double)examResults[i].Grade - examResults[i].MinGrade) / 
                (examResults[i].MaxGrade - examResults[i].MinGrade);
        }

        return examScore.Average();
    }
}
