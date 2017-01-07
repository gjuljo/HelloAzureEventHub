module EventHubSender
open Microsoft.Azure.EventHubs
open System
open System.Text
open System.Threading.Tasks
let eventHubCS   = "Endpoint=sb://xxxx.servicebus.windows.net/;SharedAccessKeyName=xxxx;SharedAccessKey=xxxx;EntityPath=xxxx"

[<EntryPoint>]
let main argv = 
    printfn "sending events from f#"
    let client  = EventHubClient.CreateFromConnectionString eventHubCS
    
    let send = async {
            let message = Guid.NewGuid().ToString()
            let event   = EventData(message |> Encoding.UTF8.GetBytes)
            printfn "%A > Sending message: %s" DateTime.Now message 
            client.SendAsync(event) |> ignore
            do! Async.Sleep 1000
        }

    while true do
        Async.RunSynchronously send
        
    0 // return an integer exit code
