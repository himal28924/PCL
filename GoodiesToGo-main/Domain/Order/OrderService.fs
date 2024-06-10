module Domain.Order.OrderService

open Domain.Order.Order

let orderAgent: MailboxProcessor<Order> = 
    MailboxProcessor.Start(fun inbox ->
        let rec processOrder = async{
            let! order = inbox.Receive()
            let stringToPrint = orderToString order
            printfn $"%s{stringToPrint}"
            return! processOrder
        }
        processOrder 
    )


let placeOrder (order: Order) = 
    orderAgent.Post(order)
    
let placeOrders (orders: Order list) = 
    orders |> List.iter placeOrder
 
 

    













