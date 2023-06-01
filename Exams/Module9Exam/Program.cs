using System;
using System.Collections.Generic;
using System.Linq;

public class InvalidSortOptionException : Exception
{
    public InvalidSortOptionException(string message) : base(message) { }
}

public class NameSorter
{
    public event Action<List<string>> SortAscending;
    public event Action<List<string>> SortDescending;

    private List<string> names;

    public NameSorter(List<string> names)
    {
        this.names = names;

        SortAscending += list => list.Sort();
        SortDescending += list => list.Sort((x, y) => y.CompareTo(x));
    }

    public void Sort(int option)
    {
        switch (option)
        {
            case 1:
                SortAscending?.Invoke(names);
                break;
            case 2:
                SortDescending?.Invoke(names);
                break;
            default:
                throw new InvalidSortOptionException("Неверный тип сортировки. Введите 1 (по возрастанию) или 2 (по убыванию).");
        }
    }

    public override string ToString()
    {
        return string.Join(", ", names);
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<string> names = new List<string> { "Иванов", "Петров", "Сидоров", "Кузнецов", "Зайцев" };

        NameSorter nameSorter = new NameSorter(names);

        while (true)
        {
            Console.WriteLine("Введите 1 для сортировки по возрастанию, 2 для сортировки по убыванию:");

            try
            {
                int option = Int32.Parse(Console.ReadLine());
                nameSorter.Sort(option);
                Console.WriteLine(nameSorter);
            }
            catch (InvalidSortOptionException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверный ввод. Пожалуйста, введите число.");
            }
            finally
            {
                Console.WriteLine();
            }
        }
    }
}
