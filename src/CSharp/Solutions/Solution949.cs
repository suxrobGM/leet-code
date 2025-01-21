using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution949
{
    /// <summary>
    /// 949. Largest Time for Given Digits - Medium
    /// <a href="https://leetcode.com/problems/largest-time-for-given-digits">See the problem</a>
    /// </summary>
    public string LargestTimeFromDigits(int[] arr)
    {
        var maxTime = -1;
        var maxTimeStr = string.Empty;

        for (var i = 0; i < arr.Length; i++)
        {
            for (var j = 0; j < arr.Length; j++)
            {
                if (j == i)
                {
                    continue;
                }

                for (var k = 0; k < arr.Length; k++)
                {
                    if (k == i || k == j)
                    {
                        continue;
                    }

                    var l = 6 - i - j - k;

                    var hours = arr[i] * 10 + arr[j];
                    var minutes = arr[k] * 10 + arr[l];

                    if (hours < 24 && minutes < 60)
                    {
                        var time = hours * 60 + minutes;

                        if (time > maxTime)
                        {
                            maxTime = time;
                            maxTimeStr = $"{arr[i]}{arr[j]}:{arr[k]}{arr[l]}";
                        }
                    }
                }
            }
        }

        return maxTimeStr;
    }
}
