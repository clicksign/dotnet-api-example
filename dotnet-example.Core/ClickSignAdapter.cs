using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dotnet_example.Core
{
    public class ClickSignAdapter
    {
        private Clicksign.Clicksign _clicksign;

        public ClickSignAdapter()
        {
            _clicksign = new Clicksign.Clicksign();
        }
    }
}
