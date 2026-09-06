namespace LeetCode.Solutions;

public class Solution2271
{
    /// <summary>
    /// 2271. Maximum White Tiles Covered by a Carpet - Medium
    /// <a href="https://leetcode.com/problems/maximum-white-tiles-covered-by-a-carpet">See the problem</a>
    /// </summary>
    public int MaximumWhiteTiles(int[][] tiles, int carpetLen)
    {
        Array.Sort(tiles, (left, right) => left[0].CompareTo(right[0]));

        var covered = 0L;
        var right = 0;
        var maximum = 0L;

        for (var left = 0; left < tiles.Length; left++)
        {
            var carpetEnd = (long)tiles[left][0] + carpetLen;

            while (right < tiles.Length && (long)tiles[right][1] + 1 <= carpetEnd)
            {
                covered += (long)tiles[right][1] - tiles[right][0] + 1;
                right++;
            }

            var partial = 0L;

            if (right < tiles.Length)
            {
                partial = Math.Max(0L, Math.Min(carpetEnd, (long)tiles[right][1] + 1) - tiles[right][0]);
            }

            maximum = Math.Max(maximum, covered + partial);

            if (right > left)
            {
                covered -= (long)tiles[left][1] - tiles[left][0] + 1;
            }
            else
            {
                // The current tile is longer than the carpet, so the next window starts at the next tile.
                right = left + 1;
            }
        }

        return (int)maximum;
    }
}
