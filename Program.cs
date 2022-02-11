using System.Globalization;
using Twilio.TwiML;
using Twilio.TwiML.Messaging;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => {
    return "Hello, world!";
});

// SMS endpoint returning hand written TwiML
app.MapPost("/sms", () => {
    var response = @"
        <Response>
            <Message>Hello from a .NET Minimal API!</Message>
        </Response>";

    return Results.Text(response, "application/xml");
});


// SMS endpoint using the Twilio library to build
// the TwiML response
// app.MapPost("/sms", () => {
//     var response = new MessagingResponse();
//     response.Append(new Message(
//         body: $"Thanks for messaging my dotnet minimal api!"
//     ));

//     return Results.Text(response.ToString(), "application/xml");
// });

// Voice endpoing returning hand written TwiML
app.MapPost("/voice", () => {
    var response = @"
        <Response>
            <Say>Thanks for calling my dotnet minimal api!</Say>
        </Response>";

    return Results.Text(response, "application/xml");
});

// Voice enpoint using the Twilio library to build
// the TwiML response
// app.MapPost("/voice", () => {
//     var response = new VoiceResponse();
//     response.Say("Thanks for calling my dotnet minimal api!");

//     return Results.Text(response.ToString(), "application/xml");
// });

app.Run();
