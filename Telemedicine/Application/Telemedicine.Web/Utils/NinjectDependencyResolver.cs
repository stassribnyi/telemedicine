using Ninject;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Telemedicine.Business.Interfaces.Services.AnalyzeService;
using Telemedicine.Business.Interfaces.Services.CommentService;
using Telemedicine.Business.Interfaces.Services.DoctorService;
using Telemedicine.Business.Interfaces.Services.PatientService;
using Telemedicine.Common.Factories;
using Telemedicine.Domain.Interfaces.Common;
using Telemedicine.Domain.Interfaces.Repositories;
using Telemedicine.Infrastructure.Business.Services.Analyzes;
using Telemedicine.Infrastructure.Business.Services.CommentService;
using Telemedicine.Infrastructure.Business.Services.DoctorService;
using Telemedicine.Infrastructure.Business.Services.PatientService;
using Telemedicine.Infrastructure.Data;

namespace Telemedicine.Web.Util
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel _kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            _kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            _kernel.Bind<IAnalyzeRepository>().To<AnalyzeRepository>();
            _kernel.Bind<IDoctorRepository>().To<DoctorRepository>();
            _kernel.Bind<IHospitalRepository>().To<HospitalRepository>();
            _kernel.Bind<IPatientRepository>().To<PatientRepository>();
            _kernel.Bind<IECGRepository>().To<ECGRepository>();
            _kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            _kernel.Bind<IMapperFactory>().To<MapperFactory>();
            _kernel.Bind<IPatientService>().To<PatientService>();
            _kernel.Bind<IDoctorService>().To<DoctorService>();
            _kernel.Bind<ICommentService>().To<CommentService>();
            _kernel.Bind<IAnalyzeService>().To<AnalyzeService>();

        }
    }
}