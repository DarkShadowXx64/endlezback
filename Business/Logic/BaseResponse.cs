

namespace Business.Logic
{
    public class BaseResponse<T> where T : class
    {
        public string Message { get; set; } = "OK";
        public int statusCode { get; set; } = 200;
        public T? DataObject { get; set; }
        public IReadOnlyList<T> ListDataObject { get; set; }


        public BaseResponse()
        {
            ListDataObject = new List<T>();
        }

    }
}
