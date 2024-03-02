namespace LeetCode.Algorithms;

public static class PartitioningUtils
{
    public static int HoarePartition(int[] arr, int low, int high)
    {
        var pivot = arr[low];
        var i = low - 1;
        var j = high + 1;

        while (true)
        {
            do
            {
                i++;
            } while (arr[i] < pivot);

            do
            {
                j--;
            } while (arr[j] > pivot);

            if (i >= j)
            {
                return j;
            }

            (arr[i], arr[j]) = (arr[j], arr[i]);
        }
    }
}
