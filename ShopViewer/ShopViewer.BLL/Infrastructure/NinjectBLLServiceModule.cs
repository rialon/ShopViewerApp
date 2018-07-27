using Ninject.Modules;
using ShopViewer.DAL.Interfaces;
using ShopViewer.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopViewer.BLL.Infrastructure {

    public class NinjectBLLServiceModule : NinjectModule {
        private string _connectionString;

        public NinjectBLLServiceModule(string connectionString) {
            this._connectionString = connectionString;
        }

        public override void Load() {
            this.Bind<ITradeUnitOfWork>().To<TradeUnitOfWork>().WithConstructorArgument(this._connectionString);
        }
    }
}
