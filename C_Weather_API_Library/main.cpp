#include <iostream>
#include "CommandBase.h"
#include "InfoCommand.h"
#include "GetCurlCommand.h"
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
			if (find != cmdMap.end()) { //�Ō�̃C�e���[�^����Ȃ�=�}�b�v�ɂ���
				CommandBase* cmd = find->second;
				cmd->runCommand(text);
			}
			else {
				cout << "�R�}���h��������܂���ł���" << endl;
			}
			cout << ">";
		}
		else {
			cout << "�R�}���h��������܂���ł���" << endl;
		}
	}
}

void initLibrary() {
	cmdMap["info"] = new InfoCommand();
	cmdMap["get_curl"] = new GetCurlCommand();

	cout << ">";
}