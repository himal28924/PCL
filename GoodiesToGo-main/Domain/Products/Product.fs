module Domain.Products.Product

open Domain.Products.Drink.Drink
open Domain.Products.Food.Food
open Domain.Products.Fruit.Fruit

type Product =
     |Drink of Drink
     |Food of Food
     |Fruit of Fruit
     
let getProductPrice product=
     match product with
     | Drink drink -> getDrinkPrice drink
     | Food food -> getFoodPrice food
     | Fruit fruit -> getFruitPrice fruit
     
let productToString product=
     match product with
     | Drink drink -> drinkToString drink;
     | Food food -> food.ToString();
     | Fruit fruit -> fruit.ToString();