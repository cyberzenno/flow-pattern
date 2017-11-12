using FlowPattern.Data.SystemParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlowPattern.Web.Models.ViewModels
{
    public class ItemViewModel
    {
        public string Id { get; set; }
        public string MainCssClass { get; set; }
        public string ActiveCssClass { get; set; }
        public string ActivatedCssClass { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public string OutputConnections { get; set; }
    }

    public static class ItemsExtensions
    {
        public static ItemViewModel ToItemViewModel(this ASystemPart part)
        {
            var viewModel = new ItemViewModel();
            viewModel.Id = part.Id;
            viewModel.X = int.Parse(part.Attributes["x"]);
            viewModel.Y = int.Parse(part.Attributes["y"]);
            viewModel.MainCssClass = part.GetViewPartType();
            viewModel.ActiveCssClass = part.IsActive ? "active" : "";
            viewModel.ActivatedCssClass = part.IsActivated ? "activated" : "";

            viewModel.OutputConnections = "";

            foreach (var outputPart in part.Output)
            {
                viewModel.OutputConnections += outputPart.Id + " ";
            }


            return viewModel;
        }

        public static string GetViewPartType(this ASystemPart part)
        {
            return part.SystemPartType.ToString().ToLower();
        }
    }
}