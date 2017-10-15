using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreServer.Models
{
    public class NodeModel
    {

        public string Id { get; set; }
        public string ParentId { get; set; }
        public string RocketId { get; set; }
        public string Text { get; set; }
        public string Flags { get; set; }
        public double Order { get; set; }
        public bool ChildrenVisibility { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

    }
}
