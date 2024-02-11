type MultiDimensionalArray = (number | MultiDimensionalArray)[];

/**
 * 2625. Flatten Deeply Nested Array
 * 
 * {@link https://leetcode.com/problems/flatten-deeply-nested-array See more}
 */
export function flat(arr: MultiDimensionalArray, n: number): MultiDimensionalArray {
  // if n is 0, no flattening is required, hence return the original array
  if (n === 0) {
    return arr;
  }

  // create an answer array to store final result
  const resultArr: MultiDimensionalArray = [];

  // traverse the array
  for (const item of arr) {
    // check if element is instance of array and depth is not equal to 0
    if (n > 0 && Array.isArray(item)) {

      // recursively call the function for this array and push the flattened array to the answer array
      resultArr.push(...flat(item, n - 1));
    }
    else { // else directy push the current array
      resultArr.push(item);
    }
  }

  return resultArr;
}
