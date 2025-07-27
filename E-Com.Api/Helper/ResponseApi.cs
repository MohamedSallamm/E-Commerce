namespace E_Com.Api.Helper
{


    public class ResponseApi
    {

        public ResponseApi(int statuscode, string message = null)
        {
            StatusCode = statuscode;
            Message = message ?? GetMessageFromStatusCode(StatusCode);
        }

        private string GetMessageFromStatusCode(int statusCode)
        {
            return statusCode switch
            {
                200 => "OK",
                201 => "Created",
                204 => "No Content",
                400 => "Bad Request",
                401 => "Unauthorized",
                403 => "Forbidden",
                404 => "Not Found",
                500 => "Internal Server Error",
                _ => "Null",
            };
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

    }

}