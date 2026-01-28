namespace LeetCode.Solutions;

public class Solution2007
{
    /// <summary>
    /// 2007. Find Original Array From Doubled Array - Medium
    /// <a href="https://leetcode.com/problems/find-original-array-from-doubled-array">See the problem</a>
    /// </summary>
    public int[] FindOriginalArray(int[] changed)
    {
        if (changed.Length % 2 != 0)
        {
            return Array.Empty<int>();
        }

        Array.Sort(changed);
        var freq = new Dictionary<int, int>();
        var original = new List<int>();

        foreach (var num in changed)
        {
            if (freq.ContainsKey(num))
            {
                freq[num]++;
            }
            else
            {
                freq[num] = 1;
            }
        }

        foreach (var num in changed)
        {
            if (freq[num] == 0)
            {
                continue;
            }

            if (num == 0)
            {
                if (freq[num] < 2)
                {
                    return Array.Empty<int>();
                }

                freq[num] -= 2;
                original.Add(num);
            }
            else
            {
                int doubleNum = num * 2;
                if (!freq.ContainsKey(doubleNum) || freq[doubleNum] == 0)
                {
                    return Array.Empty<int>();
                }

                freq[num]--;
                freq[doubleNum]--;
                original.Add(num);
            }
        }

        return original.ToArray();
    }
}
