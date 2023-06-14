namespace GradeBook // Note:  namespace depends on the project name.
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new DiskBook("Brenda's Gradebook");
            book.GradeAdded += OnGradeAdded; //subscribe to the event

            EnterGrades(book);

            var stats = book.GetStatistics();
            Console.WriteLine($"The avg grade is {stats.Average:N1}");
            Console.WriteLine($"The highest grade is {stats.High:N1}");
            Console.WriteLine($"The lowest grade is {stats.Low:N1}");
            Console.WriteLine($"The letter is {stats.Letter}");

        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input!);
                    book.AddGrade(grade);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs args)
        {
            Console.WriteLine("A grade was added");
        }
    }
}