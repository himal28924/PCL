#r "nuget: XPlot.GoogleCharts"
#r "nuget: FSharp.Data"

open FSharp.Data
open XPlot.GoogleCharts 

let co2_data = WorldBankData.GetDataContext()

co2_data.Countries.Nepal
    .Indicators.``CO2 emissions (metric tons per capita)``
    |> Chart.Line
    |> Chart.WithTitle "C02 Emission"
    |> Chart.WithYTitle "Metric Tons"
    |> Chart.WithXTitle "Years"
    |> Chart.Show


// MailboxProcessor 
// A simple print agent 
let printAgent = 
    MailboxProcessor.Start(
        fun inbox -> 
        // a func to process the message 
            let rec messageLoop = async {
                // read message
                let! msg = inbox.Receive()
                // Process message 
                printfn "\n The message is %s" msg
                // loop to the top 
                return! messageLoop
            }
            //Start the loop 
            messageLoop
    )

printAgent.Post("OO SEXY LADY !!")

// A case converter
let caseConverterAgent = 
    MailboxProcessor.Start(
        fun inbox -> 
        // a func to process the message 
            let rec processMessage state = async {
                // read message
                let! msg = inbox.Receive()
                // Process message 
                printfn "\n Received message is %s" msg
                let newState = "[" + msg + "]"
                printfn "\n processed message is %s" (newState.ToUpper())                    
                // loop to the top 
                return! processMessage newState
            }
            //Start the loop 
            processMessage "InitialState"
    )

caseConverterAgent.Post("OOOOOooooPPPppp")

let data = ["apple"; "banana"; "carrot"; "durian"; "eelf"; "fruit"]

data |> List.map caseConverterAgent.Post