namespace LeetCode.Solutions;

public class Solution189
{
    /// <summary>
    /// 189. Rotate Array
    /// <a href="https://leetcode.com/problems/rotate-array">See the problem</a>
    /// </summary>
    public void Rotate(int[] nums, int k)
    {
        ShiftRight(nums, 0, nums.Length - 1, k);
    }
    
    private void ShiftRight(int[] array, int startIndex, int lastIndex, int shiftCount)
    {
        var segmentSize = lastIndex - startIndex + 1;
        shiftCount %= segmentSize; // Normalize shift count

        // Reverse the entire segment
        Reverse(array, startIndex, lastIndex);

        // Reverse the first part
        Reverse(array, startIndex, startIndex + shiftCount - 1);

        // Reverse the second part
        Reverse(array, startIndex + shiftCount, lastIndex);
    }
    
    /// <summary>
    /// Reverse a segment of the array
    /// </summary>
    private void Reverse(int[] array, int start, int end) 
    {
        while (start < end) 
        {
            (array[start], array[end]) = (array[end], array[start]);
            start++;
            end--;
        }
    }
}
