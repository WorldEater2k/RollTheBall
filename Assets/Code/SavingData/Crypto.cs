namespace RollTheBall
{
    internal static class Crypto
    {
        public static string CryptoXOR(string data, ushort key = 87)
        {
            string result = "";
            foreach (var symbol in data)
            {
                result += (char)(symbol ^ key);
            }
            return result;
        }
    }
}
