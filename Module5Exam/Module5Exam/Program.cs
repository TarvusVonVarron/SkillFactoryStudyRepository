using System;

class Program
{
    static public bool CheckNum(string num, out int corrnum)
    {
        if (int.TryParse(num, out int intnum) && intnum > 0)
        {
            corrnum = intnum;
            return false;
        }
        else
        {
            corrnum = 0;
            return true;
        }

    }
    static public (string Name, string LastName, int Age, string[] Pets, string[] Colors) CreatePerson()
    {
        (string Name, string LastName, int Age, string[] Pets, string[] Colors) person = ("","",0, null, null);

        Console.WriteLine("Введите имя:");
        person.Name = Console.ReadLine();

        Console.WriteLine("Введите фамилию:");
        person.LastName = Console.ReadLine();

        int intage;
        string age;
        do
        {
            Console.WriteLine("Введите возраст:");
            age = Console.ReadLine();
        } while (CheckNum(age, out intage));
        person.Age = intage;

        Console.WriteLine("Есть ли у вас питомцы? 1 - нет, 2 - да");
        int isPets = 0;
        do
        {
            string temp = Console.ReadLine();
            if (temp=="1" || temp=="2")
            {
                isPets = Convert.ToInt32(temp);
            }
            else
            {
                Console.WriteLine("Неверно. Введите 1 или 2");
            }
        } while (isPets==0);
        string petsStr;
        int petsCount;
        string[] pets;

        if (isPets == 2)
        {

            do
            {
                Console.WriteLine("Введите количество питомцев:");
                petsStr = Console.ReadLine();
            } while (CheckNum(petsStr, out petsCount));

            pets = new string[petsCount];

            for (int i = 0; i < petsCount; i++)
            {
                Console.WriteLine($"Введите имя {i + 1}го питомца:");
                pets[i] = Console.ReadLine();
            }

            person.Pets = pets;
        }

        string col;
        int colorsCount;
        do
        {
            Console.WriteLine("Введите количество любимых цветов:");
            col = Console.ReadLine();
        } while (CheckNum(col, out colorsCount));

        string[] colors = new string[colorsCount];

        for (int i = 0; i < colorsCount; i++)
        {
            Console.WriteLine($"Введите название {i + 1}го цвета:");
            colors[i] = Console.ReadLine();
        }

        person.Colors = colors;

        return person;
    }

    static public void ShowPerson((string Name, string LastName, int Age, string[] Pets, string[] Colors) person)
    {
        Console.WriteLine("\nАнкета:");
        Console.WriteLine("Имя: " + person.Name);
        Console.WriteLine("Фамилия: " + person.LastName);
        Console.WriteLine("Возраст: " + person.Age);
        if (person.Pets != null)
        {
            Console.WriteLine("Питомцы:");

            for (int i = 0; i < person.Pets.Length; i++)
            {
                Console.WriteLine(person.Pets[i]);
            }
        }
        Console.WriteLine("Любимые цвета:");
        for (int i = 0; i < person.Colors.Length; i++)
        {
            Console.WriteLine(person.Colors[i]);
        }
    }

    // Main Method
    static public void Main(String[] args)
    {

        Console.WriteLine("Main Method");
        var person = CreatePerson();
        ShowPerson(person);
    }
}