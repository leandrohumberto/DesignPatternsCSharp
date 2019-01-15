using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class SingletonRecordFinder
    {
        public int GetTotalPopulation(params string[] names)
        {
            int result = 0;

            foreach (var name in names)
            {
                result += SingletonDatabase.Instance.GetPopulation(name);
            }

            return result;
        }
    }
}
