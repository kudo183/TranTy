using SimpleDataGrid.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranTy.Dto;
using TranTy.Entity;
using TranTy.Utils;

namespace TranTy.ViewModel
{
    public class LoaiChiPhiViewModel : EditableGridViewModel<LoaiChiPhiDto>
    {
        private readonly List<LoaiChiPhiDto> _removedEntitties = new List<LoaiChiPhiDto>();
        private readonly List<LoaiChiPhiDto> _addedEntitties = new List<LoaiChiPhiDto>();

        public LoaiChiPhiViewModel()
        {
            Entities = new ObservableCollection<LoaiChiPhiDto>();
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
                var result = ContextHelper.Load<LoaiChiPhiDto, LoaiChiPhi>(qe, ContextHelper.CreateContext().LoaiChiPhis);

                foreach (var dto in result.Data)
                {
                    Entities.Add(dto);
                }

                PagerViewModel.ItemCount = Entities.Count;
                PagerViewModel.PageCount = result.PageCount;
            }
            else
            {
                var result = ContextHelper.Load<LoaiChiPhiDto, LoaiChiPhi>();

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
                        _addedEntitties.Add(entity as LoaiChiPhiDto);
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Console.WriteLine("Remove");
                    foreach (var entity in e.OldItems)
                    {
                        _removedEntitties.Add(entity as LoaiChiPhiDto);
                    }
                    break;
            }
        }
    }
}
