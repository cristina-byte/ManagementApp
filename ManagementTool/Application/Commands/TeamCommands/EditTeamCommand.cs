﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.TeamCommands
{
    public class EditTeamCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
