let rec factorial_PM_FW n = 
    match n with 
    | 0 | 1 -> 1
    | _ -> 
        if n > 0 
        then n * factorial_PM_FW(n-1)
        else failwith "Non natural"


let rec factorial_PM_GE n = 
    match n with 
    | 0 | 1 -> 1
    | n when n > 0 -> n * factorial_PM_GE (n-1)
    |_ -> failwith "Non natural"

let validateAgeRange age = 
    match age with 
    | age when age < 0 -> "probably in belly"
    | age when age >= 1 && age < 18 -> "young"
    | a when a >=18 -> "J garne ho gar"
    | _ -> "How tf is even this possible "

validateAgeRange 1
// 
let student  = ("WOO",124)
fst student

let sName = student |> fst

let inttoString(x:int) = x |> string

"Life" |> ("Sweet" |> (fun x y z -> x + y + z)) "Challenging";

// Define a function to increment a value
let inc x = x + 1

// Define a function to multiply a value by 2
let multiBy2 x = x * 2

// Compose the two functions such that the output of 'inc' is passed to 'multiBy2'
let incMultiBy2 = inc >> multiBy2

// Apply the composed function to the value 2
incMultiBy2 


open System.IO
let sizeOfFolderPiped folder =
    let getFiles folder =
        Directory.GetFiles(folder,"*.*",SearchOption.AllDirectories)
    let totalSize =
        folder
        |>getFiles
        |>Array.map(fun file -> new FileInfo(file))
        |>Array.map(fun info ->info.Length)
        |>Array.sum
    totalSize

let fspath = "E:\\Semester7\\CAL"
sizeOfFolderPiped fspath


let square x = x * x

let toString (x:int) = x.ToString()

let strLen (x:string) = x.Length 

let lenOfSquare = square >> toString >> strLen

square 125 

lenOfSquare 125

// Descriminated Unions 

type Suit = Heart | Diamond | Spade | Club

type Rank = Ace | Two | Three | Four | Five | Six | Seven | Eight | Nine | Ten | Jack | Queen | King

type Card = { Suit: Suit; Rank: Rank }

let deck = 
    [ for suit in [Heart; Diamond; Spade; Club] do
        for rank in [Ace; Two; Three; Four; Five; Six; Seven; Eight; Nine; Ten; Jack; Queen; King] do
            yield { Suit = suit; Rank = rank } ]


// Construct a record 

type PersonRecord = {FirstName : string ; LastName : string; Age : int}

let him = {FirstName = "Himal" ; LastName = "Sharma"; Age = 21}

printfn "%s is %d years old." him.FirstName him.Age