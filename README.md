# Hello AzureEventHub
Simple implementation in C# and F# of a sender and a receiver using Azure Event Hub.

## Getting Started
You can refer to the offical [Getting Started with Azure Event Hub](https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-csharp-ephcs-getstarted)
guide to learn how to create and EventHub on Azure and setup the environment.

Create at least an EventHub and a Storage Account on Azure, then fill the connection trings in the code.

This repository provides four projects: C# EventHubSender & EventHubReciver and F# EventHubSender & EventHubReceiver. You can mix and match sender and receivers, such as using the C# sender and the F# receiver or viceversa: 
the implementation is the same.

- C# Implementation
    
    This impelementation is exactly what you find in the official Getting Started Guide.    
    Both projects EventHubSender and EventHubReceiver are based on Visual Studio.

- F# Implementation

    Projects EventHubSender and EventHubReceiver are based on Paket and FAKE, using Visual Studio Code.
    They are the equivalent implementation of the C# version.

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details


