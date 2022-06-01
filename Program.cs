using Twilio.TwiML;
using Twilio.AspNet.Core.MinimalApi;

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
//     response.Message("Hello from a .NET Minimal API!");

//     return Results.Extensions.TwiML(response);
// });

// Voice endpoint returning hand written TwiML
app.MapPost("/voice", () => {
    var response = @"
        <Response>
            <Say>Thanks for calling my .NET Minimal API!</Say>
        </Response>";

    return Results.Text(response, "application/xml");
});

// Voice endpoint using the Twilio library to build
// the TwiML response
// app.MapPost("/voice", () => {
//     var response = new VoiceResponse();
//     response.Say("Thanks for calling my .NET Minimal API!");

//     return Results.Extensions.TwiML(response);
// });

app.Run();
