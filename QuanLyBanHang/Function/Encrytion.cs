using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Function
{
    public static class Encrytion
    {
        /// <summary>
        ///     Mã hóa 1 chiều
        /// </summary>
        /// <param name="_input"> Chuỗi cần mã hóa</param>
        /// <returns>Chuỗi đã được mã hóa chiều</returns>
        public static string Encrypt(string _input)
        {
            // 1. Mã hóa MD5
            // 2. Sử dụng hàm mã hóa 2 chiều
            using (SHA256 sha256Hash = SHA256.Create()) //<=> md5Hash.dispose
            {
                string hash = GetHash(sha256Hash, _input);
                return MyEncrypt(hash);
            }

        }
        private static string GetHash(HashAlgorithm hashAlgorithm, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
        /// <summary>
        /// Mã hóa 2 chiều
        /// </summary>
        /// <param name="_input">Chuỗi cần mã hóa</param>
        /// <returns>Chuỗi đã được mã hóa 2 chiều</returns>
        public static string MyEncrypt(string _input)
        {
            // abc ~> 48 49 50: 48 + 0 + (49%2) ; 49 + 1 + (50%2)
            // chuyển thành mảng char 
            char[] char_input = _input.ToCharArray();
            // select val + ind ~> ano. type
            var input_withIndex = char_input.Select((val, ind) => new { val, ind }).ToArray();
            // áp dụng công thức 
            var char_input_encripted = input_withIndex.Select(c => c.val +
           c.ind + (input_withIndex.Length > c.ind + 1 ? input_withIndex[c.ind + 1].val % 2 : 0)).Select
           (c => (char)c).ToArray();
            // chuyển về kiểu string 
            string resval = new string(char_input_encripted);
            return resval;
        }
        /// <summary>
        /// Giải mã
        /// </summary>
        /// <param name="_input">chuỗi cần giải mã</param>
        /// <returns>trả ra chuỗi đã giải mã</returns>
        public static string Mydecrypt(string _input)
        {
            char[] char_input = _input.ToCharArray();
            int length = char_input.Length;
            for (int i = length - 1; i >= 0; i--)
            {
                char_input[i] = (char)(char_input[i] - i - (i == length - 1 ? 0 : char_input[i + 1] % 2));
            }
            string resVal = new string(char_input);
            return resVal;
        }
    }
}
