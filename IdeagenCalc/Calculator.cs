using System.Text.RegularExpressions;

namespace IdeagenCalc
{
    public class Calculator
    {
        /// <summary>
        /// This works with the assumption that the input has been sanitised
        /// As in, the math expression is a legal expression
        /// Ex: open/close brackets matches, double numbers have 1 dot and not multiple (ex: 6.44.212.1), etc 
        /// </summary>
        /// <param name="sum">The input parameter in string</param>
        /// <returns>The answer to the input parameter</returns>
        public static double Calculate(string sum)
        {
            sum = "(" + sum + ")";

            var bracketCount = sum.ToCharArray()
                                  .Where(x => x == '(')
                                  .Count();

            // Iteratively calculate whatever is in the bracket
            for (int i = 1; i <= bracketCount; i++)
            {
                int openBracketIdx = sum.LastIndexOf('(');
                int closeBracketIdx = sum.Substring(openBracketIdx).IndexOf(')');   // Look for next closest closing bracket
                int expressionLength = closeBracketIdx;

                var subExpression = sum.Substring(openBracketIdx, expressionLength + 1);
                string result = SolveExpressionWithoutBracket(subExpression).ToString();
                sum = sum.Replace(subExpression, result);
            }

            var doubleValue = Convert.ToDouble(sum);
            return Math.Round(doubleValue, 2);
        }

        /// <summary>
        /// Solve an expression given that it's without any brackets
        /// </summary>
        /// <param name="subExpression">An expression without bracket</param>
        /// <returns>The answer to the input expression</returns>
        internal static double SolveExpressionWithoutBracket(string subExpression)
        {
            List<double> numbers = GetNumbersFromExpression(subExpression);
            List<string> ops = GetOperatorsFromExpression(subExpression);

            // Handle priority operator: multiple and divide
            for (int i = 0; i < ops.Count(); i++)
            {
                if (ops[i] == "*" || ops[i] == "/")
                {
                    var tmpAnswer = Solve(numbers[i], numbers[i + 1], ops[i]);
                    numbers[i] = tmpAnswer;
                    numbers[i + 1] = 0;
                    ops[i] = "+";
                }
            }

            // Now that we have a flat expression (ex: 2+5-11+0+2-156) without brackets, we can iteratively calculate them all
            double answer = 0;
            for (int i = 0; i < ops.Count(); i++)
            {
                answer = Solve(numbers[i], numbers[i + 1], ops[i]);
                numbers[i + 1] = answer;
            }

            return answer;
        }

        /// <summary>
        /// Get list of mathematical operators within an expression
        /// </summary>
        /// <param name="subExpression">The input expression</param>
        /// <returns>A list of mathematical operators within the input expression</returns>
        internal static List<string> GetOperatorsFromExpression(string subExpression)
        {
            List<string> ops = new List<string>();
            var subExpArr = subExpression.ToCharArray();
            for (int i = 1; i < subExpArr.Length - 1; i++)
            {
                if (subExpArr[i - 1] == ' ' &&
                    (subExpArr[i] == '+' || subExpArr[i] == '-' || subExpArr[i] == '*' || subExpArr[i] == '/') &&
                    subExpArr[i + 1] == ' ')
                {
                    ops.Add(subExpArr[i].ToString());
                }
            }

            return ops;
        }

        /// <summary>
        /// Get list of numbers within an expression
        /// </summary>
        /// <param name="subExpression">The input expression</param>
        /// <returns>A list of numbers within the input expression</returns>
        internal static List<double> GetNumbersFromExpression(string subExpression)
        {
            List<double> numbers = new List<double>();
            // Check for numbers that are normal numbers, numbers with decimal places, and negative numbers
            var pattern = @"-?\d+(\.\d+)?";
            var regex = Regex.Matches(subExpression, pattern);
            if (regex != null)
            {
                foreach (var r in regex)
                {
                    numbers.Add(Convert.ToDouble(r.ToString()));
                }
            }

            return numbers;
        }

        /// <summary>
        /// Solve a simple expression given two numbers and a mathematical operator
        /// </summary>
        /// <param name="v1">The first number</param>
        /// <param name="v2">The second number</param>
        /// <param name="op">The mathematical operator</param>
        /// <returns>The answer to the simple expression</returns>
        internal static double Solve(double v1, double v2, string op)
        {
            switch (op)
            {
                case "+":
                    return v1 + v2;
                case "-":
                    return v1 - v2;
                case "*":
                    return v1 * v2;
                case "/":
                    return v1 / v2;
            }

            return 0;
        }
    }
}
