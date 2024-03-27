using System.Text;

namespace LeetCode.Solutions;

public class Solution60
{
    /// <summary>
    /// 60. Permutation Sequence - Hard
    /// <a href="https://leetcode.com/problems/permutation-sequence">See the problem</a>
    /// </summary>
    public string GetPermutation(int n, int k)
    {
        var factorial = new int[n + 1];
        var numbers = new List<int>();
        
        // Base case
        factorial[0] = 1;
        
        // Calculate the factorial of each number from 1 to n and add them to the list of numbers
        for (var i = 1; i <= n; i++)
        {
            factorial[i] = factorial[i - 1] * i;
            numbers.Add(i);
        }
        
        var result = new StringBuilder();
        
        // Convert k to 0-based index
        k--;
        
        // Calculate the index of each number in the permutation sequence and remove it from the list of numbers to avoid duplicates
        for (var i = 1; i <= n; i++)
        {
            var index = k / factorial[n - i]; // Calculate the index of the current number in the permutation sequence
            result.Append(numbers[index]); // Add the current number to the result
            numbers.RemoveAt(index); // Remove the current number from the list of numbers
            k -= index * factorial[n - i]; // Update k to the remaining index in the current permutation sequence 
        }
        
        return result.ToString();
    }
}
