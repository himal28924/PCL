// Himal Sharma 30881  Handin F# 

// Questions 1 - 6 Multi-paradigm programming in F#

// 1
// 1 a -------

let funqy num1 num2 = num1 + num2
let gunqy(num1, num2) = num1 + num2

// 1. i ---

// funqy 5 gunqy(3,4) # ERROR 
// Error: funqy takes two arguments but to show that this are two argument we need parentheses to group the arguments. 
// So this will raise a syntax error.

// 1 . ii---

//  we can put parentheses around 5 and gunqy(3,4) to fix the problem. 
// we can also put comma between this two and it will be another function that can be called 

funqy 5 (gunqy(3,4))

(*OUTPUT 1 ii: 
- funqy 5 (gunqy(3,4));;
val it: int = 12

- the output was 12 as expected 
*)


// 1 b 

let funqy23_5 n = 
    if (n % 2 = 0 || n % 3 = 0 )&& n % 5 <> 0 then true
    else false

// Testing
printfn "when dividing by 24 :  %b" (funqy23_5 24)
printfn "when dividing by 27 : %b" (funqy23_5 27)
printfn "when dividing by 29 : %b" (funqy23_5 29)
printfn "when dividing by 30 : %b" (funqy23_5 30)

(*OUTPUT 1b :
when dividing by 24 :  true
when dividing by 27 : true
when dividing by 29 : false
when dividing by 30 : false
val it: unit = ()
*)


// 2--------
// 2 a---

let countNumOfVowels (str : string) =
    let charList = List.ofSeq str
    let accFunc (As, Es, Is, Os, Us) letter =
        match letter with
        | 'a' | 'A' -> (As + 1, Es, Is, Os, Us)
        | 'e' | 'E' -> (As, Es + 1, Is, Os, Us)
        | 'i' | 'I' -> (As, Es, Is + 1, Os, Us)
        | 'o' | 'O' -> (As, Es, Is, Os + 1, Us)
        | 'u' | 'U' -> (As, Es, Is, Os, Us + 1)
        | _ -> (As, Es, Is, Os, Us)
    List.fold accFunc (0, 0, 0, 0, 0) charList

// Testing the function
let testStringForVowel = "Higher-order functions can take and return functions of any order"
let numberOfVowels = countNumOfVowels testStringForVowel
printfn "Vowel counts: %A" numberOfVowels

(**OUTPUT of 2a:
val testStringForVowel: string =                                                      
  "Higher-order functions can take and return functions of any order"
val numberOfVowels: int * int * int * int * int = (4, 5, 3, 5, 3)                     
> printfn "Vowel counts: %A" numberOfVowels;;

Vowel counts: (4, 5, 3, 5, 3)                                                         
val it: unit = ()  

**)

// 2 b------

let replicateNtimes n str =
    if n < 0 then
        failwith "You cannot input a negative number "
    else
        let rec replicate n str acc =
            match n with
            | 0 -> acc
            | _ -> replicate (n - 1) str (acc + str)
        replicate n str ""

// Testing the function
let testReplicate1 = replicateNtimes 3 "Fun"
(** Output :
- let testReplicate1 = replicateNtimes 3 "Fun";;
val testReplicate1: string = "FunFunFun"
**)

let testReplicate2 = replicateNtimes 0 "EMPTY"
(** Output :
- let testReplicate2 = replicateNtimes 0 "EMPTY";;
val testReplicate2: string = ""
**)

// Testing our failwith 
try
    printfn "%s" (replicateNtimes -3 "EMPTY")
with
    | ex -> printfn "%s" ex.Message
    
(** Output :
-You cannot input a negative number                                                                                                                                                      
val it: unit = ()     
**)


// 3--------

// 3 a-----

type Variant =
    | Num of int
    | Text of string
    | Empty

let printVariant variant =
    match variant with
    | Num n -> printfn "Number value : %d" n
    | Text t -> printfn "Text is : %s" t
    | Empty -> printfn "Empty"


// Testing the function
let variant1 = Num 5
let variant2 = Text "Himal"
let variant3 = Empty

printVariant variant1
printVariant variant2
printVariant variant3

(** OUTPUT of 3 a:
Number value : 5                                                                      
Text is : Himal                                                                       
Empty                                                                                 
val it: unit = ()    
**)


// 3 b-------
type Expr = 
    Num of int
    | Plus of Expr*Expr
    | Times of Expr*Expr
    | Neg of Expr

//  3b i was thinking in this way first we multiply( 6 * 10) and add it to (25 * -2) BADMAs rule
let exprValue = Plus(Times(Num 6, Num 10), Times(Num 25, Neg(Num 2)))
exprValue

(*
Output::                                                                                
> exprValue;;                                                                         
val it: Expr = Plus (Times (Num 6, Num 10), Times (Num 25, Neg (Num 2)))
*)

// 3 b ii-------

// Fixing the issue
let rec f = function
    | Num(n) -> n
    | Plus(x,Neg(y)) -> f(x) - f(y)
    | Plus(x,y) -> f(x) + f(y)
    | Times(x,y) -> f(x) * f(y)
    | Neg(x) -> -f(x)

