export {};

declare global {
  interface Array<T> {
    groupBy(fn: (item: T) => string): Record<string, T[]>
  }
}

/**
 * 2631. Group By
 * 
 * {@link https://leetcode.com/problems/group-by See more}
 */
Array.prototype.groupBy = function<T>(fn: (item: T) => string) {
  const result: Record<string, T[]> = {};

  for (const item of this) {
    const key = fn(item);
    
    if (!result[key]) {
      result[key] = [];
    }

    result[key].push(item);
  }

  return result;
}
