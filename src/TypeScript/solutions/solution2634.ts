type Fn = (n: number, i: number) => any;

/**
 * 2634. Filter Elements from Array
 * 
 * {@link https://leetcode.com/problems/filter-elements-from-array See more}
 */
export function filter(arr: number[], fn: Fn): number[] {
  const result: number[] = [];

  for (let i = 0; i < arr.length; i++) {
    if (fn(arr[i], i)) {
      result.push(arr[i]);
    }
  }

  return result;
}
