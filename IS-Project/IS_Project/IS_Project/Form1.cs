using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            input();
        }
        public void input()
        {
            Dictionary<string, int> nameNode = new Dictionary<string, int> ();
            
            int SizeOfNode = 0;

            Console.WriteLine("Enter The Number Of Task: ");
            SizeOfNode = Convert.ToInt32(Console.ReadLine());
           
            Node[] node = new Node[SizeOfNode];
            
            for (int i = 0; i < SizeOfNode; i++)
            {
                node[i] = new Node();
                node[i].takeInput();
                nameNode.Add(node[i].name, i);
            }
/*
3
A
3

B
4   
A C
C
4
A
*/            
            for (int i = 0; i < SizeOfNode; i++)
                node[i].strTOint(nameNode);
            
            
            Diagram graph = new Diagram(node , SizeOfNode);
            Tuple<int, int> T;
            for (int i = 0; i < SizeOfNode; i++)
                T = graph.DfsUpperValues(i);
            for (int i = 0; i < SizeOfNode; i++)
                node[i].print();
                
            graph.printR();
            graph.getReverseEdges(nameNode);
            graph.drawDiagram();
        }
    }
}