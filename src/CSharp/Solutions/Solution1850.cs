using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1850
{
    /// <summary>
    /// 1850. Minimum Adjacent Swaps to Reach the Kth Smallest Number - Medium
    /// <a href="https://leetcode.com/problems/minimum-adjacent-swaps-to-reach-the-kth-smallest-number">See the problem</a>
    /// </summary>
    public int GetMinSwaps(string num, int k)
    {
        // Find the k-th permutation that is greater than num
        char[] arr = num.ToCharArray();
        int n = arr.Length;

        for (int i = 0; i < k; i++)
        {
            NextPermutation(arr);
        }

        // Count the number of adjacent swaps to transform num to arr
        int swaps = 0;
        char[] original = num.ToCharArray();

        for (int i = 0; i < n; i++)
        {
            if (original[i] != arr[i])
            {
                // Find the position of arr[i] in original starting from index i
                int j = i + 1;
                while (j < n && original[j] != arr[i]) j++;

                // Swap original[j] to position i using adjacent swaps
                while (j > i)
                {
                    (original[j], original[j - 1]) = (original[j - 1], original[j]);
                    swaps++;
                    j--;
                }
            }
        }

        return swaps;
    }

    private void NextPermutation(char[] arr)
    {
        int n = arr.Length;
        int i = n - 2;

        // Find the first decreasing element from the end
        while (i >= 0 && arr[i] >= arr[i + 1]) i--;

        if (i >= 0)
        {
            // Find the element just larger than arr[i] to swap with
            int j = n - 1;
            while (arr[j] <= arr[i]) j--;

            // Swap
            (arr[i], arr[j]) = (arr[j], arr[i]);
        }

        // Reverse the elements after index i
        Array.Reverse(arr, i + 1, n - i - 1);
    }
}
