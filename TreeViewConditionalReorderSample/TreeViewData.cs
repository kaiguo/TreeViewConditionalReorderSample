using System.Collections.ObjectModel;

namespace TreeViewConditionalReorderSample
{
    public class TreeViewData
    {
        public string Content { get; set; }
        public ObservableCollection<TreeViewData> Children { get; set; }
        public bool IsGroup { get; set; }
        public bool HasParent { get; set; }

        public TreeViewData()
        {
            Children = new ObservableCollection<TreeViewData>();
        }

    }
}
