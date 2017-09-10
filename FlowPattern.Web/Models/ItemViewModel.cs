using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlowPattern.Web.Models
{
    public class ItemViewModel
    {
        public string Id { get; set; }
        public string MainCssClass { get; set; }
        public string ActiveCssClass { get; set; }
        public string ActivatedCssClass { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public void XY(int x, int y)
        {
            X = x; Y = y;
        }
    }
}