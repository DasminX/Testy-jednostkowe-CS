using Xunit;
using QuadraticEquationSolver;

namespace QuadraticEquationSolver.Tests
{
  public class QuadraticEquationTests
  {
    [Theory]
    [InlineData(1, 0, 1, 0, 0)] // Brak pierwiastków rzeczywistych
    [InlineData(1, -2, 1, 1, 1)] // Jeden pierwiastek rzeczywisty
    [InlineData(1, -7, 10, 2, 5)] // Dwa pierwiastki rzeczywiste
    public void TestQuadraticEquation(double a, double b, double c, double expectedRoot1, double expectedRoot2)
    {
      // Arrange
      QuadraticEquationResult result = Program.SolveQuadraticEquation(a, b, c);

      // Assert
      Assert.True(result.HasRealRoots);
      Assert.Equal(expectedRoot1, result.Root1, 6);
      Assert.Equal(expectedRoot2, result.Root2, 6);
    }
  }
}