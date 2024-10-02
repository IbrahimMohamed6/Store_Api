
namespace Store.Services.HandleResponse
{
    public class CustomExeption : Response
    {
        public CustomExeption(int statesCode, string? message = null,string? details=null) 
            : base(statesCode, message)
        {
            Details = details;
        }
        public string? Details { get; set; }
    }
}
