#pragma once

class BaseAccount
{
protected:
	float acountBalance = 0;
	int numOfWithdraws = 0;
public:
	void Withdraw(float amount);
	void Deposit(float amount);
	float GetBalance() const;
};
