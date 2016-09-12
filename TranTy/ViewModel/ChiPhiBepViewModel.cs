using SimpleDataGrid.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using TranTy.Dto;
using TranTy.Entity;
using TranTy.Utils;

namespace TranTy.ViewModel
{
    public class ChiPhiBepViewModel : EditableGridViewModel<ChiPhiBepDto>
    {
        private readonly List<ChiPhiBepDto> _removedEntitties = new List<ChiPhiBepDto>();
        private readonly List<ChiPhiBepDto> _addedEntitties = new List<ChiPhiBepDto>();
        private List<LoaiChiPhiDto> _loaiChiPhis;
        private List<BepDto> _beps;

        public ChiPhiBepViewModel()
        {
            Entities = new ObservableCollection<ChiPhiBepDto>();
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

                qe.WhereOptions.Add(new QueryBuilder.WhereExpression.WhereOption()
                {
                    PropertyPath = "MaVersion",
                    Predicate = "=",
                    Value = Settings.Instance.CurrentVersion.Ma
                });

                qe.OrderOptions.Add(new QueryBuilder.OrderByExpression.OrderOption()
                {
                    IsAscending = true,
                    PropertyPath = "Ma"
                });

                var result = ContextHelper.Load<ChiPhiBepDto, ChiPhiBep>(qe, ContextHelper.CreateContext().ChiPhiBeps);

                _loaiChiPhis = ContextHelper.Load<LoaiChiPhiDto, LoaiChiPhi>();
                _beps = ContextHelper.Load<BepDto, Bep>();

                foreach (var dto in result.Data)
                {
                    dto.Beps = _beps;
                    dto.LoaiChiPhis = _loaiChiPhis;
                    Entities.Add(dto);
                }

                PagerViewModel.ItemCount = Entities.Count;
                PagerViewModel.PageCount = result.PageCount;
            }
            else
            {
                var result = ContextHelper.Load<ChiPhiBepDto, ChiPhiBep>(p => p.MaVersion == Settings.Instance.CurrentVersion.Ma);

                _loaiChiPhis = ContextHelper.Load<LoaiChiPhiDto, LoaiChiPhi>();
                _beps = ContextHelper.Load<BepDto, Bep>();

                foreach (var dto in result)
                {
                    dto.Beps = _beps;
                    dto.LoaiChiPhis = _loaiChiPhis;
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

        public void Import(List<List<object>> data)
        {
            ContextHelper.CreateContext().Database.ExecuteSqlCommand(
                "delete from ChiPhiBeps where MaVersion = {0}", Settings.Instance.CurrentVersion.Ma);
            
            Entities.Clear();
            _addedEntitties.Clear();
            _removedEntitties.Clear();

            var beps = ContextHelper.Load<BepDto, Bep>()
                .ToDictionary(p => p.Ten, p => p.Ma);
            var loaiChiPhis = ContextHelper.Load<LoaiChiPhiDto, LoaiChiPhi>()
                .ToDictionary(p => p.Ten, p => p.Ma);

            foreach (var d in data)
            {
                Entities.Add(new ChiPhiBepDto()
                {
                    MaBep = beps[(string)d[0]],
                    MaLoaiChiPhi = loaiChiPhis[(string)d[1]],
                    Thang = (int)(double)d[2],
                    Nam = (int)(double)d[3],
                    ChiPhi = (long)Math.Round((double)d[4], 0)
                });
            }

            Save();
        }

        void Entitties_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Console.WriteLine("Add");
                    foreach (var entity in e.NewItems)
                    {
                        var dto = entity as ChiPhiBepDto;
                        dto.MaVersion = Settings.Instance.CurrentVersion.Ma;
                        dto.Beps = _beps;
                        dto.LoaiChiPhis = _loaiChiPhis;
                        _addedEntitties.Add(dto);
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Console.WriteLine("Remove");
                    foreach (var entity in e.OldItems)
                    {
                        _removedEntitties.Add(entity as ChiPhiBepDto);
                    }
                    break;
            }
        }
    }
}
