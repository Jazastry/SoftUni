using System;

public class CSharpExam : Exam
{
    private int score;
    private const int maxScore = 100;
    private const int minScore = 0;
    public CSharpExam(int score)
    {
        this.Score = score;
    }

    public int Score
    {
        get { return this.score; }
        set
        {
            if ((value < minScore) || (value > maxScore))
            {
                throw new ArgumentOutOfRangeException("Score",
                    String.Format("CSharpExam score: {0}," +
                    " is out of valid range (0 to 100) !", value));
            }
            this.score = value;
        }
    }

    public override ExamResult Check()
    {

        return new ExamResult(this.Score, minScore, maxScore,
            "Exam results calculated by score.");
        
    }
}
