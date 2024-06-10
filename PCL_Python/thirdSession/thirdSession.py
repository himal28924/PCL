'''
Pure Functions
A pure function is one that, given the same input, 
will always return the same output and does not have any side effects (does not alter any external state).
'''

def pure_sum(x,y):
    return x + y

# lambda expression 

lambda_add = lambda x, y : x + y


print(lambda_add(2,3))

# Recursion 

def factorial(n):
    if n == 0 : 
        return 1
    else :
        return n * (factorial(n-1))
    
print(factorial(5))

# Immutability 

immudata = ('Alfonsy', 123456, ['PME1','PCL1','ALI1'])

try:
    immudata[1] = 110220 # WIll give is error 
except TypeError as e:
    print(e    )

# Higher order function 

from functools import reduce 
'''
Higher-order functions can take other functions as arguments or return them as results.
'''

# Example of higher-order function map()
list_values = [2018, 2019, 2020, 2021, 2022, 2023]
add_one = list(map(lambda y: y + 1, list_values))
print(add_one)  # Output: [2019, 2020, 2021, 2022, 2023, 2024]


# Example of higher-order function filter()
lst2 = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
odd_num = list(filter(lambda n: n % 2 == 1, lst2))
print(odd_num)  # Output: [1, 3, 5, 7, 9]

# Example of higher-order function reduce()
vlst = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
summed_val = reduce(lambda n, m: n + m, vlst)
print(summed_val)  # Output: 45



# exercise 9.1 

numList  = [1,2,3,4,5]

def fun_list_sum(list):
    if not list: return 0
    else : 
        return list[0] + fun_list_sum(list[1::])


# Lambda function to sum a list using reduce
fun_list_sum_lambda = lambda lst: reduce(lambda x, y :x +y , lst )

print(fun_list_sum(numList))

# Test the function
print(fun_list_sum_lambda(numList))  # Output: 15


# 9.2 Recursion 

def factr(n):
    if n <= 1 :
        return 1
    else:
        return n * factr(n-1)
    
factr(5)

# 9.3 Higher - order lambda 

def print_even_num (numbers):
    even_num = list(filter(lambda x : x % 2 == 0, numbers))
    print (even_num)

natural_numbers = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]

print_even_num(natural_numbers)

'''
Given list sort it by year using lambda function
'''

gtg_sales = [('Coffee', 2018, 525.05),
 ('Juice', 2021, 526.03),
 ('Apple', 2020, 525.12),
 ('Green Tea', 2019, 525.02),
 ('Banana', 2022, 524.08)]

gtg_sales.sort(key = lambda x : x[1])

print(gtg_sales)

'''
9.5 – Recursion
(Sum series) Write a recursive function to compute the following series:
m(i) = 1/3 + 2/5 + 3/7 + 4/9 + 5/11 + 6/13 + ... + i/(2i + 1
Write a test program that displays m(i) for i 1, 2, ..., 10.
'''

def sum_series(i):
    if i == 1 : return 1/3
    else:
        return i/(2*i+1) + sum_series(i-1)
    
for i in range(1,11):
    print(sum_series(i))
    

