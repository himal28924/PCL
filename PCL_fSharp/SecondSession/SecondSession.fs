let classId = "IT-PCL1_S24"
printfn "Length : %d" classId.Length

printfn "Character at index 7 : %c" classId.[7] 

let isTrue = true
let isFalse = false 

// Conditional expresssion 
// if - then - else 

let absValueOfX x = 
    if x < 0 then -x 
    else x

absValueOfX -3

let add (x:float) y = x + y
let sum = add 5 10


// Pattern Matching 

let describerNumber x = 
    match x with 
    | 1 -> "One"
    | 2 -> "Two"
    | _ -> "Other"

describerNumber 5
describerNumber 2

// Tuples : group multiple value into a single value 

let stuendt1 = (111401, "XYz")
let (id, name ) = stuendt1 
printfn "StudentId %d , Name : %s" id name


// List 
let sumList = List.sum [1;2;3]

let lengthList = List.length ['a';'1';'.']

// list comprehension 
// List comprehensions provide a concise way to create lists.
let squaresOfOneToTen = [ for n in 1 .. 10 -> n * n ]
printfn "Squares: %A" squaresOfOneToTen

// Error Handling 
// F# provides the failwith function to handle errors by stopping execution and displaying an error message.

let factorial n = 
    if n < 0 then 
        failwith "You cannot input a negative number "
    else 
        let rec fac n = 
            if n <= 1 then 1 
            else n * fac (n-1)
        fac n

try
    printfn "Factorial of 4 is %d" (factorial 4)
    printfn "Factorial of -65 is %d" (factorial -65) 
with 
    | ex -> printfn "Error %s" ex.Message
