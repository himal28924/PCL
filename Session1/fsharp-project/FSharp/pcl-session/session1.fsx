// PCL 1 S24 Programming langauge and concept  - Session 1 

(*
  This is a comment
  This is a comment
  This is a comment
*)

/// to produce documentation XML Documentation 
printfn "This is FSharp"

let number10 = 10 
let str1 = "A nice day"

let number20 = 20
let addNumbers = number10 + number20 

// F# Syntax and examples 

let a = 10
let b = 20
// add 2 numbers
let sum = a + b 
// A function of integer 
let f x = 2 * x * x - 5 * x + 3 
let result = f (sum + 4 )

// F# example on Recursion 
// Compute the factorial of an integer recursively
let rec factorial x =
    if x <= 1 then 
        1
    else
        x * factorial(x - 1)

let fac: float = factorial 10 




// F# List Example 

let listA = [] // Empty List
let lst3 = [1;2;3] // List of Integers
