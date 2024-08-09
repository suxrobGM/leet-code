namespace LeetCode.Solutions;

public class Solution454
{
    /// <summary>
    /// 454. 4Sum II - Medium
    /// <a href="https://leetcode.com/problems/4sum-ii">See the problem</a>
    /// </summary>
    public int FourSumCount(int[] nums1, int[] nums2, int[] nums3, int[] nums4) 
    {
        var count = 0;
        var sum1 = new Dictionary<int, int>();
        
        foreach (var num1 in nums1)
        {
            foreach (var num2 in nums2)
            {
                var sum = num1 + num2;
                
                if (sum1.ContainsKey(sum))
                {
                    sum1[sum]++;
                }
                else
                {
                    sum1[sum] = 1;
                }
            }
        }
        
        foreach (var num3 in nums3)
        {
            foreach (var num4 in nums4)
            {
                var sum = num3 + num4;
                
                if (sum1.ContainsKey(-sum))
                {
                    count += sum1[-sum];
                }
            }
        }
        
        return count;
    }
}
