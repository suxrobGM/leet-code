using System.Numerics;
using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution975
{
    /// <summary>
    /// 975. Odd Even Jump - Hard
    /// <a href="https://leetcode.com/problems/odd-even-jump">See the problem</a>
    /// </summary>
    public int OddEvenJumps(int[] arr)
    {
        int n = arr.Length;
        if (n == 1) return 1;

        var oddNext = new int[n];
        var evenNext = new int[n];

        BuildJumpIndices(arr, oddNext, true);
        BuildJumpIndices(arr, evenNext, false);

        var odd = new bool[n];
        var even = new bool[n];
        odd[n - 1] = even[n - 1] = true; // Last index is always reachable

        int goodStartingIndices = 1; // Last index is always good

        for (int i = n - 2; i >= 0; i--)
        {
            if (oddNext[i] != -1) odd[i] = even[oddNext[i]];
            if (evenNext[i] != -1) even[i] = odd[evenNext[i]];
            if (odd[i]) goodStartingIndices++;
        }

        return goodStartingIndices;
    }

    private void BuildJumpIndices(int[] arr, int[] nextJump, bool isOddJump)
    {
        var stack = new Stack<int>();
        var map = new SortedDictionary<int, int>();

        int n = arr.Length;
        Array.Fill(nextJump, -1);

        int sign = isOddJump ? 1 : -1;
        var sortedIndices = new List<int>();

        for (int i = 0; i < n; i++)
            sortedIndices.Add(i);

        sortedIndices.Sort((a, b) => sign * arr[a].CompareTo(arr[b]) != 0 ? sign * arr[a].CompareTo(arr[b]) : a.CompareTo(b));

        foreach (int i in sortedIndices)
        {
            while (stack.Count > 0 && stack.Peek() < i)
                nextJump[stack.Pop()] = i;

            stack.Push(i);
        }
    }
}
