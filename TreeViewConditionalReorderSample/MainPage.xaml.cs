using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;

namespace TreeViewConditionalReorderSample
{
    public sealed partial class MainPage : Page
    {

        public ObservableCollection<TreeViewData> DataSource { get; set; }
        public static List<TreeViewData> DraggedItems { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            DraggedItems = new List<TreeViewData>();
            var item1 = new TreeViewData() { Content = "Group 1", IsGroup = true };
            item1.Children.Add(new TreeViewData() { Content = "Leaf 1.1", IsGroup = false, HasParent = true });
            item1.Children.Add(new TreeViewData() { Content = "Leaf 1.2", IsGroup = false, HasParent = true });
            var item2 = new TreeViewData() { Content = "Leaf 1", IsGroup = false };
            var item3 = new TreeViewData() { Content = "Leaf 2", IsGroup = false };
            var item4 = new TreeViewData() { Content = "Leaf 3", IsGroup = false };
            var item5 = new TreeViewData() { Content = "Group 3", IsGroup = true };
            DataSource = new ObservableCollection<TreeViewData> { item1, item2, item3, item4, item5 };
        }

        private void TreeView_DragItemsStarting(Microsoft.UI.Xaml.Controls.TreeView sender, Microsoft.UI.Xaml.Controls.TreeViewDragItemsStartingEventArgs args)
        {
            foreach (var item in args.Items)
            {
                DraggedItems.Add(item as TreeViewData);
            }
        }

        private void TreeView_DragItemsCompleted(Microsoft.UI.Xaml.Controls.TreeView sender, Microsoft.UI.Xaml.Controls.TreeViewDragItemsCompletedEventArgs args)
        {
            foreach(TreeViewData item in args.Items)
            {
                item.HasParent = args.NewParent!=null ? true : false;
            }
            DraggedItems.Clear();
        }
    }
}
