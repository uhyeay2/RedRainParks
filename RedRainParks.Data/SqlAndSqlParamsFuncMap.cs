using System.Data;

namespace RedRainParks.Data
{
    /// <summary>
    /// This class represents the ( StoredProcedureName OR InlineSql ) to run, 
    /// and the function that translates our Request object into the parameters for SQL
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    internal class SqlAndSqlParamsFuncMap<TRequest>
    {
        #region Constructor
        public SqlAndSqlParamsFuncMap(string procNameorInlineSql, Func<TRequest, object> generateSqlParamsFunc)
        {
            _procNameOrInlineSql = procNameorInlineSql;
            _generateSqlParamsFunc = generateSqlParamsFunc;
        }
        #endregion

        #region Private Members

        private Func<TRequest, object> _generateSqlParamsFunc;

        private string _procNameOrInlineSql;

        #endregion

        #region Exposed Members

        public string ProcNameOrInlineSql { get => _procNameOrInlineSql; }
        
        public CommandType CommandType { get => IsForStoredProcRequest ? CommandType.StoredProcedure : CommandType.Text; }

        public object? GetParametersOrDefault(TRequest request) => _generateSqlParamsFunc == null ? null : _generateSqlParamsFunc(request);

        #endregion

        #region Helper Methods

        /// <summary>
        /// Return true if ProcNameOrInlineSql has "PROC" in it.
        /// </summary>
        private bool IsForStoredProcRequest => ProcNameOrInlineSql.StartsWith(Constants.KeyWords.ProcKeyword);

        #endregion
    }
}