// See https://aka.ms/new-console-template for more information

using C_Sharp_Weather_API_Library;

class Program
{

    private static Dictionary<string, CommandBase> cmd_dictionary = new Dictionary<string, CommandBase>();

    public static void Main(string[] args)
    {
        initLibrary();
        while (true)
        {
            string? line = Console.ReadLine(); //入力を受け取る＆null許容
            if (line != null)
            {
                if (cmd_dictionary.ContainsKey(line))
                {
                    CommandBase cmd = cmd_dictionary[line];
                    cmd.runCommand(line);
                }
                else
                {
                    Console.WriteLine("そのコマンドは見つかりませんでした。");
                }
                Console.Write(">");
            }
            else
            {
                Console.Write(">");
            }
        }
    }

    public static void initLibrary()
    {
        cmd_dictionary.Add("info", new InfoCommand());

        Console.Write(">");
    }
}

