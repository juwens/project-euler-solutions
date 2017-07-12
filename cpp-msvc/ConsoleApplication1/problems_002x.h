#pragma once

#include "stdafx.h"

//std::string p20();
//std::string p21();
//std::string p22(); 
//std::string p23();
//std::string p24();
//std::string p25();
//std::string p26();
//std::string p27();

std::string p28() {
	using namespace std;
	long long sum = 1;

	for (long long width = 3; width <= 1001; width += 2)
	{
		long long largestCorner = (long long)pow(width, 2);
		sum += largestCorner * 4 - 6 * (width - 1);


		//for (long long tmp = largestCorner, i = 0; i < 4; i++, tmp -= width - 1)
		//{
		//	sum += tmp;
		//}
	}

	return to_string(sum);
}
std::string p29() {
	using namespace std;
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