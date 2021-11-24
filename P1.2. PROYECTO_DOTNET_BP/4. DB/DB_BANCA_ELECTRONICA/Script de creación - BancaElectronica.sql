/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     11/01/2021 21:53:24                          */
/*==============================================================*/


if exists (select 1
            from  sysobjects
           where  id = object_id('USUARIO')
            and   type = 'U')
   drop table USUARIO
go

/*==============================================================*/
/* Table: USUARIO                                               */
/*==============================================================*/
create table USUARIO (
   INT_USUCODIGO        int                  not null,
   VCH_USUNOMBRE        varchar(50)          null,
   VCH_USUAPELLIDO      varchar(50)          null,
   VCH_USUCEDULA        varchar(10)          null,
   VCH_USUDIRECCION     varchar(100)         null,
   VCH_USUTELEFONO      varchar(20)          null,
   VCH_USUEMAIL         varchar(100)         null,
   VCH_USUUSUARIO       varchar(100)         null,
   VCH_USUPASSWORD      varchar(100)         null,
   constraint PK_USUARIO primary key nonclustered (INT_USUCODIGO)
)
go

