# List 
fruits = ['apple', 'banana', 'cherry']
for fruit in fruits :
    print(fruit)

# Factorial 

n = int(input("Enter a number : "))
factorial = 1 
while n > 1 :
    factorial *= n
    n -= 1

print("Factorial = ", factorial)

# Dictionary 

students = {}
while True : 
    name = input("Enter student name (or ''stop' to finish): ")
    if name.lower() == 'stop' :
        break
    grade = input("Enter grade : ")
    students[name] = grade

print(students)

students['Himal']

# Max and min 

numbers = [3,5,1,2,9,8]

max_num = numbers[0]
min_num = numbers[0]

for num in numbers:
    if num > max_num : max_num = num
    if num < min_num : min_num = num

print("Max and min ", max_num , "  " , min_num)


# exercise 7,4 

def groupList(list , glength):
    bigList = []
    currentIndex = 0 
    noOfSmallList = len(list) / glength 
    for i in range(int(noOfSmallList)):
        smallList = []
        for j in range(glength):
            smallList.append(list[currentIndex])
            currentIndex += 1 
        bigList.append(smallList)
    return bigList
    
groupList(numbers,3)


def groupList(lst, glength):
    bigList = []
    currentIndex = 0
    while currentIndex < len(lst):
        smallList = lst[currentIndex:currentIndex + glength]
        bigList.append(smallList)
        currentIndex += glength
    return bigList

# Example usage
numbers = [1, 2, 3, 4, 5, 6]
print(groupList(numbers, 2))  # Output: [[1, 2], [3, 4], [5, 6]]
print(groupList(numbers, 3))  # Output: [[1, 2, 3], [4, 5, 6]]


# Python DIctionaries 

specialle = {'Bob Builder': 'IOT', 'Dora Explorer' : 'Interactive Media', 'Paw patrol': 'Data Engineering' }

specialle['Bob Builder'] = 'Data Engineering'

specialle['Bob Builder']

specialle['Farmerr Pickles'] = 'Climate Engineering'

specialle['Farmerr Pickles']

# Print Dora's specialization
print("Dora's specialization:", specialle['Dora Explorer'])

# Print all the keys
print("All keys in the dictionary:")
for key in specialle.keys():
    print(key)

'''
Using the imperative coding style, implement a function groupList that given a list (list) and a group
length (glength), returns a list of lists with length glength.
Example: testList = [1,2,3,4,5,6]
groupList(list, 2) gives [ [1, 2], [3, 4], [5,6] ] while groupList(list, 3) gives [ [1, 2, 3], [4, 5, 6] ]

'''

def groupList(lst, glength):
    bigList = []
    currentIndex = 0
    while currentIndex < len(lst):
        smallList = lst[currentIndex:currentIndex + glength]
        bigList.append(smallList)
        currentIndex += glength
    return bigList

# Example usage
numbers = [1, 2, 3, 4, 5, 6]
print(groupList(numbers, 2))  # Output: [[1, 2], [3, 4], [5, 6]]
print(groupList(numbers, 3))  # Output: [[1, 2, 3], [4, 5, 6]]


'''
Given the following list:
dkCities = ["Copenhagen", "Aarhus", "Aalborg", "Horsens",
"Odense"]
Define a Python function filterCities() to filter cities that starts with ‘Aa’.'''

def filterCities(cities):
    filteredCities = []
    for city in cities:
        if city.startswith("Aa"):
            filteredCities.append(city)
    return filteredCities

