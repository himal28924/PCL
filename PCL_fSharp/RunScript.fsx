
type CoffeeType =
    | Espresso
    | Americano
    | Latte

type TeaType =
    | Green
    | Black
    | White

type JuiceType =
    | OrangeJuice
    | AppleJuice
    | MangoJuice

type DrinkType =
    | Coffee of CoffeeType
    | Tea of TeaType
    | Juice of JuiceType

type Size =
    | Small
    | Medium
    | Large

type Drink = { DrinkType: DrinkType; Size: Size }



        
let pricesMap : Map<DrinkType * Size, float> =
    [
        (Coffee Espresso, Small), 12.0
        (Coffee Americano, Small), 18.0
        (Coffee Latte, Small), 20.5

        (Coffee Espresso, Medium), 14.0
        (Coffee Americano, Medium), 20.5
        (Coffee Latte, Medium), 22.0

        (Coffee Espresso, Large), 16.0
        (Coffee Americano, Large), 21.0
        (Coffee Latte, Large), 23.0

        (Tea Green, Small), 10.0
        (Tea Black, Small), 11.5
        (Tea White, Small), 20.0

        (Tea Green, Medium), 11.5
        (Tea Black, Medium), 13.0
        (Tea White, Medium), 22.5

        (Tea Green, Large), 12.0
        (Tea Black, Large), 15.5
        (Tea White, Large), 23.0

        (Juice OrangeJuice, Small), 19.0
        (Juice AppleJuice, Small), 18.5
        (Juice MangoJuice, Small), 20.0

        (Juice OrangeJuice, Medium), 19.5
        (Juice AppleJuice, Medium), 20.0
        (Juice MangoJuice, Medium), 22.5

        (Juice OrangeJuice, Large), 20.0
        (Juice AppleJuice, Large), 22.5
        (Juice MangoJuice, Large), 26.0
    ] |> Map.ofList
 
let getAfterVat beforeVat vatRate =
    beforeVat * (1.0 + vatRate)
       
let getDrinkPrice (drink: Drink) =
    let basePrice =pricesMap.[drink.DrinkType, drink.Size]
    let isCoffee = match drink.DrinkType with
                   | Coffee _ -> true
                   | _ -> false
    
    // Apply vat
    let vatPercentage = if isCoffee then 0.5 else 0.0
    let priceAfterVat = getAfterVat basePrice vatPercentage
    priceAfterVat

let drinkToString (drink: Drink) =
    match drink.Size, drink.DrinkType with
    | size, Coffee coffeeType ->
        $"%s{size.ToString()} %s{coffeeType.ToString()}"
    | size, Tea teaType ->
        $"%s{size.ToString()} %s{teaType.ToString()}"
    | size, Juice juiceType ->
        $"%s{size.ToString()} %s{juiceType.ToString()}"    
    

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


type QuantityLine = {Product: Product; Quantity: int}
type WeightLine = {Product: Product; Weight: float}

type OrderLine =
    | QuantityLine of QuantityLine
    | WeightLine of WeightLine
    
let orderLineToString orderLine =
    match orderLine with
    | QuantityLine {Product = product; Quantity = quantity} -> $"%d{quantity} - %s{productToString product}"
    | WeightLine {Product = product; Weight = weight} -> $"%.2f{weight}kg - %s{productToString product}"
 
type Order = {
    OrderLines: OrderLine list
}

let getTotalOrderPrice (order: Order) =
    let getOrderLinePrice (orderLine : OrderLine) =
        match orderLine with
        |QuantityLine {Product = product; Quantity = quantity} ->
            getProductPrice product * float quantity
        |WeightLine {Product = product; Weight = weight} ->
            getProductPrice product * float weight
    
    List.sumBy getOrderLinePrice order.OrderLines

let orderToString (order: Order) =
    match order.OrderLines with
    | [] -> "No items in the order"
    | [singleOrderLine] ->
        let totalPrice = getTotalOrderPrice order
        $"Please pay DKK%.2f{totalPrice} for your %s{orderLineToString singleOrderLine}. Thanks!"
    | _ ->
        let orderLineStrings = List.map orderLineToString order.OrderLines
        let totalPrice = getTotalOrderPrice order
        sprintf "Please pay DKK%.2f for your %s. Thanks!" totalPrice (String.concat " and " orderLineStrings)

let orderAgent: MailboxProcessor<Order> = 
    MailboxProcessor.Start(fun inbox ->
        let rec processOrder = async{
            let! order = inbox.Receive()
            let stringToPrint = orderToString order
            printfn $"%s{stringToPrint}"
            return! processOrder
        }
        processOrder 
    )


let placeOrder (order: Order) = 
    orderAgent.Post(order)
    
let placeOrders (orders: Order list) = 
    orders |> List.iter placeOrder

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