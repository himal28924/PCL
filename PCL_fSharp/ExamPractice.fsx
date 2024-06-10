let sqrOnlyFirst ls =
    match ls with
    | hd :: _ -> hd * hd

(**
Question 1a
i. sqrOnlyFirst [2; 4; 6]
Input: [2; 4; 6]
Pattern Match: The list [2; 4; 6] matches the pattern hd :: _ with hd being 2.
Output: The function returns 2 * 2 = 4.
ii. sqrOnlyFirst []
Input: [] (an empty list)
Pattern Match: The empty list does not match the pattern hd :: _ because there is no head element.
Output: The function will raise a MatchFailureException because no match is found for an empty list.

*)

let sqrOnlyFirstFixed ls =
    match ls with
    | hd :: _ -> hd * hd
    | [] -> 0


// 2 a 

type Vector =
    | Vec2 of float * float
    | Vec3 of float * float * float
    | Vec4 of float * float * float * float
    | Vec5 of float * float * float * float * float


// 2 b 

let vecLen vector =
    match vector with
    | Vec2 (x, y) ->
        sqrt (x * x + y * y)
    | Vec3 (x, y, z) ->
        sqrt (x * x + y * y + z * z)
    | Vec4 (x, y, z, w) ->
        sqrt (x * x + y * y + z * z + w * w)
    | Vec5 (x, y, z, w, v) ->
        sqrt (x * x + y * y + z * z + w * w + v * v)


// 2 c
let vecAdd v1 v2 =
    match v1, v2 with
    | Vec2 (x1, y1), Vec2 (x2, y2) ->
        Vec2 (x1 + x2, y1 + y2)
    | Vec3 (x1, y1, z1), Vec3 (x2, y2, z2) ->
        Vec3 (x1 + x2, y1 + y2, z1 + z2)
    | Vec4 (x1, y1, z1, w1), Vec4 (x2, y2, z2, w2) ->
        Vec4 (x1 + x2, y1 + y2, z1 + z2, w1 + w2)
    | Vec5 (x1, y1, z1, w1, v1), Vec5 (x2, y2, z2, w2, v2) ->
        Vec5 (x1 + x2, y1 + y2, z1 + z2, w1 + w2, v1 + v2)
    | _ -> failwith "Vectors must be of the same dimension"



// Question 3a
let rec rerun s n =
    if n <= 0 then
        ""
    else
        s + rerun s (n - 1)


// Question 3b
let rerun3b s n =
    let rec aux acc s n =
        if n <= 0 then
            acc
        else
            aux (acc + s) s (n - 1)
    aux "" s n



// 4a

// List.ofSeq (f1 2 2 3) = [(0, 0); (0, 1); (0, 2); (1, 0); (1, 1); (2, 0)]


// 4b

let f2 f p sq =
    sq
    |> Seq.filter p
    |> Seq.map f


// 5 
type expr =
    | Const of int
    | BinOpr of expr * string * expr 


let expr1 = Const 5

let expr3 = BinOpr (Const 1, "+", BinOpr (Const 2, "*", Const 3))

let rec toString expr =
    match expr with
    | Const n -> string n
    | BinOpr (left, op, right) ->
        "(" + toString left + op + toString right + ")"


// 6 


// Define the type for a product
type Product = {
    Name: string
    Quantity: int
}

// Define the messages that the agent can handle
type InventoryMessage =
    | AddProduct of Product
    | GetProduct of string * AsyncReplyChannel<Product option>

// Create the agent
let inventoryAgent = MailboxProcessor<InventoryMessage>.Start(fun inbox ->
    // Define the inventory as a mutable map
    let inventory = System.Collections.Generic.Dictionary<string, Product>()

    // The agent's message handling loop
    let rec loop () = async {
        // Receive a message
        let! msg = inbox.Receive()
        match msg with
        // Handle adding a product
        | AddProduct product ->
            if inventory.ContainsKey(product.Name) then
                // Update the quantity if the product already exists
                let existingProduct = inventory.[product.Name]
                inventory.[product.Name] <- { existingProduct with Quantity = existingProduct.Quantity + product.Quantity }
            else
                // Add the new product
                inventory.[product.Name] <- product
            return! loop ()
        // Handle getting a product
        | GetProduct (name, replyChannel) ->
            if inventory.ContainsKey(name) then
                replyChannel.Reply(Some inventory.[name])
            else
                replyChannel.Reply(None)
            return! loop ()
    }
    // Start the loop
    loop ()
)

// Test the agent
inventoryAgent.Post(AddProduct { Name = "Apple"; Quantity = 10 })
inventoryAgent.Post(AddProduct { Name = "Banana"; Quantity = 20 })

// Get a product
let getProduct name = 
    inventoryAgent.PostAndAsyncReply(fun replyChannel -> GetProduct (name, replyChannel))

// Example usage
async {
    let! apple = getProduct "Apple"
    printfn "Apple: %A" apple

    let! banana = getProduct "Banana"
    printfn "Banana: %A" banana

    let! orange = getProduct "Orange"
    printfn "Orange: %A" orange
} |> Async.RunSynchronously






