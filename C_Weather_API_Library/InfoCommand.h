#pragma once
#include "CommandBase.h"
class InfoCommand :
    public CommandBase
{
    void runCommand(string cmd) override;
};

