namespace LeetCode.Algorithms;

public static class ArrayUtils
{
    public static int AddToArray(ref int[] arr, int item, int currentSize)
    {
        var capacity = arr.Length;

        if (currentSize == capacity)
        {
            var newArr = new int[capacity * 2]; // Double the size of the array
            Array.Copy(arr, newArr, currentSize); // Copy the elements from the old array to the new array
            arr = newArr;
        }
        
        arr[currentSize] = item;
        return currentSize + 1;
    }
    
    public static int LinearSearch(int?[] arr, int target)
    {
        for (var i = 0; i < arr.Length; i++)
        {
            if (arr[i] == target)
            {
                return i;
            }
        }

        return -1;
    }
    
    public static void RemoveFromArray(ref int?[] arr, int item)
    {
        var index = -1;
        var left = 0;
        var right = arr.Length - 1;
        
        // Find the index of the target element using two pointers for faster search
        while (left < right)
        {
            if (arr[left] == item)
            {
                index = left;
                break;
            }
            
            if (arr[right] == item)
            {
                index = right;
                break;
            }
            
            left++;
            right--;
        }
        
        if (index == -1)
        {
            return;
        }

        var n = arr.Length;
        
        // Swap the element to remove with the last element in the array
        (arr[index], arr[n - 1]) = (arr[n - 1], arr[index]);
        arr[n - 1] = null; // Remove the target element
    }
}
