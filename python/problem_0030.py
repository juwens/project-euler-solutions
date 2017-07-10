# -*- coding: utf-8 -*-
"""
Created on Wed Jan 11 22:03:17 2017

@author: jensj
----------------
Digit fifth powers

Surprisingly there are only three numbers that can be written as the sum of
fourth powers of their digits:

1634 = 1**4 + 6**4 + 3**4 + 4**4
8208 = 8**4 + 2**4 + 0**4 + 8**4
9474 = 9**4 + 4**4 + 7**4 + 4**4

As 1 = 14 is not a sum it is not included.

The sum of these numbers is 1634 + 8208 + 9474 = 19316.

Find the sum of all the numbers that can be written as the sum of fifth 
powers of their digits.
"""
import functools, operator

def product(numbers):
    return functools.reduce(operator.mul, numbers, 1)

n = 5
result = 0

for i in range(2, 10**(n+1)):
    mySum = sum([int(x)**n for x in str(i)])

    if i == mySum:
        result += i
        print(i)

print("sum:", result)