using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace orderApi.RequestModel
{
    public class OrderInputModel
    {
        [Required]
        public List<string> Items { get; set; }

        [Required]
        public string CustomerName { get; set; }
    }
}