// Testing the function
let result = f exprValue
printfn "Result of the expression: %d" result

(*OUTPUT of 3 b ii:
Result of the expression: 10                                                          
val it: unit = ()        
*)


// 4 -----

// 4 a-----

(*
Declare a function trixtrans that acts upon lists of lists and transforms the lists as shown
in the figure below such that:
trixtrans [[1; 2; 3]; [4; 5; 6]; [7; 8; 9]] gives [[1; 4; 7]; [2; 5; 8]; [3; 6; 9]]
*)

let trixtrans matrix =
    if matrix = [] then []
    else
        let firstRow = List.head matrix
        let numOfRows = List.length matrix
        let numOfCols = List.length firstRow
        [for colIndex in 0 .. numOfCols - 1 ->
            [for rowIndex in 0 .. numOfRows - 1 -> (matrix.[rowIndex]).[colIndex]]]

// Example usage
let resultOfMatrix = trixtrans [[1; 2; 3]; [4; 5; 6]; [7; 8; 9]]
printfn "%A" resultOfMatrix

(*OUTPUT of 4 a:
val trixtrans: matrix: 'a list list -> 'a list list when 'a: equality                 

- let resultOfMatrix = trixtrans [[1; 2; 3]; [4; 5; 6]; [7; 8; 9]]                   
- printfn "%A" resultOfMatrix;;                                                       
RESULT : 
[[1; 4; 7]; [2; 5; 8]; [3; 6; 9]]                                                     

val it: unit = ()
*)



// 4 b---
open System.IO
let pclxms24 path =
    Directory.EnumerateFiles(path, "*.fs*", SearchOption.AllDirectories)
    |> Seq.toList


// 4 b i---
pclxms24 (".")


(*
- pclxms24 (".");;  

RESULT:
This function takes path as an argumnent and return a list of all the files in 
the directory including in the subdirectoru . 
SInce we are check with .fs it will only include file with .fs/.fsx / fsproj  extension.

so now calling the function  with path "." 
it will search in our current dirrectory and return the list of all files that 
matches the extension .fs* and similar to that in the subdirectories.

*)


// 4 b ii----
let countNoOf_FS_Files = pclxms24 (".") |> List.length
printfn "Number of files: %d" countNoOf_FS_Files

(*OUTPUT of 4 b ii:
this will change based on the number of files in the directory. 
- let countNoOf_FS_Files = pclxms24 (".") |> List.length                                                                                                                                
- printfn "Number of files: %d" countNoOf_FS_Files;; 

Number of files: 20                     

val countNoOf_FS_Files: int = 20                                                                                                                                                        
val it: unit = ()        
*)

// 5-----

// 5a -----
(*
Consider the following type definitions to model the Customer and Order part of GTG course
project including a list of orders:
*)

type Customer =
    | VIACustomer
    | SOSUCustomer

type Order = {
    OrderID : string
    CustomerID : string
    Amount : float
    Origin : Customer
}

let orders = [
    {OrderID="22401"; CustomerID="1101"; Amount = 245.00; Origin = Customer.VIACustomer}
    {OrderID="22402"; CustomerID="3302"; Amount=245.00; Origin = Customer.VIACustomer}
    {OrderID="22403"; CustomerID="2201"; Amount=245.00; Origin = Customer.SOSUCustomer}
    {OrderID="22404"; CustomerID="1102"; Amount= 255.00; Origin = Customer.VIACustomer}
    {OrderID="22405"; CustomerID="2202"; Amount = 245.00; Origin = Customer.SOSUCustomer}
    {OrderID="22406"; CustomerID="1103"; Amount=500.00; Origin = Customer.VIACustomer}]


// 5 a i -----
(*
Declare an F# function that takes the list of orders and prints out orders originating from
VIACustomer
*)

let printVIACustomerOrders orders =
    orders
    |> List.filter (fun order -> order.Origin = Customer.VIACustomer)
    |> List.iter (fun order -> printfn "Order from VIA Cusotmer  -> OrderID: %s, CustomerID: %s, Amount: %f" order.OrderID order.CustomerID order.Amount)

// testing the function 
printVIACustomerOrders orders

(*OUTPUT of 5 a i:
    > printVIACustomerOrders orders;;                                                     
    Order from VIA Cusotmer  -> OrderID: 22401, CustomerID: 1101, Amount: 245.000000      
    Order from VIA Cusotmer  -> OrderID: 22402, CustomerID: 3302, Amount: 245.000000      
    Order from VIA Cusotmer  -> OrderID: 22404, CustomerID: 1102, Amount: 255.000000      
    Order from VIA Cusotmer  -> OrderID: 22406, CustomerID: 1103, Amount: 500.000000      
    val it: unit = ()   
*)

// 5 a ii------

let totalAmountFromViaOrder orders = 
    orders
    |> List.filter (fun order -> order.Origin = Customer.VIACustomer)
    |> List.sumBy (fun order -> order.Amount)

