using System;
namespace Lab1JC.Model
{
    public class UserModel
    {
        public static bool CredentialsAreValid(string emailAddress, string password) {
            return emailAddress.Length > 5 && password.Length > 5;
        }
    }
}
