using SampleApplication.Applications.ViewModels;
using SampleApplication.Domain.Sequences;
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
            mainViewModel.Sequences = CreateSequenceGenerators();
            mainViewModel.SelectedSequence = mainViewModel.Sequences[0];
            mainViewModel.Show();
        }

        public void Shutdown()
        {
        }

        private IList<SequenceGenerator> CreateSequenceGenerators()
        {
            return new List<SequenceGenerator>
            {
                new SobolSequenceGenerator(),
                new HaltonSequenceGenerator(),
                new HammersleySequenceGenerator(),
                new FaureSequenceGenerator()
            };
        }

        private void GeneratePoints()
        {
            try
            {
                SequenceGenerator selectedSequence = mainViewModel.SelectedSequence;
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
