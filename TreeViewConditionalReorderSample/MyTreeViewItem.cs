using Microsoft.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using DataPackageOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation;
using MUXC = Microsoft.UI.Xaml.Controls;

namespace TreeViewConditionalReorderSample
{
    class MyTreeViewItem : MUXC.TreeViewItem
    {
        protected override void OnDragOver(DragEventArgs e)
        {
            base.OnDragOver(e);

            var data = DataContext as TreeViewData;
            e.AcceptedOperation = data.IsGroup ? DataPackageOperation.Move : DataPackageOperation.None;
        }

        protected override void OnDrop(DragEventArgs e)
        {
            DependencyObject parent = this;
            while(!(parent is MUXC.TreeViewList))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }

            var treeViewList = parent as MUXC.TreeViewList;
            var insertionPanel = treeViewList.ItemsPanelRoot as IInsertionPanel;

            int aboveIndex = -1;
            int belowIndex = -1;
            var point = e.GetPosition(insertionPanel as UIElement);
            insertionPanel.GetInsertionIndexes(point, out aboveIndex, out belowIndex);
            var treeViewDataAbove = GetDataFromIndex(treeViewList, aboveIndex);
            var treeViewDataBelow = GetDataFromIndex(treeViewList, belowIndex);

            var data = DataContext as TreeViewData;
            e.AcceptedOperation = /*IsAbleToDrop*/ ? DataPackageOperation.Move : DataPackageOperation.None;

            var item = MainPage.DraggedItems;
            base.OnDrop(e);
        }

        private TreeViewData GetDataFromIndex(MUXC.TreeViewList list, int index)
        {
            var treeViewItem = list.ContainerFromIndex(index);
            if(treeViewItem != null)
            {
                var data = list.ItemFromContainer(treeViewItem);
                return data as TreeViewData;
            }

            return null;
        }
    }
}
