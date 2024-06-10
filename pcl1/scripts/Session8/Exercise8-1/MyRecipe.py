class MyRecipe:
    def __init__(self,calories, cooking_time):
        self.calories = calories
        self.cooking_time = cooking_time

    def cook(self):
        print(f"Cooking the dish takes about {self.cooking_time} time and contains {self.calories} calories")

# Creating five recipes
recipes = [
    MyRecipe(100,23),
    MyRecipe(500, 60),
    MyRecipe(350, 45),
    MyRecipe(150, 15),
    MyRecipe(400, 90)
]

[item.cook() for item in recipes]