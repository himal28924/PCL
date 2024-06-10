// This is part of 1Exercise2-PCL

//1.2.1

let x = 23
let myName = "Your Name"
let age = 25
let country = "Denmark"
let y = 6 + 6

let a = 5
(*
    Scope and Shadowing
In F#, let bindings are scoped. This means that the inner binding of a in let a = 10 in a + 5 shadows the outer binding of a = 5 within that expression.

The outer a (which is 5) is not affected by the inner a (which is 10).
The outer a remains 5 outside the inner let ... in ... expression.

*)
let b = let a = 10 in a + 5 

let c = a + b 

// 1 .2.2

let addNum1 num = 
    num + 1 

printfn "Add 1 in 2 : %d" (addNum1 2)

let addNum10 num = 
    num + 10 
printfn "Add 10 in 99 : %d" (addNum10 99)

let addNum20 num = 
    num + 20 

printfn " Add num 20 to 20 : %d" (addNum20 20)

// 1.2.3

let max2 num1 num2 = 
    if num1 >= num2 then num1
    else num2

printfn "Max of 10 and 20 is : %d" (max2 10 20)

printfn "Max of 99 and -20 is : %d" (max2 99 -20)

printfn "Max of 0   and -0 is : %d" (max2 0 -0)

let evenOrOdd num = 
    if num % 2 = 0 then "Even number "
    else "Odd Number" 

printfn "Even number ? odd Number 123 : %s" (evenOrOdd 123)
printfn "Even number ? odd Number 1234 : %s" (evenOrOdd 1234)


let addXY num1 num2 = 
    printfn "The number we are adding is %d , %d" num1 num2
    num1 + num2

addXY 10 324

// 1.2.4

let addNum_jk j k = 
    let rec addNum10 k = 
        if k = 0 then 0
        elif k = 1 then 10
        else 10 + addNum10 (k-1)
    j + addNum10 k

addNum_jk 3 5

addNum_jk 3 0

addNum_jk 9 9