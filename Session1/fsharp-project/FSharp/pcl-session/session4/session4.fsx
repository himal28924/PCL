let rec sumList lst acc = 
    match lst with 
        | [] -> acc
        | hd:: tl -> sumList tl (hd + acc)

let list1 = [1;2;3]

sumList list1

// Running 1000 times 
// DO NOT RUN  

printfn "Sum : %d"(sumList [1..100000000] 0)

let rec factorial x = 
    if x <= 1 
    then 1 
    else x * factorial(x-1)
    
printf "Fact :  %d" (factorial 5000)


let accFactorial x = 
    if x < 0 then failwith "Non Natural number "

    let rec tailRecursiveFactorial x acc = 
        if x <= 1 then acc 
        else
            tailRecursiveFactorial (x-1)(x * acc)
    tailRecursiveFactorial x 1

// Continautation 
// Print a list of items in reverse order

let printListRev lst = 
    let rec printListRevTR lst cont = 
        match lst with 
            // For an empty list , excuite the continuation 
            | [] -> cont()
            |  hd :: tl -> 
                printListRevTR tl (fun () -> printf "%A " hd;  cont())
    printListRevTR lst (fun () -> printfn"Done!")

    
printListRev ['A';'B';'C';'D']

let num1 = Seq.init 20 (fun i -> i *2 )

let num2 = Seq.initInfinite (fun i -> i *2 )

let allPositiveIntsSeq = 
    seq {for i in 1 .. System.Int32.MaxValue do yield i }

// do not run this 
let allPositiveIntsList = 
    [for i in 1 .. System.Int32.MaxValue -> i]
    
// Maps

let comingEvents = 
    [
        ("What","March 28");
        ("the", "March 29");
        ("Hell", "March 30");
        ("Is", "March 31")
    ]
    |> Map.ofList

comingEvents.["What"]