#pragma once

#include <string>
using namespace std;

/*
Problem Data Struct
*/
class pdata {
	const int nr;
	const string name;
	const string expected_res;
	string(*fn) (void);

	pdata(const int nr, string(*fn) (void), const string expected_result)
		: nr(nr),
		name(to_string(nr)),
		expected_res(expected_result)
	{
		this->fn = fn;
	}

	//pdata(const pdata& src)
	//	: nr(src.nr),
	//	name(src.name),
	//	expected_res(src.expected_res)
	//{
	//}

	//pdata(pdata && p) = default;
	//pdata& operator=(const pdata& src)
	//{
	//	return pdata(src);
	//};
};