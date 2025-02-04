using IBDApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class MAUIAppProvider
    {
        public MauiApp MauiApp { get; private set; }

        public MAUIAppProvider()
        {
            MauiApp = CreateServiceProvider();
        }

        private MauiApp CreateServiceProvider()
        {
            var mauiApp = MauiProgram.CreateMauiApp();

            return mauiApp;
        }
    }
}
