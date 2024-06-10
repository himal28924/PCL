// 2.1.1 -- Pattern matching and recursion 
// a
let vowelToUpper c = 
    match c with 
    | 'a' -> 'A'
    | 'e' -> 'E'
    | 'i' -> 'I'
    | 'o' -> 'O'
    | 'u' -> 'U'
    | _  -> c


let testCharacter = ['a';'b';'e';'i'; 'o'; 'u'; 'x']

let result = testCharacter |> List.map vowelToUpper
printfn "Results: %A" result

vowelToUpper 'a'

vowelToUpper 'b'

// b

let rec vowelToUpperInString str = 
    if String.length str =  0 then ""
    else 
        let firstChar = vowelToUpper str.[0]
        let restChar = vowelToUpperInString str.[1..]
        string firstChar + restChar

vowelToUpperInString "Hello wOrld voWEl"

// 2.1.2
// a 
let rec pmLength ls = 
    match ls with 
    | [] -> 0
    | _ :: tail -> 1 + pmLength tail

// Test the function
let testList1 = [1; 2; 3; 4; 5]
let testList2 = ["a"; "b"; "c"]
let testList3 = []

printfn "Length of testList1: %d" (pmLength testList1)  // Expected: 5
printfn "Length of testList2: %d" (pmLength testList2)  // Expected: 3
printfn "Length of testList3: %d" (pmLength testList3)  // Expected: 0

// b  

let rec pclSum ls = 
    match ls with 
    | [] -> 0
    | hd :: tl -> hd + pclSum tl 

let testListForSum = [2;3;5;8]

pclSum testListForSum

// 2.1.3

let rec pmTakeSome n ls = 
    match n, ls with 
    | 0, _  -> []
    | _, [] -> []
    | _, hd :: tl -> hd :: (pmTakeSome (n-1) tl) 


pmTakeSome 2 ["apple";"banana"; "carot"; "dewberry"]

// 2.2.1
//a 
let rec pmFold func acc ls = 
    match ls with 
    | [] -> acc
    | hd :: tl -> pmFold func (acc + hd) tl

let result1 = pmFold (+) 0 [1; 2; 3]
printfn "Sum of [1; 2; 3] is %d" result1  // Expected output: 6

// b 
let pclSumWithFold ls = pmFold (+) 0 ls

let testList: int list = [1; 2; 3]
pclSumWithFold testList


// 2.2.2 - List function - foldback 

let rec pmFoldBack func acc ls = 
    match ls with
    | [] -> acc
    | hd :: tl -> func hd (pmFoldBack func acc tl)   

pmFoldBack (+) 0 testList

pmFoldBack (-) 0 testList

// b 
let rec pclSumWithFoldBack ls = 
    match ls with 
    | [] -> 0
    | _ -> pmFoldBack (+) 0 ls

pclSumWithFold testList

// c : when func is - 
(*
pmFoldBack (-) [1; 2; 3] 0
= 3 - (pmFoldBack (-) [1; 2] 0)
= 3 - (2 - (pmFoldBack (-) [1] 0))
= 3 - (2 - (1 - (pmFoldBack (-) [] 0)))
= 3 - (2 - (1 - 0))
= 3 - (2 - 1)
= 3 - 1
= 2*)


// 2.2.3 – List Functions - map 
// a 
let rec pmIncList ls = 
    match ls with 
    | [] -> []
    | hd :: tl -> (hd + 1) :: pmIncList tl  

pmIncList testList

let pmIncListTestList =  [2; 3; 1; 4 ] 
pmIncList pmIncListTestList

// b 

// Define the pclMap function
let rec pclMap func ls = 
    match ls with 
    | [] -> []  // Base case: empty list
    | hd :: tl -> (func hd) :: pclMap func tl  // Recursive case: apply func to head and process the tail

// C
// Define pclIncListWithMap using pclMap
let pclIncListWithMap ls = pclMap (fun x -> x + 1) ls

// Test the function
pclIncListWithMap testList

pclIncListWithMap testList1
pclIncListWithMap [-1;0;1]

// 2.2.4 – List Functions - filter

// a 

let rec pclFilter func ls=
    match ls with   
    | [] -> []
    | hd :: tl -> if func hd then hd :: (pclFilter func tl) else (pclFilter func tl)

// b
let pclEven num = 
    if(num % 2 = 0) then true 
    else false

let pclOdd num = 
    num % 2 <> 0

pclFilter pclEven [0; 1; 2; 3; 4; 5;6;7;8;9]
pclFilter pclOdd [0; 1; 2; 3; 4; 5;6;7;8;9]


pclFilter (fun x -> if x % 2 <> 0 then true else false) [0; 1; 2; 3; 4; 5;6;7;8;9]


// Higher-order functions, partial function application, closures 
(*
let countNumOfVowels str = 
    let charList = List.ofSeq str
    let foldFunc (a, e, i, o, u) char = 
        let result = 
            match char with
            | 'a' | 'A' -> (a + 1, e, i, o, u)
            | 'e' | 'E' -> (a, e + 1, i, o, u)
            | 'i' | 'I' -> (a, e, i + 1, o, u)
            | 'o' | 'O' -> (a, e, i, o + 1, u)
            | 'u' | 'U' -> (a, e, i, o, u + 1)
            | _ -> (a, e, i, o, u)
        printfn "Char: %c, Result: %A" char result
        result
    List.fold foldFunc (0, 0, 0, 0, 0) charList
*)


let countNumOfVowels str = 
    let charList = List.ofSeq str
    let foldFunc (a, e, i, o, u) char = 
        match char with
        | 'a' | 'A' -> (a + 1, e, i, o, u)
        | 'e' | 'E' -> (a, e + 1, i, o, u)
        | 'i' | 'I' -> (a, e, i + 1, o, u)
        | 'o' | 'O' -> (a, e, i, o + 1, u)
        | 'u' | 'U' -> (a, e, i, o, u + 1)
        | _ -> (a, e, i, o, u)
    List.fold foldFunc (0, 0, 0, 0, 0) charList

// Test the function
let testString = "Higher-order functions can take and return functions of any order"
let stringResult = countNumOfVowels testString
printfn "Vowel counts: %A" stringResult  

// 2.3.2 Fibonacci Sequence 

let rec pclFib n = 
    match n with 
    | 0 -> 0 
    | 1 -> 1
    | _-> pclFib(n-1) + pclFib(n-2)

pclFib 3

// 2.3.3 Partial function application 
// a
let doubleNum x = 
    x * 2 

doubleNum 4

let sqrnum x = 
    x * x

sqrnum 4.0

let pclQuad x = 
    doubleNum (doubleNum x)

pclQuad 2

let pclFourth x = 
    sqrnum (sqrnum x)

pclFourth 4.0