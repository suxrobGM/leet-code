using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1450
{
    /// <summary>
    /// 1450. Number of Students Doing Homework at a Given Time - Easy
    /// <a href="https://leetcode.com/problems/number-of-students-doing-homework-at-a-given-time">See the problem</a>
    /// </summary>
    public int BusyStudent(int[] startTime, int[] endTime, int queryTime)
    {
        int count = 0;
        for (int i = 0; i < startTime.Length; i++)
        {
            if (startTime[i] <= queryTime && endTime[i] >= queryTime)
            {
                count++;
            }
        }
        return count;
    }
}
