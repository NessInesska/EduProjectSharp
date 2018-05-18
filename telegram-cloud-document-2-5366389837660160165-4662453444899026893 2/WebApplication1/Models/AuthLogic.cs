namespace WebApplication1.Models
{
    public static class AuthLogic
    {
        public static bool CanAuthenticate(string userName, string password)
        {
            return userName == password;
        }
    }
}