using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution670
{
    /// <summary>
    /// 670. Maximum Swap - Medium
    /// <a href="https://leetcode.com/problems/maximum-swap">See the problem</a>
    /// </summary>
    public int MaximumSwap(int num)
    {
        var numStr = num.ToString();
        var last = new int[10];

        for (var i = 0; i < numStr.Length; i++)
        {
            last[numStr[i] - '0'] = i;
        }

        for (var i = 0; i < numStr.Length; i++)
        {
            for (var d = 9; d > numStr[i] - '0'; d--)
            {
                if (last[d] > i)
                {
                    var swap = numStr.ToCharArray();
                    swap[i] = (char)(d + '0');
                    swap[last[d]] = numStr[i];
                    return int.Parse(new string(swap));
                }
            }
        }

        return num;
    }
}
