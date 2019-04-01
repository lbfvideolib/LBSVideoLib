using LBFVideoLib.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LBFVideoLib.Client
{
    public static class TreeExtensions
    {
        public static List<TreeNode> Descendants(this TreeView tree)
        {
            var nodes = tree.Nodes.Cast<TreeNode>();
            return nodes.SelectMany(x => x.Descendants()).Concat(nodes).ToList();
        }

        public static List<TreeNode> Descendants(this TreeNode node)
        {
            var nodes = node.Nodes.Cast<TreeNode>().ToList();
            return nodes.SelectMany(x => Descendants(x)).Concat(nodes).ToList();
        }

        public static IEnumerable<TreeNode> FindByFullPath(this TreeView tree, string searchKey)
        {

            return tree.Descendants().Where((x) =>
            {
                string[] treeTag = x.Tag as string[];
                if (treeTag != null)
                {
                    if (treeTag.Contains(searchKey))
                    {
                        return true;
                    }
                }
                // (x.Name as string) == searchKey;
                return false;
            });

        }

    }
}
