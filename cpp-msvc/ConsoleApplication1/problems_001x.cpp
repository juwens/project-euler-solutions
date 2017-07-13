#include "stdafx.h"
#include "problems_001x.h"

using namespace std;
std::string p10()
{
	const int n = 2'000'000;
	auto primeList = primes(n);

	long long res = 0;
	for (auto p : primeList)
	{
		res += p;
	}

	return std::to_string(res);
}

std::string p11()
{
	stringstream ss;
	ifstream fs("Data/p11.txt");

	if (fs.fail()) //check for file open failure
	{
		cerr << "Error opening file" << endl;
		cerr << "program will halt" << endl;//error prompt
		exit(11);
	}

	vector<string> lines;
	vector<vector<int>> matrix;
	string line;

	while (getline(fs, line))
	{
		istringstream iss(line);
		vector<int> numbers{ istream_iterator<int>{iss}, istream_iterator<int>{} };
		lines.push_back(line);
		matrix.push_back(numbers);
	}

	auto n = 4;

	vector <pair<int, int>> vectors;
	vectors.push_back(make_pair(1, 0));
	vectors.push_back(make_pair(1, 1));
	vectors.push_back(make_pair(0, 1));
	vectors.push_back(make_pair(-1, 1));

	vector<long> products;
	for each (auto v in vectors)
	{
		auto xVec = get<0>(v);
		auto yVec = get<1>(v);

		for (size_t row = 0; row + (n * yVec) < matrix.size(); row++)
		{
			for (size_t column = xVec == -1 ? 3 : 0; column + (xVec == -1 ? 0 : (n * xVec)) < matrix[0].size(); column++)
			{
				auto tmp = matrix[row][column]
					* matrix[row + (1 * yVec)][column + (1 * xVec)]
					* matrix[row + (2 * yVec)][column + (2 * xVec)]
					* matrix[row + (3 * yVec)][column + (3 * xVec)];
				products.push_back(tmp);
			}
		}
	}

	std::sort(products.begin(), products.end());

	return to_string(products.back());
}

std::string p12()
{
	const __int32 n = 500;
	__int32 triNum = 0;
	__int32 numberOfDivisors = 0;
	for (__int32 i = 1; numberOfDivisors <= n; i++)
	{
		triNum += i;
		numberOfDivisors = 0;

		if (pow((__int32)sqrt(triNum), 2) == triNum) continue;

		for (__int32 d = 1; d*d < triNum; d++)
		{
			if (0 == triNum % d) {
				numberOfDivisors += 2;
			}
		}
	}

	return to_string(triNum);
}

vector<string> fileGetLines(const string path) {
	stringstream ss;
	ifstream fs(path);

	if (fs.fail()) //check for file open failure
	{
		cerr << "Error opening file" << endl;
		cerr << "program will halt" << endl;//error prompt
		exit(11);
	}

	vector<string> lines;
	string line;

	while (getline(fs, line))
	{
		lines.push_back(line);
	}

	fs.close();
	return lines;
}

std::string p13()
{
	InfInt res = 0;
	auto lines = fileGetLines("Data/p13.txt");
	for each (auto line in lines)
	{
		res += line;
		string s = res.toString();
	}

	return res.toString().substr(0, 10);
}

std::string p14()
{

	typedef unsigned __int32 _ulong;

	const _ulong max = 1'000'000;
	_ulong res_start = 0;
	_ulong res_length = 0;
	unordered_map<_ulong, _ulong> cache;
	for (_ulong currentStart = 1; currentStart < max; currentStart++)
	{
		_ulong length = 0;
		for (_ulong n = currentStart; n != 1; length++)
		{
			//auto v = cache[n];
			//if (cache.count(n) > 0) {
			//	length += cache[n];
			//	break;
			//}

			n = (n % 2 == 0) ? n / 2 : n * 3 + 1;
		}

		//cache.insert(make_pair(currentStart, length));
		if (length > res_length) {
			res_start = currentStart;
			res_length = length;
		}
	}

	return to_string(res_start);
}

std::string p15()
{
	return std::string();
}

std::string p16()
{
	return std::string();
}

std::string p17()
{
	return std::string();
}

std::string p18()
{
	return std::string();
}

std::string p19()
{
	return std::string();
}

void add_problems_001x(std::vector<pdata>& v)
{
	v.push_back(pdata(10, p10, "142913828922"));
	v.push_back(pdata(11, p11, "70600674"));
	v.push_back(pdata(12, p12, "76576500"));
	v.push_back(pdata(13, p13, "5537376230"));
	v.push_back(pdata(14, p14, "-1"));
	v.push_back(pdata(15, p15, "-1"));
	v.push_back(pdata(16, p16, "-1"));
	v.push_back(pdata(17, p17, "-1"));
	v.push_back(pdata(18, p18, "-1"));
	v.push_back(pdata(19, p19, "-1"));
}
