using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2domacazadaca
{
    public class DuplicateTodoItemException : Exception
    {
        public DuplicateTodoItemException() : base("Item with same ID already in base.")
        {
        }
    }
}
