namespace LeetCode.Solutions;

public class Solution2115
{
    /// <summary>
    /// 2115. Find All Possible Recipes from Given Supplies - Medium
    /// <a href="https://leetcode.com/problems/find-all-possible-recipes-from-given-supplies">See the problem</a>
    /// </summary>
    public IList<string> FindAllRecipes(string[] recipes, IList<IList<string>> ingredients, string[] supplies)
    {
        var graph = new Dictionary<string, List<string>>();
        var inDegree = new Dictionary<string, int>();

        for (var i = 0; i < recipes.Length; i++)
        {
            inDegree[recipes[i]] = ingredients[i].Count;
            foreach (var ingredient in ingredients[i])
            {
                if (!graph.TryGetValue(ingredient, out var dependents))
                {
                    dependents = [];
                    graph[ingredient] = dependents;
                }
                dependents.Add(recipes[i]);
            }
        }

        var queue = new Queue<string>();
        foreach (var supply in supplies)
        {
            queue.Enqueue(supply);
        }

        var result = new List<string>();
        while (queue.Count > 0)
        {
            var item = queue.Dequeue();
            if (!graph.TryGetValue(item, out var dependents))
            {
                continue;
            }

            foreach (var recipe in dependents)
            {
                if (--inDegree[recipe] == 0)
                {
                    result.Add(recipe);
                    queue.Enqueue(recipe);
                }
            }
        }

        return result;
    }
}
