#include "stdafx.h"
using namespace std;

std::string p28() {
	using namespace std;
	long long sum = 1;

	for (long long width = 3; width <= 1001; width += 2)
	{
		long long largestCorner = (long long)pow(width, 2);
		sum += largestCorner * 4 - 6 * (width - 1);
	}

	return to_string(sum);
}

std::string p29() {
	set<InfInt> s;

	for (int8_t a = 2; a <= 100; a++)
	{
		InfInt p = a; // pow(a, 1)
		for (int8_t b = 2; b <= 100; b++)
		{
			p *= a; // pow(a, b)
			s.insert(p);
		}
	}
	return to_string(s.size());
}

void add_problems_002x(std::vector<pdata> &v) {
	auto noop = []() -> std::string {return ""; };

	v.push_back(pdata(20, noop, "-1"));
	v.push_back(pdata(21, noop, "-1"));
	v.push_back(pdata(22, noop, "-1"));
	v.push_back(pdata(23, noop, "-1"));
	v.push_back(pdata(24, noop, "-1"));
	v.push_back(pdata(25, noop, "-1"));
	v.push_back(pdata(26, noop, "-1"));
	v.push_back(pdata(27, noop, "-1"));
	v.push_back(pdata(28, p28, "669171001"));
	v.push_back(pdata(29, p29, "-1"));
}

