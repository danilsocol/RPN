using System;
using System.Collections.Generic;
using System.Text;

namespace RPN.Logic
{
    public class RowInTabl
    {
        private string _RPN;
        private int _step;
        private double _res;

        public string RPN 
        { 
            get { return _RPN; } 
            set { _RPN = value; }
        }
        public int step 
        { 
            get { return _step; }
            set { _step = value; }
        }
        public double res 
        { 
            get { return _res; }
            set { _res = value; } 
        }
    }
}
