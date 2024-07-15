namespace LeetCode.Solutions;

public class Solution385
{
    /// <summary>
    /// 385. Mini Parser - Medium
    /// <a href="https://leetcode.com/problems/mini-parser">See the problem</a>
    /// </summary>
    public NestedInteger Deserialize(string s)
    {
        if (s[0] != '[')
        {
            return new NestedInteger(int.Parse(s));
        }

        var stack = new Stack<NestedInteger>();
        var current = new NestedInteger();
        stack.Push(current);

        for (var i = 1; i < s.Length; i++)
        {
            var c = s[i];

            if (c == '[')
            {
                var newNestedInteger = new NestedInteger();
                stack.Peek().Add(newNestedInteger);
                stack.Push(newNestedInteger);
            }
            else if (c == ']')
            {
                stack.Pop();
            }
            else if (c == ',')
            {
                continue;
            }
            else
            {
                var start = i;
                while (i < s.Length - 1 && char.IsDigit(s[i + 1]) || s[i + 1] == '-')
                {
                    i++;
                }

                var num = int.Parse(s[start..(i + 1)]);
                stack.Peek().Add(new NestedInteger(num));
            }
        }

        return current;
    }

    public class NestedInteger
    {
        private readonly List<NestedInteger> _list;
        private readonly int? _value;

        public NestedInteger()
        {
            _list = new List<NestedInteger>();
        }

        public NestedInteger(int value)
        {
            _value = value;
        }

        public void Add(NestedInteger ni)
        {
            if (_value != null)
            {
                throw new InvalidOperationException("Cannot add to an integer");
            }

            _list.Add(ni);
        }

        public IList<NestedInteger> GetList()
        {
            return _list;
        }

        public int GetInteger()
        {
            if (_value == null)
            {
                throw new InvalidOperationException("Cannot get integer from a list");
            }

            return _value.Value;
        }

        public bool IsInteger()
        {
            return _value != null;
        }
    }
}
