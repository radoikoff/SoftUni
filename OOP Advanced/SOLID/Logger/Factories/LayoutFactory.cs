using Logger.Models;
using Logger.Models.Interfaces;
using Logger.Models.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Factories
{
    public class LayoutFactory
    {
        public ILayout CreateLayout(string layoutType)
        {
            switch (layoutType)
            {
                case "SimpleLayout":
                    return new SimpleLayout();
                case "XmlLayout":
                    return new XmlLayout();
                default:
                    throw new ArgumentException("Invalid Layout Type!");
            }
        }
    }
}
