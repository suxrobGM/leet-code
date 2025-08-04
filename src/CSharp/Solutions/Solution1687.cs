using System.Text;


namespace LeetCode.Solutions;

public class Solution1687
{
    /// <summary>
    /// 1687. Delivering Boxes from Storage to Ports - Hard
    /// <a href="https://leetcode.com/problems/delivering-boxes-from-storage-to-ports">See the problem</a>
    /// </summary>
    public int BoxDelivering(int[][] boxes, int portsCount, int maxBoxes, int maxWeight)
    {
        int n = boxes.Length;
        int[] dp = new int[n + 1];  // dp[i]: min trips to deliver boxes[i:]
        int j = 0, weight = 0, boxCount = 0, trips = 0;
        var dq = new LinkedList<int>();
        dq.AddLast(0);

        for (int i = 0; i < n; i++)
        {
            // Expand the window [j, i]
            if (i == 0 || boxes[i][0] != boxes[i - 1][0])
                trips++;

            weight += boxes[i][1];
            boxCount++;

            // Shrink the window if over capacity
            while (boxCount > maxBoxes || weight > maxWeight || (j < i && dp[j] == dp[j + 1]))
            {
                weight -= boxes[j][1];
                if (boxes[j][0] != boxes[j + 1][0])
                    trips--;
                j++;
                boxCount--;
            }

            // dp[j] + trips + 1 (return trip)
            dp[i + 1] = dp[j] + trips + 1;
        }

        return dp[n];
    }
}
