namespace Template.Domain.Common
{
    public class Response<T>
    {
        public string Title { get; set; }

        public int Status { get; set; }

        public bool IsSuccess { get; set; }

        public T Data { get; set; }

        public Response()
        {
        }
    }
}
