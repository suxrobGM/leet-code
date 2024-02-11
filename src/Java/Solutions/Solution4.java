package solutions;

public class Solution4 {
    public double findMedianSortedArrays(int[] nums1, int[] nums2) {
        var len1 = nums1.length;
        var len2 = nums2.length;
        var mergedLen = len1 + len2;
        var mergedArr = new int[mergedLen];
        var median = 0d;
        var midIndex = mergedLen / 2;

        var left = 0;
        var right = 0;
        var mergedArrIndex = 0;

        // Merge nums1 and nums2 into mergedArr
        while (left < len1 && right < len2) {
            if (nums1[left] < nums2[right]) {
                mergedArr[mergedArrIndex++] = nums1[left++];
            }
            else {
                mergedArr[mergedArrIndex++] = nums2[right++];
            }
        }

        // Copy any remaining elements from nums1
        while (left < len1) {
            mergedArr[mergedArrIndex++] = nums1[left++];
        }
        
        // Copy any remaining elements from nums2
        while (right < len2) {
            mergedArr[mergedArrIndex++] = nums2[right++];
        }

        if (mergedLen % 2 == 0) {
            median = (mergedArr[midIndex] + mergedArr[midIndex - 1]) / 2.0;
        }
        else {
            median = mergedArr[midIndex];
        }

        return median;
    }

    public double findMedianSortedArrays2(int[] nums1, int[] nums2) {
        var m = nums1.length;
        var n = nums2.length;

        // Ensure nums1 is the smaller array.
        if (m > n) {
            var temp = nums1; // swap nums1 and nums2
            nums1 = nums2;
            nums2 = temp;

            var tmp = m; // swap m and n
            m = n;
            n = tmp;
        }

        var left = 0;
        var right = m;
        var halfLength = (m + n + 1) / 2;

        while (left <= right) {
            var i = (left + right) / 2;
            var j = halfLength - i;

            if (i < right && nums2[j - 1] > nums1[i]) {
                left = i + 1; // i is too small
            }
            else if (i > left && nums1[i - 1] > nums2[j]) {
                right = i - 1; // i is too big
            }
            else { // Edge cases: i is perfect
                var maxLeft = 0;
                var minRight = 0;

                if (i == 0) {
                    maxLeft = nums2[j - 1];
                } else if (j == 0) {
                    maxLeft = nums1[i - 1];
                } else {
                    maxLeft = Math.max(nums1[i - 1], nums2[j - 1]);
                }

                if ((m + n) % 2 == 1) {
                    return maxLeft; // Odd number of elements
                }

                if (i == m) {
                    minRight = nums2[j];
                } else if (j == n) {
                    minRight = nums1[i];
                } else {
                    minRight = Math.min(nums2[j], nums1[i]);
                }

                return (maxLeft + minRight) / 2.0; // Even number of elements
            }
        }

        return 0.0;
    }
}
