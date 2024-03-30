namespace LeetCode.Solutions;

public class Solution118
{
    /// <summary>
    /// 118. Pascal's Triangle - Easy
    /// <a href="https://leetcode.com/problems/pascals-triangle">See the problem</a>
    /// </summary>
    public IList<IList<int>> Generate(int numRows)
    {
        var triangle = new List<IList<int>>();

        for (var i = 0; i < numRows; i++)
        {
            var row = new List<int>();
            
            for (var j = 0; j <= i; j++)
            {
                var coefficient = BinomialCoefficient(i, j);
                row.Add(coefficient);
            }
            
            triangle.Add(row);
        }
        
        return triangle;
    }
    
    private int BinomialCoefficient(int n, int k)
    {
        var coefficient = 1; 
  
        // Since C(n, k) = C(n, n-k) 
        if (k > n - k)
        {
            k = n - k;
        }
  
        // Calculate value of
        // [n * ( n - 1) *---* (n - k + 1)] / [k * (k - 1) *----* 1] 
        for (var i = 0; i < k; ++i) 
        { 
            coefficient *= n - i; 
            coefficient /= i + 1; 
        } 
  
        return coefficient; 
    }
}
