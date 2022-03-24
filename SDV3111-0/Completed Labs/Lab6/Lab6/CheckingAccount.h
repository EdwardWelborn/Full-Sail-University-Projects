#pragma once

#include "BaseAccount.h"

class CheckingAccount : public BaseAccount
{
public:
	void Withdraw(float amount);
};
