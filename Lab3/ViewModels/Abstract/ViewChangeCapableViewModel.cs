namespace KMA.CSharp2024.Lab3.ViewModels.Abstract
{
    public abstract class ViewChangeCapableViewModel : BaseViewModel
    {
        public delegate void ChangeViewRequestedEventHandler(
            object sender, Type newViewType, object[] constructionParams
        );

        public event ChangeViewRequestedEventHandler? ChangeViewRequested;

        protected void OnChangeViewRequested(Type newViewType, object[] constructionParams)
        {
            ChangeViewRequested?.Invoke(this, newViewType, constructionParams);
        }

        public void RequestViewChange(Type newViewType, object[] constructionParam)
        {
            OnChangeViewRequested(newViewType, constructionParam);
        }
    }
}
