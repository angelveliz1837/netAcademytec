﻿using Domain.Domain;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IFactura : ISelect<Factura>, ICrud<Factura>
    {
    }
}
