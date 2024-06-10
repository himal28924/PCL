let add(x : float) y = x + y    
let a = add 10.0 20.0

printfn "The sum of 10.0 and 20.0 is %f" a


// Mathc expression

match a with 
| 10.0 -> printfn "The value of a is 10.0"
| 20.0 -> printfn "The value of a is 20.0"

| _ -> printfn "The value of a is neither 10.0 nor 20.0"

// Convert factorial function 
let rec factorial n = 
    if n < 1 then 1
    else n * factorial (n - 1)
    
let fact = factorial 10
printfn "The factorial of 10 is %d" fact

// convert the factorial function to a match expression
let rec fact_PM n =
    match n with 
        |   0 | 1 -> 1
        |   _-> n * fact_PM(n-1)
        

// TUPLE 
let wishList = ("Iphone", 13000)

// Deconstruction 
let wishListAmnt = snd wishList

let wishListName = fst wishList