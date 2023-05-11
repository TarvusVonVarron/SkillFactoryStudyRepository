using System;
using System.IO;

class Program
{
    static long CalculateDirectorySize(string path)
    {
        long size = 0;
        // проверяем, существует ли директория
        if (!Directory.Exists(path))
        {
            throw new DirectoryNotFoundException("Указанная директория не существует.");
        }

        DirectoryInfo dir = new DirectoryInfo(path);

        // получаем все файлы и суммируем их размеры
        FileInfo[] files = dir.GetFiles();
        foreach (FileInfo file in files)
        {
            size += file.Length;
        }

        // рекурсивно делаем то же самое для всех поддиректорий
        DirectoryInfo[] dirs = dir.GetDirectories();
        foreach (DirectoryInfo subdir in dirs)
        {
            size += CalculateDirectorySize(subdir.FullName);
        }

        return size;
    }

    static void Main(string[] args)
    {
        string directoryPath = @"D:\\"; // Указываем путь к папке
        try
        {
            long size = CalculateDirectorySize(directoryPath);
            Console.WriteLine($"Размер папки: {size} байт.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка: {e.Message}");
        }
    }
}
