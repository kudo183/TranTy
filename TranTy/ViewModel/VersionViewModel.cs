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

        public VersionViewModel()
        {
            Entities = new ObservableCollection<VersionDto>();
            PagerViewModel = new PagerViewModel()
            {
                IsEnablePaging = true,
                CurrentPageIndex = 1,
                ItemCount = 0,
                PageCount = 1
            };
        }

        public void Load()
        {
            Entities.CollectionChanged -= Entitties_CollectionChanged;
            PagerViewModel.PropertyChanged -= PagerViewModel_PropertyChanged;

            Entities.Clear();
            _removedEntitties.Clear();
            _addedEntitties.Clear();

            if (PagerViewModel.IsEnablePaging == true)
            {
                var qe = new QueryBuilder.QueryExpression();
                qe.PageIndex = PagerViewModel.CurrentPageIndex;

                qe.OrderOptions.Add(new QueryBuilder.OrderByExpression.OrderOption()
                {
                    IsAscending = false,
                    PropertyPath = "NgayTaoUtc"
                });
                var result = ContextHelper.Load<VersionDto, Version>(qe, ContextHelper.CreateContext().Versions);

                foreach (var dto in result.Data)
                {
                    Entities.Add(dto);
                }

                PagerViewModel.ItemCount = Entities.Count;
                PagerViewModel.PageCount = result.PageCount;
            }
            else
            {
                var result = ContextHelper.Load<VersionDto, Version>();

                foreach (var dto in result)
                {
                    Entities.Add(dto);
                }
                PagerViewModel.ItemCount = Entities.Count;
                PagerViewModel.PageCount = 1;
            }

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
                    Load();
                    break;
                case "IsEnablePaging":
                    Console.WriteLine("IsEnablePaging: " + PagerViewModel.IsEnablePaging);
                    Load();
                    break;
            }
        }

        public void Save()
        {
            ContextHelper.Save(_addedEntitties, _removedEntitties, Entities);
            Load();
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
