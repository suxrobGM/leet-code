using System.Text;


namespace LeetCode.Solutions;

public class Solution1718
{
    private int n, L;
    private int[] res;
    private bool[] used;

    /// <summary>
    /// 1718. Construct the Lexicographically Largest Valid Sequence - Medium
    /// <a href="https://leetcode.com/problems/construct-the-lexicographically-largest-valid-sequence">See the problem</a>
    /// </summary>
    public int[] ConstructDistancedSequence(int n)
    {
        this.n = n;
        L = 2 * n - 1;
        res = new int[L];
        used = new bool[n + 1];

        Dfs(0);
        return res;
    }

    private bool Dfs(int idx)
    {
        // advance to next empty slot
        while (idx < L && res[idx] != 0) idx++;
        if (idx == L) return true; // filled all

        // try larger numbers first for lexicographically largest sequence
        for (int k = n; k >= 1; k--)
        {
            if (used[k]) continue;

            if (k == 1)
            {
                // place single 1 at idx
                res[idx] = 1;
                used[1] = true;
                if (Dfs(idx + 1)) return true;
                used[1] = false;
                res[idx] = 0;
            }
            else
            {
                int j = idx + k;
                if (j < L && res[idx] == 0 && res[j] == 0)
                {
                    res[idx] = res[j] = k;
                    used[k] = true;
                    if (Dfs(idx + 1)) return true;
                    used[k] = false;
                    res[idx] = res[j] = 0;
                }
            }
        }
        return false; // no feasible placement from here
    }
}
