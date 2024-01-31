declare global {
  interface Array<T> {
    last(): T | -1;
  }
}

Array.prototype.last = () => {
  const arr = this as unknown as Array<any>;

  if (arr == null || arr.length === 0) {
    return -1;
  }

  return arr[arr.length - 1];
};

/**
 * 2619. Array Prototype Last
 * 
 * {@link https://leetcode.com/problems/array-prototype-last See more}
 */
export {};
