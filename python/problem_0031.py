# -*- coding: utf-8 -*-
"""
Created on Sun Jan 15 11:08:48 2017

@author: jensj

https://projecteuler.net/problem=31

Coin sums
Problem 31
In England the currency is made up of pound, £, and pence, p, and there are eight coins in general circulation:

1p, 2p, 5p, 10p, 20p, 50p, £1 (100p) and £2 (200p).
It is possible to make £2 in the following way:

1×£1 + 1×50p + 2×20p + 1×5p + 1×2p + 3×1p
How many different ways can £2 be made using any number of coins?

1 = 1
1 + 0.5 = 3

"""

def f(a,b,c,d,e,f,g):
    return a*1 + b*0.5 + c*0.2 + d*0.1 + e*0.05 + f*0.02 + g*0.01

res = []

while True:
    if 2 == f(a,b,c,d,e,f,g):
        res.append([a,b,c,d,e,f,g])