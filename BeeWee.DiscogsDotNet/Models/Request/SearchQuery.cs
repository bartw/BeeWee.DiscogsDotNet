using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeeWee.DiscogsDotNet.Models
{
    public class SearchQuery
    {
        public string Query { get; set; }
        public SearchItemType? Type { get; set; }
        public string Title { get; set; }
        public string Release_title { get; set; }
        public string Credit { get; set; }
        public string Artist { get; set; }
        public string Anv { get; set; }
        public string Label { get; set; }
        public string Genre { get; set; }
        public string Style { get; set; }
        public string Country { get; set; }
        public string Year { get; set; }
        public string Format { get; set; }
        public string Catno { get; set; }
        public string Barcode { get; set; }
        public string Track { get; set; }
        public string Submitter { get; set; }
        public string Contributor { get; set; }

    }
}
