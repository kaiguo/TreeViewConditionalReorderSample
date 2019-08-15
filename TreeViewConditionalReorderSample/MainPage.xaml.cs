using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;

namespace TreeViewConditionalReorderSample
{
    public sealed partial class MainPage : Page
    {

        public ObservableCollection<TreeViewData> DataSource { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            var item1 = new TreeViewData() { Content = "Group 1", IsGroup = true };
            item1.Children.Add(new TreeViewData() { Content = "Leaf 1.1", IsGroup = false });
            var item2 = new TreeViewData() { Content = "Leaf 1", IsGroup = false };
            var item3 = new TreeViewData() { Content = "Leaf 2", IsGroup = false };
            var item4 = new TreeViewData() { Content = "Group 3", IsGroup = true };
            DataSource = new ObservableCollection<TreeViewData> { item1, item2, item3, item4 };
        }
    }
}
