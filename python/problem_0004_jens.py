def is_palindrom(i):
    s = str(i)
    for pos in xrange(len(s)/2):
        if s[pos] != s[-1 - pos]:
            return False
    return True

if __name__ ==  "__main__":
    numbers = range(100, 999)

    largest_pal = 0
    for a in numbers:
        for b in numbers:
            prod = a * b
            if is_palindrom(prod) and prod > largest_pal:
                largest_pal = prod
                print largest_pal, a, b
