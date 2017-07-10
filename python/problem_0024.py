# -*- coding: utf-8 -*-
"""
Created on Sat Jan 14 12:55:32 2017

@author: jensj

Lexicographic permutations
Problem 24
A permutation is an ordered arrangement of objects. 
For example, 3124 is one possible permutation of the digits 
1, 2, 3 and 4. If all of the permutations are listed numerically or
 alphabetically, we call it lexicographic order. The lexicographic 
 permutations of 0, 1 and 2 are:

012   021   102   120   201   210

What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?
"""

import itertools

def perm(enumerable):
    if len(enumerable) == 1:
        yield list(enumerable)
        return
    
    #print(enumerable)
    for idx in range(len(enumerable)):
        new_list = list(enumerable)
        del(new_list[idx])
        prefix = enumerable[idx]
        
        perm_res = list(perm(new_list))
        #print(prefix, new_list, perm_res)
        for sub in perm_res:
            #print(prefix, new_list, sub)
            yield list([prefix] + sub)
            
n = 1000000
generator = perm([0,1,2,3,4,5,6,7,8,9])
res = next(itertools.islice(generator, n - 1, n))
print("res", res)
print("res", "".join([str(x) for x in res]))