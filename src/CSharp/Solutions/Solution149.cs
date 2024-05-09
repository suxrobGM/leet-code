namespace LeetCode.Solutions;

public class Solution149
{
    /// <summary>
    /// 149. Max Points on a Line - Hard
    /// <a href="https://leetcode.com/problems/max-points-on-a-line">See the problem</a>
    /// </summary>
    public int MaxPoints(int[][] points)
    {
        if (points.Length < 3)
        {
            return points.Length;
        }
        
        var max = 0;
        
        for (var i = 0; i < points.Length; i++)
        {
            var slopes = new Dictionary<string, int>();
            var duplicates = 0;
            var localMax = 0;
            
            for (var j = i + 1; j < points.Length; j++)
            {
                if (points[i][0] == points[j][0] && points[i][1] == points[j][1])
                {
                    duplicates++;
                    continue;
                }
                
                var slope = CalculateSlope(points[i], points[j]);
                var key = slope.Item1 + "/" + slope.Item2;
                
                if (!slopes.ContainsKey(key))
                {
                    slopes[key] = 0;
                }
                
                slopes[key]++;
                localMax = Math.Max(localMax, slopes[key]);
            }
            
            max = Math.Max(max, localMax + duplicates + 1);
        }
        
        return max;
    }
    
    private (int, int) CalculateSlope(int[] point1, int[] point2)
    {
        var dx = point2[0] - point1[0];
        var dy = point2[1] - point1[1];
        
        if (dx == 0)
        {
            return (0, 1);
        }
        
        if (dy == 0)
        {
            return (1, 0);
        }
        
        var gcd = GCD(dx, dy);
        return (dx / gcd, dy / gcd);
    }
    
    private int GCD(int a, int b)
    {
        while (b != 0)
        {
            var temp = b;
            b = a % b;
            a = temp;
        }
        
        return a;
    }
}
