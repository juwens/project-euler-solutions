MAX = 4 * 10**6

terms = [1,2]
while (terms[-1] + terms[-2]) < MAX:
    terms.append(terms[-1] + terms[-2])

even_sum = 0
for term in terms:
    if term % 2 == 0:
        even_sum += term

print even_sum
print terms
    
