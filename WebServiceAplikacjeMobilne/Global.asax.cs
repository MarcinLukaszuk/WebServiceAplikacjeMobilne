using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebServiceAplikacjeMobilne.Models;

namespace WebServiceAplikacjeMobilne
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Mapper.Initialize(cfg => cfg.AddProfile<DefaultProfile>());
        }
        public class DefaultProfile : Profile
        {
            public DefaultProfile()
            {
                CreateMap<Competition, CompetitionViewModel>();
                CreateMap<Event, EventViewModel>();
                CreateMap<EventCompetition, EventCompetitionViewModel>().ForMember(x => x.CompetitionName, y => y.Ignore());
                CreateMap<ShooterEventCompetition, ShooterEventCompetitionViewModel>().ForMember(x=>x.Shoots,y=>y.Ignore());
                CreateMap<Shoot, ShootViewModel>();
                CreateMap<Shooter, ShooterViewModel>();

            }
        }
    }
}
