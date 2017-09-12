using FlowPattern.Data.SystemParts;
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

    public static class ItemsExtensions
    {
        public static ItemViewModel ToItemViewModel(this ASystemPart part)
        {
            var type = part.SystemPartType.ToString().ToLower();
            var viewModel = new ItemViewModel();
            viewModel.Id = type + "_" + part.Id;
            viewModel.MainCssClass = type;
            viewModel.ActiveCssClass = part.IsActive ? "active" : "";
            viewModel.ActivatedCssClass = part.IsActivated ? "activated" : "";

            return viewModel;
        }
    }
}