using Microsoft.UI.Xaml.Controls;
using Windows.UI.Xaml;
using DataPackageOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation;

namespace TreeViewConditionalReorderSample
{
    class MyTreeViewItem : TreeViewItem
    {
        protected override void OnDragOver(DragEventArgs e)
        {
            var draggedItem = MainPage.DraggedItems[0];
            var draggedOverItem = DataContext as TreeViewData;
            if (draggedItem.IsGroup && (draggedOverItem.IsGroup || draggedOverItem.HasParent))
            {
                e.Handled = true;
            }
            base.OnDragOver(e);
            e.AcceptedOperation = draggedOverItem.IsGroup && !draggedItem.IsGroup ? DataPackageOperation.Move : DataPackageOperation.None;
        }
        protected override void OnDrop(DragEventArgs e)
        {
            var data = DataContext as TreeViewData;
            if(!data.IsGroup)
            {
                e.Handled = true;
            }

            base.OnDrop(e);
        }

    }
}
