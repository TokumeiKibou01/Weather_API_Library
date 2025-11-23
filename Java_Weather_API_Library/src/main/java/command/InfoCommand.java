package command;

public class InfoCommand implements CommandBase {

    @Override
    public void runCommand(String name) {
        if (name.equalsIgnoreCase("info")) {
            System.out.print("開発者：TokumeiKibou01");
        }
    }

}
