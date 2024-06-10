# Himal Sharma 308831 Python Handin 

# Questions 7 - 10 Multi-paradigm programming in Python

# Question 7a

# Imperative way of programming (I)
def sumPositiveNumbersImperative(numbers):
    sum = 0
    for num in numbers:
        if num > 0:
            sum += num
    return sum

# Functional way of programming (II)

def sumPositiveNumbersFunctional(numbers):
    return sum(filter(lambda x: x > 0, numbers))

# Test the functions
numbers = [2, -3, 4, -5, 6]
print("Sum using impreative ", sumPositiveNumbersImperative(numbers))
print("Sum using functional ", sumPositiveNumbersFunctional(numbers))
''' Question 7a Output
>>> print("Sum using impreative ", sumPositiveNumbersImperative(numbers))
Sum using impreative  12
>>> print("Sum using functional ", sumPositiveNumbersFunctional(numbers))
Sum using functional  12
'''

# Question 7b
def printEvenNumbers(numbers):
    evenNumbers = list(filter(lambda x: x % 2 == 0, numbers))
    print(evenNumbers)

testEvenNumbers = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]

printEvenNumbers(testEvenNumbers)
'''
7 b Output
>>> printEvenNumbers(testEvenNumbers)
[0, 2, 4, 6, 8]
'''

# Question 8

# Question 8a
def group_List(lst, gl):
    bigList = []
    currentIndex = 0
    while currentIndex < len(lst):
        smallList = lst[currentIndex:currentIndex + gl]
        bigList.append(smallList)
        currentIndex += gl
    return bigList

# testing the function
testGroupListnumbers = [1, 2, 3, 4, 5, 6]

print(group_List(testGroupListnumbers, 2))
print(group_List(testGroupListnumbers, 3))

'''
8a Output
>>> print(group_List(testGroupListnumbers, 2))
[[1, 2], [3, 4], [5, 6]]
>>> print(group_List(testGroupListnumbers, 3))
[[1, 2, 3], [4, 5, 6]]

'''

# 8 b 

def averageExerciseTime():
    enteredMinutes = []
    while True:
        minutes = int(input("Enter minutes (0 to finish): "))
        if minutes == 0:
            break
        enteredMinutes.append(minutes)

    totalMinutes = sum(enteredMinutes)
    averageTime = totalMinutes / len(enteredMinutes) 
    averageMinutes = int(averageTime)  
    averageSeconds = int((averageTime - averageMinutes) * 60)  
    print(f"Average exercise time: {averageMinutes} minutes and {averageSeconds} seconds")



# Test the function
averageExerciseTime()
'''
 8b output 

 >>> averageExerciseTime()
Enter minutes (0 to finish): 30
Enter minutes (0 to finish): 20
Enter minutes (0 to finish): 60
Enter minutes (0 to finish): 15
Enter minutes (0 to finish): 0
Average exercise time: 31 minutes and 15 seconds

we have different second from question cause i actually converted the remainder
'''

# Question 9

# product, type, quantity, unit price
gtg_data2 = [('Coffee', 'Drink', 1015, 15.05),
('Juice', 'Drink', 800, 6.05),
('Tuna Mini Sandwiches', 'Food', 800, 6.05),
('Apple', 'Fruit', 925, 5.15),
('Tuna Mini Sandwiches', 'Food', 800, 6.05),
('Green Tea', 'Drink', 630, 12.05),
('Veggie Sandwiches Mix', 'Food', 800, 6.05),
('Banana', 'Fruit', 915, 3.10)]


#Question 9a
def filterDrinkProducts(data):
    return list(filter(lambda x: x[1] == 'Drink', data))

# Test the function
print(filterDrinkProducts(gtg_data2))
'''
9a Output
>>> print(filterDrinkProducts(gtg_data2))
[('Coffee', 'Drink', 1015, 15.05), 
('Juice', 'Drink', 800, 6.05), 
('Green Tea', 'Drink', 630, 12.05)]

'''

# Question 9b
def calculateDrinkSubtotal(data):
    drinks = filterDrinkProducts(data)
    drinkSubtotal = list(map(lambda x: (x[0], x[2] * x[3]), drinks))
    totalAmount = sum(map(lambda x: x[1], drinkSubtotal))
    return drinkSubtotal, totalAmount

# Test the function
print(calculateDrinkSubtotal(gtg_data2))

