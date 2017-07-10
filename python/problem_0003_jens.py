rest = 600851475143
#rest = 2520
i = 2
pfactors = []
while rest != 1 and i <= rest:
    if rest % i == 0:
        pfactors.append(i)
        rest = rest / i
    i += 1
    #print i, rest, pfactors
print(pfactors, rest, i)
