namespace IdeagenCalc // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var answer = Calculator.Calculate("( 11.5 + 15.4 ) + 10.1");
            Console.WriteLine($"Answer: {answer}");         // 37
            answer = Calculator.Calculate("23 - ( 29.3 - 12.5 )");
            Console.WriteLine($"Answer: {answer}");         // 6.2
            answer = Calculator.Calculate("( 1 / 2 ) - 1 + 1");
            Console.WriteLine($"Answer: {answer}");         // 0.5
            answer = Calculator.Calculate("1 + 2 + 3");
            Console.WriteLine($"Answer: {answer}");         // 6
            var answer2 = Calculator.Calculate("5 * ( 5 + ( 1 * 2.2 ) * ( 6.2 - 1.3 * ( 7.7 * 3 ) ) )");
            Console.WriteLine($"Answer: {answer2}");         // -237.13
            answer2 = Calculator.Calculate("5 * ( -5.15 + ( -1 * 2.2 ) + ( 6.2 * 1.3 - ( 7.7 + 3 ) ) )");
            Console.WriteLine($"Answer: {answer2}");         // -49.95
            answer2 = Calculator.Calculate("5 - ( -5.15 + ( -1 * 2.2 ) * ( 6.2 * 1.3 - ( 7.7 + 3 ) ) )");
            Console.WriteLine($"Answer: {answer2}");        // 4.342
        }
    }
}