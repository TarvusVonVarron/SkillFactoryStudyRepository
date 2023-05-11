using System;
using System.IO;

class Program
{
    static long CalculateDirectorySize(string path)
    {
        long size = 0;
        if (!Directory.Exists(path))
        {
            throw new DirectoryNotFoundException("Указанная директория не существует.");
        }

        DirectoryInfo dir = new DirectoryInfo(path);
        FileInfo[] files = dir.GetFiles();
        foreach (FileInfo file in files)
        {
            size += file.Length;
        }

        DirectoryInfo[] dirs = dir.GetDirectories();
        foreach (DirectoryInfo subdir in dirs)
        {
            size += CalculateDirectorySize(subdir.FullName);
        }

        return size;
    }

    static int CleanDirectory(string path)
    {
        int filesDeleted = 0;
        if (!Directory.Exists(path))
        {
            throw new DirectoryNotFoundException("Указанная директория не существует.");
        }

        DirectoryInfo dir = new DirectoryInfo(path);
        FileInfo[] files = dir.GetFiles();
        foreach (FileInfo file in files)
        {
            TimeSpan timeInactive = DateTime.Now - file.LastAccessTime;
            if (timeInactive.TotalMinutes > 30)
            {
                file.Delete();
                filesDeleted++;
            }
        }

        DirectoryInfo[] dirs = dir.GetDirectories();
        foreach (DirectoryInfo subdir in dirs)
        {
            TimeSpan timeInactive = DateTime.Now - subdir.LastAccessTime;
            if (timeInactive.TotalMinutes > 30)
            {
                subdir.Delete(true);
                filesDeleted++;
            }
        }

        return filesDeleted;
    }

    static void Main(string[] args)
    {
        string directoryPath = @"D:\\"; // Указываем путь к папке
        try
        {
            // Вычисляем исходный размер папки
            long initialSize = CalculateDirectorySize(directoryPath);
            Console.WriteLine($"Исходный размер папки: {initialSize} байт.");

            // Выполняем очистку и получаем количество удаленных файлов
            int filesDeleted = CleanDirectory(directoryPath);
            Console.WriteLine($"Удалено файлов: {filesDeleted}");

            // Вычисляем конечный размер папки и выводим разницу
            long finalSize = CalculateDirectorySize(directoryPath);
            Console.WriteLine($"Освобождено места: {initialSize - finalSize} байт.");
            Console.WriteLine($"Конечный размер папки: {finalSize} байт.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка: {e.Message}");
        }
    }
}
