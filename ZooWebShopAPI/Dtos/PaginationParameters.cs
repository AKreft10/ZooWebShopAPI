﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooWebShopAPI.Dtos
{
    public class PaginationParameters
    {
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
    }
}
