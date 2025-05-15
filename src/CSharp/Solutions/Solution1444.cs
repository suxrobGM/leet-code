namespace LeetCode.Solutions;

public class Solution1444
{
    /// <summary>
    /// 1444. Number of Ways of Cutting a Pizza - Hard
    /// <a href="https://leetcode.com/problems/number-of-ways-of-cutting-a-pizza">See the problem</a>
    /// </summary>
    public int Ways(string[] pizza, int k)
    {
        const int MOD = 1_000_000_007;
        int rows = pizza.Length, cols = pizza[0].Length;
        int[,] apples = new int[rows + 1, cols + 1];

        // Step 1: Build suffix sum of apples
        for (int r = rows - 1; r >= 0; r--)
        {
            for (int c = cols - 1; c >= 0; c--)
            {
                apples[r, c] = (pizza[r][c] == 'A' ? 1 : 0) +
                               apples[r + 1, c] + apples[r, c + 1] - apples[r + 1, c + 1];
            }
        }

        // Step 2: Memoized DP
        var memo = new int[k, rows, cols];
        for (int i = 0; i < k; i++)
            for (int j = 0; j < rows; j++)
                for (int l = 0; l < cols; l++)
                    memo[i, j, l] = -1;

        int Dp(int cuts, int r, int c)
        {
            if (apples[r, c] == 0) return 0; // No apple in this sub-pizza
            if (cuts == 0) return 1;        // Last piece, and it has apple

            if (memo[cuts, r, c] != -1) return memo[cuts, r, c];

            int res = 0;

            // Try horizontal cuts
            for (int nr = r + 1; nr < rows; nr++)
            {
                if (apples[r, c] - apples[nr, c] > 0) // top has apple
                    res = (res + Dp(cuts - 1, nr, c)) % MOD;
            }

            // Try vertical cuts
            for (int nc = c + 1; nc < cols; nc++)
            {
                if (apples[r, c] - apples[r, nc] > 0) // left has apple
                    res = (res + Dp(cuts - 1, r, nc)) % MOD;
            }

            memo[cuts, r, c] = res;
            return res;
        }

        return Dp(k - 1, 0, 0);
    }
}
