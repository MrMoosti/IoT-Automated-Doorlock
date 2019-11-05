using Rfid.Logger;
using Rfid.Persistence.MongoDb;
using Rfid.Persistence.MongoDb.Repositories;
using Rfid.Persistence.MongoDb.UnitOfWorks;
using Rfid.Persistence.Repositories;
using Rfid.Persistence.UnitOfWorks;
using Unity;
using Unity.Lifetime;

namespace RfidScanner
{
    public static class Unity
    {
        private static UnityContainer container;

        private static UnityContainer Container
        {
            get
            {
                //Register all types if none are register.
                if (container == null)
                    RegisterTypes();
                return container;
            }
        }


        /// <summary>
        /// Resolve a objects that is registered in the <see cref="container"/>.
        /// </summary>
        /// <typeparam name="T">The object you want to resolve</typeparam>
        /// <returns>The resolved object.</returns>
        public static T Resolve<T>()
        {
            return (T)Container.Resolve(typeof(T));
        }


        /// <summary>
        /// Registers objects to the <see cref="container"/>
        /// </summary>
        public static void RegisterTypes()
        {
            container = new UnityContainer();

            container.RegisterType<ILogger, Logger>(new PerResolveLifetimeManager());
            //container.RegisterSingleton<RfidMenu>();
            container.RegisterSingleton<Scanner>();
            container.RegisterSingleton<CpuTemp>();


            //DI for the persistence database.
            #region Persistence

            container.RegisterSingleton<MongoContext>();
            container.RegisterType<IUnitOfWork, UnitOfWork>(new PerResolveLifetimeManager());
            container.RegisterType<ILogRepository, LogRepository>(new PerResolveLifetimeManager());
            container.RegisterType<IDoorRepository, DoorRepository>(new PerResolveLifetimeManager());
            container.RegisterType<ICpuRepository, CpuRepository>(new PerResolveLifetimeManager());

            #endregion
        }
    }
}
