#include "SavingsAccount.h"

void SavingsAccount::Withdraw(float amount)
{
	if (numOfWithdraws < 3)
	{
		BaseAccount::Withdraw(amount);
	}
}