using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessDefinitionLibrary.Authentication
{
    /// <summary>
    /// This class assembles the three pieces of BCrypt functionality needed to hash and validate passwords.
    /// </summary>
    public static class BCryptTool
    {
        private static string GetRandomSalt() => BCrypt.Net.BCrypt.GenerateSalt(12);

        public static string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password, GetRandomSalt());

        public static bool ValidatePassword(string password, string correctHash) => BCrypt.Net.BCrypt.Verify(password, correctHash);
    }
}
