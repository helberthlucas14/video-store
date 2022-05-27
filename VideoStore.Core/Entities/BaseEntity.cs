﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Application.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; private set; }

        protected BaseEntity() { }
        protected BaseEntity(int id)
        {
            Id = id;
        }
    }
}
