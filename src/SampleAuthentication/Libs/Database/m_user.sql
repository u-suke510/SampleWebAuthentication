CREATE TABLE [dbo].[m_user] (
    [user_id]        VARCHAR (36)  NOT NULL,
    [user_name]      VARCHAR (256) NOT NULL,
    [disp_name]      NVARCHAR (20) NOT NULL,
    [email_address]  VARCHAR (256) NOT NULL,
    [pwd_hash]       VARCHAR (MAX) NULL,
    [s_ins_datetime] DATETIME      NOT NULL,
    [s_ins_id]       VARCHAR (36)  NOT NULL,
    [s_upd_datetime] DATETIME      NULL,
    [s_upd_id]       VARCHAR (36)  NULL,
    PRIMARY KEY CLUSTERED ([user_id] ASC)
);
