using System.Text;

namespace LeetCode.Solutions;

public class Solution68
{
    /// <summary>
    /// 68. Text Justification
    /// <a href="https://leetcode.com/problems/text-justification">See the problem</a>
    /// </summary>
    public IList<string> FullJustify(string[] words, int maxWidth)
    {
        var result = new List<string>();
        var i = 0;

        while (i < words.Length) 
        {
            var lineLength = words[i].Length;
            var j = i + 1;

            // Determine how many words can fit in the current line
            while (j < words.Length && (lineLength + words[j].Length + (j - i)) <= maxWidth) 
            {
                lineLength += words[j].Length;
                j++;
            }

            var line = new StringBuilder();
            var numberOfWords = j - i;
            
            // For the last line or a line with a single word, left-justify
            if (j == words.Length || numberOfWords == 1) 
            {
                for (var k = i; k < j; k++) 
                {
                    line.Append(words[k]);
                    if (k < j - 1)
                    {
                        line.Append(' ');
                    }
                }
                
                // Fill the rest of the line with spaces
                while (line.Length < maxWidth) 
                {
                    line.Append(' ');
                }
            } 
            else 
            {
                // Calculate even spacing and distribute extra spaces if needed
                var spaces = (maxWidth - lineLength) / (numberOfWords - 1);
                var extraSpaces = (maxWidth - lineLength) % (numberOfWords - 1);

                for (var k = i; k < j; k++) 
                {
                    line.Append(words[k]);
                    if (k < j - 1) 
                    {
                        var spaceCount = spaces + (k - i < extraSpaces ? 1 : 0);
                        line.Append(' ', spaceCount);
                    }
                }
            }
            
            result.Add(line.ToString());
            i = j;
        }

        return result;
    }
}
