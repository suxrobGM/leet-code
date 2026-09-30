using System.Text;

namespace LeetCode.Solutions;

public class Solution2296
{
    /// <summary>
    /// 2296. Design a Text Editor - Hard
    /// <a href="https://leetcode.com/problems/design-a-text-editor">See the problem</a>
    /// </summary>
    public class TextEditor
    {
        // Characters left of the cursor, in order
        private readonly StringBuilder _left = new();

        // Characters right of the cursor, in reverse order (top of stack is nearest the cursor)
        private readonly StringBuilder _right = new();

        public TextEditor()
        {
        }

        public void AddText(string text)
        {
            _left.Append(text);
        }

        public int DeleteText(int k)
        {
            var deleted = Math.Min(k, _left.Length);
            _left.Length -= deleted;
            return deleted;
        }

        public string CursorLeft(int k)
        {
            while (k > 0 && _left.Length > 0)
            {
                _right.Append(_left[^1]);
                _left.Length--;
                k--;
            }

            return LastChars();
        }

        public string CursorRight(int k)
        {
            while (k > 0 && _right.Length > 0)
            {
                _left.Append(_right[^1]);
                _right.Length--;
                k--;
            }

            return LastChars();
        }

        private string LastChars()
        {
            var len = Math.Min(10, _left.Length);
            return _left.ToString(_left.Length - len, len);
        }
    }
}
