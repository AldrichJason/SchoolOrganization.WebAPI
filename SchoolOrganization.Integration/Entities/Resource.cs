using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolOrganization.Integration.Entities
{
    public class Resource
    {
        public int Page { get; set; }
        public int Per_Page { get; set; }
        public int Total { get; set; }
        public int Total_Pages { get; set; }
        public List<ResourceData> Data { get; set; }

        public Resource(int page, int per_Page, int total, int total_Pages, List<ResourceData> data)
        {
            Page = page;
            Per_Page = per_Page;
            Total = total;
            Total_Pages = total_Pages;
            Data = data;
        }
    }
}
