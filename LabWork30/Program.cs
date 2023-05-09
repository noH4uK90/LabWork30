Task3();

void Task1()
{
    if (!args.Any())
        return;
    
    var helpParams = new[]{ "/?", "/h", "/help" };

    var firstArg = args[0].ToLower();
    
    if (helpParams.Contains(firstArg))
        Console.WriteLine("Фамилии разработчиков: Спирин, Степанов, Белов");
    if (firstArg == "-view")
        Console.WriteLine($"Параметры: \n{string.Join("\n", args.Skip(1))}");
}

void Task2()
{

    while (true)
    {
        Clear();
        DisplayMenu();

        Console.WriteLine("Введите цифру:");
        if (!int.TryParse(Console.ReadLine(), out var selected))
            continue;

        switch (selected)
        {
            case 1:
                Clear();
                InputText();
                break;
            case 2:
                Clear();
                ReadFile();
                break;
            case 3:
                Environment.Exit(0);
                break;
        }
    }
}

void DisplayMenu()
{
    var menu = new[]
    {
        "Запись файла",
        "Чтение файла",
        "Выход"
    }.Select((value, i) => $"[{i + 1}] {value}");
    Console.WriteLine(string.Join("\n", menu));
}

void InputText()
{
    Console.Title = "Запись файла";

    Console.WriteLine("Введите имя файла:");
    var fileName = Console.ReadLine();
    
    if (string.IsNullOrWhiteSpace(fileName))
        return;
    
    using var fs = File.Open(fileName, FileMode.OpenOrCreate);
    using var sw = new StreamWriter(fs);

    Console.SetOut(sw);

    var line = string.Empty;
    while ((line = Console.ReadLine()) != "end")
        Console.WriteLine(line);


    var standardOutput = new StreamWriter(Console.OpenStandardOutput());
    standardOutput.AutoFlush = true;
    Console.SetOut(standardOutput);
    Console.OutputEncoding = standardOutput.Encoding;
    Console.ReadKey();
}

void ReadFile()
{
    Console.Title = "Чтение файла";
    Console.ReadKey();
}

void Clear()
{
    Console.Title = "МДК 01.04";
    Console.Clear();
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.White;
}

void Task3()
{
    Console.WriteLine("UI");
    
    if (!args.Any())
        return;

    if (args[0] == "-console")
    {
        Task2();
    }
    else
    {
        Console.WriteLine("UI");
    }
}