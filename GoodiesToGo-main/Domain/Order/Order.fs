module Domain.Order.Order

open Domain.Order.OrderLine
open Domain.Products.Product


type Order = {
    OrderLines: OrderLine list
}

let getTotalOrderPrice (order: Order) =
    let getOrderLinePrice (orderLine : OrderLine) =
        match orderLine with
        |QuantityLine {Product = product; Quantity = quantity} ->
            getProductPrice product * float quantity
        |WeightLine {Product = product; Weight = weight} ->
            getProductPrice product * float weight
    
    List.sumBy getOrderLinePrice order.OrderLines

let orderToString (order: Order) =
    match order.OrderLines with
    | [] -> "No items in the order"
    | [singleOrderLine] ->
        let totalPrice = getTotalOrderPrice order
        $"Please pay DKK%.2f{totalPrice} for your %s{orderLineToString singleOrderLine}. Thanks!"
    | _ ->
        let orderLineStrings = List.map orderLineToString order.OrderLines
        let totalPrice = getTotalOrderPrice order
        sprintf "Please pay DKK%.2f for your %s. Thanks!" totalPrice (String.concat " and " orderLineStrings)
   