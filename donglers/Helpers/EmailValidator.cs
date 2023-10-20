using System.Text.RegularExpressions;

namespace donglers.Helpers;

public static class EmailValidator
{
    public static bool ValidateEmail(string email)
    {
        string pattern = @"^[\w.-]+@[\w.-]+.\w+$";
        return Regex.IsMatch(email, pattern);
    }
}