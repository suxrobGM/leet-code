using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution912
{
    /// <summary>
    /// 912. Sort an Array - Medium
    /// <a href="https://leetcode.com/problems/sort-an-array">See the problem</a>
    /// </summary>
    public int[] SortArray(int[] nums)
    {
        int n = nums.Length;

        // Step 1: Build a max heap
        for (int i = n / 2 - 1; i >= 0; i--)
        {
            Heapify(nums, n, i);
        }

        // Step 2: Extract elements from the heap
        for (int i = n - 1; i > 0; i--)
        {
            // Swap the root (max element) with the last element
            Swap(nums, 0, i);

            // Restore the max-heap property for the reduced heap
            Heapify(nums, i, 0);
        }

        return nums;
    }

    private void Heapify(int[] nums, int heapSize, int rootIndex)
    {
        int largest = rootIndex;
        int leftChild = 2 * rootIndex + 1;
        int rightChild = 2 * rootIndex + 2;

        // Check if the left child is larger than the root
        if (leftChild < heapSize && nums[leftChild] > nums[largest])
        {
            largest = leftChild;
        }

        // Check if the right child is larger than the largest so far
        if (rightChild < heapSize && nums[rightChild] > nums[largest])
        {
            largest = rightChild;
        }

        // If the largest is not the root, swap and continue heapifying
        if (largest != rootIndex)
        {
            Swap(nums, rootIndex, largest);
            Heapify(nums, heapSize, largest);
        }
    }

    private void Swap(int[] nums, int i, int j)
    {
        (nums[j], nums[i]) = (nums[i], nums[j]);
    }
}
