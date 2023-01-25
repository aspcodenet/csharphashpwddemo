using System.Security.Cryptography;
using System.Text;

public class App
{
    private readonly string dictFile = "example.dict.txt";
    private readonly string hashedFile = "hashadelosen.txt";

    public void Run()
    {
        EnsurePreHashedFileExists();
        while (true)
        {
            Console.WriteLine("Ange hash:");
            var hash = Console.ReadLine();
            //TODO Skriv kod som söker i hashadelosen.txt och 
            //Hittar du denna hash så är ju lösenordet på samma rad!
        }
    }

    private void EnsurePreHashedFileExists()
    {
        if (File.Exists(hashedFile)) return;

        var writer = File.CreateText(hashedFile);
        foreach (var line in File.ReadLines(dictFile))
        {
            var hash = GenerateHash(line);
            writer.WriteLine(hash + " " + line);
        }
        writer.Close();
    }

    private string GenerateHash(string line)
    {
        using (var md5 = MD5.Create())
        {
            return BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(line)))
                .Replace("-", "");
        }
    }
}