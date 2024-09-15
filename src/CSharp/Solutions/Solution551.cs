using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution551
{
    /// <summary>
    /// 551. Student Attendance Record I - Easy
    /// <a href="https://leetcode.com/problems/student-attendance-record-i">See the problem</a>
    /// </summary>
    public bool CheckRecord(string s)
    {
        int absentCount = 0;
        int lateCount = 0;

        foreach (char c in s)
        {
            if (c == 'A')
            {
                absentCount++;
                lateCount = 0;
            }
            else if (c == 'L')
            {
                lateCount++;
            }
            else
            {
                lateCount = 0;
            }

            if (absentCount > 1 || lateCount > 2)
            {
                return false;
            }
        }

        return true;
    }
}
