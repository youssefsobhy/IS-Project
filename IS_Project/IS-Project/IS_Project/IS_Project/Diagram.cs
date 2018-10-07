using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_Project
{
    class Diagram
    {
        Node[] node = new Node[1];
        

        public Diagram(Node[] nod , int size)
        {
            System.Array.Resize(ref node, size);
            for(int i=0; i<size; i++)
            {
                node[i] = new Node();
                node[i] = nod[i];
            }
        }

        

       

       

        public Tuple<int, int> DfsUpperValues(int idx)
        {
            Tuple<int, int> T;
            if (node[idx].vis==1)
            {
                T = new Tuple<int, int>(node[idx].level, node[idx].EF);
                return T;
            }
            node[idx].vis = 1;
            int maxlvl = 0, maxEF = 0;
            List < int > Child = node[idx].child();
            for (int i=0; i<Child.Count; i++)
            {
                Tuple<int, int> Nt;
                Nt = DfsUpperValues(Child[i]);
                if (Nt.Item1 > maxlvl)
                    maxlvl = Nt.Item1;
                if (Nt.Item2 > maxEF)
                    maxEF = Nt.Item2;

            }
            node[idx].level = maxlvl + 1;
            node[idx].ES = maxEF;
            node[idx].EF = maxEF + node[idx].durationTime;
            T = new Tuple<int, int>(node[idx].level, node[idx].EF);
            return T;
        }
        public void endFirstDFS(ref Node[] n , int size)
        {
            for (int i = 0; i < size; i++)
                n[i] = node[i];
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
