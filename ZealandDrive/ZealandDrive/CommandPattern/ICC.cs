﻿using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZealandDrive.CommandPattern
{
    public interface ICC
    {
        CompositeCommand OpretRuteCommand { get; }
    }
}