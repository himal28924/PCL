module Domain.Products.Drink.Drink

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
    
 
 // Using pattern matching -->   
// let getDrinkPrice (drink: Drink) =
//     match drink.DrinkType, drink.Size with
//
//     // For Coffee
//     | Coffee coffeeType, Small ->
//         match coffeeType with
//         | Espresso -> 12.0
//         | Americano -> 18.0
//         | Latte -> 20.5
//
//     | Coffee coffeeType, Medium ->
//         match coffeeType with
//         | Espresso -> 14.0
//         | Americano -> 20.5
//         | Latte -> 22.0
//
//     | Coffee coffeeType, Large ->
//         match coffeeType with
//         | Espresso -> 16.0
//         | Americano -> 21.0
//         | Latte -> 23.0
//
//     // For Tea
//     | Tea teaType, Small ->
//         match teaType with
//         | Green -> 10.0
//         | Black -> 11.5
//         | White -> 20.0
//
//     | Tea teaType, Medium ->
//         match teaType with
//         | Green -> 11.5
//         | Black -> 13.0
//         | White -> 22.5
//
//     | Tea teaType, Large ->
//         match teaType with
//         | Green -> 12.0
//         | Black -> 15.5
//         | White -> 23.0
//
//     // For Juice
//     | Juice juiceType, Small ->
//         match juiceType with
//         | OrangeJuice -> 19.0
//         | AppleJuice -> 18.5
//         | MangoJuice -> 20.0
//
//     | Juice juiceType, Medium ->
//         match juiceType with
//         | OrangeJuice -> 19.5
//         | AppleJuice -> 20.0
//         | MangoJuice -> 22.5
//
//     | Juice juiceType, Large ->
//         match juiceType with
//         | OrangeJuice -> 20.0
//         | AppleJuice -> 22.5
//         | MangoJuice -> 26.0
 