using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution535
{
    /// <summary>
    /// 535. Encode and Decode TinyURL - Medium
    /// <a href="https://leetcode.com/problems/encode-and-decode-tinyurl">See the problem</a>
    /// </summary>
    public class Codec
    {
        private readonly Dictionary<string, string> _shortToLong = [];
        private readonly Dictionary<string, string> _longToShort = [];
        private const string _alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private const string _baseUrl = "http://tinyurl.com/";
        private readonly Random _random = new();

        // Encodes a URL to a shortened URL
        public string Encode(string longUrl)
        {
            if (_longToShort.ContainsKey(longUrl))
            {
                return _longToShort[longUrl];
            }

            var shortUrl = GetRandomString();
            while (_shortToLong.ContainsKey(shortUrl))
            {
                shortUrl = GetRandomString();
            }

            _shortToLong[shortUrl] = longUrl;
            _longToShort[longUrl] = shortUrl;

            return _baseUrl + shortUrl;
        }

        // Decodes a shortened URL to its original URL
        public string Decode(string shortUrl)
        {
            var shortUrlKey = shortUrl.Replace(_baseUrl, string.Empty);
            return _shortToLong.ContainsKey(shortUrlKey) ? _shortToLong[shortUrlKey] : string.Empty;
        }

        private string GetRandomString()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < 6; i++)
            {
                sb.Append(_alphabet[_random.Next(0, _alphabet.Length)]);
            }

            return sb.ToString();
        }
    }
}
