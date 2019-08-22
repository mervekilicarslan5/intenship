using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Models;
namespace WebApplication3
{
    public static class Container
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.
                RegisterType<Repository>().As<IRepository<Student>>();

            return builder.Build();
        }
    }
}