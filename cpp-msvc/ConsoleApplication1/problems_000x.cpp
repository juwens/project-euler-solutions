#include "stdafx.h"

using namespace std;

bool isPalindrom(std::string s) {
	int mid = (int)floorl((float)s.length() / 2);

	for (int x = 0; x <= mid; x++)
	{
		auto a = s[x];
		auto b = s[s.length() - 1 - x];
		if (s[x] != s[s.length() - 1 - x]) {
			return false;
		}
	}

	return true;
}

string p1() {
	auto sum = 0ll;
	for (long long i = 0; i < 1000; i++)
	{
		if (i % 3 == 0 || i % 5 == 0)
		{
			sum += i;
		}
	}

	return to_string(sum);
}

string p2() {
	int a = 0, b = 1;

	int sum = 0;
	while (a + b < 4 * 1000 * 1000)
	{
		auto tmp = a + b;
		a = b;
		b = tmp;

		if (b % 2 == 0) {
			sum += b;
		}
		//cout << b << endl;
	};

	return to_string(sum);
}

string p3()
{
	std::vector<int> factors;
	auto rest = 600'851'475'143;
	auto max = (long)sqrtl((double)rest);
	for (long i = 3; i <= max && rest > 1; i += 2)
	{
		if (rest % i == 0) {
			while (rest % i == 0) {
				rest = rest / i;
			}
			factors.push_back(i);
		}
	}

	return to_string(factors.back());
}

string p4()
{
	int largestPal = 0;

	for (int i = 999; i > 100; i--)
	{
		if (i % 11 == 0) continue;

		for (int j = 990; j > 100; j -= 11)
		{
			auto prod = i * j;
			if (prod < largestPal) break;

			string s = to_string(prod);

			if (isPalindrom(s) && prod > largestPal) {
				largestPal = prod;
			}
		}
	}

	return to_string(largestPal);
}

string p5()
{
	int primes[] = { 2, 3, 5, 7, 11, 13, 17, 19, 23 };

	const int k = 20;
	__int64 N = 1;
	bool check = true;

	auto limit = sqrt(k);
	unordered_map<int, int> a;
	for (long i = 0; primes[i] <= k; i++)
	{
		a[i] = 1;
		if (check) {
			if (primes[i] <= limit) {
				a[i] = (int)floor(log(k) / log(primes[i]));
			}
			else {
				check = false;
			}
		}
		N = N * (long long)pow(primes[i], a[i]);
	}

	return to_string(N);
}

string p6() {
	typedef long long i64;

	i64 a = 0;
	i64 b = 0;
	for (i64 i = 1; i <= 100; i++)
	{
		a += (i64)pow(i, 2);
		b += i;
	}
	b = (i64)pow(b, 2);
	i64 res = abs(a - b);
	return to_string(res);
}

string p7() {
	const long n = 10'001;
	const long size = n * 20;

	auto prime = primes(size, n);

	return to_string(prime[n-1]);
}

int to_int(const std::string& str) {
	return std::stoi(str);
}

string p8() {


	stringstream ss;
	ifstream fs("Data/p8.txt");

	if (fs.fail()) //check for file open failure
	{
		cerr << "Error opening file" << endl;
		cerr << "program will halt" << endl;//error prompt
		exit(8);
	}

	std::string line;
	while (getline(fs, line))
	{
		ss << line;
	}

	const int n = 13;

	string text = ss.str();
	__int64 largestProduct = 1;
	for (size_t i = 0; i + n < text.size(); i++)
	{
		auto sub = text.substr(i, n);

		__int64 product = 1;
		for each (auto c in sub)
		{
			auto f = c - '0';
			product *= f;
		}

		if (product > largestProduct) { largestProduct = product; }
	}

	return to_string(largestProduct);
}

string p9() {
	const long n = 1000;
	long res = 0;

	for (long a = 1; a < 999; a++)
	{
		for (long b = a + 1; b < n - a; b++)
		{
			long c = n - a - b;

			if (pow(a, 2) + pow(b, 2) == pow(c, 2)) {
				return to_string(a*b*c);
			}
		}
	}

	return "error";
}

void add_problems_000x(vector<pdata> &v) {
	v.push_back(pdata(1, p1, "233168"));
	v.push_back(pdata(2, p2, "4613732"));
	v.push_back(pdata(3, p3, "6857"));
	v.push_back(pdata(4, p4, "906609"));
	v.push_back(pdata(5, p5, "232792560"));
	v.push_back(pdata(6, p6, "25164150"));
	v.push_back(pdata(7, p7, "104743"));
	v.push_back(pdata(8, p8, "23514624000"));
	v.push_back(pdata(9, p9, "31875000"));
}

void add_problems_000x(std::vector<reference_wrapper<pdata>> &v) {
	v.push_back(ref(pdata(1, p1, "233168")));
	v.push_back(pdata(2, p2, "4613732"));
	v.push_back(pdata(3, p3, "6857"));
	v.push_back(pdata(4, p4, "906609"));
	v.push_back(pdata(5, p5, "232792560"));
	v.push_back(pdata(6, p6, "25164150"));
	v.push_back(pdata(7, p7, "104743"));
	v.push_back(pdata(8, p8, "23514624000"));
	v.push_back(pdata(9, p9, "31875000"));
}