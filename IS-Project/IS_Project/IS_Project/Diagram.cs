using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;

namespace IS_Project
{
    class Diagram
    {
        Node[] node = new Node[1];
        Button[] currentNodeButton;
        List<List<int>> rEdges;
        List<int> levelCoutner;
        List<int> topoSort;
        List<int> rTopoSort;
        List<bool> visited;
        int numberOfNodes;
        bool isDrawn;

        public Diagram(Node[] nod, int size)
        {
            isDrawn = false;
            visited = new List<bool>();
            topoSort = new List<int>(); 
            System.Array.Resize(ref node, size);
            rEdges = new List<List<int>>();
            for (int i = 0; i < size; i++)
            {
                visited.Add(false);
                rEdges.Add(new List<int>());
                rEdges[i] = new List<int>();
                node[i] = new Node();
                levelCoutner = new List<int>();
                node[i] = nod[i];
            }
            numberOfNodes = size;
        }
        

        public void getReverseEdges(IDictionary<string, int> trunNameIntoInt)
        {
            foreach(Node i in node)
            {
                foreach(int j in i.child())
                {
                    rEdges[j].Add(trunNameIntoInt[i.name]);
                }
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

            Console.WriteLine(node[idx].name);
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

        public void printR()
        {

            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < rEdges.Count; i++)
            {
                Console.WriteLine(node[i].name + " : ");
                for (int j = 0; j < rEdges[i].Count; j++)
                {
                    Console.Write(node[rEdges[i][j]].name + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("end");
        }

        public void DfsLowerValues()
        {

        }

        void TopolocgicalSort(int idx)
        {
            visited[idx] = true;
            foreach(int i in node[idx].child())
                if (!visited[i])
                    TopolocgicalSort(i);
            topoSort.Add(idx);
        }

        public void rTopologicalSorting(int idx)
        {
            visited[idx] = true;
            foreach (int i in node[idx].rChild)
                if (!visited[i])
                    rTopologicalSorting(i);
            rTopoSort.Add(idx);
        }

        public void drawDiagram()
        {
            for (int i = 0; i < numberOfNodes; i++)
                if (!visited[i])
                    TopolocgicalSort(i);
            
            Form drawingForm = new Form();
            drawingForm.Size = new Size(1500, 700);
            drawingForm.StartPosition = FormStartPosition.CenterScreen;
            Panel panel = new Panel();
            panel.AutoScroll = true;
            panel.Size = new Size(drawingForm.Width , drawingForm.Height);
            drawingForm.Controls.Add(panel);

            int startX = 10 , startY = 10;
            int x = 0, y = 0;
            Size SIZE = new Size(50, 50);
            int addWidth /*= SIZE.Width / 2*/ , addHeight = SIZE.Height / 2;

            addWidth = drawingForm.Width / (numberOfNodes + 2);

            currentNodeButton = new Button[numberOfNodes+2];
            currentNodeButton[0] = new Button();
            currentNodeButton[0].Size = SIZE;
            currentNodeButton[0].Location = new Point( startX  , startY);
            currentNodeButton[0].Text = "Start";
            panel.Controls.Add(currentNodeButton[0]);
            
            y = x = 10;
            foreach(int i in topoSort) 
            {
                currentNodeButton[i+1] = new Button();
                currentNodeButton[i+1].Size = SIZE;

                x += addWidth ;
                y +=  SIZE.Height;
                
                currentNodeButton[i+1].Location = new Point(x, y);
                node[i].btnIndex = i + 1;
                currentNodeButton[i+1].Text = node[i].name;
                panel.Controls.Add(currentNodeButton[i+1]);
            }

            x += addWidth ;
            y += SIZE.Height;

            currentNodeButton[numberOfNodes + 1] = new Button();
            currentNodeButton[numberOfNodes + 1].Size = SIZE;
            currentNodeButton[numberOfNodes + 1].Location = new Point(x, y);
            currentNodeButton[numberOfNodes + 1].Text = "Finish";
            panel.Controls.Add(currentNodeButton[topoSort.Count + 1]);
            
            panel.Paint += new PaintEventHandler(panel_paint);
            
            drawingForm.Show();
        }
        
        private void panel_paint(object sender, PaintEventArgs e)
        {
            List<int> positionIn = new List<int>();
            List<int> positionOut = new List<int>();
            foreach(Button btn in currentNodeButton)
            {
                positionIn.Add(btn.Location.Y + btn.Size.Height - 5);
                positionOut.Add(btn.Location.X + btn.Width - 3);
            }

            Pen penWithoutArrow = new Pen(Color.Black);
            Pen penWithArrow = new Pen(Color.Black);
            using (GraphicsPath capPath = new GraphicsPath())
            {
                capPath.AddLine(-5, 0, 5, 0);
                capPath.AddLine(-5, 0, 0, 5);
                capPath.AddLine(0, 5, 5, 0);

                penWithArrow.CustomEndCap = new CustomLineCap(null, capPath);

                Console.WriteLine("hello");

                foreach(int child in topoSort)
                {
                    Console.WriteLine( child + " " + node[child].name + " " + node[child].child().Count);
                    if(node[child].child().Count == 0)
                    {
                        int i = 0;
                        int j = node[child].btnIndex;
                        e.Graphics.DrawLine(penWithoutArrow, positionOut[i], currentNodeButton[i].Location.Y + currentNodeButton[i].Height - 3, positionOut[i], positionIn[j]);


                        e.Graphics.DrawLine(penWithArrow, positionOut[i] , positionIn[j] , currentNodeButton[j].Location.X - 5, positionIn[j]);

                        positionIn[j] -= 5;
                        positionOut[i] -= 5;
                    }

                    foreach(int parnet in node[child].child())
                    {
                        node[parnet].isFree = false;
                        int i = node[parnet].btnIndex;
                        int j = node[child].btnIndex;
                        e.Graphics.DrawLine(penWithoutArrow, positionOut[i] , currentNodeButton[i].Location.Y + currentNodeButton[i].Height-3, positionOut[i] ,positionIn[j]);

                        e.Graphics.DrawLine(penWithArrow, positionOut[i] , positionIn[j] , currentNodeButton[j].Location.X -5, positionIn[j]);

                        positionIn[j] -= 5;
                        positionOut[i] -= 5;
                    }
   
                }

                int takeFromFinish = 0;
                foreach (Node currNode in node)
                {
                    if (currNode.isFree)
                    {
                        int i = currNode.btnIndex;
                        int j = numberOfNodes + 1;
                        e.Graphics.DrawLine(penWithoutArrow, positionOut[i], currentNodeButton[i].Location.Y + currentNodeButton[i].Height - 3, positionOut[i], currentNodeButton[j].Location.Y + currentNodeButton[j].Height - 5 - takeFromFinish);

                        e.Graphics.DrawLine(penWithArrow, positionOut[i], currentNodeButton[j].Location.Y + currentNodeButton[j].Height - 5 - takeFromFinish, currentNodeButton[j].Location.X - 5, currentNodeButton[j].Location.Y + currentNodeButton[j].Height - 5 - takeFromFinish);

                        takeFromFinish += 5;
                        positionOut[i] -= 5;
                    }
                }
            }

        }

    }
}
