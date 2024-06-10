// Things done in this file 
// Simple function 
// Immutability 
// First-Class and Higher-Order Functions
// Pure Functions
// Recursion 
// Tuple 
// Add value to list (at last index)


// Define a function 

let helloWorld name = 
    printfn "Hello, %s!" name

// Call the function

helloWorld "F#"

// Once we assign value to a variable, we can't change it. 

let x = 5 
x <- 6 // This will give an error
printfn "x is %d" x

// We can use mutable keyword to make a variable mutable

let mutable y = 5
y <- 6
printfn "y is %d" y

// But we can also use function to do it 
let incrementValue number = 
    let newValue = number + 1
    newValue

// now we just call the function and it will increment the value 
incrementValue 6


// First-Class and High Order function 
// we can pass function as arguments to other function and return them as results 

let add a b = a + b 

let applyFunction func x y = func x y

applyFunction add 4 8

// Pure function 
// it does not have any side effect and will always produce the same out put for the input 
// here no matter what the square value is only dependent on input not any other variable from function 
let square x = x * x

square 5 

// Recursion 
// it is often used instead of loop in FP 

let rec factorial n =
    // first check for best case scenraio 
    if n <= 1 then 1 
    else n * factorial(n-1)

let factorialResult = factorial 5

printfn "Factoruial result of 5 is %d " factorialResult

// Tuples 
// it is used to group multiple values 

let pointA = (32,42)
let dataB = (1,"Thursday",25.15)

let swap (a,b) = (b,a)

let pointB = swap pointA
printfn "Swapped value : (%d, %d)" (fst pointB)(snd pointB)

// Lists 
// it is a fundamental data structure in f# 

let listA= []
let lst3 = [1; 2; 3]

// it adds value to front of list 
let newList = 0 :: lst3

let squareOfOneToTen = [for n in 1..10 -> n*n]



// Exercise 1 
1 :: [2 ; 5 ; 3; 7] // It should add 1 in front

List.length[2 ; 5; 3; 7] // return 4 

[2; 5; 3; 7] :: 4 ;; // it will return error 
// since we can not add it in this way there are multiple ways to do it 
// 1 : 
// use recursive .. mind it it is not tail recursive 
let rec add lst value = 
    match lst with 
    | [] -> [value] // Base case: if the list is empty, return a new list containing just the value
    |h :: t -> h :: add t value// Recursive case: decompose the list into head (h) and tail (t) 

// using that 

add [2; 5; 3; 7] 9


// We can also use built in append operator 
let add lst value = lst @ [value]
add [2; 5; 3; 7] 10

// Or we can also use List.append 
let add lst value = List.append lst [value] 

add [2; 5; 3; 7] 11
// Also worth Knowing that append is an expensive function on a singly linked immutable list which create a new copy of the entire list.
