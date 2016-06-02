using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmStore.core.Interfaces;
using FilmStore.core;

namespace FilmStore.IntegrationTests
{
    public class DependencyInjection : NinjectModule
    {
        public override void Load()
        {
            Bind<IFilmRepository>().To<CollectionFilmRepository>();
            Bind<ISerializer>().To<XmlSerializer>();
        }
    }
}
