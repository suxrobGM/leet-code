
namespace LeetCode.Solutions;

public class Solution799
{
    /// <summary>
    /// 799. Champagne Tower - Medium
    /// <a href="https://leetcode.com/problems/champagne-tower">See the problem</a>
    /// </summary>
    public double ChampagneTower(int poured, int query_row, int query_glass)
    {
        var tower = new double[101][];
        for (var i = 0; i < 101; i++)
        {
            tower[i] = new double[i + 1];
        }

        tower[0][0] = poured;

        for (var i = 0; i < 100; i++)
        {
            for (var j = 0; j <= i; j++)
            {
                if (tower[i][j] > 1)
                {
                    tower[i + 1][j] += (tower[i][j] - 1) / 2;
                    tower[i + 1][j + 1] += (tower[i][j] - 1) / 2;
                    tower[i][j] = 1;
                }
            }
        }

        return tower[query_row][query_glass];
    }
}
