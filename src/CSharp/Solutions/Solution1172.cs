using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1172
{
    /// <summary>
    /// 1172. Dinner Plate Stacks - Hard
    /// <a href="https://leetcode.com/problems/dinner-plate-stacks">See the problem</a>
    /// </summary>
    public class DinnerPlates
    {
        private int capacity;
        private List<Stack<int>> stacks;
        private SortedSet<int> available; // Indices of stacks that are not full
        private int rightMost; // Rightmost non-empty stack

        public DinnerPlates(int capacity)
        {
            this.capacity = capacity;
            this.stacks = [];
            this.available = [];
            this.rightMost = -1;
        }

        public void Push(int val)
        {
            // Find the leftmost available stack
            if (available.Count > 0)
            {
                int idx = GetFirst(available);
                stacks[idx].Push(val);
                if (stacks[idx].Count == capacity)
                    available.Remove(idx);
            }
            else
            {
                // No available stack, add new
                Stack<int> newStack = new Stack<int>();
                newStack.Push(val);
                stacks.Add(newStack);
                int idx = stacks.Count - 1;
                if (capacity > 1) available.Add(idx); // Still space left
            }

            rightMost = Math.Max(rightMost, stacks.Count - 1);
        }

        public int Pop()
        {
            while (rightMost >= 0 && (rightMost >= stacks.Count || stacks[rightMost].Count == 0))
            {
                rightMost--;
            }

            if (rightMost < 0) return -1;

            int val = stacks[rightMost].Pop();
            available.Add(rightMost); // now this has space

            while (rightMost >= 0 && stacks[rightMost].Count == 0)
                rightMost--;

            return val;
        }

        public int PopAtStack(int index)
        {
            if (index >= stacks.Count || stacks[index].Count == 0)
                return -1;

            int val = stacks[index].Pop();
            available.Add(index);
            if (index == rightMost && stacks[index].Count == 0)
            {
                while (rightMost >= 0 && stacks[rightMost].Count == 0)
                    rightMost--;
            }

            return val;
        }

        private int GetFirst(SortedSet<int> set)
        {
            foreach (var val in set)
                return val;
            return -1;
        }
    }
}
