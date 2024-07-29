using IBDApp.State;
using IBDApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBDApp.States
{
    public class DetailsStateHandler : IStateHandler
    {
        private Details _detailView;
        public DetailsStateHandler(Details detailsView)
        {
            _detailView = detailsView;
        }
        public void setErrorState()
        {
            //disable our loading state and start our error state
            _detailView.GetOverviewOnCompleted.IsVisible = false;
            _detailView.GetOverviewOnLoading.IsVisible = false;
            _detailView.GetOverviewOnError.IsVisible = true;
        }

        public void setLoadingState()
        {
            //disable our ready and error state and start our loading state
            _detailView.GetOverviewOnCompleted.IsVisible = false;
            _detailView.GetOverviewOnError.IsVisible = false;
            _detailView.GetOverviewOnLoading.IsVisible = true;
        }

        public void setReadyState()
        {
            //disable our loading state and start our ready state
            _detailView.GetOverviewOnLoading.IsVisible = false;
            _detailView.GetOverviewOnError.IsVisible = false;
            _detailView.GetOverviewOnCompleted.IsVisible = true;
        }
    }
}
