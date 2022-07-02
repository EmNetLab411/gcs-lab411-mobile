﻿using GCS_LAB411.Commands;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GCS_LAB411.ViewModels.SubViewsModel
{
    public class MapViewModel : BaseViewModel
    {
        private SlideConfirmViewModel _scViewModel;
        private VehicleManagerViewModel _vhManagerViewModel;
        public VehicleManagerViewModel VehicleManagerViewModel
        {
            get => _vhManagerViewModel;
        }
        public PilotCommand AutoPilotCommand { get; set; }
        public MapViewModel(SlideConfirmViewModel scViewModel, VehicleManagerViewModel vhManagerViewModel)
        {
            _scViewModel = scViewModel;
            _vhManagerViewModel = vhManagerViewModel;
            AutoPilotCommand = new PilotCommand(this, scViewModel);
        }

        private bool _isShow = true;
        public bool IsShow
        {
            get => _isShow;
            set => SetProperty(ref _isShow, value);
        }

        public void HandleChangeMode(int mode)
        {
            _vhManagerViewModel.Vehicle.DoChangeMode(mode);
        }

        public async Task<Tuple<bool, string>> FlytoAction()
        {
            
            return await Task.FromResult(Tuple.Create(false, ""));
        }

        public async Task<Tuple<bool, string>> Takeoff(float altitude)
        {
            return await _vhManagerViewModel.Vehicle.Takeoff(altitude);
        }

        public async Task<Tuple<bool, string>> ArmDisarm()
        {
            return await _vhManagerViewModel.Vehicle.ArmDisarm();
        }
    }
}
