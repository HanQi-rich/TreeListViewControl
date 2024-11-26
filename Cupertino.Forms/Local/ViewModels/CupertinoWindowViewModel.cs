using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Cupertino.Support.Local.Helpers;
using Cupertino.Support.Local.Models;
using Jamesnet.Wpf.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.CustomControl.Local;

namespace Cupertino.Forms.Local.ViewModels
{
    public partial class CupertinoWindowViewModel : ObservableBase
    {
        [ObservableProperty]
        private List<FileItem> files=[];

        [ObservableProperty]
        public FileItem _seletItem;

        [ObservableProperty]
        private ObservableCollection<SysDeptDto> _deptTreeList = [];

        public List<SysDeptDto> deptList { get; set; } = [];
        public void InitializeViewModel()
        {
            deptList.Add(new SysDeptDto { Name = "root1", ParentId = -1, Id = 1, Leader = "admin" });
            deptList.Add(new SysDeptDto { Name = "root2", ParentId = -1, Id = 2, Leader = "admin1" });
            deptList.Add(new SysDeptDto { Name = "children10", ParentId = 1, Id = 10, Leader = "admin" });
            deptList.Add(new SysDeptDto { Name = "children11", ParentId = 1, Id = 11, Leader = "admin" });
            deptList.Add(new SysDeptDto { Name = "children20", ParentId = 2, Id = 20, Leader = "admin1" });
            deptList.Add(new SysDeptDto { Name = "children21", ParentId = 2, Id = 21, Leader = "admin1" });
            deptList.Add(new SysDeptDto { Name = "children210", ParentId = 21, Id = 210, Leader = "admin1" });

            DeptTreeList = new ObservableCollection<SysDeptDto>(BuildDepartmentTree(deptList));


            List<SysDeptDto> BuildDepartmentTree(List<SysDeptDto> depts)
            {
                var returnList = new List<SysDeptDto>();
                if (depts.Count == 0)
                    return returnList;
                foreach (var dept in depts.Where(dept => dept.ParentId == -1))
                {
                    dept.Depth = 0;
                    RecursionFn(depts, dept);
                    returnList.Add(dept);
                }

                return returnList;

                void RecursionFn(List<SysDeptDto> list, SysDeptDto sysDeptDto, int depth = 0)
                {

                    // 得到子节点列表
                    var childList = list.Where(p => p.ParentId == sysDeptDto.Id).ToList();
                    childList.ForEach(t => t.Depth = depth + 1);
                    sysDeptDto.ChildList = childList;

                    foreach (var item in childList.Where(item => list.Any(p => p.ParentId == item.Id)))
                    {
                        RecursionFn(list, item, depth + 1);
                    }
                }
            }
        }
        public CupertinoWindowViewModel()
        {
            FileCreator fileCreator = new();
            fileCreator.Create();

            int depth = 0;
            string root = fileCreator.BasePath + "/Vicky";
            List<FileItem> source = new();

            GetFiles(root, source, depth);

            Files = source;

            InitializeViewModel();
        }

        private void GetFiles(string root, List<FileItem> source, int depth)
        {
            string[] dirs = Directory.GetDirectories(root);
            string[] files = Directory.GetFiles(root);

            foreach (string dir in dirs )
            {
                FileItem item = new();
                item.Names = Path.GetFileNameWithoutExtension(dir);
                item.Paths = dir;
                item.Sizes = null;
                item.Type = "Folder";
                item.Depth = depth;
                item.Children = new();

                source.Add(item);

                GetFiles(dir, item.Children, depth + 1);
            }

            foreach (string file in files)
            {
                FileItem item = new();
                item.Names = Path.GetFileNameWithoutExtension(file);
                item.Paths = file;
                item.Sizes = new FileInfo(file).Length;
                item.Type = "File";
                item.Extension = new FileInfo(file).Extension;
                item.Depth = depth;

                source.Add(item);
            }
        }

        [RelayCommand]
        private void Selection(FileItem item)
        {
            string name = item.Names;
            SeletItem = item;
            SeletItem.isSelected = true;
        }
    }
}
