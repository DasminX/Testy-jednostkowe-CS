using System;

namespace QuadraticEquationSolver
{
  public class Program
  {
    static void Main()
    {
      Console.WriteLine("Podaj współczynniki równania kwadratowego ax^2 + bx + c = 0:");

      Console.Write("Podaj współczynnik a: ");
      double a = Convert.ToDouble(Console.ReadLine());

      Console.Write("Podaj współczynnik b: ");
      double b = Convert.ToDouble(Console.ReadLine());

      Console.Write("Podaj współczynnik c: ");
      double c = Convert.ToDouble(Console.ReadLine());

      QuadraticEquationResult result = SolveQuadraticEquation(a, b, c);

      if (result.HasRealRoots)
      {
        if (result.Root1 == result.Root2)
        {
          Console.WriteLine("x = " + result.Root1);
        }
        else
        {

          Console.WriteLine("Pierwiastki równania kwadratowego:");
          Console.WriteLine("x1 = " + result.Root1);
          Console.WriteLine("x2 = " + result.Root2);
        }
      }
      else
      {
        Console.WriteLine("Równanie nie ma pierwiastków rzeczywistych.");
      }

      Console.ReadLine();
    }

    public static QuadraticEquationResult SolveQuadraticEquation(double a, double b, double c)
    {
      double delta = b * b - 4 * a * c;

      if (delta > 0)
      {
        double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
        double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
        return new QuadraticEquationResult(x1, x2);
      }
      else if (delta == 0)
      {
        double x = -b / (2 * a);
        return new QuadraticEquationResult(x);
      }
      else
      {
        return QuadraticEquationResult.NoRealRoots();
      }
    }
  }

  public class QuadraticEquationResult
  {
    public double Root1 { get; }
    public double Root2 { get; }
    public bool HasRealRoots { get; }

    public QuadraticEquationResult(double root1, double root2)
    {
      Root1 = root1;
      Root2 = root2;
      HasRealRoots = true;
    }

    public QuadraticEquationResult(double root)
    {
      Root1 = root;
      Root2 = root;
      HasRealRoots = true;
    }

    private QuadraticEquationResult()
    {
      HasRealRoots = false;
    }

    public static QuadraticEquationResult NoRealRoots()
    {
      return new QuadraticEquationResult();
    }
  }
}