#include "CheckingAccount.h"

void CheckingAccount::Withdraw(float amount)
{
	BaseAccount::Withdraw(amount);

	if (numOfWithdraws > 10)
	{
		acountBalance = acountBalance - 5;
	}
}