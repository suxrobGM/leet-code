namespace LeetCode.Solutions;

public class Solution1095
{
    public interface IMountainArray {
        int Get(int index);
        int Length();
    }
    
    /// <summary>
    /// 1095. Find in Mountain Array - Hard
    /// <a href="https://leetcode.com/problems/find-in-mountain-array">See the problem</a>
    /// </summary>
    public int FindInMountainArray(int target, IMountainArray mountainArr)
    {
        // First, find the peak of the mountain array.
        var peak = FindPeak(mountainArr);
        
        // Attempt to find the target in the ascending part of the array.
        var targetIndex = TernarySearch(mountainArr, 0, peak, target, true);
        
        if (targetIndex != -1)
        {
            return targetIndex; // Target found in the ascending part.
        }

        // Target not found in ascending part, search in the descending part.
        return TernarySearch(mountainArr, peak + 1, mountainArr.Length() - 1, target, false);
    }

    /// <summary>
    /// Find the peak of the mountain array. Uses ternary search to find the peak.
    /// </summary>
    /// <param name="arr">The mountain array to search in.</param>
    /// <returns> The index of the peak element.</returns>
    private int FindPeak(IMountainArray arr)
    {
        var start = 0;
        var end = arr.Length() - 1;
        
        while (start < end)
        {
            var mid1 = start + (end - start) / 3;
            var mid2 = end - (end - start) / 3;
            
            // Comparing the values at mid points to determine the direction of the peak.
            if (arr.Get(mid1) < arr.Get(mid2))
            {
                start = mid1 + 1; // The peak is in the right one-third of the range.
            }
            else
            {
                end = mid2 - 1; // The peak is in the left one-third of the range.
            }
        }

        // At the end of the loop, start == end == peak of the mountain.
        return start;
    }

    /// <summary>
    /// Perform ternary search on the mountain array.
    /// </summary>
    /// <param name="arr">The mountain array to search in.</param>
    /// <param name="left">The left boundary of the search range.</param>
    /// <param name="right">The right boundary of the search range.</param>
    /// <param name="target">The target element to search for.</param>
    /// <param name="ascending">
    ///  True if searching in the ascending part of the mountain array. False if searching in the descending part.
    /// </param>
    /// <returns>The index of the target element if found, otherwise -1.</returns>
    private int TernarySearch(IMountainArray arr, int left, int right, int target, bool ascending)
    {
        while (left <= right)
        {
            // Calculate two mid points for ternary search.
            var mid1 = left + (right - left) / 3;
            var mid2 = right - (right - left) / 3;
            
            // Retrieve values at the mid points.
            var val1 = arr.Get(mid1);
            var val2 = arr.Get(mid2);

            if (val1 == target)
            {
                return mid1;
            }
            
            if (val2 == target)
            {
                return mid2;
            }

            // Narrow down the search range based on whether we're searching an ascending or descending part.
            if (ascending)
            {
                if (target < val1)
                {
                    right = mid1 - 1; // Target is in the left one-third of the range.
                }
                else if (target > val2)
                {
                    left = mid2 + 1; // Target is in the right one-third of the range.
                }
                else
                {
                    left = mid1 + 1; // Target is in the middle one-third of the range.
                    right = mid2 - 1;
                }
            }
            else
            {
                if (target > val1)
                {
                    right = mid1 - 1; // Target is in the left one-third of the range (since array is descending here).
                }
                else if (target < val2)
                {
                    left = mid2 + 1; // Target is in the right one-third of the range (descending).
                }
                else
                {
                    left = mid1 + 1; // Target is in the middle one-third (descending).
                    right = mid2 - 1;
                }
            }
        }

        return -1;
    }
}
