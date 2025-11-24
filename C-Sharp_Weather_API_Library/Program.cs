// See https://aka.ms/new-console-template for more information

class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            string? line = Console.ReadLine(); //入力を受け取る＆null許容
            if (line != null)
            {
                Console.WriteLine(line);
            }
        }
    }
}

