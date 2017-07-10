MAX = 100
sum_of_squares = sum([x**2 for x in range(1,MAX + 1)])
square_of_sum = sum(range(1,MAX + 1))**2
print sum_of_squares, square_of_sum, square_of_sum - sum_of_squares
