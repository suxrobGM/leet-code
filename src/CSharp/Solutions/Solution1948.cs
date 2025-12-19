using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1948
{
    private class TrieNode
    {
        public Dictionary<string, TrieNode> children = new Dictionary<string, TrieNode>();
    }

    /// <summary>
    /// 1948. Delete Duplicate Folders in System - Hard
    /// <a href="https://leetcode.com/problems/delete-duplicate-folders-in-system">See the problem</a>
    /// </summary>
    public IList<IList<string>> DeleteDuplicateFolder(IList<IList<string>> paths)
    {
        // Build trie structure from paths
        var root = new TrieNode();
        foreach (var path in paths)
        {
            var current = root;
            foreach (var folder in path)
            {
                if (!current.children.ContainsKey(folder))
                {
                    current.children[folder] = new TrieNode();
                }
                current = current.children[folder];
            }
        }

        // Compute signatures and find duplicates
        var signatureCounts = new Dictionary<string, int>();
        var nodeSignatures = new Dictionary<TrieNode, string>();

        GetSignature(root, signatureCounts, nodeSignatures);

        // Mark nodes with duplicate signatures
        var duplicates = new HashSet<TrieNode>();
        foreach (var entry in nodeSignatures)
        {
            if (signatureCounts[entry.Value] > 1)
            {
                duplicates.Add(entry.Key);
            }
        }

        // Collect remaining paths
        var result = new List<IList<string>>();
        var currentPath = new List<string>();
        DFS(root, currentPath, duplicates, result);

        return result;
    }

    private string GetSignature(TrieNode node, Dictionary<string, int> signatureCounts,
                                Dictionary<TrieNode, string> nodeSignatures)
    {
        var childSignatures = new List<string>();

        // Post-order traversal: process children first
        foreach (var child in node.children.OrderBy(x => x.Key))
        {
            string childSig = GetSignature(child.Value, signatureCounts, nodeSignatures);
            childSignatures.Add(child.Key + ":" + childSig);
        }

        // Only non-leaf nodes get signatures (for comparison purposes)
        if (childSignatures.Count > 0)
        {
            string sig = "(" + string.Join(",", childSignatures) + ")";

            nodeSignatures[node] = sig;

            // Count occurrences of this signature
            if (!signatureCounts.ContainsKey(sig))
            {
                signatureCounts[sig] = 0;
            }
            signatureCounts[sig]++;

            return sig;
        }

        return "()"; // Leaf node - return empty signature
    }

    private void DFS(TrieNode node, List<string> path, HashSet<TrieNode> duplicates,
                     IList<IList<string>> result)
    {
        foreach (var child in node.children)
        {
            // Skip if this folder is marked for deletion
            if (!duplicates.Contains(child.Value))
            {
                path.Add(child.Key);
                result.Add([.. path]);
                DFS(child.Value, path, duplicates, result);
                path.RemoveAt(path.Count - 1);
            }
        }
    }
}
