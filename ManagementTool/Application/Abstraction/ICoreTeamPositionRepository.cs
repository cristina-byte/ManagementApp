﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction
{
    public interface ICoreTeamPositionRepository
    {
        public Task CreateAsync(CoreTeamPosition position);
    }
}
