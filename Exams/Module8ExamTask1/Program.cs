using System;
using System.IO;

class Program
{
    static void AutoClearFolder(string path)
    {
        // Проверяем, существует ли директория
        if (!Directory.Exists(path))
        {
            Console.WriteLine("Ошибка: указанная директория не существует.");
            return;
        }

        DirectoryInfo dir = new DirectoryInfo(path);

        // Пытаемся получить список файлов в директории
        FileInfo[] files;
        try
        {
            files = dir.GetFiles("*", SearchOption.AllDirectories);
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Ошибка: нет прав доступа к указанной директории.");
            return;
        }

        DateTime currentTime = DateTime.Now;
        TimeSpan thirtyMinutes = new TimeSpan(0, 30, 0);

        foreach (FileInfo file in files)
        {
            // Проверяем, был ли файл изменен в последние 30 минут
            if (currentTime - file.LastAccessTime > thirtyMinutes)
            {
                try
                {
                    file.Delete();
                    Console.WriteLine($"Удалён файл: {file.FullName}");
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine($"Ошибка: нет прав доступа к файлу {file.Name}.");
                }
            }
        }
    }


    static void Main(string[] args)
    {
        AutoClearFolder(@"D:\\"); // Указываем путь к папке, из которой будут очищены файлы
    }
}
