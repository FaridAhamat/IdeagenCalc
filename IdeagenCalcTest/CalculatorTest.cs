using IdeagenCalc;

namespace IdeagenCalcTest;

[TestClass]
public class CalculatorTest
{
    #region Calculate
    [TestMethod]
    public void Calculate_OneOperatorExpression()
    {
        // Arrange
        string sum = "2 * 2";

        // Act
        var result = Calculator.Calculate(sum);

        // Assert
        Assert.AreEqual(4, result);
    }

    [TestMethod]
    public void Calculate_TwoOperatorExpression()
    {
        // Arrange
        string sum = "1 + 2 + 3";

        // Act
        var result = Calculator.Calculate(sum);

        // Assert
        Assert.AreEqual(6, result);
    }

    [TestMethod]
    public void Calculate_ExpressionWithDecimalPointNumber()
    {
        // Arrange
        string sum = "11.1 + 23";

        // Act
        var result = Calculator.Calculate(sum);

        // Assert
        Assert.AreEqual(34.1, result);
    }

    [TestMethod]
    public void Calculate_ExpressionStartsWithBracket()
    {
        // Arrange
        string sum = "( 11.5 + 15.4 ) + 10.1";

        // Act
        var result = Calculator.Calculate(sum);

        // Assert
        Assert.AreEqual(37, result);
    }

    [TestMethod]
    public void Calculate_ExpressionEndsWithBracket()
    {
        // Arrange
        string sum = "23 - ( 29.3 - 12.5 )";

        // Act
        var result = Calculator.Calculate(sum);

        // Assert
        Assert.AreEqual(6.2, result);
    }

    [TestMethod]
    public void Calculate_ExpressionStartsWithNestedBracket()
    {
        // Arrange
        string sum = "10 - ( 2 + 3 * ( 7 - 5 ) )";

        // Act
        var result = Calculator.Calculate(sum);

        // Assert
        Assert.AreEqual(2, result);
    }

    [TestMethod]
    public void Calculate_ExpressionEndsWithNestedBracket()
    {
        // Arrange
        string sum = "( 2 + 3 * ( 7 - 5 ) ) * 5";

        // Act
        var result = Calculator.Calculate(sum);

        // Assert
        Assert.AreEqual(40, result);
    }

    [TestMethod]
    public void Calculate_ExpressionWithTwoSeparateBracket()
    {
        // Arrange
        string sum = "( 5 + 10 ) / ( 3 * 2 )";

        // Act
        var result = Calculator.Calculate(sum);

        // Assert
        Assert.AreEqual(2.5, result);
    }
    #endregion

    #region GetOperatorsFromExpression
    [TestMethod]
    public void GetOperatorsFromExpression_SingleOperator()
    {
        // Arrange
        string sum = "26 + 22";

        // Act
        var result = Calculator.GetOperatorsFromExpression(sum);

        // Assert
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("+", result[0]);
    }

    [TestMethod]
    public void GetOperatorsFromExpression_MultipleOperator()
    {
        // Arrange
        string sum = "26 + 22 * 32 / 24";

        // Act
        var result = Calculator.GetOperatorsFromExpression(sum);

        // Assert
        Assert.AreEqual(3, result.Count);
        Assert.AreEqual("*", result[1]);
        Assert.AreEqual("/", result[2]);
    }

    [TestMethod]
    public void GetOperatorsFromExpression_MultipleOperatorWithNegativeNumbers()
    {
        // Arrange
        string sum = "-26 + 22 * -32 / 24";

        // Act
        var result = Calculator.GetOperatorsFromExpression(sum);

        // Assert
        Assert.AreEqual(3, result.Count);
        Assert.AreEqual("*", result[1]);
        Assert.AreEqual("/", result[2]);
    }
    #endregion

    #region GetNumbersFromExpression
    [TestMethod]
    public void GetNumbersFromExpression_SimpleNumbers()
    {
        // Arrange
        string sum = "5 + 10 - 32";

        // Act
        var result = Calculator.GetNumbersFromExpression(sum);

        // Assert
        Assert.AreEqual(3, result.Count);
        Assert.AreEqual(10, result[1]);
        Assert.AreEqual(32, result[2]);
    }

    [TestMethod]
    public void GetNumbersFromExpression_ContainNegativeNumbers()
    {
        // Arrange
        string sum = "5 + -10 - 32";

        // Act
        var result = Calculator.GetNumbersFromExpression(sum);

        // Assert
        Assert.AreEqual(3, result.Count);
        Assert.AreEqual(-10, result[1]);
        Assert.AreEqual(32, result[2]);
    }

    [TestMethod]
    public void GetNumbersFromExpression_ContainNumbersWithDecimalPoints()
    {
        // Arrange
        string sum = "5 + 10 - 32 * -1.5";

        // Act
        var result = Calculator.GetNumbersFromExpression(sum);

        // Assert
        Assert.AreEqual(4, result.Count);
        Assert.AreEqual(32, result[2]);
        Assert.AreEqual(-1.5, result[3]);
    }
    #endregion

    #region Solve
    [TestMethod]
    public void Solve_Add()
    {
        // Arrange
        int v1 = 10;
        int v2 = 20;
        string op = "+";

        // Act
        var result = Calculator.Solve(v1, v2, op);

        // Assert
        Assert.AreEqual(30, result);
    }

    [TestMethod]
    public void Solve_Minus()
    {
        // Arrange
        int v1 = 100;
        int v2 = 20;
        string op = "-";

        // Act
        var result = Calculator.Solve(v1, v2, op);

        // Assert
        Assert.AreEqual(80, result);
    }

    [TestMethod]
    public void Solve_Multiply()
    {
        // Arrange
        int v1 = 10;
        int v2 = 20;
        string op = "*";

        // Act
        var result = Calculator.Solve(v1, v2, op);

        // Assert
        Assert.AreEqual(200, result);
    }

    [TestMethod]
    public void Solve_Divide()
    {
        // Arrange
        int v1 = 500;
        int v2 = 20;
        string op = "/";

        // Act
        var result = Calculator.Solve(v1, v2, op);

        // Assert
        Assert.AreEqual(25, result);
    }
    #endregion
}
