﻿using System.ComponentModel;
using System.Windows;
using PlannerClosedXML.Model;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using RelayCommand = CommunityToolkit.Mvvm.Input.RelayCommand;

namespace PlannerClosedXML.ViewModel
{
    public class MainViewModel : ObservableObject, INotifyPropertyChanged
    {
        private PlannerGenerator _plannerGenerator;
        public MainViewModel()
        {
            _plannerGenerator = new PlannerGenerator();
            InitializeMonths();
        }
        
        private RelayCommand _generateCommand;
        public RelayCommand GenerateCommand
        {
            get
            {
                if (_generateCommand == null)
                {
                    _generateCommand = new RelayCommand(GeneratePlanner);
                }
                return _generateCommand;
            }
        }

        private int? _year;
        public int? Year
        {
            get => _year;
            set => SetProperty(ref _year, value);
        }

        private int? _firstMonth;
        public int? FirstMonth
        {
            get => _firstMonth; 
            set => SetProperty(ref _firstMonth, value);
        }

        private int? _numberOfMonths;
        public int? NumberOfMonths
        {
            get => _numberOfMonths;
            set => SetProperty(ref _numberOfMonths, value);
        }

        private List<int> _months;
        public List<int> Months
        {
            get => _months;
            set => SetProperty(ref _months, value);
        }

        private Visibility _labelVisibility = Visibility.Visible;
        public Visibility LabelVisibility
        {
            get => _labelVisibility;
            set => SetProperty(ref _labelVisibility, value);
        }

        private Visibility _comboBoxVisibility = Visibility.Collapsed;
        public Visibility ComboBoxVisibility
        {
            get => _comboBoxVisibility;
            set => SetProperty(ref _comboBoxVisibility, value);
        }

        private CommunityToolkit.Mvvm.Input.RelayCommand _labelClickedCommand;
        public CommunityToolkit.Mvvm.Input.RelayCommand LabelClickedCommand
        {
            get
            {
                if (_labelClickedCommand == null)
                {
                    _labelClickedCommand = new RelayCommand(LabelClicked);
                }
                return _labelClickedCommand;
            }
        }
        private void InitializeMonths()
        {
            Months = Enumerable.Range(1, 12).ToList();
        }

        public void LabelClicked()
        {
            LabelVisibility = Visibility.Collapsed;
            ComboBoxVisibility = Visibility.Visible;
        }

        private async void GeneratePlanner()
        {
            await _plannerGenerator.GeneratePlanner(Year, FirstMonth, NumberOfMonths);
            Year = null;
            FirstMonth = null;
            NumberOfMonths = null;
        }
    }
}