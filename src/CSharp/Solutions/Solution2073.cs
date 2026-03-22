namespace LeetCode.Solutions;

public class Solution2073
{
    /// <summary>
    /// 2073. Time Needed to Buy Tickets - Easy
    /// <a href="https://leetcode.com/problems/time-needed-to-buy-tickets">See the problem</a>
    /// </summary>
    public int TimeRequiredToBuy(int[] tickets, int k)
    {
        var time = 0;
        var n = tickets.Length;

        while (tickets[k] > 0)
        {
            for (var i = 0; i < n; i++)
            {
                if (tickets[i] > 0)
                {
                    tickets[i]--;
                    time++;
                }

                if (tickets[k] == 0)
                    break;
            }
        }

        return time;
    }
}