'''
9b Output
>>> print(calculateDrinkSubtotal(gtg_data2))
([('Coffee', 15275.75), ('Juice', 4840.0), ('Green Tea', 7591.5)], 27707.25)
'''

# Question 10

# Question 10a
# assuming for now we will ask receiption to enter the detail 
def calculateTaxAndDiscount():
    productType = input("Enter the name of the product: ")
    cost = float(input("Enter the cost of the product: "))
    isViaCustomer = input("Are you a VIA Customer? (yes/no): ").lower() == 'yes'
    gtgVAT = 0.25 # only for coffee thats what we have in our project
    discountRate = 0.05

    if isViaCustomer:
        discount = cost * discountRate
    else:
        discount = 0

    if productType.lower() == 'coffee':
        tax = cost * gtgVAT
    else:
        tax = 0

    grandTotal = cost + tax - discount

    print(f"Tax: {tax:.2f}")
    print(f"Discount: {discount:.2f}")
    print(f"Grand total: {grandTotal:.2f}")

    return tax, discount, grandTotal

# Test the function
calculateTaxAndDiscount()

'''
10 a Output:: 
Via customer :

>>> calculateTaxAndDiscount()
Enter the name of the product: coffee
Enter the cost of the product: 25
Are you a VIA Customer? (yes/no): yes
Tax: 6.25
Discount: 1.25
Grand total: 30.00
(6.25, 1.25, 30.0)

For non-VIA customer
>>> calculateTaxAndDiscount()
Enter the name of the product: coffee
Enter the cost of the product: 25
Are you a VIA Customer? (yes/no): no
Tax: 6.25
Discount: 0.00
Grand total: 31.25
(6.25, 0, 31.25)
'''

# Question 10b

class Property:
    def __init__(self, square_meter, num_bedrooms):
        self.square_meter = square_meter
        self.num_bedrooms = num_bedrooms

    def show_detail(self):
        print(f"Detail of property  Square Meter: {self.square_meter} Number of Bedrooms: {self.num_bedrooms}")


class House(Property):
    def __init__(self, square_meter, num_bedrooms, garage, fenced, num_floors):
        super().__init__(square_meter, num_bedrooms)
        self.garage = garage
        self.fenced = fenced
        self.num_floors = num_floors

    def show_detail(self):
        super().show_detail()
        print(f"Garage part : {self.garage} fenced: {self.fenced} no. of floors= {self.num_floors}")

    def __str__(self):
        return f"Bedroom = {self.num_bedrooms} , {self.square_meter} sq meters, garag =  {self.garage}, fence =  {self.fenced}, floor =  {self.num_floors}"


class Rental:
    def __init__(self, furnished, rent):
        self.furnished = furnished
        self.rent = rent

    def show_detail(self):
        print(f"Furnished =  {self.furnished} -- Rent =  {self.rent}")


class HouseRental(House, Rental):
    def __init__(self, square_meter, num_bedrooms, garage, fenced, num_floors, furnished, rent):
        House.__init__(self, square_meter, num_bedrooms, garage, fenced, num_floors)
        Rental.__init__(self, furnished, rent)

    def show_detail(self):
        House.show_detail(self)
        Rental.show_detail(self)


# Creating objects of all the classes with examples
property_obj = Property(49, 1)
house_obj = House(200, 4, "Yes", "no", 3)
rental_obj = Rental("Yes", 4589)
house_rental_obj = HouseRental(250, 5, "Ys", "No", 3, "Yes", 15000)

print("Property Object Detail:")
property_obj.show_detail()
'''
>>> property_obj.show_detail()
Detail of property  Square Meter: 49 Number of Bedrooms: 1
'''

print("House Object Detail:")
house_obj.show_detail()
'''
>>> house_obj.show_detail()
Detail of property  Square Meter: 200 Number of Bedrooms: 4
Garage part : Yes fenced: no no. of floors= 3
'''

print("Rental Object Detail:")
rental_obj.show_detail()
'''Rental Object Detail:
>>> rental_obj.show_detail()
Furnished =  Yes -- Rent =  4589'''

print("HouseRental Object Detail:")
house_rental_obj.show_detail()
'''
Detail of property  Square Meter: 250 Number of Bedrooms: 5
Garage part : Ys fenced: No no. of floors= 3
Furnished =  Yes -- Rent =  15000
'''
