using System.Collections.Generic;

namespace Demo.Library.Model
{
    public class ResultData
    {
        public IEnumerable<int> RemovedChildrenSequence { get; set; }
        public int WinningChild { get; set; }
        public bool HasError { get; set; }
    }
}
