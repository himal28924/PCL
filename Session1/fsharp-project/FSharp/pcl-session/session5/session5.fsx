type MutableRecord = 
    { mutable Field1: int
      mutable Field2: string }


//  Mutable record 

type MutableCar = {
    Make : string
    Model : string
    mutable Miles : int
}

let driveForASeason car = 
    let randomRangeOfValues = new System.Random()
    car.Miles <- car.Miles + randomRangeOfValues.Next() % 10000 

let tesla = { 
    Make = "Tesla"
    Model = "S"
    Miles = 0
}
    
driveForASeason tesla
let BMW = { 
    Make = "BMW"
    Model = "XXX"
    Miles = 78000
}

driveForASeason BMW

for i = 1 to 5 do 
    printfn "%d" i

for i in [1..5] do 
    printfn "%d" i


// Check if num is prime 

let stopWatch = System.Diagnostics.Stopwatch()

let ResetStopWatch() = stopWatch.Reset(); stopWatch.Start()
let showTime() = printfn">>>>>> It took  %d ms " stopWatch.ElapsedMilliseconds
let isPrimeNumber x =  
    let mutable i = 2 
    let mutable isFactorFound = false
    while not isFactorFound && i <= x do 
        if x % i = 0 then 
            isFactorFound <-true
        i <- i + 1
    not isFactorFound

isPrimeNumber 5000

let intArray = [| for i in 100000000..100040000 -> i |]

ResetStopWatch()
let primeDetails1 = 
    intArray
    |> Array.map(fun x -> (x, isPrimeNumber x))

showTime()

ResetStopWatch()
let primeDetails2 = 
    intArray
    |> Array.map(fun x -> async{ return (x, isPrimeNumber x)})
    |> Async.Parallel
    |> Async.RunSynchronously
showTime()


ResetStopWatch()

