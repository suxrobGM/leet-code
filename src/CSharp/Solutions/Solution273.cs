using System.Text;

namespace LeetCode.Solutions;

public class Solution273
{
    /// <summary>
    /// 273. Integer to English Words - Hard
    /// <a href="https://leetcode.com/problems/integer-to-english-words">See the problem</a>
    /// </summary>
    public string NumberToWords(int num)
    {
        if (num == 0)
        {
            return "Zero";
        }

        var sb = new StringBuilder();
        var billion = num / 1_000_000_000;
        var million = (num - billion * 1_000_000_000) / 1_000_000;
        var thousand = (num - billion * 1_000_000_000 - million * 1_000_000) / 1_000;
        var rest = num - billion * 1_000_000_000 - million * 1_000_000 - thousand * 1_000;

        if (billion > 0)
        {
            sb.Append(NumberToWords(billion) + " Billion");
        }

        if (million > 0)
        {
            if (sb.Length > 0)
            {
                sb.Append(' ');
            }

            sb.Append(NumberToWords(million) + " Million");
        }

        if (thousand > 0)
        {
            if (sb.Length > 0)
            {
                sb.Append(' ');
            }

            sb.Append(NumberToWords(thousand) + " Thousand");
        }

        if (rest > 0)
        {
            if (sb.Length > 0)
            {
                sb.Append(' ');
            }

            sb.Append(NumberToWordsLessThanThousand(rest));
        }

        return sb.ToString();
    }

    private string NumberToWordsLessThanThousand(int num)
    {
        var sb = new StringBuilder();

        var hundreds = num / 100;
        var rest = num - hundreds * 100;

        if (hundreds > 0)
        {
            sb.Append(NumberToWordsLessThanTwenty(hundreds) + " Hundred");
        }

        if (rest > 0)
        {
            if (sb.Length > 0)
            {
                sb.Append(' ');
            }

            sb.Append(NumberToWordsLessThanHundred(rest));
        }

        return sb.ToString();
    }

    private string NumberToWordsLessThanHundred(int num)
    {
        if (num < 20)
        {
            return NumberToWordsLessThanTwenty(num);
        }

        var sb = new StringBuilder();
        var tens = num / 10;
        var rest = num - tens * 10;

        sb.Append(NumberToWordsLessThanTen(tens));

        if (rest > 0)
        {
            if (sb.Length > 0)
            {
                sb.Append(' ');
            }

            sb.Append(NumberToWordsLessThanTwenty(rest));
        }

        return sb.ToString();
    }

    private string NumberToWordsLessThanTwenty(int num)
    {
        return num switch
        {
            1 => "One",
            2 => "Two",
            3 => "Three",
            4 => "Four",
            5 => "Five",
            6 => "Six",
            7 => "Seven",
            8 => "Eight",
            9 => "Nine",
            10 => "Ten",
            11 => "Eleven",
            12 => "Twelve",
            13 => "Thirteen",
            14 => "Fourteen",
            15 => "Fifteen",
            16 => "Sixteen",
            17 => "Seventeen",
            18 => "Eighteen",
            19 => "Nineteen",
            _ => string.Empty
        };
    }

    private string NumberToWordsLessThanTen(int num)
    {
        return num switch
        {
            1 => "Ten",
            2 => "Twenty",
            3 => "Thirty",
            4 => "Forty",
            5 => "Fifty",
            6 => "Sixty",
            7 => "Seventy",
            8 => "Eighty",
            9 => "Ninety",
            _ => string.Empty
        };
    }
}
