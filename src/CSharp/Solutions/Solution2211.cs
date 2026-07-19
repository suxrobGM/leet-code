namespace LeetCode.Solutions;

public class Solution2211
{
    /// <summary>
    /// 2211. Count Collisions on a Road - Medium
    /// <a href="https://leetcode.com/problems/count-collisions-on-a-road">See the problem</a>
    /// </summary>
    public int CountCollisions(string directions)
    {
        // Cars moving left ('L') at the very start never hit anything, and cars
        // moving right ('R') at the very end never hit anything. Every other
        // moving car ('L' or 'R') is guaranteed to eventually collide and stop,
        // so each contributes exactly one collision.
        var left = 0;
        while (left < directions.Length && directions[left] == 'L')
        {
            left++;
        }

        var right = directions.Length - 1;
        while (right >= 0 && directions[right] == 'R')
        {
            right--;
        }

        var collisions = 0;
        for (var i = left; i <= right; i++)
        {
            if (directions[i] != 'S')
            {
                collisions++;
            }
        }

        return collisions;
    }
}
