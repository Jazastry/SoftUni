using System;

public class SimpleMathExam : Exam
{
    private int problemsSolved;
    private const int maxGrade = 6;
    private const int minGrade = 2;
    private const int maxProblemsSolved = 10;
    private const int minProblemsSolved = 0;
    public SimpleMathExam(int problemsSolved)
    {
        this.ProblemsSolved = problemsSolved;
    }
    public int ProblemsSolved
    {
        get { return this.problemsSolved; }
        set
        {
            if (value < minProblemsSolved)
            {
                throw new ArgumentOutOfRangeException("ProblemsSolved",
                    String.Format("Value {0} can not be assigned ! SimpleMathExam" +
                    " problems Solved have to be in range 0 to 2!", value));
            }
            else if (value > maxProblemsSolved)
            {
                this.problemsSolved = 10;
            }

            this.problemsSolved = value;
        }
    }

    public override ExamResult Check()
    {
        ExamResult curentResult = new ExamResult();

        switch (this.ProblemsSolved % 6)
        {
            case 0:
                curentResult =  new ExamResult(2, minGrade,
                    maxGrade, "Bad result: nothing is done.");;
                break;
            case 1:
                curentResult = new ExamResult(3, minGrade,
                    maxGrade, "Bad result: vary little is done."); ;
                break;
            case 2:
                curentResult = new ExamResult(4, minGrade,
                    maxGrade, "Average result: half of the work is done."); ;
                break;
            case 3:
                curentResult = new ExamResult(5, minGrade,
                    maxGrade, "Good result: more than half of the work is done."); ;
                break;
            case 4:
                curentResult = new ExamResult(6, minGrade,
                    maxGrade, "Vary Good result: all work is done."); ;
                break;
            default:
                throw new ArgumentException("ProblemsSolved", "Number of solved problems " +
                    "can not be less than 0 and more than 10");
                break;
        }
        return curentResult;
    }
}
