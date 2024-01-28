type ToBeOrNotToBe = {
  toBe: (val: any) => boolean;
  notToBe: (val: any) => boolean;
};

/**
 * 2704. To Be Or Not To Be
 * 
 * {@link https://leetcode.com/problems/to-be-or-not-to-be See more}
 */
export function expect(val1: any): ToBeOrNotToBe {
  return {
    toBe: (val2: any) => {
      if (val1 !== val2) {
        throw new Error('Not Equal');
      }
      return true;
    },
    notToBe: (val2: any) => {
      if (val1 === val2) {
        throw new Error('Equal');
      }
      return true;
    },
  };
};
