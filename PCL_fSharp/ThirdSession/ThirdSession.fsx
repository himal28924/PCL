open System
open System.IO
// Pipelining 
let square x = x * x
let toString (x : int) = x.ToString()
let strLen (x : string) = x.Length


let result = 
    3 
    |> square 
    |> toString 
    |> strLen

let sizeOfFilderPiped foler = 
    let getFilles folder = 
        Directory.GetFiles(folder,"*.*", SearchOption.AllDirectories)

    let totalSize = 
        foler
        |> getFilles
        |> Array.map (fun file -> new FileInfo(file))
        |> Array.map (fun info -> info.Length)
        |>Array.sum
    
    totalSize

sizeOfFilderPiped("E:\\Semester7\\PCL\\PCL_fSharp\\ThirdSession")

// Function Composition 

let lenOfSquare = square >> toString >> strLen

lenOfSquare 5

// Data type
// abbrevoation 
type lineNumber = int 

// Discriminated union 
type Color = Black | Blue | Green | Cyan | Red | Magenta | Yellow 

// Example deck of cards

type Suit = Heart | Diamond | Spade | Club

let suits = [Heart; Diamond; Spade; Club]

type PlayingCard = 
    | Ace of Suit
    | King of Suit
    | Queen of Suit 
    | Jack of Suit
    | ValueCard of int * Suit


// Option and discrementation 

let myFirstOption = Some(12)

let mySecondOption = None

type Option<'a> =
 | Some of 'a
 | None



 // Generating deck of cards 
let deck = 
    [for suit in suits do 
        for value in 2..10 do 
            yield ValueCard(value, suit)
        yield Ace suit
        yield King suit
        yield Queen suit
        yield Jack suit
    ]

// Record Type 

type PersonRecord = { FirstName:string ; Lastname:string ; Age:int }

let person = {FirstName = "Himal" ; Lastname ="Sharma" ; Age =24}

printfn "%s %s is %d years old " person.FirstName person.Lastname  person.Age



// Exercise 3 

type PCLShape = 
    | Rectangle of float * float  
    | Triangle of float * float 

let rect = Rectangle(10,12)

let tri = Triangle(5,2)

let pclAread shape = 
    match shape with 
    | Rectangle (width,length) -> width * length
    | Triangle (bases, height: float) -> bases * height * 0.5


pclAread rect

pclAread tri


let pclPerimeter shape = 
    match shape with 
    | Rectangle(width , length ) -> (2.0* width )+ (2.0 * length)
    | Triangle (bases, height) -> bases + height + sqrt (bases * bases + height * height)


pclPerimeter rect
pclPerimeter tri

type Rectangle = { Width: float; Height: float }
type RightTriangle = { Base: float; Height: float }

type PclShapeRecord = 
    | Rect of Rectangle
    | Tri of RightTriangle


// Create instances
let rectRecord = Rect { Width = 3.0; Height = 4.0 }
let triRecord = Tri { Base = 3.0; Height = 4.0 }


let pclAreaRecord shape =
    match shape with
    | Rect r -> r.Width * r.Height
    | Tri t -> 0.5 * t.Base * t.Height


let pclPerimeterRecord shape =
    match shape with
    | Rect r -> 2.0 * (r.Width + r.Height)
    | Tri t -> t.Base + t.Height + sqrt (t.Base * t.Base + t.Height * t.Height)


// Testing the functions
printfn "Area of rectRecord: %f" (pclAreaRecord rectRecord)  // Expected: 12.0
printfn "Area of triRecord: %f" (pclAreaRecord triRecord)  // Expected: 6.0

printfn "Perimeter of rectRecord: %f" (pclPerimeterRecord rectRecord)  // Expected: 14.0
printfn "Perimeter of triRecord: %f" (pclPerimeterRecord triRecord)  // Expected: 12.0