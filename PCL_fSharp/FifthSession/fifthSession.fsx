// 

let printAgent = MailboxProcessor.Start (fun inbox ->
    let rec msgLoop = async {
        let! msg = inbox.Receive()
        printfn "\nThe message is: %s" msg
        return! msgLoop
    }
    msgLoop
)

// Using the print agent
printAgent.Post "Hello, World!"
printAgent.Post "F# is awesome!"


let caseConverterAgent = MailboxProcessor.Start (fun inbox ->
    let rec processMessage state = async {
        let! msg = inbox.Receive()
        printfn "\nReceived: %A" msg
        let newState = "[" + msg + "]"
        printfn "Processed: %s" (newState.ToUpper())
        return! processMessage newState
    }
    processMessage "initialState"
)

// Using the case converter agent
let data = ["apple"; "banana"; "carrot"; "durian"; "elgray"; "fruit"]
data |> List.iter caseConverterAgent.Post


// Exercise

// 5.1 

// Integer tree

type IntegerTree = 
    | Leaf of int
    | Node of IntegerTree * IntegerTree

let rec sumIntegerTree tree = 
    match tree with 
    | Leaf value -> value
    | Node(left,right) -> sumIntegerTree left + sumIntegerTree right

    // Define a sample tree
let tree1 = Node (Leaf 1, Node (Leaf 2, Leaf 3))
let tree2 = Node (Node (Leaf 4, Leaf 5), Leaf 6)

// Test the function
let sum1 = sumIntegerTree tree1
let sum2 = sumIntegerTree tree2

printfn "Sum of tree1: %d" sum1  // Expected output: 6
printfn "Sum of tree2: %d" sum2  // Expected output: 15



// 5,2

type WordLetterCount = {
    WordCount: int
    LetterCount: int
}

let countWordnLetter (str:string) =
    let wordCount = str.Split [| ' ' |]
    let letterCount = wordCount |> Array.sumBy (fun w -> w.Length)
    { WordCount = wordCount.Length; LetterCount = letterCount }

// Test it
let result = countWordnLetter "functional programming is fun and rewarding"
printfn "Word count: %d, Letter count: %d" result.WordCount result.LetterCount
