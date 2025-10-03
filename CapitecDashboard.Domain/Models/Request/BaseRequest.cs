using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitecDashboard.Domain.Models.Request
{
    public class BaseRequest
    {
        public string? Id { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
