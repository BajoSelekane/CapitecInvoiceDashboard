using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitecDashboard.Domain.Models
{
    public class BackDateDataModel
    {
        public int RowNumber { get; set; }
        public string? Number { get; set; }
        public string? DateCaptured { get; set; }
        public string? Name { get; set; }
        public string? SurnameAtBirth { get; set; }
        public string? Sex { get; set; }
        public string? Ethnicity { get; set; }
        public string? DateOfBirth { get; set; }
        public string? IdNumber { get; set; }
        public string? Operation { get; set; }
        public string? BusinessUnit { get; set; }
        public string? ImplementingPartner { get; set; }
        public string? PackageOfService { get; set; }
        public string? ServiceRendered { get; set; }
        public string? Province { get; set; }
        public string? District { get; set; }
        public string? SubDistrict { get; set; }
        public string? Facility { get; set; }
        public string? ProvinceOfBirth { get; set; }
        public string? AdditionalNeeds { get; set; }
        public string? ReferredOnwards { get; set; }
    }
}
