/**
 * 2621. Sleep
 * 
 * {@link https://leetcode.com/problems/sleep See more}
 */
export async function sleep(millis: number): Promise<void> {
  const delay = new Promise((resolve) => setTimeout(resolve, millis));
  await delay;
}
