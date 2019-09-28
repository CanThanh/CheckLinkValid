using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckLinkValid
{
    public class ValidateLink
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemLink { get; set; }
        public string NameLinkCheck { get; set; }
        public string HrefLinkCheck { get; set; }
        public string LinkPrevious { get; set; }
        public string LinkNext { get; set; }
        public bool IsValid { get; set; }
    }
}
