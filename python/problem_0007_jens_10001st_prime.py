import math
PRIME_TO_FIND = 1000001
def is_prime(number):
    global primes
    try:
        number_sqrt = math.sqrt(number)
    except:
        print number
        exit()
    for i in primes:
        if i > number_sqrt:
            return True
        elif number % i == 0:
            return False
    return True

primes = [2,3]

i = 1
to_check = (5,7)
while len(primes) < PRIME_TO_FIND:
    to_check = ((i * 6) - 1, (i * 6) + 1)
    i += 1

    for j in to_check:
        #print "checking", j
        if is_prime(j):
            #print "prime", j
            primes.append(j)
            if len(primes) % 10000 == 0 or len(primes) == 10001:
                print "is prime:", j, "nr:", len(primes)

