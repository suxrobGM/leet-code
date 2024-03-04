namespace LeetCode.Solutions;

public class Solution15
{
    /// <summary>
    /// Problem #15
    /// <a href="https://leetcode.com/problems/3sum/">See the problem</a>
    /// </summary>
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        var tripletsSet = new HashSet<Triplet>();
        Array.Sort(nums); // SortingMethods the array first

        for (var i = 0; i < nums.Length - 2; i++)
        {
            var left = i + 1;
            var right = nums.Length - 1;

            while (left < right)
            {
                var sum = nums[i] + nums[left] + nums[right];
                if (sum == 0)
                {
                    tripletsSet.Add(new Triplet(nums[i], nums[left], nums[right]));
                    left++;
                    right--;
                }
                else if (sum < 0)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
        }

        var tripletsList = tripletsSet
            .Select(triplet => triplet.ToList())
            .ToList();
        
        return tripletsList;
    }
    
    private readonly record struct Triplet
    {
        public Triplet(int num1, int num2, int num3)
        {
            var min = Math.Min(num1, Math.Min(num2, num3));
            var max = Math.Max(num1, Math.Max(num2, num3));
            var mid = num1 + num2 + num3 - (min + max);
            Num1 = min;
            Num2 = mid;
            Num3 = max;
        }
    
        public int Num1 { get; }
        public int Num2 { get; }
        public int Num3 { get; }

        public IList<int> ToList() => [Num1, Num2, Num3];
    }
}
