namespace LeetCode.Solutions;

public class Solution2126
{
    /// <summary>
    /// 2126. Destroying Asteroids - Medium
    /// <a href="https://leetcode.com/problems/destroying-asteroids">See the problem</a>
    /// </summary>
    public bool AsteroidsDestroyed(int mass, int[] asteroids)
    {
        Array.Sort(asteroids);
        long current = mass;
        foreach (var asteroid in asteroids)
        {
            if (current < asteroid)
            {
                return false;
            }
            current += asteroid;
        }

        return true;
    }
}
