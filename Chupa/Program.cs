using FastSearchLibrary;

Console.WriteLine("Введите имя файла");
string FileName = Console.ReadLine();
DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\");
string path = null;
string txt = String.Empty;
try
{
    List<FileInfo> resultFiles1 = FileSearcher.GetFilesFast(@"C:\", (f) => f.Name.Contains(FileName));
    path = resultFiles1[0].FullName;
}
catch { }
if (path != null)
{
    using (StreamReader reader = new StreamReader(path))
    {
        txt = reader.ReadToEnd();
        Console.WriteLine(txt);
    }
}
else
{
    Console.WriteLine("Такого файла не существует");
}
Console.WriteLine("Введите имя файла латинскими буквами");
string FileName2 = Console.ReadLine();
bool True = true;
string Fulltxt = String.Empty;
while (True)
{
    Console.WriteLine("Введите букву для поиска слова");
    string ch = Console.ReadLine();
    foreach (var item in txt.Split(' '))
    {
        if (item[0] == ch?.ToCharArray()[0])
        {
            try
            {
                Fulltxt += item + "\n";
            }
            catch { }
        }
    }
    if(Console.ReadKey().Key == ConsoleKey.Escape)
    {
        True = false;
    }
}
using (StreamWriter wr = new StreamWriter($"C:/programm/{FileName2}.txt"))
{
    wr.Write(Fulltxt);
}









