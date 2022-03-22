#include "BaseAccount.h"

void BaseAccount::Withdraw(float amount)
{
	acountBalance = acountBalance - amount;
}

void BaseAccount::Deposit(float amount)
{
	acountBalance = acountBalance + amount;
}

float BaseAccount::GetBalance() const
{
	return acountBalance;
}
