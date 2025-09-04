using System.Text;

namespace LeetCode.Solutions;

public class Solution1797
{
    /// <summary>
    /// 1797. Design Authentication Manager - Medium
    /// <a href="https://leetcode.com/problems/second-largest-digit-in-a-string">See the problem</a>
    /// </summary>
    public class AuthenticationManager
    {
        private readonly int timeToLive;
        private readonly Dictionary<string, int> expiry;

        public AuthenticationManager(int timeToLive)
        {
            this.timeToLive = timeToLive;
            this.expiry = [];
        }

        public void Generate(string tokenId, int currentTime)
        {
            expiry[tokenId] = currentTime + timeToLive;
        }

        public void Renew(string tokenId, int currentTime)
        {
            if (expiry.ContainsKey(tokenId))
            {
                if (expiry[tokenId] > currentTime)
                {
                    // unexpired, so renew
                    expiry[tokenId] = currentTime + timeToLive;
                }
            }
        }

        public int CountUnexpiredTokens(int currentTime)
        {
            // Clean up expired tokens
            var expiredKeys = new List<string>();
            foreach (var kv in expiry)
            {
                if (kv.Value <= currentTime)
                {
                    expiredKeys.Add(kv.Key);
                }
            }
            foreach (var key in expiredKeys) expiry.Remove(key);

            return expiry.Count;
        }
    }
}

