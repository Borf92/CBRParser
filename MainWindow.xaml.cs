using System.Collections.Generic;
using System.Windows;
using System.Configuration;
using System.Linq;
using CBRParser.BizObjModel;

namespace CBRParser
{
    public partial class MainWindow
    {
        private readonly string _dbConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private static readonly Logger Logger = new Logger();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void GetDataFromDbButton_Click(object sender, RoutedEventArgs e)
        {
            var cbrDbContext = new CbrDb();
            cbrDbContext.OpenConnection(_dbConnectionString);

            CurrenciesGrid.ItemsSource = cbrDbContext.GetAllValuteAsList();

            cbrDbContext.CloseConnection();
        }

        private void GetDataFromXMLByLinqButton_Click(object sender, RoutedEventArgs e)
        {
            var remoteXmlUrl = ConfigurationManager.AppSettings["ValCursXmlRemoteUrl"];
            var cbrXmlParser = new CbrXmlValCurseParser();

            var currencyRate = cbrXmlParser.GetSomeCurrencyRateFromXmlUrl(remoteXmlUrl);

            if (currencyRate == null)
            {
                return;
            }

            if (!SaveDataToDb(currencyRate))
            {
                return;
            }

            Logger.Notify("Data recieved");

        }

        private bool SaveDataToDb(IEnumerable<CurrencyRateModel> currencyRate)
        {
            var cbrDbContext = new CbrDb();
            cbrDbContext.OpenConnection(_dbConnectionString);

            if (!cbrDbContext.CleanCurrencyRateTable())
            {
                cbrDbContext.CloseConnection();
                return false;
            }

            if (currencyRate.Any(valute => !cbrDbContext.InsertCurrencyRate(valute)))
            {
                cbrDbContext.CloseConnection();
                return false;
            }

            cbrDbContext.CloseConnection();
            return true;
        }
    }
}
