using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using Gallery.Core.Domain;
using Gallery.Web.App_Start;
using Gallery.Web.Models;

namespace Gallery.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DependancyInjection.Setup();
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Mapper.CreateMap<Image, ImageModel>();
            Mapper.CreateMap<Album, AlbumModel>();

            Mapper.CreateMap<GalleryItem, BaseGalleryModel>()
                .Include<GalleryItemImage, GalleryImageModel>()
                .Include<GalleryItemAlbum, GalleryAlbumModel>();
            Mapper.CreateMap<GalleryItemImage, GalleryImageModel>();
            Mapper.CreateMap<GalleryItemAlbum, GalleryAlbumModel>();
        }
    }
}
