using System.ComponentModel.DataAnnotations.Schema;

namespace Libs.Entities
{
    /// <summary>
    /// ユーザーマスタのエンティティクラス
    /// </summary>
    public class MUser : EntityBase
    {
        public static readonly string TblNm = "m_user";
        public static readonly string ColId = "user_id";
        public static readonly string ColUsrNm = "user_name";
        public static readonly string ColDispNm = "disp_name";
        public static readonly string ColEmail = "email_address";
        public static readonly string ColPwdHash = "pwd_hash";

        public MUser() : base(TblNm)
        {
        }

        [Column("user_id")]
        public string Id
        {
            get;
            set;
        }

        [Column("user_name")]
        public string UserName
        {
            get;
            set;
        }

        [Column("disp_name")]
        public string DispName
        {
            get;
            set;
        }

        [Column("email_address")]
        public string Email
        {
            get;
            set;
        }

        [Column("pwd_hash")]
        public string PwdHash
        {
            get;
            set;
        }
    }
}
