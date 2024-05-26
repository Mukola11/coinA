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
using coinA.Services;
using System.Diagnostics;

namespace coinA.ViewModels
{
    public class CryptoDetailViewModel : ViewModelBase
    {
        private readonly CryptoApiService _cryptoApiService;

        public string Id { get; }

        public ICommand NavigateBackCommand { get; }

        public ICommand OpenUrlCommand { get; }

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
            _cryptoApiService = new CryptoApiService();
            Id = id;

            NavigateBackCommand = new NavigateCommand(navigationStore, new TopCryptoViewModel(navigationStore));

            _ = LoadCryptoDetailAsync(id);

            OpenUrlCommand = new OpenUrlCommand();
        }


        private async Task LoadCryptoDetailAsync(string id)
        {
            CryptoDetail = await _cryptoApiService.GetCryptoDetailAsync(id);
        }

        private void UpdatePriceChangePlot()
        {
            if (CryptoDetail?.PriceChanges != null && CryptoDetail.PriceChanges.Any())
            {
                var plotModel = new PlotModel { Title = "Price change in 24 hours" };

                var dateAxis = new DateTimeAxis
                {
                    Position = AxisPosition.Bottom,
                    StringFormat = "HH:mm",
                    IntervalType = DateTimeIntervalType.Hours,
                    MajorGridlineStyle = LineStyle.Solid,
                    MajorGridlineColor = OxyColors.LightGray,
                    MinorGridlineStyle = LineStyle.Dot,
                    MinorGridlineColor = OxyColors.LightGray
                };
                plotModel.Axes.Add(dateAxis);

                var valueAxis = new LinearAxis
                {
                    Position = AxisPosition.Left,
                    MajorGridlineStyle = LineStyle.Solid,
                    MajorGridlineColor = OxyColors.LightGray,
                    MinorGridlineStyle = LineStyle.Dot,
                    MinorGridlineColor = OxyColors.LightGray
                };
                plotModel.Axes.Add(valueAxis);

                var series = new LineSeries
                {
                    Color = OxyColors.Red,
                    StrokeThickness = 2
                };

                foreach (var priceChange in CryptoDetail.PriceChanges)
                {
                    var time = DateTimeOffset.FromUnixTimeMilliseconds(priceChange.Timestamp).DateTime;
                    series.Points.Add(new DataPoint(DateTimeAxis.ToDouble(time), (double)priceChange.Price));
                }

                plotModel.Series.Add(series);
                PriceChangePlotModel = plotModel;
            }
        }


    }
}
