#include "stdafx.h"
// ConsoleApplication1.cpp : Defines the entry point for the console application.
//

#include "problems_000x.h"
#include "problems_001x.h"
#include "problems_002x.h"
#include <map>
#include <chrono>
#include <iomanip>

#define WINDOWS true

#include <stdio.h>  /* defines FILENAME_MAX */
#ifdef WINDOWS
#include <direct.h>
#define GetCurrentDir _getcwd
#else
#include <unistd.h>
#define GetCurrentDir getcwd
#endif

using namespace std;

typedef tuple <int, string, int(*)(void)> kk;

struct foo {
	string rs;
	string(*fn)(void);
};

//map<int, tuple <string, string(*)(void)>> results = {
//	{1, make_tuple("233168", p1)}
//	//{2, "4613732"}
//};

map<int, foo> results = {
	{1, {"233168", p1}},
	{2, {"4613732", p2}},
	{3,{ "6857", p3}},
	{4, {"906609", p4}},
	{5, {"232792560", p5}},
	{6, {"25164150", p6}},
	{7, {"104743", p7}},
	{8, {"23514624000", p8}},
	{9,{ "31875000", p9}},
	{10,{ "142913828922", p10 } },
	{11,{ "70600674", p11 } },
	{12,{ "76576500", p12 } },
	{13,{ "5537376230", p13 } },
	{14,{ "837799", p14 } },
	{28,{ "669171001", p28 } },
	{29,{ "", p29} },
	{30,{ "-1",[]() -> string {return ""; } } },
};

void assert_and_print(int nr, string(*f)(void), const string s) {
	auto start = std::chrono::steady_clock::now();
	auto r = (*f)();
	auto duration = std::chrono::duration_cast<std::chrono::microseconds>
		(std::chrono::steady_clock::now() - start);

	auto eq = r == s;
	auto ms = (double)duration.count() / 1000;

	cout << "p" << nr << ": " << (eq ? "correct" : "false") << "; " << r << "; ";

	cout << std::fixed << setprecision(3) << ms << "ms" << endl;
}

int main()
{
	auto fn = []() -> string { return ""; };

	foo res666 = { "666", fn };
	results[666] = res666;

	std::map<int, foo>::reverse_iterator rit;
	for (rit = results.rbegin(); rit != results.rend(); ++rit)
	{
		auto nr = rit->first;
		auto fn = rit->second.fn;
		assert_and_print(rit->first, rit->second.fn, rit->second.rs);
	}

	for (auto const &item : results)
	{
		auto nr = item.first;
		auto fn = item.second.fn;
		assert_and_print(item.first, item.second.fn, item.second.rs);
	}

	string s;
	getline(cin, s);
	return 0;
}
