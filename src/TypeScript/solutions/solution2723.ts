type P = Promise<number>;

/**
 * 2723. Add Two Promises
 * 
 * {@link https://leetcode.com/problems/add-two-promises See more}
 */
export async function addTwoPromises(promise1: P, promise2: P): P {
  const a = await promise1;
  const b = await promise2;
  return a + b;
}
