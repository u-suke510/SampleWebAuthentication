using Libs.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Repositories
{
    public interface IUserRepository : IRepositoryBase
    {
        MUser GetItemById(string id);

        MUser GetItemByUsrNm(string usrNm);

        string GetPwdHashById(string id);

        bool InsMUser(MUser entity, string insId, DateTime? dateTime = null);
    }

    public class UserRepository : RepositoryBase, IUserRepository
    {
        public UserRepository(IOptions<ConfigManager> options, ILoggerFactory loggerFactory) : base(options)
        {
            logger = loggerFactory.CreateLogger<UserRepository>();
        }

        public MUser GetItemById(string id)
        {
            var query = new StringBuilder();
            query.Append($"SELECT * ");
            query.Append($"FROM {MUser.TblNm} ");
            query.Append($"WHERE {MUser.ColId}=@pId ");

            MUser result = null;
            using (var conn = new SqlConnection(conf.ConnString))
            using (var cmd = new SqlCommand(query.ToString(), conn))
            {
                // パラメータの設定
                cmd.Parameters.Add("@pId", SqlDbType.VarChar, 36).Value = id;

                // データの取得
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    result = new MUser {
                        Id = Utility.Null2Blank(reader[MUser.ColId]),
                        UserName = Utility.Null2Blank(reader[MUser.ColUsrNm]),
                        DispName = Utility.Null2Blank(reader[MUser.ColDispNm]),
                        Email = Utility.Null2Blank(reader[MUser.ColEmail])
                    };
                }
                conn.Close();
            }

            return result;
        }

        public MUser GetItemByUsrNm(string usrNm)
        {
            var query = new StringBuilder();
            query.Append($"SELECT * ");
            query.Append($"FROM {MUser.TblNm} ");
            query.Append($"WHERE {MUser.ColUsrNm}=@pUsrNm ");

            MUser result = null;
            using (var conn = new SqlConnection(conf.ConnString))
            using (var cmd = new SqlCommand(query.ToString(), conn))
            {
                // パラメータの設定
                cmd.Parameters.Add("@pUsrNm", SqlDbType.VarChar, 256).Value = usrNm;

                // データの取得
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    result = new MUser {
                        Id = Utility.Null2Blank(reader[MUser.ColId]),
                        UserName = Utility.Null2Blank(reader[MUser.ColUsrNm]),
                        DispName = Utility.Null2Blank(reader[MUser.ColDispNm]),
                        Email = Utility.Null2Blank(reader[MUser.ColEmail])
                    };
                }
                conn.Close();
            }

            return result;
        }

        public string GetPwdHashById(string id)
        {
            var query = new StringBuilder();
            query.Append($"SELECT {MUser.ColPwdHash} ");
            query.Append($"FROM {MUser.TblNm} ");
            query.Append($"WHERE {MUser.ColId}=@pId ");

            var result = string.Empty;
            using (var conn = new SqlConnection(conf.ConnString))
            using (var cmd = new SqlCommand(query.ToString(), conn))
            {
                // パラメータの設定
                cmd.Parameters.Add("@pId", SqlDbType.VarChar, 36).Value = id;

                // データの取得
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    result = Utility.Null2Blank(reader[MUser.ColPwdHash]);
                }
                conn.Close();
            }

            return result;
        }

        public bool InsMUser(MUser entity, string insId, DateTime? dateTime = null)
        {
            if (!dateTime.HasValue)
            {
                dateTime = DateTime.Now;
            }

            var query = new StringBuilder();
            query.Append($"INSERT INTO {MUser.TblNm}( ");
            query.Append($"    {MUser.ColId} ");
            query.Append($"  , {MUser.ColUsrNm} ");
            query.Append($"  , {MUser.ColDispNm} ");
            query.Append($"  , {MUser.ColEmail} ");
            if (!string.IsNullOrEmpty(entity.PwdHash))
            {
                query.Append($"  , {MUser.ColPwdHash} ");
            }
            query.Append($"  , {EntityBase.ColSInsDt} ");
            query.Append($"  , {EntityBase.ColSInsId} ");
            query.Append($") VALUES( ");
            query.Append($"    @pId ");
            query.Append($"  , @pUsrNm ");
            query.Append($"  , @pDispNm ");
            query.Append($"  , @pEmail ");
            if (!string.IsNullOrEmpty(entity.PwdHash))
            {
                query.Append($"  , @pPwdHash ");
            }
            query.Append($"  , @pSInsDt ");
            query.Append($"  , @pSInsId ");
            query.Append($"); ");

            using (var conn = new SqlConnection(conf.ConnString))
            using (var cmd = new SqlCommand(query.ToString(), conn))
            {
                // パラメータの設定
                cmd.Parameters.Add("@pId", SqlDbType.VarChar, 36).Value = entity.Id;
                cmd.Parameters.Add("@pUsrNm", SqlDbType.VarChar, 256).Value = entity.UserName;
                cmd.Parameters.Add("@pDispNm", SqlDbType.NVarChar, 20).Value = entity.DispName;
                cmd.Parameters.Add("@pEmail", SqlDbType.VarChar, 256).Value = entity.Email;
                if (!string.IsNullOrEmpty(entity.PwdHash))
                {
                    cmd.Parameters.Add("@pPwdHash", SqlDbType.VarChar).Value = entity.PwdHash;
                }
                cmd.Parameters.Add("@pSInsDt", SqlDbType.DateTime).Value = dateTime.Value;
                cmd.Parameters.Add("@pSInsId", SqlDbType.VarChar, 36).Value = insId;

                // データの登録
                conn.Open();
                cmd.ExecuteScalar();
                conn.Close();
            }

            return true;
        }
    }
}
