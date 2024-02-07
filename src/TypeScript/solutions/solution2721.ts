type Fn<T> = () => Promise<T>;

/**
 * 2721. Execute Asynchronous Functions in Parallel
 * 
 * {@link https://leetcode.com/problems/execute-asynchronous-functions-in-parallel See more}
 */
export async function promiseAll<T>(functions: Fn<T>[]): Promise<T[]> {
  return new Promise((resolve, reject) => {
    const results = new Array<T>(functions.length);
    let count = 0;
    
    functions.forEach((func, index) => {
      func()
        .then((result) => {
          results[index] = result;
          count++;

          if (count === functions.length) {
            resolve(results);
          }
        })
        .catch((reason) => reject(reason));
    });
  });
}
