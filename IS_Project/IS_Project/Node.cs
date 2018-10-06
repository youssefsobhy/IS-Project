using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_Project
{
    class Node
    {
        public string name;
        public int ES, EF, LS, LF, durationTime, V1, V2;
        List<string> Dep;

        public Node(string receiveName, int _durationTime , int receiveES, int receiveEF, int receiveLS, int receiveLF)
        {
            name = receiveName;
            durationTime = _durationTime;
            ES = receiveES;
            EF = receiveEF;
            LS = receiveLS;
            LF = receiveLF;
            Dep = new List<string>();
        }
        public void takeInput()
        {
            Console.WriteLine("Enter task name: ");
            name = Console.ReadLine();
            Console.WriteLine("Enter task task duration: ");
            durationTime = Console.Read();
            Console.WriteLine("Enter task number of dependencies: ");
        }

        public void insertChild(string node)
        {
            Dep.Add(node);
        }
    }
}
