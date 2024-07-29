namespace IBDApp.State
{
    internal interface IStateHandler
    {
        //Create an interface for our states to be implemented in all views
        public void setErrorState();
        public void setLoadingState();
        public void setReadyState();
    }
}
