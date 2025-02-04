using IBDApp.States;
using IBDApp.Views;

namespace IBDApp.State
{
    public class OverviewStateHandler : StateHandlerBase, IStateHandler
    {
        private Grid _gridOnReady;
        private Grid _gridOnLoading;
        private Grid _gridOnError; 
        
        public OverviewStateHandler(OverviewPage overviewView) {
            _gridOnReady = (Grid)overviewView.FindByName("OnReady");
            _gridOnLoading = (Grid)overviewView.FindByName("OnLoading");
            _gridOnError = (Grid)overviewView.FindByName("OnError");

            base.Init(_gridOnReady, _gridOnLoading, _gridOnError);
        }
    }
}
