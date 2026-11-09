namespace LeetCode.Solutions;

public class Solution2349
{
    /// <summary>
    /// 2349. Design a Number Container System - Medium
    /// <a href="https://leetcode.com/problems/design-a-number-container-system">See the problem</a>
    /// </summary>
    public class NumberContainers
    {
        private readonly Dictionary<int, int> _numbersByIndex;
        private readonly Dictionary<int, SortedSet<int>> _indicesByNumber;

        public NumberContainers()
        {
            _numbersByIndex = [];
            _indicesByNumber = [];
        }

        public void Change(int index, int number)
        {
            if (_numbersByIndex.TryGetValue(index, out int previousNumber))
            {
                if (previousNumber == number)
                {
                    return;
                }

                // Remove the index from its previous number before reassigning it.
                var previousIndices = _indicesByNumber[previousNumber];
                previousIndices.Remove(index);
                if (previousIndices.Count == 0)
                {
                    _indicesByNumber.Remove(previousNumber);
                }
            }

            _numbersByIndex[index] = number;
            if (!_indicesByNumber.TryGetValue(number, out var indices))
            {
                indices = [];
                _indicesByNumber[number] = indices;
            }

            indices.Add(index);
        }

        public int Find(int number)
        {
            return _indicesByNumber.TryGetValue(number, out var indices) ? indices.Min : -1;
        }
    }
}
