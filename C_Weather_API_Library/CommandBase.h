#pragma once
#include <iostream>

using namespace std;

class CommandBase
{
public:
	virtual void runCommand(string cmd);
};

