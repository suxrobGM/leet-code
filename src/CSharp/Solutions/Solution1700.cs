using System.Text;


namespace LeetCode.Solutions;

public class Solution1700
{
    /// <summary>
    /// 1700. Number of Students Unable to Eat Lunch - Easy
    /// <a href="https://leetcode.com/problems/number-of-students-unable-to-eat-lunch">See the problem</a>
    /// </summary>
    public int CountStudents(int[] students, int[] sandwiches)
    {
        int need0 = 0, need1 = 0;
        foreach (var s in students)
        {
            if (s == 0)
            {
                need0++;
            }
            else
            {
                need1++;
            }
        }

        foreach (var sw in sandwiches)
        {
            if (sw == 0)
            {
                if (need0 == 0) break;
                need0--;
            }
            else
            {
                if (need1 == 0) break;
                need1--;
            }
        }

        return need0 + need1;
    }
}
