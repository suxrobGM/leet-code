using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1601
{
    /// <summary>
    /// 1601. Maximum Number of Achievable Transfer Requests - Hard
    /// <a href="https://leetcode.com/problems/maximum-number-of-achievable-transfer-requests">See the problem</a>
    /// </summary>
    public int MaximumRequests(int n, int[][] requests)
    {
        int maxRequests = 0;
        int m = requests.Length;

        for (int mask = 0; mask < (1 << m); mask++)
        {
            int[] netChange = new int[n];
            int requestCount = 0;

            for (int i = 0; i < m; i++)
            {
                if (((mask >> i) & 1) == 1)
                {
                    int from = requests[i][0];
                    int to = requests[i][1];
                    netChange[from]--;
                    netChange[to]++;
                    requestCount++;
                }
            }

            bool isValid = true;
            for (int i = 0; i < n; i++)
            {
                if (netChange[i] != 0)
                {
                    isValid = false;
                    break;
                }
            }

            if (isValid)
            {
                maxRequests = Math.Max(maxRequests, requestCount);
            }
        }

        return maxRequests;
    }
}
