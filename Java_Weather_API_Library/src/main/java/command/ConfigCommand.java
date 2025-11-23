package command;

import manager.ConfigJson;
import manager.DeserializedJson;
import manager.JsonManager;

public class ConfigCommand implements CommandBase {

    @Override
    public void runCommand(String name) {
        if (name.equalsIgnoreCase("get_config")) {
            JsonManager configManager = new JsonManager(JsonManager.FileType.CONFIG);
            ConfigJson deserializedJson = (ConfigJson) configManager.getDeserializedJson();
            System.out.print("生データ：" + configManager.getRawElement());
        }
    }

}
