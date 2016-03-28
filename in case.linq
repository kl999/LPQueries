<Query Kind="SQL">
  <Namespace>System.Data.Linq.SqlClient</Namespace>
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

return

insert into [ImexOfflineRegistry].[KETS].[tbl_Payments] (account,amount,date,systemId,bankReference,isCanceled)
select account,amount,[date],systemId,bankReference,isCanceled from [KETS].[dbo].[tbl_Payments]
where paymentId >= 54296
GO

insert into [ImexOfflineRegistry].[KokshEnCntrGorElectroseti].[Payments] (Account,Date,Amount,SystemId,BankReference,Canceled)
select Account,Date,Amount,SystemId,BankReference,Canceled from [KokshEnCntrGorElectroseti].[dbo].[Payments]
where paymentId >= 24131
GO

insert into [ImexOfflineRegistry].[KostanaiSu].[PaymentDetails] (PaymentId,ServiceCode,ReadingP,ReadingL,Amount)
select PaymentId,ServiceCode,ReadingP,ReadingL,Amount from [KostanaiSu].[dbo].[PaymentDetails]
where paymentId >= 13018
GO

insert into [ImexOfflineRegistry].[KostanaiSu].[Payments] (Account,Date,Amount,SystemId,BankReference,Canceled)
select Account,Date,Amount,SystemId,BankReference,Canceled from [KostanaiSu].[dbo].[Payments]
where paymentId >= 13018
GO