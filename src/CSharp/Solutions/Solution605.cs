namespace LeetCode.Solutions;

public class Solution605
{
    /// <summary>
    /// 605. Can Place Flowers - Easy
    /// <a href="https://leetcode.com/problems/can-place-flowers">See the problem</a>
    /// </summary>
    public bool CanPlaceFlowers(int[] flowerbed, int n)
    {
        for (var i = 0; i < flowerbed.Length; i++)
        {
            if (flowerbed[i] == 0 && 
                (i == 0 || flowerbed[i - 1] == 0) && 
                (i == flowerbed.Length - 1 || flowerbed[i + 1] == 0))
            {
                flowerbed[i] = 1;
                n--;
            }
        }
    
        return n <= 0;
    }
}
