namespace IDM.API.Helpers
{
    public static class Hashing
    {
        public static void CreatePasswordHash(string password,out byte[] passwordHash,out byte[] passwordSalt) {
            using(var hmac = new System.Security.Cryptography.HMACSHA512()) {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool VerifyPasswordHash(string password,byte[] passwordHash,byte[] passwordSalt) {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt)) {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for (int i=0; i < computedHash.Length; i++)
                    if (computedHash[i] != passwordHash[i])
                        return false;
            }
            return true;
        }
    }
}