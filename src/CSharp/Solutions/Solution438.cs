using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution438
{
    /// <summary>
    /// 438. Find All Anagrams in a String - Medium
    /// <a href="https://leetcode.com/problems/find-all-anagrams-in-a-string">See the problem</a>
    /// </summary>
    public IList<int> FindAnagrams(string s, string p)
    {
        var result = new List<int>();
        var pMap = new Dictionary<char, int>();

        foreach (var c in p)
        {
            if (pMap.ContainsKey(c))
            {
                pMap[c]++;
            }
            else
            {
                pMap[c] = 1;
            }
        }

        var left = 0;
        var right = 0;
        var count = pMap.Count;

        while (right < s.Length)
        {
            var c = s[right];

            if (pMap.ContainsKey(c))
            {
                pMap[c]--;

                if (pMap[c] == 0)
                {
                    count--;
                }
            }

            right++;

            while (count == 0)
            {
                if (right - left == p.Length)
                {
                    result.Add(left);
                }

                var c2 = s[left];

                if (pMap.ContainsKey(c2))
                {
                    pMap[c2]++;

                    if (pMap[c2] > 0)
                    {
                        count++;
                    }
                }

                left++;
            }
        }

        return result;
    }
}
