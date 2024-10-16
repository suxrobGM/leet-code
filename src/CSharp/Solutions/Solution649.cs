namespace LeetCode.Solutions;

public class Solution649
{
    /// <summary>
    /// 649. Dota2 Senate - Medium
    /// <a href="https://leetcode.com/problems/dota2-senate">See the problem</a>
    /// </summary>
    public string PredictPartyVictory(string senate)
    {
        var radiantQueue = new Queue<int>();
        var direQueue = new Queue<int>();
        var n = senate.Length;

        // Initialize the queues with the index of each senator
        for (var i = 0; i < n; i++)
        {
            if (senate[i] == 'R')
            {
                radiantQueue.Enqueue(i);
            }
            else
            {
                direQueue.Enqueue(i);
            }
        }

        // Simulate the rounds
        while (radiantQueue.Count > 0 && direQueue.Count > 0)
        {
            var radiantIndex = radiantQueue.Dequeue();
            var direIndex = direQueue.Dequeue();

            // Whoever has the smaller index acts first and bans the other party's senator
            if (radiantIndex < direIndex)
            {
                // Radiant bans Dire, move Radiant to the back of the queue for the next round
                radiantQueue.Enqueue(radiantIndex + n);
            }
            else
            {
                // Dire bans Radiant, move Dire to the back of the queue for the next round
                direQueue.Enqueue(direIndex + n);
            }
        }

        // If one of the queues is empty, the other party wins
        return radiantQueue.Count > 0 ? "Radiant" : "Dire";
    }
}
