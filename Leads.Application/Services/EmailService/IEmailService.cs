﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leads.Application.Services.EmailService
{
    public interface IEmailService
    {
        Task SendAcceptanceEmail();
    }
}
