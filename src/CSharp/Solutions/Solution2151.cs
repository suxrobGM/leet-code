namespace LeetCode.Solutions;

public class Solution2151
{
    /// <summary>
    /// 2151. Maximum Good People Based on Statements - Hard
    /// <a href="https://leetcode.com/problems/maximum-good-people-based-on-statements">See the problem</a>
    /// </summary>
    public int MaximumGood(int[][] statements)
    {
        int n = statements.Length;
        int maxGood = 0;

        // Iterate through all possible combinations of good and bad people
        for (int mask = 0; mask < (1 << n); mask++)
        {
            bool isValid = true;
            int goodCount = 0;

            for (int i = 0; i < n; i++)
            {
                if ((mask & (1 << i)) != 0) // If person i is considered good
                {
                    goodCount++;
                    for (int j = 0; j < n; j++)
                    {
                        if (statements[i][j] == 1 && (mask & (1 << j)) == 0) // Person i says person j is good, but j is bad
                        {
                            isValid = false;
                            break;
                        }
                        if (statements[i][j] == 0 && (mask & (1 << j)) != 0) // Person i says person j is bad, but j is good
                        {
                            isValid = false;
                            break;
                        }
                    }
                }
                if (!isValid)
                {
                    break;
                }
            }

            if (isValid)
            {
                maxGood = Math.Max(maxGood, goodCount);
            }
        }

        return maxGood;
    }
}
