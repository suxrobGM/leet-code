namespace LeetCode.Solutions;

public class Solution2034
{
    /// <summary>
    /// 2034. Stock Price Fluctuation - Medium
    /// <a href="https://leetcode.com/problems/stock-price-fluctuation">See the problem</a>
    /// </summary>
    public class StockPrice
    {
        private readonly Dictionary<int, int> _timestampToPrice = new();
        private readonly SortedList<int, int> _priceCount = new();
        private int _latestTimestamp;

        public void Update(int timestamp, int price)
        {
            if (_timestampToPrice.TryGetValue(timestamp, out var oldPrice))
            {
                _priceCount[oldPrice]--;
                if (_priceCount[oldPrice] == 0)
                    _priceCount.Remove(oldPrice);
            }

            _timestampToPrice[timestamp] = price;
            if (!_priceCount.TryGetValue(price, out var count))
                count = 0;
            _priceCount[price] = count + 1;
            _latestTimestamp = Math.Max(_latestTimestamp, timestamp);
        }

        public int Current() => _timestampToPrice[_latestTimestamp];

        public int Maximum() => _priceCount.GetKeyAtIndex(_priceCount.Count - 1);

        public int Minimum() => _priceCount.GetKeyAtIndex(0);
    }
}
