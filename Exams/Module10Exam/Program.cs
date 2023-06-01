using System;

public interface ICalculator
{
    double Add(double a, double b);
}

public class Calculator : ICalculator
{
    public double Add(double a, double b)
    {
        return a + b;
    }
}

public interface ILogger
{
    void LogError(string message);
    void LogInfo(string message);
}

public class ConsoleLogger : ILogger
{
    public void LogError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public void LogInfo(string message)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}

class Program
{
    static void Main(string[] args)
    {
        ICalculator calculator = new Calculator();
        ILogger logger = new ConsoleLogger();

        try
        {
            Console.Write("Введите первое число: ");
            double a = Double.Parse(Console.ReadLine());

            Console.Write("Введите второе число: ");
            double b = Double.Parse(Console.ReadLine());

            double result = calculator.Add(a, b);

            logger.LogInfo($"Сумма чисел: {result}");
        }
        catch (FormatException)
        {
            logger.LogError("Введено некорректное значение. Пожалуйста, убедитесь, что вы вводите целое число.");
        }
        finally
        {
            logger.LogInfo("Калькулятор завершил работу.");
        }
    }
}