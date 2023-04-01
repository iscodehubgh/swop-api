namespace WebAPI.Models
{
    public class ApplicationSettings
    {
        public string JWT_Secret { get; set; } = string.Empty;
        public string Client_URL { get; set; } = string.Empty;
    }
}
