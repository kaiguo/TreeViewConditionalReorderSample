using Microsoft.UI.Xaml.Controls;
using Windows.UI.Xaml;
using DataPackageOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation;

namespace TreeViewConditionalReorderSample
{
    class MyTreeViewItem : TreeViewItem
    {
        protected override void OnDragEnter(DragEventArgs e)
        {
            var draggedItem = MainPage.DraggedItems[0];
            var draggedOverItem = DataContext as TreeViewData;
            // Block TreeViewNode auto expanding if we are dragging a group onto another group
            if (draggedItem.IsGroup && draggedOverItem.IsGroup)
            {
                e.Handled = true;
            }

            base.OnDragEnter(e);
        }

        protected override void OnDragOver(DragEventArgs e)
        {
            var draggedItem = MainPage.DraggedItems[0];
            var draggedOverItem = DataContext as TreeViewData;

            if (draggedItem.IsGroup && (draggedOverItem.IsGroup || draggedOverItem.Parent!=null))
            {
                //- Group
                //-- Leaf1
                //-- (Group2) <- Blocks dropping another Group here
                //-- Leaf2
                e.Handled = true;
            }
            base.OnDragOver(e);
            e.AcceptedOperation = draggedOverItem.IsGroup && !draggedItem.IsGroup ? DataPackageOperation.Move : DataPackageOperation.None;
        }
        protected override void OnDrop(DragEventArgs e)
        {
            var data = DataContext as TreeViewData;
            // Block all drops on leaf node
            if(!data.IsGroup)
            {
                e.Handled = true;
            }

            base.OnDrop(e);
        }

    }
}
