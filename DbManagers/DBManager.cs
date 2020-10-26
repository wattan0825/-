using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoingToWorkApp.DbManagers
{
    /// <summary>
    /// 現在不使用クラス
    /// </summary>
    public class DBManager
    {
        private SqlConnection sqlConnection = null;
        private SqlTransaction sqlTransaction = null;
        private string connectString = ConfigurationManager.ConnectionStrings["GoingToWorkAppContext"].ConnectionString;

        /// <summary>
        /// コンストラクタ（DB接続）
        /// </summary>
        public DBManager()
        {
            // SqlConnection の新しいインスタンスを生成 (接続文字列を指定)
            this.sqlConnection = new SqlConnection(connectString);

            // データベース接続を開く
            this.sqlConnection.Open();
        }

        /// <summary>
        /// DB切断
        /// </summary>
        public void Close()
        {
            this.sqlConnection.Close();
            this.sqlConnection.Dispose();
        }

        /// <summary>
        /// トランザクション開始
        /// </summary>
        public void BeginTran()
        {
            this.sqlTransaction = this.sqlConnection.BeginTransaction();
        }

        /// <summary>
        /// トランザクション　コミット
        /// </summary>
        public void CommitTran()
        {
            if (this.sqlTransaction.Connection != null)
            {
                this.sqlTransaction.Commit();
                this.sqlTransaction.Dispose();
            }
        }

        /// <summary>
        /// トランザクション　ロールバック
        /// </summary>
        public void RollBack()
        {
            if (this.sqlTransaction.Connection != null)
            {
                this.sqlTransaction.Rollback();
                this.sqlTransaction.Dispose();
            }
        }

        /// <summary>
        /// クエリー実行(OUTPUT項目あり)
        /// <para name="query">SQL文</para>
        /// <para name="paramDict">SQLパラメータ</para>
        /// </summary>
        public SqlDataReader ExecuteQuery(string query, Dictionary<string, Object> paramDict)
        {
            SqlCommand sqlCom = new SqlCommand();

            //クエリー送信先、トランザクションの指定
            sqlCom.Connection = this.sqlConnection;
            sqlCom.Transaction = this.sqlTransaction;

            sqlCom.CommandText = query;
            foreach (KeyValuePair<string, Object> item in paramDict)
            {
                sqlCom.Parameters.Add(new SqlParameter(item.Key, item.Value));
            }

            // SQLを実行
            SqlDataReader reader = sqlCom.ExecuteReader();

            return reader;
        }

        /// <summary>
        /// クエリー実行(OUTPUT項目あり)
        /// <para name="query">SQL文</para>
        /// </summary>
        public SqlDataReader ExecuteQuery(string query)
        {
            return this.ExecuteQuery(query, new Dictionary<string, Object>());
        }

        /// <summary>
        /// クエリー実行(OUTPUT項目なし)
        /// <para name="query">SQL文</para>
        /// <para name="paramDict">SQLパラメータ</para>
        /// </summary>
        public void ExecuteNonQuery(string query)
        {
            SqlCommand sqlCom = new SqlCommand();

            //クエリー送信先、トランザクションの指定
            sqlCom.Connection = this.sqlConnection;
            sqlCom.Transaction = this.sqlTransaction;

            sqlCom.CommandText = query;

            // SQLを実行
            sqlCom.ExecuteNonQuery();
        }
    }
}
