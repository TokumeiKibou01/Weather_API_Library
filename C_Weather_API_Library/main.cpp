#include <iostream>
#include "CommandBase.h"
#include "InfoCommand.h"
#include <map>

using namespace std;

namespace {
	map<string, CommandBase*> cmdMap;
}

void initLibrary();

int main() {
	initLibrary();

	string text = "";
	while (true) {
		cin >> text;
		if (text.length() != 0) {
			map<string, CommandBase*>::iterator find = cmdMap.find(text);
			if (find != cmdMap.end()) { //最後のイテレータじゃない=マップにある
				CommandBase* cmd = find->second;
				cmd->runCommand(text);
			}
			else {
				cout << "コマンドが見つかりませんでした" << endl;
			}
			cout << ">";
		}
		else {
			cout << "コマンドが見つかりませんでした" << endl;
		}
	}
}

void initLibrary() {
	cmdMap["info"] = new InfoCommand();

	cout << ">";
}