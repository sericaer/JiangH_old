using JiangH.API;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using ReactiveMarbles.PropertyChanged;
using System.Collections.Generic;
using System.ComponentModel;

namespace JiangH.Runtime
{
    internal class EnergyMgr : IEnergyMgr
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public ReadOnlyObservableCollection<IEnergyOccupy> estateOccupys { get; private set; }

        public int energyValue { get; private set; }

        public int totalEstateOccupied { get; private set; }

        private readonly IPerson owner;

        private ObservableCollection<IEnergyOccupy> _estateOccupys = new ObservableCollection<IEnergyOccupy>();
        private Dictionary<IEnergyOccupy, IDisposable> _dictOccupyDispose = new Dictionary<IEnergyOccupy, IDisposable>();

        public EnergyMgr(IPerson owner)
        {
            this.owner = owner;

            energyValue = 100;

            totalEstateOccupied = 0;

            estateOccupys = new ReadOnlyObservableCollection<IEnergyOccupy>(_estateOccupys);
        }

        public void AddEstateOccupy(IEstate estate)
        {
            var energyOccupy = new EnergyOccupy(estate, owner);
            _estateOccupys.Add(energyOccupy);


            var dispose = energyOccupy.WhenChanged(x=>x.energyValue).Subscribe(_ => UpdateTotalEstateOccupied());

            _dictOccupyDispose.Add(energyOccupy, dispose);
        }

        public void RemoveEstateOccupy(IEstate estate)
        {
            var energyOccupy = _estateOccupys.Single(x => x.target == estate);

            _estateOccupys.Remove(energyOccupy);
            UpdateTotalEstateOccupied();

            _dictOccupyDispose[energyOccupy].Dispose();
        }

        private void UpdateTotalEstateOccupied()
        {
            totalEstateOccupied = _estateOccupys.Sum(x => x.energyValue);
        }
    }
}