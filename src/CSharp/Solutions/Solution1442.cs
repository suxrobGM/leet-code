namespace LeetCode.Solutions;

public class Solution1442
{
    /// <summary>
    /// 1442. Count Triplets That Can Form Two Arrays of Equal XOR - Medium
    /// <a href="https://leetcode.com/problems/count-triplets-that-can-form-two-arrays-of-equal-xor">See the problem</a>
    /// </summary>
    public int CountTriplets(int[] arr)
    {
        int n = arr.Length;
        int[] prefixXor = new int[n + 1];
        prefixXor[0] = 0;

        for (int i = 1; i <= n; i++)
        {
            prefixXor[i] = prefixXor[i - 1] ^ arr[i - 1];
        }

        int count = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (prefixXor[i] == prefixXor[j + 1])
                {
                    count += j - i;
                }
            }
        }

        return count;
    }
}
