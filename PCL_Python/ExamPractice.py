# Python 

'''
Question 7
Question 7a [ 5% ]
Given numLst= [1, 2, 3, 4, 5] we can compute the sum in an imperative way.
Write a Python program such that it uses imperative way to compute the sum of the list.
'''

numLst = [1, 2, 3, 4, 5]

sum = 0
for num in numLst:
    sum += num
print(sum)

'''
Using the imperative way of programming, check for even numbers given a user input:
Write a program, which repeatedly prompts the user for an integer.
If the integer is even, print the integer. If the integer is odd, don’t print anything. Print “Bye for
now!” and Exit the program if the user enters the integer 123.

'''

while True:
    num = int(input("Enter an integer: "))
    if num == 123:
        print("Bye for now!")
        break
    if num % 2 == 0:
        print(num)


'''
Question 8
Question 8a [ 5% ]
Given the following list:
data = [1, 2, 3, 4, 5]
Write a Python code that adds 10 to every element in the list using lambda and the map() function.
Include the resulting list as part of your solution.
'''

data = [1, 2, 3, 4, 5]
result = list(map(lambda x: x + 10, data))
print(result)

'''
Question 8b [ 5% ]
Using lambda and the filter() function, write a Python function to find even numbers
(printEvenNumbers) given a list of natural numbers:
naturalNumbers = [0,1,2,3,4,5,6,7,8,9]


'''

def printEvenNumbers(numbers):
    evenNumbers = list(filter(lambda x: x % 2 == 0, numbers))
    print(evenNumbers)

naturalNumbers = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]

printEvenNumbers(naturalNumbers)

'''
Question 9
Question 9a [ 5% ]
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
Question 9b [ 5% ]

Given the following list:
dkCities = ["Copenhagen", "Aarhus", "Aalborg", "Horsens",
"Odense"]

Define a Python function filterCities() to filter cities that starts with ‘Aa’.
'''

dkCities = ["Copenhagen", "Aarhus", "Aalborg", "Horsens", "Odense"]
filteredList = list(filter(lambda city : city.startswith("Aa"), dkCities))
print(filteredList)


'''
Question 10a [ 5% ]
Implement the following UML class diagram in Python

'''

from datetime import datetime

class CourseNote:
    def __init__(self, jotting, keywords):
        self.jotting = jotting
        self.creationDate = datetime.now()
        self.keywords = keywords

    def is_a_match(self, search_filter):
        return search_filter in self.jotting or search_filter in self.keywords

class Notebook:
    def __init__(self):
        self.courseNotes = []

    def addNote(self, jotting, keywords):
        note = CourseNote(jotting, keywords)
        self.courseNotes.append(note)

    def search(self, search_filter):
        return [note for note in self.courseNotes if note.is_a_match(search_filter)]

# Example usage:
notebook = Notebook()
notebook.addNote("Python OOP concepts", "class, object, inheritance")
notebook.addNote("Functional programming", "lambda, map, reduce")

search_results = notebook.search("class")
for note in search_results:
    print(f"Jotting: {note.jotting}, Date: {note.creationDate}, Keywords: {note.keywords}")


'''
Question 10b [ 5% ]
Implement the following UML class diagram in Python
'''
# Define the Singer class
class Singer:
    def sing(self):
        print("Singing a song")

# Define the SongWriter class
class SongWriter:
    def compose(self):
        print("Composing a song")

# Define the SingerSongwriter class that inherits from both Singer and SongWriter
class SingerSongwriter(Singer, SongWriter):
    def strum(self):
        print("Strumming the guitar")
    
    def actSensitive(self):
        print("Acting sensitive")

# Test the implementation
if __name__ == "__main__":
    # Create an instance of SingerSongwriter
    artist = SingerSongwriter()
    
    # Test all methods
    artist.sing()            # From Singer class
    artist.compose()         # From SongWriter class
    artist.strum()           # From SingerSongwriter class
    artist.actSensitive()    # From SingerSongwriter class
