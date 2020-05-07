using SampleApplication.Applications.Views;
using SampleApplication.Domain;
using SampleApplication.Domain.Sequences;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Waf.Applications;
using System.Windows.Input;

namespace SampleApplication.Applications.ViewModels
{
    [Export]
    public class MainViewModel : ViewModel<IMainView>
    {
        [ImportingConstructor]
        public MainViewModel(IMainView view) : base(view)
        {
        }

        private IList<SequenceGenerator> sequences;
        public IList<SequenceGenerator> Sequences
        {
            get => sequences;
            set => SetProperty(ref sequences, value);
        }

        private SequenceGenerator selectedSequence;
        public SequenceGenerator SelectedSequence
        {
            get => selectedSequence;
            set => SetProperty(ref selectedSequence, value);
        }

        private int dimensionCount;
        public int DimensionCount
        {
            get => dimensionCount;
            set
            {
                SetProperty(ref dimensionCount, value);
                RaisePropertyChanged(nameof(MaxDimensionIndex));
            }
        }

        public int MaxDimensionIndex => dimensionCount - 1;

        private int maxDimensionCount;
        public int MaxDimensionCount
        {
            get => maxDimensionCount;
            set => SetProperty(ref maxDimensionCount, value);
        }

        private int pointCount;
        public int PointCount
        {
            get => pointCount;
            set => SetProperty(ref pointCount, value);
        }

        private int xDimension;
        public int XDimension
        {
            get => xDimension;
            set => SetProperty(ref xDimension, value);
        }

        private int yDimension;
        public int YDimension
        {
            get => yDimension;
            set => SetProperty(ref yDimension, value);
        }

        private ICommand generateCommand;
        public ICommand GenerateCommand
        {
            get => generateCommand;
            set => SetProperty(ref generateCommand, value);
        }

        private string chartTitle;
        public string ChartTitle
        {
            get => chartTitle;
            set => SetProperty(ref chartTitle, value);
        }


        IList<Point> points = Array.Empty<Point>();
        public IList<Point> Points
        {
            get => points;
            set => SetProperty(ref points, value);
        }

        public void Show()
        {
            ViewCore.Show();
        }
    }
}
