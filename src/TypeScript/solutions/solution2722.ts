type JSONValue = null | boolean | number | string | JSONValue[] | { [key: string]: JSONValue };
type ArrayType = { "id": number } & Record<string, JSONValue>;

/**
 * 2722. Join Two Arrays by ID
 * 
 * {@link https://leetcode.com/problems/join-two-arrays-by-id See more}
 */
export function join(arr1: ArrayType[], arr2: ArrayType[]): ArrayType[] {
  const resultMap = new Map<number, ArrayType>();
  for (const item of arr1) {
    resultMap.set(item.id, item);
  }

  for (const item of arr2) {
    if (resultMap.has(item.id)) {
      const resultItem = resultMap.get(item.id);
      resultMap.set(item.id, { ...resultItem, ...item });
    }
    else {
      resultMap.set(item.id, item);
    }
  }

  const resultArray = Array.from(resultMap.values());
  resultArray.sort((a, b) => a.id - b.id);
  return resultArray;
}
