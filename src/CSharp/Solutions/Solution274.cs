namespace LeetCode.Solutions;

public class Solution274
{
    /// <summary>
    /// 274. H-Index
    /// <a href="https://leetcode.com/problems/h-index">See the problem</a>
    /// </summary>
    public int HIndex(int[] citations)
    {
        Array.Sort(citations, (a, b) => b - a); // QuickSort in descending order
        var hIndex = 0;
        
        for (var i = 0; i < citations.Length; i++)
        {
            if (citations[i] >= i + 1) 
            {
                hIndex = i + 1;
            }
            else 
            {
                break;
            }
        }

        return hIndex;
    }
}
