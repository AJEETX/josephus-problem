using System;
using System.Collections.Generic;
using System.Text;

namespace Josephus.Library
{
    class ResultData
    {
        public IEnumerable<int> RemovedChildrenSequence { get; set; }
        public int WinningChild { get; set; }
    }
}
