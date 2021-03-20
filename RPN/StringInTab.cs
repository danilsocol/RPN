using System;
using System.Collections.Generic;
using System.Text;

namespace RPN
{
    class StringInTab
    {
        private int _Range;
        private string _Function;
        private string _Result;
        public int Range
        {
            get { return _Range; }
            set { _Range = value; }
        }
        public string Function
        {
            get { return _Function; }
            set { _Function = value; }
        }

        public string Result
        {
            get { return _Result; }
            set { _Result = value; }
        }
    }
}
