'''
Create a class Person with attributes for first name, last name, and age. Include methods to display full name and check if the person is an adult.
'''

class Person :
    def __init__(self,first_name,last_name,age):
        self.first_name = first_name
        self.last_name = last_name
        self.age = age
    
    def display_name(self):
        return f"{self.first_name} {self.last_name}"
    
    def is_adult(self):
        return self.age >= 18 
    
    # Example usage
person = Person("John", "Doe", 20)
print(person.display_name())  # Output: John Doe
print(person.is_adult())   # Output: True


# Exercise 2: Implement Inheritance

'''
Create a class Employee that inherits from Person and adds an attribute for the job title. Override the full_name method to include the job title.
'''

class Empployee(Person) : 
    def __init__(self,first_name,last_name,age,job_title) :
        super().__init__(first_name,last_name,age)
        self.job_title = job_title

    def display_name(self):
        return f"{self.first_name} {self.last_name} {self.job_title}"
    
# Example usage
employee = Empployee("Jane", "Doe", 30, "Software Engineer")
print(employee.display_name())  # Output: Jane Doe, Software Engineer


'''
Exercise 3: Use Polymorphism
Create a base class Shape with a method area. Create two derived classes Rectangle and Circle that override the area method.
'''

import math

class Shape:
    def area(self):
        pass

class Rectangle(Shape):
    def __init__(self,width,length):
        self.width = width
        self.length = length
    
    def area(self):
        return self.width * self.length
    
class Circle(Shape):
    def __init__(self,radius):
        self.radius = radius
    
    def area(self):
        return math.pi * self.radius **2

# Example usage
shapes = [Rectangle(3, 4), Circle(5)]
for shape in shapes:
    print(shape.area())

'''
    Exercise 4: Multiple Inheritance
Create two base classes A and B with methods foo and bar. Create a derived class C that inherits from both and implements its own method baz.
'''

class A:
    def foo(self):
        print("A's foo")

class B:
    def bar(self):
        print("B's bar")

class C(A, B):
    def baz(self):
        print("C's baz")

# Example usage
c = C()
c.foo()  # Output: A's foo
c.bar()  # Output: B's bar
c.baz()  # Output: C's baz

#08Exercises-PCL1.pdf

# 8.1 Classes and Objects

'''
Python Create a class called MyRecipewith two fields caloriesand cooking_time. 
Add a cook() function to simulate cooking by just printing out a message. 
Create the corresponding object and print out five of your favourite recipes.
'''
# 7,2

class Contact:
    def __init__(self, name, email):
        self.name = name
        self.email = email

    def __str__(self):
        return f"Name: {self.name}, Email: {self.email}"

class AddressHolder:
    def __init__(self, street, post_code, city):
        self.street = street
        self.post_code = post_code
        self.city = city

    def __str__(self):
        return f"Address: {self.street}, Post Code: {self.post_code}, City: {self.city}"

class Friend(Contact, AddressHolder):
    def __init__(self, name, email, street, post_code, city, phone):
        Contact.__init__(self, name, email)
        AddressHolder.__init__(self, street, post_code, city)
        self.phone = phone

    def __str__(self):
        contact_info = Contact.__str__(self)
        address_info = AddressHolder.__str__(self)
        return f"{contact_info}, {address_info}, Phone: {self.phone}"

# Example usage
def main():
    friend = Friend("John Doe", "john@example.com", "123 Main St", 12345, "Springfield", "555-1234")
    print(friend)

if __name__ == "__main__":
    main()




# 7,3

from abc import ABC, abstractmethod

# Abstract Base Class
class Fish(ABC):
    @abstractmethod
    def eat(self):
        pass
    
    @abstractmethod
    def swim(self):
        pass

# Shark Class
class Shark(Fish):
    def __init__(self, name, place_found):
        self.name = name
        self.place_found = place_found
    
    def eat(self):
        print(f"{self.name} the shark is eating fish.")
    
    def swim(self):
        print(f"{self.name} the shark swims swiftly in the {self.place_found}.")

# Dolphin Class
class Dolphin(Fish):
    def __init__(self, name):
        self.name = name
    
    def eat(self):
        print(f"{self.name} the dolphin is eating small fish and squid.")
    
    def swim(self):
        print(f"{self.name} the dolphin swims gracefully in the ocean.")

# Example usage
def main():
    shark = Shark("Great White", "Atlantic Ocean")
    dolphin = Dolphin("Flipper")

    # Using polymorphism to call methods
    for fish in [shark, dolphin]:
        fish.eat()
        fish.swim()

if __name__ == "__main__":
    main()




## Exercise 7.4 Abstraction -- also known as 8,4

from abc import ABC , abstractmethod

class CaffeineDrink(ABC):
    def __init__(self,description,size):
        self.description = description
        self.size = size
    
    def drink_info(self):        
        return f"{self.size} {self.description}"

    @abstractmethod
    def get_price(self):
        pass

class Coffee(CaffeineDrink):
    def __init__(self, description, size,quantity,tax_rate):
        super().__init__(description, size)
        self.quantity = quantity
        self.size = size
        self.tax_rate = tax_rate
    
    def get_price(self):
        base_price= 3.00
        total_price = (base_price*self.quantity)*(1+self.tax_rate)
        return total_price

# Tea Class
class Tea(CaffeineDrink):
    def __init__(self, description, size, quantity):
        super().__init__(description, size)
        self.quantity = quantity

    def get_price(self):
        base_price = 2.50  # example base price
        total_price = base_price * self.quantity
        return total_price

# Example usage
coffee = Coffee("Coffee", "Large", 2, 0.07)
tea = Tea("Tea", "Medium", 3)

print(coffee.drink_info())  # Output: Large Coffee
print("Total price for coffee:", coffee.get_price())  # Output: Total price for coffee: 6.42

print(tea.drink_info())  # Output: Medium Tea
print("Total price for tea:", tea.get_price())  # Output: Total price for tea: 7.5