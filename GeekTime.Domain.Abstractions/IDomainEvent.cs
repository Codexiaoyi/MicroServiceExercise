﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeekTime.Domain.Abstractions
{
    public interface IDomainEvent : INotification
    {
    }
}
