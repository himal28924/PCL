class Contact:
    def __init__(self, name, email):
        self.name = name
        self.email = email

    def __str__(self):
        return f"Name : {self.name} , email : {self.email}"


class AddressHolder:
    def __init__(self, street, post_code, city):
        self.street = street
        self.post_code = post_code
        self.city = city

    def __str__(self):
        return f"Address : {self.street},{self.post_code},{self.city}"


class Friend(Contact, AddressHolder):
    def __init__(self, name, email, street, post_code, city,phone):
        Contact.__init__(self, name, email)
        AddressHolder.__init__(self, street, post_code, city)
        self.phone = phone

    def __str__(self):
        return f"{Contact.__str__(self)} {AddressHolder.__str__(self)} , Phone : {self.phone}"


friend = Friend("Himal Sharma", "Himal28924@gmail.com", "lilli","8700","Horsens",12345678)
print(friend.__str__())


"""

>>> friend = Friend("Himal Sharma", "Himal28924@gmail.com", "lilli","8700","Horsens",12345678)
>>> print(friend.__str__())
Name : Himal Sharma , email : Himal28924@gmail.com Address : lilli,8700,Horsens , Phone : 12345678
>>>
"""