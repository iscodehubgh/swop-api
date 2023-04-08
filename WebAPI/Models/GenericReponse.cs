namespace WebAPI.Models
{
    public class GenericReponse<T> where T : class, new()
    {
        public T Data { get; set; } = new T();
        public List<string> ErrorMessages { get; set; } = new List<string>();
    }
}
