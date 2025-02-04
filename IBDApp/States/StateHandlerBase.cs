using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBDApp.States
{
    public abstract class StateHandlerBase
    {
        private Grid? _onReady;
        private Grid? _onLoading;
        private Grid? _onError;

        public void Init(Grid onReady, Grid onLoading, Grid onError)
        {
            _onReady = onReady;
            _onLoading = onLoading;
            _onError = onError;
        }

        public void setReadyState()
        {
            _onReady.IsVisible = true;
            _onLoading.IsVisible = false;
            _onError.IsVisible = false;
        }

        public void setLoadingState()
        {
            _onReady.IsVisible = false;
            _onLoading.IsVisible = true;
            _onError.IsVisible = false;
        }

        public void setErrorState()
        {
            _onReady.IsVisible = false;
            _onLoading.IsVisible = false;
            _onError.IsVisible = true;
        }
    }
}
