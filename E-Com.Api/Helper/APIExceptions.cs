namespace E_Com.Api.Helper
{
    public class APIExceptions : ResponseApi
    {
        public APIExceptions(int statuscode, string message = null, string Details = null) : base(statuscode, message)
        {
        }

        public string Details { get; set; }
    }
}
