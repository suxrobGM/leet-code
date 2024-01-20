import { addTwoPromises } from './solutions/solution2723';

const output = addTwoPromises(new Promise(resolve => setTimeout(() => resolve(2), 20)), new Promise(resolve => setTimeout(() => resolve(5), 60)));
output.then((value) => console.log(value));
console.log();
