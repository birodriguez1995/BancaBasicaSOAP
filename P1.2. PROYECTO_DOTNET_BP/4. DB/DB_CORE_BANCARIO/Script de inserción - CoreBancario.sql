/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     10/01/2021 10:32:32                          */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CUENTA') and o.name = 'FK_CUENTA_RELATIONS_CLIENTE')
alter table CUENTA
   drop constraint FK_CUENTA_RELATIONS_CLIENTE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('MOVIMIENTO') and o.name = 'FK_MOVIMIEN_RELATIONS_CUENTA')
alter table MOVIMIENTO
   drop constraint FK_MOVIMIEN_RELATIONS_CUENTA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CLIENTE')
            and   type = 'U')
   drop table CLIENTE
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CUENTA')
            and   name  = 'RELATIONSHIP_1_FK'
            and   indid > 0
            and   indid < 255)
   drop index CUENTA.RELATIONSHIP_1_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CUENTA')
            and   type = 'U')
   drop table CUENTA
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('MOVIMIENTO')
            and   name  = 'RELATIONSHIP_2_FK'
            and   indid > 0
            and   indid < 255)
   drop index MOVIMIENTO.RELATIONSHIP_2_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('MOVIMIENTO')
            and   type = 'U')
   drop table MOVIMIENTO
go

/*==============================================================*/
/* Table: CLIENTE                                               */
/*==============================================================*/
create table CLIENTE (
   INT_CLIECODIGO       int                  not null IDENTITY(1,1),
   VCH_CLIENOMBRE       varchar(50)          null,
   VCH_CLIEAPELLIDO     varchar(50)          null,
   VCH_CLIECEDULA       varchar(10)          null,
   VCH_CLIEDIRECCION    varchar(100)         null,
   VCH_CLIETELEFONO     varchar(20)          null,
   VCH_CLIEEMAIL        varchar(100)         null,
   constraint PK_CLIENTE primary key nonclustered (INT_CLIECODIGO)
)
go

/*==============================================================*/
/* Table: CUENTA                                                */
/*==============================================================*/
create table CUENTA (
   INT_CUENCODIGO       int                  not null IDENTITY(1,1),
   INT_CLIECODIGO       int                  not null,
   VCH_CUENNUMERO       varchar(10)          null,
   VCH_CUENTIPO         varchar(64)          null,
   DEC_CUENSALDO        decimal(12,2)        null,
   DTT_CUENFECHACREACION datetime             null,
   constraint PK_CUENTA primary key nonclustered (INT_CUENCODIGO)
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_1_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_1_FK on CUENTA (
INT_CLIECODIGO ASC
)
go

/*==============================================================*/
/* Table: MOVIMIENTO                                            */
/*==============================================================*/
create table MOVIMIENTO (
   INT_MOVICODIGO       int                  not null IDENTITY(1,1),
   INT_CUENCODIGO       int                  not null,
   DTT_MOVIFECHA        datetime             null,
   VCH_MOVITIPO         char(64)             null,
   DEC_MOVIVALOR        decimal(12,2)        null,
   DEC_MOVISALDOFINAL   decimal(12,2)        null,
   VCH_MOVICUENTORIG    varchar(10)          null,
   VCH_MOVICUENTDEST    varchar(10)          null,
   constraint PK_MOVIMIENTO primary key nonclustered (INT_MOVICODIGO)
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_2_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_2_FK on MOVIMIENTO (
INT_CUENCODIGO ASC
)
go

alter table CUENTA
   add constraint FK_CUENTA_RELATIONS_CLIENTE foreign key (INT_CLIECODIGO)
      references CLIENTE (INT_CLIECODIGO)
go

alter table MOVIMIENTO
   add constraint FK_MOVIMIEN_RELATIONS_CUENTA foreign key (INT_CUENCODIGO)
      references CUENTA (INT_CUENCODIGO)
go

