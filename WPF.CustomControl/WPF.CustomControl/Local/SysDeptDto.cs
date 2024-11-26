using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.CustomControl.Local
{
    public partial class SysDeptDto:ObservableObject
    {
        [ObservableProperty]
        private string _name = string.Empty;

        [ObservableProperty]
        private long _id = 0;

        [ObservableProperty]
        private long _parentId = -1;

        [ObservableProperty]
        private string _leader = string.Empty;

        [ObservableProperty]
        private bool? _isSelected = false;

        [ObservableProperty]
        private int? _depth = 0;

        [ObservableProperty]
        private List<SysDeptDto> _childList = [];
    }
}
