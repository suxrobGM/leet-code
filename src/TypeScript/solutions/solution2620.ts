/**
 * 2620. Counter
 * 
 * {@link https://leetcode.com/problems/counter See more}
 */
export function createCounter(n: number): () => number {
  return () => n++;
}
