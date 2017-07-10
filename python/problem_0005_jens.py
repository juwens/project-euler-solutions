def smallest_multiple(max):
    dividers = range(max/2,max)
    i = 0
    while True:
        i += max        
        even_div = True
        for div in dividers:
            if i % div != 0:
                even_div = False
                break
        if even_div:
            return i

for i in range(2,21):
    print i, smallest_multiple(i)
