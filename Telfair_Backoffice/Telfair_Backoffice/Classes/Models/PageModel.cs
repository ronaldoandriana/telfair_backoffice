using System;
using System.ComponentModel.DataAnnotations;

namespace Telfair_Backend.Classes.Models
{
    public class PageModel
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }

        public long Total { get; set; }
    }
}