# Cleverbot.Net
A cleverbot wrapper for .NET 4.6.1+ and .NET Core (targets .NET Standard 1.6).

## How to set up?
First, get an api key from http://www.cleverbot.com/api/ to be able to create a instance of 
Cleverbot. To further set up Cleverbot.Net, download it from the nuget package manager.

>Install-Package Cleverbot

Once you've installed Cleverbot.Net in your C# project. Include the new header `using Cleverbot.Net;`

## Sample code

Asynchronous sample
```csharp
// Let's say we are in a thread 
CleverbotSession cleverbot = new CleverbotSession("api-key-here");
Label1.Text = "Cleverbot is typing...";
CleverbotResponse r = await cleverbot.GetResponseAsync("Hello!");
Label1.Text = r.Response;
```

Synchronous sample
```Csharp
CleverbotSession cleverbot = new CleverbotSession("api-key-here");
CleverbotResponse r = cleverbot.GetResponse("Hello!");
Console.WriteLine(r.Response);
```
