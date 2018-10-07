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
        public int ES, EF, LS, LF, durationTime, V1, V2, level, vis;
        List<string> Dep;
        List<int> Child;
        public Node()
        {
            name = "2";
            durationTime = 0;
            ES = 0;
            EF = 0;
            LS = 0;
            LF = 0;
            level = 0;
            vis = 0;
            Dep = new List<string>();
            Child = new List<int>();
        }
        public string takeInput()
        {
            Console.WriteLine("Enter task name: ");
            name = Console.ReadLine();

            Console.WriteLine("Enter task task duration: ");
            durationTime = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter task number of dependencies: ");
            string depen = Console.ReadLine();
            string OneDep = "";
            for (int i = 0; i < depen.Length; i++)
            {
                if (depen[i] == ' ')
                {
                    if (OneDep.Length >= 1)
                    {
                        Dep.Add(OneDep);
                    }
                    OneDep = "";
                }
                else
                    OneDep += depen[i];

            }
            if (OneDep.Length >= 1)
            {
                Dep.Add(OneDep);
            }
            return name;
        }


        public void strTOint(IDictionary<string, int> rename)
        {
            foreach (string i in Dep)
            {
                Child.Add(rename[i]);
            }
        }
        public void print()
        {
            Console.WriteLine(name);
            Console.WriteLine("The Early Start is : " + ES + " and The Early Finish is : " + EF);
            Console.WriteLine("The Node lvl :" + level);
            Console.WriteLine();


        }
        public List<int> child()
        {
            return Child;
        }

    }
}
