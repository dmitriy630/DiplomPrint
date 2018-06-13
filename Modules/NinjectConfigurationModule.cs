using System;
using Ninject.Modules;
using DiplomPrint.Model;
using DiplomPrint.Model.DBContext;

namespace DiplomPrint.Modules
{
    class NinjectConfigurationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<StudentContext>().ToSelf();
            Bind<Student>().ToSelf();
            Bind<CourseWork>().ToSelf();
            Bind<Practice>().ToSelf();
            Bind<StateAttestation>().ToSelf();
            Bind<Discipline>().ToSelf();
            Bind<Electives>().ToSelf();
            Bind<AdditionalInformation>().ToSelf();
        }
    }
}
