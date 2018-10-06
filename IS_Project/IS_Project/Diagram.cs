using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_Project
{
    class Diagram
    {
        public Dictionary<string , HashSet<string>> adj;
        public Dictionary<string , HashSet<string>> radj;
        public Dictionary<string, Node> strToNode;
        public List<int> levelCounter; 
        
        public Diagram()
        {
            adj = new Dictionary<string , HashSet<string>>();
            radj = new Dictionary<string , HashSet<string>>();
            strToNode = new Dictionary<string, Node>();
        }

        public void addNode(Node node)
        {
            strToNode[node.name] = node;
            adj[node.name] = new HashSet<string>();
        }

        public void printAll()
        {
            foreach(KeyValuePair<string, HashSet<string>> node in adj)
            {
                Console.WriteLine(node.Key + ": ");
                foreach (string item in node.Value)
                    Console.Write(item + " ");
                Console.WriteLine();
            }
        }

        public void addEdge(string parent , string child)
        {
            adj[parent].Add(child);
        }

        public void DfsUpperValues()
        {

        }

        public void DfsLowerValues()
        {

        }
 
        public void maxLevel()
        {
            
        }
        public void drawDiagram()
        {

        }
    }
}
