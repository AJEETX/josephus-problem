using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Library
{
    public class ResultData
    {
        public IEnumerable<int> RemovedChildrenSequence { get; set; }
        public int WinningChild { get; set; }
        public bool HasError { get; set; }
    }
}
