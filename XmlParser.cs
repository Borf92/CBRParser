using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using CBRParser.BizObjModel;

namespace CBRParser
{
    public class CbrXmlValCurseParser
    {
        private static readonly Logger Logger = new Logger();

        public List<CurrencyRateModel> GetSomeCurrencyRateFromXmlUrl(string url)
        {
            try
            {
                var httpRequest = (HttpWebRequest)WebRequest.Create(url);
                var result = new List<CurrencyRateModel>();
                using (var httpResponse = (HttpWebResponse)httpRequest.GetResponse())
                {
                    var responseStream = httpResponse.GetResponseStream();

                    var doc = XDocument.Load(responseStream);

                    var selectedCurency = new[] { ValuteCharCodeEnum.USD.ToString(), ValuteCharCodeEnum.GBP.ToString(), ValuteCharCodeEnum.EUR.ToString() };

                    if (doc.Root != null)
                    {
                        result.AddRange(doc.Root.Elements()
                            .Where(c => selectedCurency.Contains(c.Element("CharCode")?.Value))
                            .Select(valute => new CurrencyRateModel
                            {
                                ValuteId = valute.Attribute("ID")?.Value,
                                NumCode = int.Parse(valute.Element("NumCode")?.Value),
                                CharCode = valute.Element("CharCode")?.Value,
                                Nominal = int.Parse(valute.Element("Nominal")?.Value),
                                Name = valute.Element("Name")?.Value,
                                Value = valute.Element("Value").Value.ToDecimalWithInvariantCulture()
                            }));
                    }
                }
                return result;
            }
            catch (Exception exception)
            {
                Logger.Error(exception);
                return null;
            }
        }
    }
}
