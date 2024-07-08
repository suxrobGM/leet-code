using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution341
{
    public interface NestedInteger
    {
        bool IsInteger();
        int GetInteger();
        IList<NestedInteger> GetList();
    }

    /// <summary>
    /// 341. Flatten Nested List Iterator - Medium
    /// <a href="https://leetcode.com/problems/flatten-nested-list-iterator">See the problem</a>
    /// </summary>
    public class NestedIterator 
    {
        private readonly List<int> _list = [];
        private int _index = 0;

        public NestedIterator(IList<NestedInteger> nestedList)
        {
            Flatten(nestedList);
        }

        private void Flatten(IList<NestedInteger> nestedList)
        {
            foreach (var nestedInteger in nestedList)
            {
                if (nestedInteger.IsInteger())
                {
                    _list.Add(nestedInteger.GetInteger());
                }
                else
                {
                    Flatten(nestedInteger.GetList());
                }
            }
        }

        public bool HasNext()
        {
            return _index < _list.Count;
        }

        public int Next()
        {
            return _list[_index++];
        }
    }
}
