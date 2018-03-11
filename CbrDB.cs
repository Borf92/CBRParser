using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CBRParser.BizObjModel;

namespace CBRParser
{
    public class CbrDb
    {
        private SqlConnection _sqlConnection;
        private static readonly Logger Logger = new Logger();

        public void OpenConnection(string connectionString)
        {
            _sqlConnection = new SqlConnection { ConnectionString = connectionString };
            _sqlConnection.Open();
        }

        public void CloseConnection()
        {
            _sqlConnection.Close();
        }

        public bool InsertCurrencyRate(CurrencyRateModel currencyRateModel)
        {
            var isSuccess = false;
            var sqlStatement =
                string.Format("INSERT INTO tb_valute ([ValuteId], [NumCode], [CharCode], [Nominal], [Name], [Value])" +
                              "VALUES ('{0}', '{1}', '{2}', {3}, N'{4}', {5})",
                    currencyRateModel.ValuteId,
                    currencyRateModel.NumCode,
                    currencyRateModel.CharCode,
                    currencyRateModel.Nominal,
                    currencyRateModel.Name,
                    currencyRateModel.Value.ToStingWithDot());

            using (var sqlCommand = new SqlCommand(sqlStatement, _sqlConnection))
            {
                try
                {
                    sqlCommand.ExecuteNonQuery();
                    isSuccess = true;
                }
                catch (Exception exception)
                {
                    var errorHandler = new Logger();
                    errorHandler.Error(exception);
                }
            }

            return isSuccess;
        }

        public List<CurrencyRateModel> GetAllValuteAsList()
        {
            var сurrencyRateList = new List<CurrencyRateModel>();
            var sqlStatement = "SELECT * FROM tb_valute";
            try
            {
                using (var sqlCommand = new SqlCommand(sqlStatement, _sqlConnection))
                {
                    using (var dataReader = sqlCommand.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            сurrencyRateList.Add(new CurrencyRateModel
                            {
                                ValuteId = (string)dataReader["ValuteId"],
                                NumCode = (int)dataReader["NumCode"],
                                CharCode = (string)dataReader["CharCode"],
                                Nominal = (int)dataReader["Nominal"],
                                Name = (string)dataReader["Name"],
                                Value = (decimal)dataReader["Value"]
                            });
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Logger.Error(exception);
            }
            return сurrencyRateList;
        }

        public bool CleanCurrencyRateTable()
        {
            var isSuccess = false;
            var sqlStatement = "DELETE FROM tb_valute";
            try
            {
                using (var sqlCommand = new SqlCommand(sqlStatement, _sqlConnection))
                {
                    sqlCommand.ExecuteNonQuery();
                    isSuccess = true;
                }
            }
            catch (Exception exception)
            {
                Logger.Error(exception);
            }
            return isSuccess;
        }
    }
}
