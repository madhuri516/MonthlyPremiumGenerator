﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CmdApi.Models
{
    public class CommandContext: DbContext
    {
        public CommandContext(DbContextOptions<CommandContext> options) : base (options)
        {

        }

        public DbSet<Command> CommandItems { get; set; }
    }
}
