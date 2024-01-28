type Counter = {
  increment: () => number,
  decrement: () => number,
  reset: () => number,
}

/**
 * 2665. Counter II
 * 
 * {@link https://leetcode.com/problems/counter-ii See more}
 */
export function createCounter(init: number): Counter {
  const initialValue = init;

  return {
    increment: () => ++init,
    decrement: () => --init,
    reset: () => init = initialValue,
  };
}
