namespace LeetCode.Solutions;

public class Solution2019
{
    /// <summary>
    /// 2019. The Score of Students Solving Math Expression - Hard
    /// <a href="https://leetcode.com/problems/the-score-of-students-solving-math-expression">See the problem</a>
    /// </summary>
    public int ScoreOfStudents(string s, int[] answers)
    {
        var nums = new List<int>();
        var ops = new List<char>();

        for (var i = 0; i < s.Length; i++)
        {
            var c = s[i];
            if (c == '+' || c == '*')
            {
                ops.Add(c);
            }
            else
            {
                nums.Add(c - '0');
            }
        }

        var correct = EvaluateCorrect(nums, ops);
        var possible = ComputeAllResults(nums, ops);

        var score = 0;
        foreach (var ans in answers)
        {
            if (ans == correct)
            {
                score += 5;
            }
            else if (ans <= 1000 && possible.Contains(ans))
            {
                score += 2;
            }
        }

        return score;
    }

    private static int EvaluateCorrect(List<int> nums, List<char> ops)
    {
        var stack = new List<int> { nums[0] };

        for (var i = 0; i < ops.Count; i++)
        {
            var op = ops[i];
            var value = nums[i + 1];

            if (op == '*')
            {
                stack[stack.Count - 1] *= value;
            }
            else
            {
                stack.Add(value);
            }
        }

        var sum = 0;
        foreach (var v in stack)
        {
            sum += v;
        }

        return sum;
    }

    private static HashSet<int> ComputeAllResults(List<int> nums, List<char> ops)
    {
        var memo = new Dictionary<(int Left, int Right), HashSet<int>>();
        return Dfs(0, nums.Count - 1);

        HashSet<int> Dfs(int left, int right)
        {
            if (memo.TryGetValue((left, right), out var cached))
            {
                return cached;
            }

            var result = new HashSet<int>();

            if (left == right)
            {
                result.Add(nums[left]);
                memo[(left, right)] = result;
                return result;
            }

            for (var k = left; k < right; k++)
            {
                var op = ops[k];
                var leftSet = Dfs(left, k);
                var rightSet = Dfs(k + 1, right);

                foreach (var a in leftSet)
                {
                    foreach (var b in rightSet)
                    {
                        var value = op == '+' ? a + b : a * b;
                        if (value <= 1000)
                        {
                            result.Add(value);
                        }
                    }
                }
            }

            memo[(left, right)] = result;
            return result;
        }
    }
}
