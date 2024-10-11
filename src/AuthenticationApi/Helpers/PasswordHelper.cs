namespace AuthenticationApi.Helpers;

public class PasswordHelper
{
    public string HashePassword(string password)
    {
        return BCrypt.Net.BCrypt.EnhancedHashPassword(password, 10);
    }
    public bool VerfifyPassword(string password,string storePassword)
    {
        return BCrypt.Net.BCrypt.EnhancedVerify(password, storePassword);
    }
}