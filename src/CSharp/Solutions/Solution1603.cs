using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1603
{
    /// <summary>
    /// 1603. Design Parking System - Easy
    /// <a href="https://leetcode.com/problems/design-parking-system">See the problem</a>
    /// </summary>
    public class ParkingSystem
    {
        private int[] _carCounts;
        private int[] _capacity;

        public ParkingSystem(int big, int medium, int small)
        {
            _capacity = [big, medium, small];
            _carCounts = new int[3];
        }

        public bool AddCar(int carType)
        {
            if (_carCounts[carType - 1] < _capacity[carType - 1])
            {
                _carCounts[carType - 1]++;
                return true;
            }
            return false;
        }
    }
}
