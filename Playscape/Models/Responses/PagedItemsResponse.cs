using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sabio.Web.Models.Responses
{
    public class PagedItemsResponse<T> : ItemsResponse<T>
    {
        public int PageNumber {get;set;}

        public int PageSize { get; set; }

        public int TotalItems { get; set; }

        public string QueryString { get; set; }

        public Guid UserId { get; set; }

    }
}