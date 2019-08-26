using System.Collections;
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
            DraggedItems = new List<TreeViewData>();
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

        private void TreeView_DragItemsStarting(Microsoft.UI.Xaml.Controls.TreeView sender, Microsoft.UI.Xaml.Controls.TreeViewDragItemsStartingEventArgs args)
        {
            foreach (var item in args.Items)
            {
                DraggedItems.Add(item as TreeViewData);
            }
        }

        private void TreeView_DragItemsCompleted(Microsoft.UI.Xaml.Controls.TreeView sender, Microsoft.UI.Xaml.Controls.TreeViewDragItemsCompletedEventArgs args)
        {
            DraggedItems.Clear();
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var result = new List<string>();
            TraverseTreeViewData(DataSource, result);
            TestTextBlock.Text = string.Join(", ", result);
        }

        private void TraverseTreeViewData(ObservableCollection<TreeViewData> data, List<string> result)
        {
            if (data == null) return;

            foreach (var d in data)
            {
                result.Add(d.Content);
                TraverseTreeViewData(d.Children, result);
            }
        }
    }
}
