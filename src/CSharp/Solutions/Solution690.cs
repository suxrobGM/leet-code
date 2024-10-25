namespace LeetCode.Solutions;

public class Solution690
{
    /// <summary>
    /// 690. Employee Importance - Medium
    /// <a href="https://leetcode.com/problems/employee-importance">See the problem</a>
    /// </summary>
    public int GetImportance(IList<Employee> employees, int id)
    {
        var employeeMap = employees.ToDictionary(e => e.id);
        return GetImportance(employeeMap, id);
    }

    private static int GetImportance(Dictionary<int, Employee> employeeMap, int id)
    {
        var employee = employeeMap[id];
        var importance = employee.importance;
        foreach (var subordinateId in employee.subordinates)
        {
            importance += GetImportance(employeeMap, subordinateId);
        }

        return importance;
    }

    public class Employee {
        public int id;
        public int importance;
        public IList<int> subordinates;
    }
}
