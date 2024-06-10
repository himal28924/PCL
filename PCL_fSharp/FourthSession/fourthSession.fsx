// Tail recursion 

(*
Tail Recursion is a special case of recursion where the recursive call is the last operation in the function. 
This allows the compiler to optimize the recursion to prevent stack overflow.
*)

// Example of non tail recursive 
// Factorial 
let rec factorial x =
    if x <= 1 then 1
    else x * factorial (x - 1)

//This function is not tail-recursive because the multiplication operation (x * ...) happens after the recursive call.

// Sum List 

let rec sumList lst = 
    match lst with
    | [] -> 0 
    | hd::tl -> hd + sumList(tl)

// Simillary this is also not tail recursive cause hd + happens after recusrive call 

// Converting to Tail Recursion
//To make a function tail-recursive, we need to ensure that no additional work is done after the recursive call. 
//This often involves using an accumulator.

let factorialTailRec x = 
    let rec loop x acc = 
        if x <= 1 then acc 
        else loop(x-1) (acc * x)
    loop x 1

// In this version, loop is tail-recursive because the recursive call is the last operation.

// For sum list 

let sumListTailRec lst = 
    let rec loop lst acc =
        match lst with
        | [] -> 0
        | hd :: tl -> loop tl (acc + hd)
    loop lst 0

// Stack overflow 

(*
A stack frame is allocated for each function call.
If a function calls itself recursively without tail recursion, each call adds a new frame to the stack, which can lead to a stack overflow.*)

(*
3. Benefits of Tail Recursion
Performance: Tail-recursive functions execute faster due to fewer stack operations.
Stack Safety: Tail-recursive functions can recurse indefinitely without causing a stack overflow.*)

// F# provides several recursive data types such as lists, sequences, sets, maps, and arrays.

//Sequences:

// Sequences are similar to lists but are lazily evaluated.
// Defined using sequence expressions.


let seqOfNumbers = seq { 1 .. 5 }
seqOfNumbers |> Seq.iter (printfn "%d")

// infine sequence 

let all postiveIntSeq = 
    seq { for i in 1 .. System.Int32.MaxValue do yield i}

// Example Using Seq.map and Seq.fold:

let squares = seq { for i in 1 .. 100 -> i * i }
let sumOfSquares = Seq.fold (+) 0 squares
printfn "Sum of squares: %d" sumOfSquares

// Sets 

(*Sets:

Sets are collections of unique elements.
Implemented using binary trees for fast membership checking.
*)
let setA = Set.ofSeq [ 1 .. 10 ]
let setB = Set.ofSeq [ 5 .. 10 ]
let isSubset = Set.isSubset setB setA  // true


(*Maps:

Maps are collections of key-value pairs.
Similar to sets but with associated values.*)

let comingEvents =
    [ ("Palm Sunday", "March 24")
      ("Maundy Thursday", "March 28")
      ("Good Friday", "March 29")
      ("Easter Sunday", "March 31") ]
    |> Map.ofList

let goodFriday = comingEvents.["Good Friday"]
printfn "Good Friday is on %s" goodFriday


// Exercise 4.2 

// part from 2.3.2 
let rec pclFib n = 
    match n with 
    | 0 -> 0 
    | 1 -> 1
    | _-> pclFib(n-1) + pclFib(n-2)

pclFib 3

// Now for 4.2 

let pclFibTailRec n = 
    let rec loop n a b =
        match n with 
        | 0 -> a
        | 1 -> b
        | _ -> loop (n - 1) b (a + b)
    loop n 0 1

// Test the function
let result = pclFibTailRec 10
printfn "Fibonacci of 10: %d" result  // Expected output: 55


// 4.3 
let factorialCont n =
    let rec loop n cont =
        if n <= 1 then
            cont 1
        else
            loop (n - 1) (fun v -> cont (n * v))
    loop n id

// Test the function
let facR = factorialCont 5
printfn "Factorial of 5: %d" facR  // Expected output: 120


let isLeapYear year = 
    if (year % 400 = 0 )||((year % 4 = 0) && (year % 100 <> 0 )) then true
    else false

let testYear = [1992;2024;1901;2023]

List.map(fun year -> (year , isLeapYear year)) testYear


