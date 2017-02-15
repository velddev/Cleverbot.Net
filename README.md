# Cleverbot.Net
A cleverbot wrapper for .Net 4.5/4.6.

## How to set up?
First, get an api key from http://www.cleverbot.com/api/ to be able to create a instance of 
Cleverbot. To further set up Cleverbot.Net, download it from the nuget package manager.
>Install-Package Cleverbot

Once you've installed Cleverbot.Net in your C# project. Include the new header `using Cleverbot.Net;`

## Example code

I have two different kind of example code, one sync and one async.

Sync
```Csharp
Cleverbot cleverbot = new Cleverbot("api-key-here");
CleverbotResponse r = cleverbot.GetResponse("Hello!");
Console.WriteLine(r.Response);
```

Async
```csharp
Cleverbot cleverbot = new Cleverbot("api-key-here");
await cleverbot.GetResponseAsync("Hello!", r => {
  Label1.Text = r.Response;
});
Label1.Text = "Cleverbot is typing...";
```
