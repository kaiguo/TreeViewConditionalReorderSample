using Microsoft.UI.Xaml.Controls;
using Windows.UI.Xaml;
using DataPackageOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation;

namespace TreeViewConditionalReorderSample
{
    class MyTreeViewItem : TreeViewItem
    {
        protected override void OnDragOver(DragEventArgs e)
        {
            base.OnDragOver(e);

            var data = DataContext as TreeViewData;
            e.AcceptedOperation = data.IsGroup ? DataPackageOperation.Move : DataPackageOperation.None;
        }

        protected override void OnDrop(DragEventArgs e)
        {
            var data = DataContext as TreeViewData;
            e.AcceptedOperation = data.IsGroup ? DataPackageOperation.Move : DataPackageOperation.None;

            base.OnDrop(e);
        }
    }
}
