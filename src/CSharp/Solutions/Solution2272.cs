namespace LeetCode.Solutions;

public class Solution2272
{
    /// <summary>
    /// 2272. Substring With Largest Variance - Hard
    /// <a href="https://leetcode.com/problems/substring-with-largest-variance">See the problem</a>
    /// </summary>
    public int LargestVariance(string s)
    {
        var frequencies = new int[26];

        foreach (var character in s)
        {
            frequencies[character - 'a']++;
        }

        var largestVariance = 0;

        for (var majority = 0; majority < 26; majority++)
        {
            if (frequencies[majority] == 0)
            {
                continue;
            }

            for (var minority = 0; minority < 26; minority++)
            {
                if (majority == minority || frequencies[minority] == 0)
                {
                    continue;
                }

                var majorityCount = 0;
                var minorityCount = 0;
                var remainingMinority = frequencies[minority];

                foreach (var character in s)
                {
                    if (character - 'a' == majority)
                    {
                        majorityCount++;
                    }
                    else if (character - 'a' == minority)
                    {
                        minorityCount++;
                        remainingMinority--;
                    }

                    if (minorityCount > 0)
                    {
                        largestVariance = Math.Max(largestVariance, majorityCount - minorityCount);
                    }

                    // Discard a prefix that hurts the difference if another minority
                    // character can still make a valid substring.
                    if (minorityCount > majorityCount && remainingMinority > 0)
                    {
                        majorityCount = 0;
                        minorityCount = 0;
                    }
                }
            }
        }

        return largestVariance;
    }
}
