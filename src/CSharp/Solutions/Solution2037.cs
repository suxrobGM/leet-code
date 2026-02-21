namespace LeetCode.Solutions;

public class Solution2037
{
    /// <summary>
    /// 2037. Minimum Number of Moves to Seat Everyone - Easy
    /// <a href="https://leetcode.com/problems/minimum-number-of-moves-to-seat-everyone">See the problem</a>
    /// </summary>
    public int MinMovesToSeat(int[] seats, int[] students)
    {
        Array.Sort(seats);
        Array.Sort(students);

        var result = 0;
        for (var i = 0; i < seats.Length; i++)
            result += Math.Abs(seats[i] - students[i]);

        return result;
    }
}
