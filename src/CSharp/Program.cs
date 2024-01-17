using System.Diagnostics;
using LeetCode.DataStructures;
using LeetCode.Solutions;

var solution = new Solution29();

var output = solution.Divide(1, 1);
Debug.Assert(solution.Divide(1, 1) == 1);
Debug.Assert(solution.Divide(1, -1) == -1);
Debug.Assert(solution.Divide(0, 1) == 0);
Debug.Assert(solution.Divide(10, 1) == 10);
Debug.Assert(solution.Divide(10, 2) == 5);
Debug.Assert(solution.Divide(10, -2) == -5);
Debug.Assert(solution.Divide(10, 3) == 3);
Debug.Assert(solution.Divide(7, -3) == -2);
Console.WriteLine(output);
Console.ReadLine();
