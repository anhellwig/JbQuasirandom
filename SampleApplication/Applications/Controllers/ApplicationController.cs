using SampleApplication.Applications.Sequences;
using SampleApplication.Applications.ViewModels;
using SampleApplication.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Waf.Applications;
using System.Waf.Applications.Services;

namespace SampleApplication.Applications.Controllers
{
    [Export]
    internal class ApplicationController
    {
        private readonly MainViewModel mainViewModel;
        private readonly IMessageService messageService;


        [ImportingConstructor]
        public ApplicationController(MainViewModel mainViewModel, IMessageService messageService)
        {
            this.mainViewModel = mainViewModel;
            this.messageService = messageService;
        }

        public void Initialize()
        {
        }

        public void Run()
        {
            mainViewModel.PointCount = 100;
            mainViewModel.DimensionCount = 3;
            mainViewModel.XDimension = 1;
            mainViewModel.YDimension = 2;
            mainViewModel.GenerateCommand = new DelegateCommand(GeneratePoints);
            mainViewModel.Sequences = CreateSequenceModels();
            mainViewModel.SelectedSequence = mainViewModel.Sequences[0];
            mainViewModel.Show();
        }

        public void Shutdown()
        {
        }

        private IList<SequenceModelBase> CreateSequenceModels()
        {
            return new List<SequenceModelBase>
            {
                new SobolSequenceModel(),
                new HaltonSequenceModel(),
                new HammersleySequenceModel(),
                new FaureSequenceModel()
            };
        }

        private void GeneratePoints()
        {
            try
            {
                SequenceModelBase selectedSequence = mainViewModel.SelectedSequence;
                mainViewModel.ChartTitle = selectedSequence.Description;
                mainViewModel.Points = selectedSequence.GeneratePoints(mainViewModel.DimensionCount,
                    mainViewModel.PointCount,
                    mainViewModel.XDimension,
                    mainViewModel.YDimension);
            }
            catch (Exception ex)
            {
                messageService.ShowError(mainViewModel.View, ex.Message);
            }
        }
    }
}
