USE [xxx]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[xxx]
(
	@dtFrom datetime = null,
	@dtTo datetime = null,
	@id int
)
AS

/*--------------------------------------------------------------
declare @id int,
	@dtFrom datetime = null,
	@dtTo datetime = null

set @id = 516
set @dtFrom = '2015-04-27 00:00'
set @dtTo = '2015-04-28 00:00'
--------------------------------------------------------------*/

SET NOCOUNT ON

declare @invIds table(bintInvoiceId bigint, dtProvTimestamp datetime)

INSERT @invIds
	SELECT
		bintInvoceId,
		dtProvTimestamp
	FROM
		xxx RQ
	WHERE
		RQ.intServiceId=@id
		AND RQ.vchRequestType = 'payment'
		AND RQ.intProvResultCode = 0
		AND	RQ.dtProvTimestamp >= @dtFrom AND RQ.dtProvTimestamp < @dtTo

--select * from @invIds
declare @rez table(TransId varchar(20), [DateTime] datetime, Amount bigint)

DECLARE @invId bigint, @dt datetime

DECLARE MY_CURSOR CURSOR 
  LOCAL STATIC READ_ONLY FORWARD_ONLY
FOR 
SELECT * 
FROM @invIds

OPEN MY_CURSOR
FETCH NEXT FROM MY_CURSOR INTO @invId, @dt
WHILE @@FETCH_STATUS = 0
BEGIN 
    --PRINT @invId
	--PRINT @dt

	declare @invXml varchar(8000)

	select @invXml = txtText from xxx where [bintRegId] = @invId

	set @invXml = '<?xml version="1.0" encoding="windows-1251"?>' + @invXml

	--print @invXml

	DECLARE @idoc int

	EXEC sp_xml_preparedocument @idoc OUTPUT, @invXml

	INSERT INTO @rez
	(
		Amount,
		TransId,
		[DateTime]
	)
	SELECT
		paySum,
		serviceIdExt,
		@dt
	FROM
		OPENXML (@idoc, '/document/invoices/invoice/parameters/parameter', 1)
	WITH 
	(
		paySum bigint,
		serviceIdExt varchar(20)
	)

	EXEC sp_xml_removedocument @idoc

    FETCH NEXT FROM MY_CURSOR INTO @invId, @dt
END
CLOSE MY_CURSOR
DEALLOCATE MY_CURSOR

--select * from @rez

SELECT
	[DateTime] as 'DateTime',
	Amount / 100.0 as Amount,
	TransId as TransId
FROM
	@rez
WHERE Amount <> 0

GO


