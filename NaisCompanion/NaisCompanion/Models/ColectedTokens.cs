using System;
using System.Collections.Generic;
using System.Text;

namespace NaisCompanion.Models
{
    public class ColectedTokens
    {
        public int LocationId { get; set; }
        public bool VisitedTokens { get; set; }
        public bool PhotoTokens { get; set; }
        public bool PostTokens { get; set; }
    }
}
