type F = (x: number) => number;

/**
 * 2629. Function Composition
 * 
 * {@link https://leetcode.com/problems/function-composition See more}
 */
export function compose(functions: F[]): F {
  return (x) => {
    for (let i = functions.length - 1; i >= 0; i--) {
      x = functions[i](x);
    }
    return x;
  }
}
