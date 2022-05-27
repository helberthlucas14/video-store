﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Entities;

namespace VideoStore.Application.Repositories
{
    public interface IMovieGenreRepository
    {
        Task AddMovieGenreAsync(MovieGenre genre);
    }
}
