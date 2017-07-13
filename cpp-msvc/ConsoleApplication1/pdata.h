#pragma once

#include <string>

/*
Problem Data Struct
*/
struct pdata {
	int nr;
	std::string name;
	std::string expected_res;
	std::string (*fn) (void);

	pdata(const int nr, std::string(*fn) (void), const std::string expected_result) {
		this->nr = nr;
		this->name = std::to_string(nr);
		this->fn = fn;
		this->expected_res = expected_result;
	}

	pdata() {

	}
};