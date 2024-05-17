namespace LeetCode.Solutions;

public class Solution146
{
    /// <summary>
    /// 146. LRU Cache - Medium
    /// <a href="https://leetcode.com/problems/lru-cache">See the problem</a>
    /// </summary>
    public class LRUCache 
    {
        private readonly int _capacity;
        private readonly Dictionary<int, LinkedListNode<(int, int)>> _cache;
        private readonly LinkedList<(int, int)> _list;

        public LRUCache(int capacity) 
        {
            _capacity = capacity;
            _cache = new Dictionary<int, LinkedListNode<(int, int)>>();
            _list = [];
        }

        public int Get(int key) 
        {
            if (!_cache.TryGetValue(key, out var node))
            {
                return -1;
            }

            _list.Remove(node);
            _list.AddFirst(node);

            return node.Value.Item2;
        }

        public void Put(int key, int value) 
        {
            if (_cache.TryGetValue(key, out var node1))
            {
                _list.Remove(node1);
                _list.AddFirst(node1);
                node1.Value = (key, value);
            }
            else
            {
                if (_cache.Count == _capacity)
                {
                    _cache.Remove(_list.Last!.Value.Item1);
                    _list.RemoveLast();
                }

                var node = new LinkedListNode<(int, int)>((key, value));
                _cache[key] = node;
                _list.AddFirst(node);
            }
        }
    }
}
