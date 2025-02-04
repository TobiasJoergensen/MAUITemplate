using IBDApp.State;
using IBDApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBDApp.States
{
    public class DetailsStateHandler : StateHandlerBase, IStateHandler
    {
        private Grid _gridOnReady;
        private Grid _gridOnLoading;
        private Grid _gridOnError;
        public DetailsStateHandler(DetailsPage detailsView)
        {
            _gridOnReady = (Grid)detailsView.FindByName("OnReady");
            _gridOnLoading = (Grid)detailsView.FindByName("OnLoading");
            _gridOnError = (Grid)detailsView.FindByName("OnError");

            base.Init(_gridOnReady, _gridOnLoading, _gridOnError);
        }
    }
}
