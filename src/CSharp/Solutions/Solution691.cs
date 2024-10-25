using System.Text;

namespace LeetCode.Solutions;

public class Solution691
{
    /// <summary>
    /// 691. Stickers to Spell Word - Hard
    /// <a href="https://leetcode.com/problems/stickers-to-spell-word">See the problem</a>
    /// </summary>
    public int MinStickers(string[] stickers, string target)
    {
        var n = stickers.Length;
        // Frequency maps for each sticker (only letters that appear in the target)
        var stickerFreqs = new int[n][];
        for (var i = 0; i < n; i++)
        {
            stickerFreqs[i] = new int[26];
            foreach (var c in stickers[i])
            {
                stickerFreqs[i][c - 'a']++;
            }
        }

        // Memoization dictionary to store the minimum number of stickers for each target state
        var memo = new Dictionary<string, int>
        {
            [""] = 0  // Base case: if target is empty, 0 stickers are needed
        };

        // Helper function for DFS + Memoization
        int DFS(string remaining)
        {
            if (memo.ContainsKey(remaining)) return memo[remaining];
            var targetFreq = new int[26];
            foreach (var c in remaining)
            {
                targetFreq[c - 'a']++;
            }

            int ans = int.MaxValue;
            // Try each sticker to reduce the remaining target
            foreach (var sticker in stickerFreqs)
            {
                // If the sticker does not contain the first letter of the remaining target, skip it
                if (sticker[remaining[0] - 'a'] == 0) continue;

                // Build a new target by using the current sticker
                var newTarget = new StringBuilder();
                for (var i = 0; i < 26; i++)
                {
                    if (targetFreq[i] > 0)
                    {
                        var remainingCount = Math.Max(0, targetFreq[i] - sticker[i]);
                        for (var j = 0; j < remainingCount; j++)
                        {
                            newTarget.Append((char)('a' + i));
                        }
                    }
                }

                var newTargetStr = newTarget.ToString();
                var subProblem = DFS(newTargetStr);
                if (subProblem != -1)
                {
                    ans = Math.Min(ans, 1 + subProblem); // 1 for the current sticker
                }
            }

            memo[remaining] = (ans == int.MaxValue) ? -1 : ans;
            return memo[remaining];
        }

        // Start DFS from the full target string
        return DFS(target);
    }
}
