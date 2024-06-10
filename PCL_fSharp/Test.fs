module ViaCanteen.Test


open Domain.Products.Drink.Drink
open Domain.Products.Food.Food
open Domain.Products.Fruit.Fruit
open Domain.Products.Product

open Domain.Order.Order
open Domain.Order.OrderLine
open Domain.Order.OrderService



let smallLatte =
    { DrinkType = Coffee(Latte)
      Size = Small }

let largeAmericano =
    { DrinkType = Coffee(Americano)
      Size = Large }

let banana = Banana
let rice = Rice
let apple = Apple





let product1 = Drink smallLatte
let product2 = Drink largeAmericano
let product3 = Food rice
let product4 = Fruit banana
let product5 = Fruit apple


let orderLine1 = QuantityLine { Product = product1; Quantity = 1 }
let orderLine2 = QuantityLine { Product = product2; Quantity = 2}

let orderLine3 = WeightLine { Product = product3; Weight = 0.8 }
let orderLine4 = QuantityLine { Product = product4; Quantity = 3 }
let orderLine5 = QuantityLine { Product = product5; Quantity = 4 }


let order1 = { OrderLines = [orderLine1; orderLine2] }
let order2 = { OrderLines = [orderLine3; orderLine4; orderLine5] }

let order3 = {OrderLines = [orderLine1]}


let orders = [order1; order2; order3]
placeOrders orders




// printfn "Hello world!"