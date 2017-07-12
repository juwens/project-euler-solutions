#include "stdafx.h"
#include "primes.h"
#include <bitset>
using namespace std;

std::vector<long> primes(const int max, const int count) {
	const long size = max;

	vector<bool> sieve(size, true);
	sieve[0] = false;
	sieve[1] = false;

	vector<long> primes;

	for (long i = 0; i < size; i++)
	{
		if (sieve[i] == false) continue;

		primes.push_back(i);

		if (count > 0 && primes.size() == count) {
			break;
		}

		for (long j = i * 2; j < size; j += i)
		{
			sieve[j] = false;
		}
	}

	return primes;
}

