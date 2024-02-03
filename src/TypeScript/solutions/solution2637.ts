type Fn = (...params: any[]) => Promise<any>;

/**
 * 2637. Promise Time Limit
 * 
 * {@link https://leetcode.com/problems/promise-time-limit See more}
 */
export function timeLimit(fn: Fn, t: number): Fn {
  return (...args) => {
    return Promise.race([
      fn(...args),
      new Promise((_, reject) => {
        setTimeout(() => {
          reject('Time Limit Exceeded');
        }, t);
      })
    ]);
  }
}
