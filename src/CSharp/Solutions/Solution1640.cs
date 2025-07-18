using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1640
{
    /// <summary>
    /// 1640. Check Array Formation Through Concatenation - Easy
    /// <a href="https://leetcode.com/problems/check-array-formation-through-concatenation">See the problem</a>
    /// </summary>
    public bool CanFormArray(int[] arr, int[][] pieces)
    {
        var pieceMap = new Dictionary<int, int[]>();
        foreach (var piece in pieces)
        {
            pieceMap[piece[0]] = piece;
        }

        int index = 0;
        while (index < arr.Length)
        {
            if (!pieceMap.TryGetValue(arr[index], out var piece))
            {
                return false; // No matching piece found
            }

            for (int i = 0; i < piece.Length; i++)
            {
                if (index >= arr.Length || arr[index] != piece[i])
                {
                    return false; // Mismatch found
                }
                index++;
            }
        }

        return true; // Successfully formed the array
    }
}
