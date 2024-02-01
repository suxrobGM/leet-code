/**
 * 2695. Array Wrapper
 * 
 * {@link https://leetcode.com/problems/array-wrapper See more}
 */
class ArrayWrapper {
  private readonly nums: number[];

  constructor(nums: number[]) {
    this.nums = nums;
  }
  
  valueOf(): number {
    return this.nums.reduce((acc, cur) => acc + cur, 0);
  }
  
  toString(): string {
    const arrItems = this.nums.join(',');
    return `[${arrItems}]`;
  }
}
