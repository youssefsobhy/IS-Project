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
            Diagram graph = new Diagram();
            Node x = new Node("a", 0, 0, 0, 0 , 0);
            Node y = new Node("b", 0, 0, 0, 0 , 0);

            graph.addNode(x);
            graph.addNode(y);
            graph.addEdge(x.name, y.name);
            graph.addEdge(y.name, x.name);

            graph.addNode(new Node("c", 0, 0, 0, 0 , 0));
            graph.addNode(new Node("d", 0, 0, 0, 0 , 0));
            graph.addNode(new Node("e", 0, 0, 0, 0 , 0));
            graph.addNode(new Node("f", 0, 0, 0, 0 , 0));
            
            graph.printAll();
        }
    }
}
