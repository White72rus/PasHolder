using System.Windows;
using System.Windows.Controls;

namespace PassHolder.Components
{
    public partial class PanelItem : UserControl
    {

        private static readonly DependencyProperty _appNameLabel = DependencyProperty.Register(
            "AppLabel",
            typeof(string),
            typeof(PanelItem),
            new PropertyMetadata(null));
        private static readonly DependencyProperty _appLoginLabel = DependencyProperty.Register(
            "LoginLabel",
            typeof(string),
            typeof(PanelItem),
            new PropertyMetadata(null));
        private static readonly DependencyProperty _appPassLabel = DependencyProperty.Register(
            "PassLabel",
            typeof(string),
            typeof(PanelItem),
            new PropertyMetadata(null));
        private static readonly DependencyProperty _appUrlLabel = DependencyProperty.Register(
            "UrlLabel",
            typeof(string),
            typeof(PanelItem),
            new PropertyMetadata(null));
        private static readonly DependencyProperty _appId = DependencyProperty.Register(
            "Id",
            typeof(string),
            typeof(PanelItem),
            new PropertyMetadata(null));

        public string Id
        {
            get { return (string)GetValue(_appId); }
            set { SetValue(_appId, value); }
        }

        public string AppLabel
        {
            get { return (string)GetValue(_appNameLabel); }
            set { SetValue(_appNameLabel, value); }
        }

        public string LoginLabel
        {
            get { return (string)GetValue(_appLoginLabel); }
            set { SetValue(_appLoginLabel, value); }
        }

        public string PassLabel
        {
            get { return (string)GetValue(_appPassLabel); }
            set { SetValue(_appPassLabel, value); }
        }
        public string UrlLabel
        {
            get { return (string)GetValue(_appUrlLabel); }
            set { SetValue(_appUrlLabel, value); }
        }
        public PanelItem()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
}
