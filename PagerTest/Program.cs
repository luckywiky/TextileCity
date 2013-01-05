using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextileCity.Entity;

namespace PagerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Pager pager = new Pager(1, 150, 8);
            for (int i = 1; i <= pager.Count; i++)
            {
                pager.Index=i;
                List<PagerItem> items = pager.CreatePager();
                StringBuilder strPager =new StringBuilder();
                strPager.AppendFormat("第{0}页：",i);
                foreach(PagerItem item in items)
                {
                    if (item.Active)
                    {
                        strPager.AppendFormat(" [{0}]", item.Text);
                    }
                    else
                    {
                        strPager.AppendFormat(" {0}", item.Text);
                    }
                }
                Console.WriteLine(strPager);
            }

            Console.Read();
        }
    }
}
