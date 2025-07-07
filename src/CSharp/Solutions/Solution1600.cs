using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1600
{
    /// <summary>
    /// 1600. Throne Inheritance - Medium
    /// <a href="https://leetcode.com/problems/throne-inheritance">See the problem</a>
    /// </summary>
    public class ThroneInheritance
    {
        private readonly Dictionary<string, List<string>> _familyTree;
        private readonly HashSet<string> _deadMembers;
        private readonly string _king;

        public ThroneInheritance(string kingName)
        {
            _king = kingName;
            _familyTree = [];
            _deadMembers = [];
            _familyTree[kingName] = [];
        }

        public void Birth(string parentName, string childName)
        {
            if (!_familyTree.ContainsKey(parentName))
            {
                _familyTree[parentName] = [];
            }
            _familyTree[parentName].Add(childName);
            _familyTree[childName] = [];
        }

        public void Death(string name)
        {
            _deadMembers.Add(name);
        }

        public IList<string> GetInheritanceOrder()
        {
            var result = new List<string>();
            TraverseFamilyTree(_king, result);
            return result;
        }

        private void TraverseFamilyTree(string name, List<string> result)
        {
            if (!_deadMembers.Contains(name))
            {
                result.Add(name);
            }
            if (_familyTree.ContainsKey(name))
            {
                foreach (var child in _familyTree[name])
                {
                    TraverseFamilyTree(child, result);
                }
            }
        }
    }
}
