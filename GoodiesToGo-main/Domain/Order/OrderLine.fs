module Domain.Order.OrderLine

open Domain.Products.Product


type QuantityLine = {Product: Product; Quantity: int}
type WeightLine = {Product: Product; Weight: float}

type OrderLine =
    | QuantityLine of QuantityLine
    | WeightLine of WeightLine
    
let orderLineToString orderLine =
    match orderLine with
    | QuantityLine {Product = product; Quantity = quantity} -> $"%d{quantity} - %s{productToString product}"
    | WeightLine {Product = product; Weight = weight} -> $"%.2f{weight}kg - %s{productToString product}"
    
    