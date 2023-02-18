﻿using Barca.Business.Interfaces;
using Barca.Business.Models;
using Dev.Data.Context;
using Dev.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barca.Data.Repository
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(EfContext context) : base(context) { }
    }
}
