﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluffinMuffin.Logger.DBAccess
{
    internal partial class BluffinMuffinLogsEntities
    {
        public BluffinMuffinLogsEntities(string connString) : base(connString)
        {
        }
    }
}