using Ninject.Modules;
using ShopViewer.BLL.Interfaces;
using ShopViewer.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopViewer.WEB.Infrastructure {

    public class NinjectWEBServiceModule : NinjectModule {

        public override void Load() {
            this.Bind<IShopService>().To<ShopService>();
            this.Bind<IProductService>().To<ProductService>();
        }
    }
}