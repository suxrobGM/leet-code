using System.Text;

namespace LeetCode.Solutions;

public class Solution2227
{
    /// <summary>
    /// 2227. Encrypt and Decrypt Strings - Hard
    /// <a href="https://leetcode.com/problems/encrypt-and-decrypt-strings">See the problem</a>
    /// </summary>
    public class Encrypter
    {
        private readonly Dictionary<char, string> _encryptMap;
        private readonly Dictionary<string, int> _encryptedCounts;

        public Encrypter(char[] keys, string[] values, string[] dictionary)
        {
            _encryptMap = new Dictionary<char, string>(keys.Length);
            _encryptedCounts = new Dictionary<string, int>(dictionary.Length);

            for (int i = 0; i < keys.Length; i++)
                _encryptMap[keys[i]] = values[i];

            // Decrypting is counting how many dictionary words encrypt to the given string,
            // so precompute the frequency of every encrypted dictionary word.
            foreach (var word in dictionary)
            {
                var encrypted = Encrypt(word);

                if (encrypted.Length == 0)
                    continue;

                _encryptedCounts.TryGetValue(encrypted, out int count);
                _encryptedCounts[encrypted] = count + 1;
            }
        }

        public string Encrypt(string word1)
        {
            var sb = new StringBuilder(word1.Length * 2);

            foreach (var c in word1)
            {
                if (!_encryptMap.TryGetValue(c, out var value))
                    return string.Empty;

                sb.Append(value);
            }

            return sb.ToString();
        }

        public int Decrypt(string word2)
        {
            return _encryptedCounts.GetValueOrDefault(word2, 0);
        }
    }
}
