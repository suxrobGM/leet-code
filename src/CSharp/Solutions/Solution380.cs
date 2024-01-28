namespace LeetCode.Solutions;

public class Solution380
{
    /// <summary>
    /// 380. Insert Delete GetRandom O(1)
    /// <a href="https://leetcode.com/problems/insert-delete-getrandom-o1">See the problem</a>
    /// </summary>
    public class RandomizedSet
    {
        private Dictionary<int, int> _dict;
        private List<int> _list;
        private Random _rand;
        
        public RandomizedSet()
        {
            _dict = [];
            _list = [];
            _rand = new Random();
        }
    
        public bool Insert(int val)
        {
            if (_dict.ContainsKey(val))
            {
                return false;
            }

            _dict[val] = _list.Count;
            _list.Add(val);
            return true;
        }
    
        public bool Remove(int val)
        {
            if (!_dict.TryGetValue(val, out var index))
            {
                return false;
            }

            // Move the last element to the place of the element to delete
            var lastElement = _list[^1];
            _list[index] = lastElement;
            _dict[lastElement] = index;

            // Remove the last element
            _list.RemoveAt(_list.Count - 1);
            _dict.Remove(val);
            return true;
        }
    
        public int GetRandom()
        {
            var index = _rand.Next(0, _list.Count);
            return _list[index];
        }
    }
}
