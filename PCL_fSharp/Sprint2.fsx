open System

// Define the data types for drinks, food, and fruits
type CoffeeType =
    | Espresso
    | Americano
    | Latte
    | GTGSpecialCoffee


type GtgCupSize =
    | GtgDemi 
    | GtgShort
    | GtgTall

type GtgCoffeeDrink = {
    CoffeeType: CoffeeType
    CupSize: GtgCupSize
}


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
    | GTGSize of GtgCupSize

type Drink = { DrinkType: DrinkType; Size: Size }

type Food =
    | Rice
    | Chicken
    | Fish
    | Pasta
    | Salad

type Fruit =
    | Apple
    | Banana
    | Orange

type Product =
    | Drink of Drink
    | Food of Food
    | Fruit of Fruit

// Prices for drinks
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

        (Coffee GTGSpecialCoffee, GTGSize GtgDemi), 29.0
        (Coffee GTGSpecialCoffee, GTGSize GtgShort), 35.0
        (Coffee GTGSpecialCoffee, GTGSize GtgTall), 39.5


    ] |> Map.ofList



// Prices for food
let pricesPerKg =
    [ Rice, 19.99; Chicken, 24.99; Fish, 29.99; Pasta, 14.99; Salad, 9.99 ]
    |> Map.ofList

// Prices for fruits
let pricesPerFruitType = 
    [ Apple, 2.99
      Banana, 1.99
      Orange, 1.59 ] |> Map.ofList

// Function to get price of a drink
let getDrinkPrice (drink: Drink) =
    let basePrice = pricesMap.[drink.DrinkType, drink.Size]
    let isCoffee = match drink.DrinkType with
                   | Coffee _ -> true
                   | _ -> false
    let vatPercentage = if isCoffee then 0.25 else 0.0 // VAT percentage for coffee
    basePrice * (1.0 + vatPercentage)

// Function to get price of a food item
let getFoodPrice (food: Food) =
    pricesPerKg.[food]

// Function to get price of a fruit
let getFruitPrice (fruit : Fruit) =
    pricesPerFruitType.[fruit]

// Function to get price of a product
let getProductPrice product =
    match product with
    | Drink drink -> getDrinkPrice drink
    | Food food -> getFoodPrice food
    | Fruit fruit -> getFruitPrice fruit

// Function to convert a drink to string
let drinkToString (drink: Drink) =
    match drink.Size, drink.DrinkType with
    | size, Coffee coffeeType ->
        $"{size.ToString()} {coffeeType.ToString()}"
    | size, Tea teaType ->
        $"{size.ToString()} {teaType.ToString()}"
    | size, Juice juiceType ->
        $"{size.ToString()} {juiceType.ToString()}"

// Function to convert a product to string
let productToString product =
    match product with
    | Drink drink -> drinkToString drink
    | Food food -> food.ToString()
    | Fruit fruit -> fruit.ToString()

// Define the types for customers and payment methods
type Customer =
    | VIACustomer of string // Name of the customer
    | SOSUCustomer of string // Name of the customer

type PaymentType =
    | Cash
    | CreditCard
    | MobilePay

// Define a type for order messages
type OrderDrinkMsg =
    | OrderDrink of Drink * int // Drink item and quantity
    | LeaveComment of string

// Function to calculate VAT
let gtgVAT (n: int) (x: float) =
    x * (1.0 + (float n / 100.0))

// Define the agent to handle order messages
let gtgAgent: MailboxProcessor<OrderDrinkMsg> = 
    MailboxProcessor.Start(fun inbox ->
        let rec processOrder = async {
            let! msg = inbox.Receive()
            match msg with
            | OrderDrink (drink, qty) ->
                // Get the base price of the drink
                let basePrice = getDrinkPrice drink
                // Determine the VAT percentage based on drink type
                let vatPercentage = match drink.DrinkType with
                                    | Coffee _ -> 25 // Assuming 25% VAT for coffee
                                    | _ -> 0
                // Calculate the price including VAT
                let priceWithVat = gtgVAT vatPercentage basePrice
                let totalPrice = priceWithVat * float qty
                let drinkStr = drinkToString drink
                // Print the total price for the order
                printfn "Please pay DKK%.2f for your %d %s drinks. Thanks!" totalPrice qty drinkStr
            | LeaveComment comment ->
                // Acknowledge the comment
                printfn "Comment received: %s" comment
            return! processOrder
        }
        processOrder
    )

// Function to place an order
let placeOrder (orderMsg: OrderDrinkMsg) = 
    gtgAgent.Post(orderMsg)

// Define some sample drinks
let smallLatte = { DrinkType = Coffee(Latte); Size = Small }
let largeAmericano = { DrinkType = Coffee(Americano); Size = Large }

// Place some orders and leave a comment
placeOrder (OrderDrink (smallLatte, 2))
placeOrder (OrderDrink (largeAmericano, 1))
placeOrder (LeaveComment "This is a great service!")

// Expected output:
// Please pay DKK51.25 for your 2 Small Latte drinks. Thanks!
// Please pay DKK26.25 for your 1 Large Americano drink. Thanks!
// Comment received: This is a great service!

(*
This requires that you add the code to your GTG course project and include the results and
only the applicable code snippet for the question.
Supposing we were given a new requirement to expand our GTG course project to add new
coffee drink products. The new coffee drink product is a special coffee of three different cup
sizes, GtgDemi(9cl), GtgShort(24cl) and GtgTall(36cl)
*)


(*
i. Define the data type for the new coffee cup sizes, a new coffee record and the
corresponding price calculation function and include it in your GTG course project.
Include only the snippet for the data type and price calculation function as the answer for this
question.

*)


// lets try to order the new coffee drink product
let gtgSpecialCoffeeDemi = { CoffeeType = GTGSpecialCoffee; CupSize = GtgDemi }
let gtgSpecialCoffeeShort = { CoffeeType = GTGSpecialCoffee; CupSize = GtgShort }
let gtgSpecialCoffeeTall = { CoffeeType = GTGSpecialCoffee; CupSize = GtgTall }

// converting gtgSpecialCoffeeDemi to Drink 
let gtgSpecialCoffeeDemiDrink = { DrinkType = Coffee(GTGSpecialCoffee); Size = GTGSize GtgDemi }
let gtgSpecialCoffeeShortDrink = { DrinkType = Coffee(GTGSpecialCoffee); Size = GTGSize GtgShort }


placeOrder (OrderDrink (gtgSpecialCoffeeDemiDrink, 1))
placeOrder (OrderDrink (gtgSpecialCoffeeShortDrink, 2))


let gtgSpecialCoffeeTallDrink = { DrinkType = Coffee(GTGSpecialCoffee); Size = GTGSize GtgTall }

placeOrder (OrderDrink (gtgSpecialCoffeeTallDrink, 4))
