using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution881
{
    /// <summary>
    /// 881. Boats to Save People - Medium
    /// <a href="https://leetcode.com/problems/boats-to-save-people">See the problem</a>
    /// </summary>
    public int NumRescueBoats(int[] people, int limit)
    {
        Array.Sort(people);
        int left = 0;
        int right = people.Length - 1;
        int boats = 0;

        while (left <= right)
        {
            if (people[left] + people[right] <= limit)
            {
                left++;
            }
            right--;
            boats++;
        }

        return boats;
    }
}
