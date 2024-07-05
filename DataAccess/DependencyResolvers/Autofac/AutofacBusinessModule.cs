using Autofac;
using AutoMapper;
using DataAccess.AutoMapper;
using DataAccess.Sevices.Concrete;
using DataAccess.Sevices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //istek başı bu nesne bir adet üretilmesi sağlanır.
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>().InstancePerLifetimeScope();


            //Automapper configurasyonu
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new Mapping());
            });

            var mapper = mapperConfig.CreateMapper();
            builder.RegisterInstance<IMapper>(mapper);
        }
    }
}
