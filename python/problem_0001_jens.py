MAX = 1000
sum = 0
for i in xrange(1, MAX):
    if i % 3 == 0 or i % 5 == 0:
        sum += i
print sum
