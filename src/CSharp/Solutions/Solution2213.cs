namespace LeetCode.Solutions;

public class Solution2213
{
    private char[] _chars = [];
    private int[] _prefix = [];
    private int[] _suffix = [];
    private int[] _best = [];

    /// <summary>
    /// 2213. Longest Substring of One Repeating Character - Hard
    /// <a href="https://leetcode.com/problems/longest-substring-of-one-repeating-character">See the problem</a>
    /// </summary>
    public int[] LongestRepeating(string s, string queryCharacters, int[] queryIndices)
    {
        var n = s.Length;
        _chars = s.ToCharArray();
        _prefix = new int[4 * n];
        _suffix = new int[4 * n];
        _best = new int[4 * n];

        Build(1, 0, n - 1);

        var result = new int[queryIndices.Length];
        for (var i = 0; i < queryIndices.Length; i++)
        {
            _chars[queryIndices[i]] = queryCharacters[i];
            Update(1, 0, n - 1, queryIndices[i]);
            result[i] = _best[1];
        }

        return result;
    }

    private void Build(int node, int left, int right)
    {
        if (left == right)
        {
            _prefix[node] = _suffix[node] = _best[node] = 1;
            return;
        }

        var mid = left + ((right - left) / 2);
        Build(2 * node, left, mid);
        Build(2 * node + 1, mid + 1, right);
        Merge(node, left, mid, right);
    }

    private void Update(int node, int left, int right, int index)
    {
        if (left == right)
        {
            return;
        }

        var mid = left + ((right - left) / 2);
        if (index <= mid)
        {
            Update(2 * node, left, mid, index);
        }
        else
        {
            Update(2 * node + 1, mid + 1, right, index);
        }

        Merge(node, left, mid, right);
    }

    /// <summary>
    /// Combines the two children of <paramref name="node"/>, joining their runs when the
    /// characters on both sides of the split point match.
    /// </summary>
    private void Merge(int node, int left, int mid, int right)
    {
        var leftChild = 2 * node;
        var rightChild = 2 * node + 1;
        var leftLength = mid - left + 1;
        var rightLength = right - mid;

        _prefix[node] = _prefix[leftChild];
        _suffix[node] = _suffix[rightChild];
        _best[node] = Math.Max(_best[leftChild], _best[rightChild]);

        if (_chars[mid] != _chars[mid + 1])
        {
            return;
        }

        _best[node] = Math.Max(_best[node], _suffix[leftChild] + _prefix[rightChild]);

        if (_prefix[leftChild] == leftLength)
        {
            _prefix[node] = leftLength + _prefix[rightChild];
        }

        if (_suffix[rightChild] == rightLength)
        {
            _suffix[node] = rightLength + _suffix[leftChild];
        }
    }
}
