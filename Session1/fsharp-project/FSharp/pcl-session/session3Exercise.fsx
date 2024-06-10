// Domain modelling : Data type declaration 

// Define the data type declaration (PclShape) for Rectangleand RightTriangle
type PclShape = 
    | Rectangle of float * float  // Represents Length and Breadth
    | RightAngle of float * float * float  // Represents Base, Height, Hypotenuse

let rectangle1 = Rectangle (10.0, 5.0)
let rightAngle1 = RightAngle (5.0, 10.0, 11.18)


type RectangleType = {
    Length: float
    Breadth: float
}

type RightAngleType = {
    Base: float
    Height: float
    Hypotenuse: float
}

type PclShapeRecord = 
    | Rectangle of RectangleType
    | RightAngle of RightAngleType

// Create some values to represent both shapes

let rectangle2 = Rectangle {Length = 10.0 ; Breadth = 5.0}

let rightAngle2 = RightAngle { Base = 5.0; Height = 10.0; Hypotenuse = 11.18 } 

let pclAread shape = 
    match shape with 
    | Rectangle r-> r.Length * r.Breadth
    | RightAngle r -> r.Base * r.Height * 0.5

let pclParameter shape = 
    match shape with
    | Rectangle r -> 2.0 * (r.Length + r.Breadth)
    | _ -> failwith "Not supported type"
    
