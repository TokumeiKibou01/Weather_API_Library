#pragma once
#include "CommandBase.h"
class GetCurlCommand :
    public CommandBase
{
    void runCommand(string cmd) override;
};

