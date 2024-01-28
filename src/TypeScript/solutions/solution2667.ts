type P = Promise<number>;

/**
 * 2667. Create Hello World Function
 * 
 * {@link https://leetcode.com/problems/create-hello-world-function See more}
 */
export function createHelloWorld() {
  return function(...args: any[]): string {
    return 'Hello World';
  }
}
