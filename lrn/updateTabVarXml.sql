declare @a table(f1 int null, f2 varchar(max) null)

Insert into @a (f1, f2) values (1, 'a')
Insert into @a (f1, f2) values (2, 'b')

DECLARE @idoc int

EXEC sp_xml_preparedocument @idoc OUTPUT, '<asd f1 = "2" f2 = "z">t</asd>'

UPDATE @a SET f2 = [@a].f2 + [xml].f2
FROM
	OPENXML (@idoc, '/asd', 1)
WITH 
(
	f1 int,
	f2 varchar(50)
) as [xml]
WHERE 
	[@a].f1 = [xml].f1

EXEC sp_xml_removedocument @idoc

select * from @a