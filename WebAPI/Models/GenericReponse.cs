namespace WebAPI.Models
{
    public class GenericReponse<T> where T : class, new()
    {
        public T Data { get; set; } = new T();
        public int StatusCode { get; set; }
        public List<string> ErrorMessages { get; set; } = new List<string>();
    }
}
