using CapitecDashboard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitecDashboard.Domain.Utils
{
    public interface IEmailService
    {
        void Send(Email email);
    }
}
