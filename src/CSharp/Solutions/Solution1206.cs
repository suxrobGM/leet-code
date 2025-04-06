using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1206
{
    /// <summary>
    /// 1206. Design Skiplist - Hard
    /// <a href="https://leetcode.com/problems/design-skiplist">See the problem</a>
    /// </summary>
    public class Skiplist
    {
        private class Node(int val, int level)
        {
            public int val = val;
            public Node[] forward = new Node[level + 1];
        }

        private const int MAX_LEVEL = 16;
        private const double P = 0.5;
        private readonly Node head;
        private int level;
        private readonly Random rand;

        public Skiplist()
        {
            head = new Node(-1, MAX_LEVEL);
            level = 0;
            rand = new Random();
        }

        // Search for a value in the skiplist
        public bool Search(int target)
        {
            var curr = head;
            for (int i = level; i >= 0; i--)
            {
                while (curr.forward[i] != null && curr.forward[i].val < target)
                {
                    curr = curr.forward[i];
                }
            }

            curr = curr.forward[0];
            return curr != null && curr.val == target;
        }

        // Add a new number into the skiplist
        public void Add(int num)
        {
            var update = new Node[MAX_LEVEL + 1];
            var curr = head;

            for (int i = level; i >= 0; i--)
            {
                while (curr.forward[i] != null && curr.forward[i].val < num)
                {
                    curr = curr.forward[i];
                }
                update[i] = curr;
            }

            int lvl = RandomLevel();

            if (lvl > level)
            {
                for (int i = level + 1; i <= lvl; i++)
                {
                    update[i] = head;
                }
                level = lvl;
            }

            var newNode = new Node(num, lvl);
            for (int i = 0; i <= lvl; i++)
            {
                newNode.forward[i] = update[i].forward[i];
                update[i].forward[i] = newNode;
            }
        }

        // Erase a number from the skiplist
        public bool Erase(int num)
        {
            var update = new Node[MAX_LEVEL + 1];
            var curr = head;

            for (int i = level; i >= 0; i--)
            {
                while (curr.forward[i] != null && curr.forward[i].val < num)
                {
                    curr = curr.forward[i];
                }
                update[i] = curr;
            }

            curr = curr.forward[0];

            if (curr == null || curr.val != num)
                return false;

            for (int i = 0; i <= level; i++)
            {
                if (update[i].forward[i] != curr)
                    break;

                update[i].forward[i] = curr.forward[i];
            }

            // Adjust the level if highest levels become empty
            while (level > 0 && head.forward[level] == null)
                level--;

            return true;
        }

        // Generate random level
        private int RandomLevel()
        {
            int lvl = 0;
            while (rand.NextDouble() < P && lvl < MAX_LEVEL)
                lvl++;
            return lvl;
        }
    }
}
