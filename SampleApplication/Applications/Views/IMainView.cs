using System.Waf.Applications;

namespace SampleApplication.Applications.Views
{
    public interface IMainView : IView
    {
        void Show();

        void Close();
    }
}
