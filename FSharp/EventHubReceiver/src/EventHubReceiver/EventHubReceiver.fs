open Microsoft.Azure.EventHubs
open Microsoft.Azure.EventHubs.Processor
open System
open System.Text
open System.Threading.Tasks

let eventHubCS   = "Endpoint=sb://xxxx.servicebus.windows.net/;SharedAccessKeyName=xxxx;SharedAccessKey=xxxx;EntityPath=xxxx"
let ehEntityPath = "xxxx";
let storageContainerName = "xxxx";
let storageAccountName = "xxxx";
let storageAccountKey = "xxxx";

let storageConnectionString = sprintf "DefaultEndpointsProtocol=https;AccountName=%s;AccountKey=%s" storageAccountName storageAccountKey


let emptyTask() = Task.FromResult(true) :> Task

type MySimpleEventProcessor() =
    interface IEventProcessor with
        member x.OpenAsync (context) = 
            printfn "MySimpleEventProcessor initialized. Partition: '%s'" context.PartitionId
            emptyTask()

        member x.CloseAsync (context, reason) =
            printfn "Processor Shutting Down. Partition '%s', Reason: '%A'." context.PartitionId reason 
            emptyTask()

        member x.ProcessErrorAsync (context, error) =
            printfn "Error on Partition: %s, Error: %A" context.PartitionId error 
            emptyTask() 

        member x.ProcessEventsAsync(context, events) = 
            events 
                |> Seq.map (fun e -> e.Body.Array |> Encoding.UTF8.GetString )
                |> Seq.iter (printfn "Message received. Partition: '%s', Data: '%s'" context.PartitionId)
            context.CheckpointAsync()

[<EntryPoint>]
let main argv = 

    let processor = EventProcessorHost(ehEntityPath,PartitionReceiver.DefaultConsumerGroupName,eventHubCS,storageConnectionString,storageContainerName)
    
    processor.RegisterEventProcessorAsync<MySimpleEventProcessor>() |> ignore

    Console.WriteLine "Receiving. Press enter key to stop worker."
    Console.ReadKey() |> ignore

    processor.UnregisterEventProcessorAsync() |> ignore

    0 // return an integer exit code