// Testing the function
let totalAmountFromVIa = totalAmountFromViaOrder orders
printfn "Total amount from VIA customers: %f" totalAmountFromVIa

(*OUTPUT of 5 a ii:
- let totalAmountFromVIa = totalAmountFromViaOrder orders
- printfn "Total amount from VIA customers: %f" totalAmountFromVIa;;

RESULT : 
Total amount from VIA customers: 1245.000000

val totalAmountFromVIa: float = 1245.0
val it: unit = ()
*)

// 5 b --------

let getLunch (customer, foodChoice) =
    match foodChoice with
    | "veggies" | "fish" | "chicken" -> sprintf "%s doesn't want red meat" customer
    | _ -> sprintf "%s wants 'emmm delicious %s" customer foodChoice

// Testing the function
let lunchChoice1 = ("Himal", "chicken")
let lunchChoice2 = ("John Cena", "bird")

printfn "%s" (getLunch lunchChoice1)
printfn "%s" (getLunch lunchChoice2)

(*OUTPUT of 5 b:
> printfn "%s" (getLunch lunchChoice1)                                                
- printfn "%s" (getLunch lunchChoice2);;       

Himal doesn't want red meat                                                           
John Cena wants 'emmm delicious bird                                                  

val it: unit = () 
*)  


// 6-----

// 6 a -------
// Defining the data and record types for the GTG coffee project
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

type DrinkType =
    | Coffee of CoffeeType
//    | Tea of TeaType  ------ Not needed for our part 
//    | Juice of JuiceType

type Size =
    | Small
    | Medium
    | Large
    | GTGSize of GtgCupSize // Adding GTGSize to the Size type
    // This will make it so easier since we can now use GTGSize in the Size type
    // and our method will not need to be changed. 


type Drink = { DrinkType: DrinkType; Size: Size }

type Product =
    | Drink of Drink
  //  | Food of Food
   // | Fruit of Fruit

// part of price map of drink NOW when we add out new coffe and size we can add it to the map

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

        (Coffee GTGSpecialCoffee, GTGSize GtgDemi), 29.0
        (Coffee GTGSpecialCoffee, GTGSize GtgShort), 35.0
        (Coffee GTGSpecialCoffee, GTGSize GtgTall), 39.5
    ] |> Map.ofList


// Function to get price of a drink
// The below methof will work for all the drinks and sizes 
//since we have added GTGSize to the Size type
// and the map has been updated to include the new coffee type and size
let getDrinkPrice (drink: Drink) =
    let basePrice = pricesMap.[drink.DrinkType, drink.Size]
    let isCoffee = match drink.DrinkType with
                   | Coffee _ -> true
                   | _ -> false // this suggestion is not needed since we are only dealing with coffee in this example but in our actual we have more 
    let vatPercentage = if isCoffee then 0.25 else 0.0 // VAT percentage for coffee
    basePrice * (1.0 + vatPercentage)

// if we want we can also use this function to get the price of the GTG coffe from prodcut 
// Function to get price of a product  in this way we can also use getProductPrice to get the price of the GTG coffee
let getProductPrice product =
    match product with
        | Drink drink -> getDrinkPrice drink
    //| Food food -> getFoodPrice food.
    //| Fruit fruit -> getFruitPrice fruit


// now lets test the function with one normal coffee and one GTG coffee 
let largeAmericano = { DrinkType = Coffee(Americano); Size = Large }

// This is how we place order same as our hand in 

// placeOrder (OrderDrink (largeAmericano, 1))

(* OUTPUT FOR Large Americano:
# 218 @"e:\Semester7\PCL\PCL_fSharp\Sprint2.fsx"                                    
- placeOrder (OrderDrink (largeAmericano, 1))                                         
- ;;                                                                                  
val it: unit = ()                                                                     
                                                                                      
> Please pay DKK32.81 for your 1 Large Americano drinks. Thanks!  

*)

let gtgSpecialCoffeeTallDrink = { DrinkType = Coffee(GTGSpecialCoffee); Size = GTGSize GtgTall }

// This method will order 4 GTG special coffee tall drinks
// placeOrder (OrderDrink (gtgSpecialCoffeeTallDrink, 4))



(*

# 258 @"e:\Semester7\PCL\PCL_fSharp\Sprint2.fsx"                                                                                                                                                                                                                           
- let gtgSpecialCoffeeTallDrink = { DrinkType = Coffee(GTGSpecialCoffee); Size = GTGSize GtgTall }                                                                                                                                                                                                                                                                                                                                                                                                                                            
val gtgSpecialCoffeeTallDrink: Drink = { DrinkType = Coffee GTGSpecialCoffee
                                         Size = GTGSize GtgTall }

                RESULT :                          
- placeOrder (OrderDrink (gtgSpecialCoffeeTallDrink, 4));;
Please pay DKKval246.88 for your 4 GTGSize GtgTall GTGSpecialCoffee drinks. Thanks!
 it: unit = ()

// IN this way we can use the same function to get the price of the GTG coffee as well. 

NO NEED TO MOPDIFY THE FUNCTION
*)



