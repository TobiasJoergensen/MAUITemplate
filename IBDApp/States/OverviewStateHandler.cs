using IBDApp.Views;

namespace IBDApp.State
{
    public class OverviewStateHandler : IStateHandler
    {
        private Overview _overviewView;
        public OverviewStateHandler(Overview overviewView) { 
            _overviewView = overviewView;
        }

        public void setErrorState()
        {
            //disable our loading state and start our error state
            _overviewView.GetOverviewOnCompleted.IsVisible = false;
            _overviewView.GetOverviewOnLoading.IsVisible = false;
            _overviewView.GetOverviewOnError.IsVisible = true;
        }

        public void setLoadingState()
        {
            //disable our ready and error state and start our loading state
            _overviewView.GetOverviewOnCompleted.IsVisible = false;
            _overviewView.GetOverviewOnError.IsVisible = false;
            _overviewView.GetOverviewOnLoading.IsVisible = true;
        }

        public void setReadyState()
        {
            //disable our loading state and start our ready state
            _overviewView.GetOverviewOnLoading.IsVisible = false;
            _overviewView.GetOverviewOnError.IsVisible = false;
            _overviewView.GetOverviewOnCompleted.IsVisible = true;
        }
    }
}
