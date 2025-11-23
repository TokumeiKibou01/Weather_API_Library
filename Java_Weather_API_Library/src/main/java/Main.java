import command.CommandBase;
import command.InfoCommand;

import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.logging.Logger;

public class Main {

    private static final Logger logger = Logger.getLogger("Java_Weather_API_Lib");
    private static final Map<String, CommandBase> cmd_map = new HashMap<>();

    public static void main(String[] args) {
        initLibrary();

        Scanner scanner = new Scanner(System.in);
        while (scanner.hasNext()) {
            String line = scanner.nextLine();
            if (cmd_map.containsKey(line)) {
                CommandBase cmd = cmd_map.get(line);
                cmd.runCommand(line);
            }
            else {
                System.out.print("そのコマンドは見つかりませんでした。");
            }

            System.out.print("\n>");
        }

    }

    public static void initLibrary() {
        InfoCommand info_cmd = new InfoCommand();
        cmd_map.put("info", info_cmd);

        System.out.print(
                "---------- \n" +
                "Java版の天気情報を取得するライブラリです。\n" +
                "---------- \n");
        System.out.print("\n>");
    }
}
