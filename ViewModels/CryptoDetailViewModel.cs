using coinA.Models;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using coinA.Stores;
using coinA.Commands;

namespace coinA.ViewModels
{
    public class CryptoDetailViewModel : ViewModelBase
    {
        public string Id { get; }

        public ICommand NavigateBackCommand { get; }

        private CryptoDetailModel cryptoDetail;
        public CryptoDetailModel CryptoDetail
        {
            get => cryptoDetail;
            set
            {
                if (cryptoDetail != value)
                {
                    cryptoDetail = value;
                    OnPropertyChange(nameof(CryptoDetail));
                    UpdatePriceChangePlot();
                }
            }
        }

        private PlotModel priceChangePlotModel;
        public PlotModel PriceChangePlotModel
        {
            get => priceChangePlotModel;
            set
            {
                if (priceChangePlotModel != value)
                {
                    priceChangePlotModel = value;
                    OnPropertyChange(nameof(PriceChangePlotModel));
                }
            }
        }

        public CryptoDetailViewModel(NavigationStore navigationStore, string id)
        {
            NavigateBackCommand = new NavigateBackCommand(navigationStore);

            CryptoDetail = new CryptoDetailModel
            {
                Name = "Bitcoin",
                Symbol = id,
                Image = "https://assets.coingecko.com/coins/images/1/large/bitcoin.png?1696501400",
                CurrentPrice = 40000.00m,
                Volume = 15000000m,
                Markets = new List<Market>
                {
                    new Market { Name = "Market 1", Price = 40000.00m },
                    new Market { Name = "Market 2", Price = 40010.00m },
                },
                PriceChanges = new List<PriceChange>
                {
                    new PriceChange { Timestamp = DateTime.Now.AddHours(-5), Price = 39500.00m },
                    new PriceChange { Timestamp = DateTime.Now.AddHours(-4), Price = 39600.00m },
                    new PriceChange { Timestamp = DateTime.Now.AddHours(-3), Price = 39700.00m },
                    new PriceChange { Timestamp = DateTime.Now.AddHours(-2), Price = 39800.00m },
                    new PriceChange { Timestamp = DateTime.Now.AddHours(-1), Price = 39900.00m },
                    new PriceChange { Timestamp = DateTime.Now, Price = 40000.00m },
                }
            };

            UpdatePriceChangePlot();

            Id = id;
        }

        private void UpdatePriceChangePlot()
        {
            var plotModel = new PlotModel { Title = "Price Changes Over Time" };
            var series = new LineSeries { MarkerType = MarkerType.Circle };

            foreach (var priceChange in CryptoDetail.PriceChanges)
            {
                series.Points.Add(new DataPoint(DateTimeAxis.ToDouble(priceChange.Timestamp), (double)priceChange.Price));
            }

            plotModel.Series.Add(series);
            PriceChangePlotModel = plotModel;
        }
    }
}
