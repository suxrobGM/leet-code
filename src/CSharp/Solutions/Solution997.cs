namespace LeetCode.Solutions;

public class Solution997
{
    /// <summary>
    /// 997. Find the Town Judge - Easy
    /// <a href="https://leetcode.com/problems/find-the-town-judge">See the problem</a>
    /// </summary>
    public int FindJudge(int n, int[][] trust)
    {
        var trustCount = new int[n + 1];
        
        foreach (var pair in trust)
        {
            trustCount[pair[0]]--;
            trustCount[pair[1]]++;
        }
        
        for (var i = 1; i <= n; i++)
        {
            if (trustCount[i] == n - 1)
            {
                return i;
            }
        }
        
        return -1;
    }
}
