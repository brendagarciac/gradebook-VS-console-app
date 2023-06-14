using System.Diagnostics;

namespace GradeBook
{
    public class Statistics
    {
        public double Average { get { return Sum / Count; } }
        public double Low;
        public double High;
        public double Sum;
        public int Count; 
        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var d when d >= 90.0:
                        return 'A';

                    case var d when d >= 80.0:
                        return 'B';

                    case var d when d >= 70.0:
                        return 'C';

                    case var d when d >= 60.0:
                        return 'D';

                    default:
                        return 'F';
                }
            }
        }
        public Statistics()
        {
            High = double.MinValue;
            Low = double.MaxValue;
            Sum = 0.0;
            Count = 0;
        }

        public void Add(double grade)
        {
            Sum += grade;
            Count += 1;
            High = Math.Max(High, grade);
            Low = Math.Min(Low, grade);
        }
    }
}