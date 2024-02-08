public class Solution4 {
    public double findMedianSortedArrays(int[] nums1, int[] nums2) {
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

            if (i < right && nums2[j-1] > nums1[i]) {
                left = i + 1; // i is too small
            }
            else if (i > left && nums1[i-1] > nums2[j]) {
                right = i - 1; // i is too big
            }
            else { // Edge cases: i is perfect
                var maxLeft = 0;
                var minRight = 0;

                if (i == 0) {
                    maxLeft = nums2[j-1]; 
                }
                else if (j == 0) {
                    maxLeft = nums1[i-1];
                }
                else {
                    maxLeft = Math.max(nums1[i-1], nums2[j-1]);
                }

                if ((m + n) % 2 == 1) {
                    return maxLeft; // Odd number of elements
                }
                

                if (i == m) {
                    minRight = nums2[j];
                }
                else if (j == n) {
                    minRight = nums1[i];
                }
                else {
                    minRight = Math.min(nums2[j], nums1[i]);
                }
                
                return (maxLeft + minRight) / 2.0; // Even number of elements
            }
        }

        return 0.0;
    }
}
