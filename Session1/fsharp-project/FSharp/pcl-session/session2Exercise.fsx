// Pattern matching and recursion

let vowelTOUpper c = 
    match c with 
        | 'a' -> 'A'
        | 'i' -> 'I'
        | 'e' -> 'E'
        | 'o' -> 'O'
        | 'u' -> 'U'
        | c -> c 
        

let a = vowelTOUpper 'i'
let b = vowelTOUpper 'b'

let rec voweltoUpperCase (a : string) = 
    match a with 
        | "" -> ()
        | _ -> 
            let h = a.[0]
            let t = a.Substring(1)
            let result = vowelTOUpper h
            printfn "%c" result
            voweltoUpperCase t

voweltoUpperCase "hello"

// 2.1.2  -- Function on list 
// Define a function pmLengthlsthat computes the length of a list.Use pattern matching 

let rec pmLengthls list = 
    match list with
        | [] -> 0
        | _::tl -> 1 + pmLengthls tl 

pmLengthls [1;2;3]

let rec pmSumls list = 
    match list with 
        | [] -> 0
        | hd::tl -> hd + pmSumls tl

pmSumls [1;2;3]

// 2.1.3 - List processing 
// Define a function, pmTakeSome n lsthat returns list of first nelements from the list ls. 
//Define the function using pattern matching:
//Example pmTakeSome 2 ["apple";"banana"; "carot"; "dewberry"];;
//should returnreturn["apple"; "banana"]

let rec pmTakeSome n list = 
    match n, list with 
        | 0,  [] -> []
        | 0, _ -> []
        | _, []-> failwith "Taking too many elements" 
        | n, hd :: tl when n > 0 -> hd :: pmTakeSome (n-1) tl
        | _, _ -> []
       
pmTakeSome 3 [1;2;3;4;5]

pmTakeSome 2 [1;2;3;4;5]



// 2.2.1–List Functions -fold 

let rec pmFold (op) accumulatorValue ls = 
    match ls with
        | [] -> accumulatorValue
        | _ -> 
            pmFold op (accumulatorValue + ls[0]) ls[1..]
    
pmFold (+) 5 [1;2;3]

// Test 
let rec fact_PM n =
    match n with 
        |   0 | 1 -> 1
        |   _-> if n < 0
                then failwith "This sucks "
                else n * fact_PM(n-1)

    
fact_PM (-1)

let rec pmSumWithFold fn list = 
    match fn, list with 
        | _ , [] -> 0
        | _, _ -> fn list


pmSumWithFold pmSumls [1;2;3]

pmSumWithFold pmSumls [1;2;3;5]



// FOld back 
let rec pmfoldBack op acc ls = 
    match ls with 
        | [] -> acc
        | hd::tl -> 
            let foldedtail = pmfoldBack op acc tl        // Recursively process the tail to ensure we start folding from the last element

            op   foldedtail hd       // Apply the function to the head of the current list and the result of folding the tail

            
let sum: int = pmfoldBack (-) 0 [1; 2; 3]

// b. Define a function pclSumWithFoldBack that changes the pclSum you defined
//previously in 2.1.2b) to use pmFoldBack defined above.

(* 2.2.3 – List Functions - map
a. Define a function pmIncList that adds one to each element in a list of integers. You
are not allowed to use the standard F# functions. Use recursion and pattern
matching. For example, pmIncList [2; 3; 1; 4 ] should return [3; 4; 2; 5 ]. *)

let rec pmIncList ls = 
    match ls with
        | []-> []
        | hd::tl -> 
            (hd + 1 :: pmIncList tl)

let incrementedList: int list = pmIncList [2; 3; 1; 4]

(* b. Define a function, pclMap that applies an arbitrary function f to the elements in a
list. *)
let rec pclMap func list =  
    match list with
    | [] -> []
    | hd::tl ->
        (func hd :: pclMap func tl)

(* Define a function pclIncListWithMap that changes the pmIncList you defined
previously in 2.2.3a to use pclMap defined above. *)

let pclIncListWithMap lst =
    let increment x = x + 1
    pclMap increment lst

pclIncListWithMap [2; 3; 1; 4]