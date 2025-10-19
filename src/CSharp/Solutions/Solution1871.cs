using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1871
{
    /// <summary>
    /// 1871. Jump Game VII - Medium
    /// <a href="https://leetcode.com/problems/jump-game-vii">See the problem</a>
    /// </summary>
    public bool CanReach(string s, int minJump, int maxJump)
    {
        int n = s.Length;
        var can = new bool[n];
        var pref = new int[n]; // pref[i] = number of reachable indices in [0..i]

        can[0] = true;
        pref[0] = 1;

        for (int i = 1; i < n; i++)
        {
            if (s[i] == '0')
            {
                int l = i - maxJump; if (l < 0) l = 0;
                int r = i - minJump;

                if (r >= 0 && l <= r)
                {
                    int leftPref = l > 0 ? pref[l - 1] : 0;
                    int reachableInWindow = pref[r] - leftPref;
                    if (reachableInWindow > 0) can[i] = true;
                }
            }

            pref[i] = pref[i - 1] + (can[i] ? 1 : 0);
        }

        return can[n - 1];
    }
}
