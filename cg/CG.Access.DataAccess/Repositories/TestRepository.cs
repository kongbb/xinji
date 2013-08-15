﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CG.Access.DataAccess.RepositoryInterface;
using Microsoft.Practices.Unity;

namespace CG.Access.DataAccess.Repositories
{
    public class TestRepository : ITestRepository
    {
        [Dependency]
        protected CGEntities Context { get; set; }

        public TestTable GetTestMessageById(long messageId)
        {
            return Context.TestTables.SingleOrDefault(x => x.Id == messageId);
        }
    }
}
