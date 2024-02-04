/**
 * 2622. Cache With Time Limit
 * 
 * {@link https://leetcode.com/problems/cache-with-time-limit See more}
 */
export class TimeLimitedCache {
  private readonly cache = new Map<number, {value: number, timeoutRef: any}>();
  
  set(key: number, value: number, duration: number): boolean {
    const hasKey = this.cache.has(key);

    if (hasKey) {
      clearTimeout(this.cache.get(key)!.timeoutRef);
    }

    const timeoutRef = setTimeout(() => this.cache.delete(key), duration);
    this.cache.set(key, {value: value, timeoutRef: timeoutRef});
    return hasKey;
  }
  
  get(key: number): number {
    return this.cache.get(key)?.value ?? -1;
  }
  
  count(): number {
    return this.cache.size;
  }
}
