﻿using EntityFrameworkCore.Testing.Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace InnoTech.LegosForLife.DataAccess.Test
{
    public class MainDbContextTest
    {
        [Fact]
        public void DbContext_WithDbContextOptions_IsAvailable()
        {
            var mockedDbContext = Create.MockedDbContextFor<MainDbContext>();
            Assert.NotNull(mockedDbContext);
        }

        [Fact]
        public void DbContext_DbSets_MustHaveDbSetWithTypeProduct()
        {

        }
    }
}