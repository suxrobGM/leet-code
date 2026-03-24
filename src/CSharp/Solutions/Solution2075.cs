using System.Text;

namespace LeetCode.Solutions;

public class Solution2075
{
    /// <summary>
    /// 2075. Decode the Slanted Ciphertext - Medium
    /// <a href="https://leetcode.com/problems/decode-the-slanted-ciphertext">See the problem</a>
    /// </summary>
    public string DecodeCiphertext(string encodedText, int rows)
    {
        var cols = encodedText.Length / rows;
        var sb = new StringBuilder();

        for (var startCol = 0; startCol < cols; startCol++)
        {
            for (int r = 0, c = startCol; r < rows && c < cols; r++, c++)
                sb.Append(encodedText[r * cols + c]);
        }

        return sb.ToString().TrimEnd();
    }
}
