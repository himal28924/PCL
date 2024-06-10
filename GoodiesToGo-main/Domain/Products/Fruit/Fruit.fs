module Domain.Products.Fruit.Fruit

type Fruit =
    | Apple
    | Banana
    | Orange
               
let pricesPerFruitType = 
    [ Apple, 2.99
      Banana, 1.99
      Orange, 1.59 ] |> Map.ofList

let getFruitPrice (fruit : Fruit) =
    pricesPerFruitType.[fruit] 