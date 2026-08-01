namespace LeetCode.Solutions;

public class Solution2225
{
    /// <summary>
    /// 2225. Find Players With Zero or One Losses - Medium
    /// <a href="https://leetcode.com/problems/find-players-with-zero-or-one-losses">See the problem</a>
    /// </summary>
    public IList<IList<int>> FindWinners(int[][] matches)
    {
        var wins = new Dictionary<int, int>();
        var losses = new Dictionary<int, int>();

        foreach (var match in matches)
        {
            int winner = match[0];
            int loser = match[1];

            if (!wins.ContainsKey(winner))
                wins[winner] = 0;
            wins[winner]++;

            if (!losses.ContainsKey(loser))
                losses[loser] = 0;
            losses[loser]++;
        }

        var zeroLosses = new List<int>();
        var oneLoss = new List<int>();

        foreach (var player in wins.Keys)
        {
            if (!losses.ContainsKey(player))
                zeroLosses.Add(player);
        }

        foreach (var player in losses.Keys)
        {
            if (losses[player] == 1)
                oneLoss.Add(player);
        }

        zeroLosses.Sort();
        oneLoss.Sort();

        return [zeroLosses, oneLoss];
    }
}
