#include "BaseAccount.h"

class CreditAccount : public BaseAccount
{
private:
	int spent = 0;
public:
	void Withdraw(float amount);
};
