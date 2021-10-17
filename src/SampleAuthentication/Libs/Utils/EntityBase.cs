using System;

namespace Libs
{
    public abstract class EntityBase
    {
        public static readonly string ColSInsDt = "s_ins_datetime";
        public static readonly string ColSInsId = "s_ins_id";
        public static readonly string ColSUpdDt = "s_upd_datetime";
        public static readonly string ColSUpdId = "s_upd_id";

        protected string _tblNm;

        public EntityBase(string tblNm)
        {
            _tblNm = tblNm;
        }

        public DateTime SInsDatetime
        {
            get;
            set;
        }

        public string SInsId
        {
            get;
            set;
        }

        public DateTime SUpdDatetime
        {
            get;
            set;
        }

        public string SUpdId
        {
            get;
            set;
        }
    }
}
