namespace LeetCode.Solutions;

public class Solution1993
{
    /// <summary>
    /// 1993. Operations on Tree - Medium
    /// <a href="https://leetcode.com/problems/operations-on-tree">See the problem</a>
    /// </summary>
    public class LockingTree
    {
        private readonly int[] _parent;
        private readonly Dictionary<int, int> _lockedNodes; // node -> user
        private readonly Dictionary<int, List<int>> _children; // node -> children

        public LockingTree(int[] parent)
        {
            _parent = parent;
            _lockedNodes = [];
            _children = [];

            for (int i = 0; i < parent.Length; i++)
            {
                if (parent[i] != -1)
                {
                    if (!_children.ContainsKey(parent[i]))
                    {
                        _children[parent[i]] = [];
                    }
                    _children[parent[i]].Add(i);
                }
            }
        }

        public bool Lock(int num, int user)
        {
            if (_lockedNodes.ContainsKey(num))
            {
                return false;
            }

            _lockedNodes[num] = user;
            return true;
        }

        public bool Unlock(int num, int user)
        {
            if (_lockedNodes.TryGetValue(num, out int lockedUser) && lockedUser == user)
            {
                _lockedNodes.Remove(num);
                return true;
            }

            return false;
        }

        public bool Upgrade(int num, int user)
        {
            if (_lockedNodes.ContainsKey(num))
            {
                return false; // Node is already locked
            }

            // Check if any ancestors are locked
            int current = _parent[num];
            while (current != -1)
            {
                if (_lockedNodes.ContainsKey(current))
                {
                    return false; // An ancestor is locked
                }
                current = _parent[current];
            }

            // Check for locked descendants
            var lockedDescendants = new List<int>();
            var stack = new Stack<int>();
            stack.Push(num);

            while (stack.Count > 0)
            {
                int node = stack.Pop();
                if (_lockedNodes.ContainsKey(node))
                {
                    lockedDescendants.Add(node);
                }

                if (_children.ContainsKey(node))
                {
                    foreach (var child in _children[node])
                    {
                        stack.Push(child);
                    }
                }
            }

            if (lockedDescendants.Count == 0)
            {
                return false; // No locked descendants
            }

            // Unlock all locked descendants
            foreach (var desc in lockedDescendants)
            {
                _lockedNodes.Remove(desc);
            }

            // Lock the current
            _lockedNodes[num] = user;
            return true;
        }
    }
}
