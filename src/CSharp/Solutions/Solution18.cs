namespace LeetCode.Solutions;

public class Solution18
{
    /// <summary>
    /// Problem #18
    /// <a href="https://leetcode.com/problems/4sum">See the problem</a>
    /// </summary>
    public IList<IList<int>> FourSum(int[] nums, int target)
    {
        Array.Sort(nums); // Sort the array first
        var quadrupletsSet = new HashSet<Quadruplet>();
        
        for (var i = 0; i < nums.Length - 3; i++)
        {
            for (var j = i + 1; j < nums.Length - 2; j++)
            {
                var left = j + 1;
                var right = nums.Length - 1;
                
                while (left < right)
                {
                    var sum = (long)nums[i] + nums[j] + nums[left] + nums[right];
                    
                    if (sum == target)
                    {
                        quadrupletsSet.Add(new Quadruplet(nums[i], nums[j], nums[left], nums[right]));
                        left++;
                        right--;
                    }
                    else if (sum < target)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
            }
        }

        var quadrupletsList = quadrupletsSet
            .Select(quadruplet => quadruplet.ToList())
            .ToList();
        
        return quadrupletsList;
    }
    
    private readonly record struct Quadruplet
    {
        public Quadruplet(int num1, int num2, int num3, int num4)
        {
            SortNumbers(ref num1, ref num2, ref num3, ref num4);
            Num1 = num1;
            Num2 = num2;
            Num3 = num3;
            Num4 = num4;
        }
    
        public int Num1 { get; }
        public int Num2 { get; }
        public int Num3 { get; }
        public int Num4 { get; }

        public IList<int> ToList() => [Num1, Num2, Num3, Num4];

        private static void SortNumbers(ref int num1, ref int num2, ref int num3, ref int num4)
        {
            if (num1 > num2)
            {
                Swap(ref num1, ref num2);
            }
            if (num3 > num4)
            {
                Swap(ref num3, ref num4);
            }
            if (num1 > num3)
            {
                Swap(ref num1, ref num3);
            }
            if (num2 > num4)
            {
                Swap(ref num2, ref num4);
            }
            if (num2 > num3)
            {
                Swap(ref num2, ref num3);
            }
        }

        private static void Swap(ref int x, ref int y)
        {
            (x, y) = (y, x);
        }
    }
}
