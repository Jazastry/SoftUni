using System;

public class ExamResult
{
    private int grade;
    private int minGrade;
    private int maxGrade;
    private string comments;
    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public ExamResult()
    {
    }

    public int Grade
    {
        get { return this.grade; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("grade",
                    String.Format("Exam Result property grade {0} can not be negative value.", value));
            }
            this.grade = value;
        }
    }

    public int MinGrade 
    { 
        get { return this.minGrade; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("minGrade",
                     String.Format("Exam Result property minGrade value {0}" +
                     " can not be negative value.", value));
            }
            this.minGrade = value;
        } 
    }

    public int MaxGrade
    {
        get { return this.maxGrade; }
        set
        {
            if (value <= minGrade)
            {
                throw new ArgumentException("minGrade",
                    String.Format("Exam Result property minGrade value {0} can not be" +
                    " smaller than minGrade value.", value));
            }
            this.maxGrade = value;
        }
        
    }

    public string Comments
    {
        get { return this.comments; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("comments",
                    String.Format("Comments value {0} can not be null !", value));
            }
            this.comments = value;
        }
        
    }
}
