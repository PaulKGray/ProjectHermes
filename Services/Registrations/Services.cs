﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectHermes.Services.Interfaces;
using ProjectHermes.Repository.Interfaces;
using ProjectHermes.Repository;

using Ninject;
using ProjectHermes.Domain;


namespace ProjectHermes.Services.Registrations
{
    public static class Services
    {
        public static void RegisterServices(IKernel kernel)
        {
            
            // services
            
            kernel.Bind<IParentItemService>().To<ParentItemService>();
            kernel.Bind<IChildItemService>().To<ChildItemService>();

            // repositories

            kernel.Bind(typeof(IRepository<>)).To(typeof(Repository<>));

        }
    }
}