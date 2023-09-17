using System;
using System.Collections.Generic;
using System.Text;

namespace StarterKit.Application.Filters
{
    public class RequestParameter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Culture { get; set; }
        public RequestParameter()
        {
            this.PageNumber = 1;
            this.PageSize = 20;
            this.Culture = "FR";
        }
        public RequestParameter(int pageNumber, int pageSize, string culture)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 50 ? 50 : pageSize;
            this.Culture = string.IsNullOrWhiteSpace(culture) ? "FR" : culture;
        }
    }
}
