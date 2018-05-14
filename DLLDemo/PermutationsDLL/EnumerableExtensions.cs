using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomElementsControlLibrary
{
    public static class EnumerableExternsions
    {

        /**
         * Cycles IEnumberable forever
         */
        public static IEnumerable<T> Forever<T>(this IEnumerable<T> collection)
        {
            for (; /* loops forever */ ;)
            {
                foreach (var item in collection)
                {
                    yield return item;
                }
            }
        }
    
    }
}
