﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.Dtos;

namespace ZooWebShopAPI.Feautures.Invoices.Commands
{
    public record AddInvoiceUrlToOrderNotification(AddInvoiceToOrderDto dto) : INotification;
}