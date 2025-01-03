using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution927
{
    /// <summary>
    /// 927. Three Equal Parts - Hard
    /// <a href="https://leetcode.com/problems/three-equal-parts">See the problem</a>
    /// </summary>
    public int[] ThreeEqualParts(int[] arr)
    {
        int n = arr.Length;
        int countOnes = 0;

        foreach (int num in arr)
        {
            countOnes += num;
        }

        if (countOnes == 0)
        {
            return [0, n - 1];
        }

        if (countOnes % 3 != 0)
        {
            return [-1, -1];
        }

        int onesInEachPart = countOnes / 3;
        int[] indexes = new int[3];
        int count = 0;
        
        for (int i = 0; i < n; i++)
        {
            if (arr[i] == 1)
            {
                if (count % onesInEachPart == 0)
                {
                    indexes[count / onesInEachPart] = i;
                }

                count++;
            }
        }

        while (indexes[2] < n && arr[indexes[0]] == arr[indexes[1]] && arr[indexes[1]] == arr[indexes[2]])
        {
            indexes[0]++;
            indexes[1]++;
            indexes[2]++;
        }

        if (indexes[2] == n)
        {
            return [indexes[0] - 1, indexes[1]];
        }

        return [-1, -1];
    }
}
