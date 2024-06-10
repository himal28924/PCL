module Domain.Products.Food.Food

type Food =
    | Rice
    | Chicken
    | Fish
    | Pasta
    | Salad

let pricesPerKg =
    [ Rice, 19.99; Chicken, 24.99; Fish, 29.99; Pasta, 14.99; Salad, 9.99 ]
    |> Map.ofList


      
let getFoodPrice (food: Food) =
    pricesPerKg.[food] 
