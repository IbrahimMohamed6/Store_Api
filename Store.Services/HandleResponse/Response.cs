
namespace Store.Services.HandleResponse
{
    public class Response
    {
        public Response(int statesCode, string? message = null)
        {
            StatesCode = statesCode;
            Message =message?? GetDefultMessageForStatesCode(statesCode);
        }

        public int StatesCode { get; set; }
        public string Message { get; set; }

        private string GetDefultMessageForStatesCode(int statesCode)
           => statesCode switch
           {
               100 => "Continue: The client can continue with its request.",
               101 => "Switching Protocols: The server is switching protocols as requested.",
               102 => "Processing: The request is being processed, but no response is available yet.",
               200 => "OK: The request was successful.",
               201 => "Created: The request was successful and a new resource was created.",
               204 => "No Content: The request was successful, but no content to send in response.",
               400 => "Bad Request: The server couldn't understand the request due to invalid syntax.",
               401 => "Unauthorized: The client must authenticate to get the requested response.",
               403 => "Forbidden: The client does not have access rights to the content.",
               404 => "Not Found: The server cannot find the requested resource.",
               500 => "Internal Server Error: The server encountered an unexpected condition.",
               502 => "Bad Gateway: The server, while acting as a gateway, received an invalid response.",
               503 => "Service Unavailable: The server is not ready to handle the request.",
               504 => "Gateway Timeout: The server, while acting as a gateway, did not receive a timely response.",
               _ => "Unknown Status Code: The server encountered an unknown status code."
           };


    }


}
