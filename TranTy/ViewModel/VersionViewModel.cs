using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using SimpleDataGrid.ViewModel;
using TranTy.Dto;
using TranTy.Utils;
using Version = TranTy.Entity.Version;

namespace TranTy.ViewModel
{
    public class VersionViewModel : EditableGridViewModel<VersionDto>
    {
        private readonly List<VersionDto> _removedEntitties = new List<VersionDto>();
        private readonly List<VersionDto> _addedEntitties = new List<VersionDto>();

        public void Load()
        {
            var dataSource = ContextHelper.Load<VersionDto, Version>();

            if (Entities != null)
            {
                Entities.CollectionChanged -= Entitties_CollectionChanged;
            }

            Entities = new ObservableCollection<VersionDto>(dataSource);
            _removedEntitties.Clear();
            _addedEntitties.Clear();
            PagerViewModel = new PagerViewModel()
            {
                IsEnablePaging = true,
                CurrentPageIndex = 1,
                ItemCount = 3,
                PageCount = 5
            };

            PagerViewModel.PropertyChanged += PagerViewModel_PropertyChanged;
            Entities.CollectionChanged += Entitties_CollectionChanged;
        }

        public void Unload()
        {
            PagerViewModel.PropertyChanged -= PagerViewModel_PropertyChanged;
            Entities.CollectionChanged -= Entitties_CollectionChanged;
        }

        void PagerViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "CurrentPageIndex":
                    Console.WriteLine("CurrentPageIndex: " + PagerViewModel.CurrentPageIndex);
                    break;
                case "IsEnablePaging":
                    Console.WriteLine("IsEnablePaging: " + PagerViewModel.IsEnablePaging);
                    break;
            }
        }

        public void Save()
        {
            ContextHelper.Save(_addedEntitties, _removedEntitties, Entities);
        }

        void Entitties_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Console.WriteLine("Add");
                    foreach (var entity in e.NewItems)
                    {
                        _addedEntitties.Add(entity as VersionDto);
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Console.WriteLine("Remove");
                    foreach (var entity in e.OldItems)
                    {
                        _removedEntitties.Add(entity as VersionDto);
                    }
                    break;
            }
        }
    }
}
