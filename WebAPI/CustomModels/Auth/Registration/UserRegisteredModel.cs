namespace DAL.CustomModels.Auth
{
    public class UserRegisteredModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        
        public string GetFullname(string FirstName, string LastName)
        {
            return $"{FirstName} {LastName}";
        }
    }
}
