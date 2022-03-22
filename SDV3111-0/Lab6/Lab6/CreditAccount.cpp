#include "CreditAccount.h"

void CreditAccount::Withdraw(float amount)
{
	BaseAccount::Withdraw(amount);
	spent = spent + amount;
	if (spent > 40)
	{
		acountBalance = acountBalance + 5000;
	}
}