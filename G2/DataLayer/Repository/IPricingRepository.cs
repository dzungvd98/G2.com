﻿using DataLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public interface IPricingRepository
    {
        Task<IEnumerable<PricingDTO>> GetPricesByProductId(int productId);
    }
}
