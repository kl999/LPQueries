(Select 15 as 'quantity', 7 as 'f1', 8 as 'f2'
	union all
	Select 3 as 'quantity', 6 as 'f1', 8 as 'f2'
	union all
	Select 6 as 'quantity', 6 as 'f1', 8 as 'f2'
	union all
	Select 17 as 'quantity', 7 as 'f1', 9 as 'f2'
	union all
	Select 20 as 'quantity', 7 as 'f1', 9 as 'f2')

select sum(quantity),
	f1,
	f2
from (Select 15 as 'quantity', 7 as 'f1', 8 as 'f2'
	union all
	Select 3 as 'quantity', 6 as 'f1', 8 as 'f2'
	union all
	Select 6 as 'quantity', 6 as 'f1', 8 as 'f2'
	union all
	Select 17 as 'quantity', 7 as 'f1', 9 as 'f2'
	union all
	Select 20 as 'quantity', 7 as 'f1', 9 as 'f2') as t1
group by f1, f2