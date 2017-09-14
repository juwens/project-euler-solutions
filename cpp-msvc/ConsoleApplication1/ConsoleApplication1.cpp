#define _ITERATOR_DEBUG_LEVEL 0

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
#include "ConsoleApplication1.h"
#define GetCurrentDir getcwd
#endif

using namespace std;

//void assert_and_print(string nr, string(*fp)(void), const string expected_result) {
void assert_and_print(const string nr, const function<string(void)> &fn, const string expected_result) {
	cout << "p" << nr << ": ";

	auto start = std::chrono::steady_clock::now();
	auto result = fn();
	auto duration = std::chrono::duration_cast<std::chrono::microseconds>
		(std::chrono::steady_clock::now() - start);

	auto eq = result == expected_result;
	auto ms = round((double)duration.count() / 1000);

	
	cout << (eq ? "correct" : "false") << "; ";
	cout << result << "; ";
	cout /*<< std::fixed << setprecision(0) */<< ms << "ms" << endl;
}
using namespace std;
int main()
{
	vector<reference_wrapper<pdata>> problems;



	add_problems_000x(problems);
	add_problems_001x(problems);
	add_problems_002x(problems);

	sort(problems.begin(), problems.end(), [](const pdata& a, const pdata& b) -> auto { return a.nr < b.nr; });
	//sort(problems.begin(), problems.end(), less_than_key());

	for (const auto& problem_ref : problems)
	{
		auto problem = problem_ref.get();
		auto nr = problem.nr;
		auto fn = problem.fn;
		assert_and_print(problem.name, fn, problem.expected_res);
	}

	cout << endl;
	cout << "finished. press <any key> to quit." << endl;

	string s;
	getline(cin, s);
	return 0;
}
