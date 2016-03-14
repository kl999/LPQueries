select *
from
	(select 1 'id', 'a' 'name' union select 2, 's' union select 3, 'd') as tab
inner join
	(select 1 'id2', 'a' 'name2' union select 3, 'd') as tab2 on tab.id = tab2.id2

select *
from
	(select 1 'id', 'a' 'name' union select 2, 's' union select 3, 'd') as tab
left join
	(select 1 'id2', 'a' 'name2' union select 3, 'd') as tab2 on tab.id = tab2.id2

select *
from
	(select 1 'id', 'a' 'name' union select 2, 's' union select 3, 'd') as tab
right join
	(select 1 'id2', 'a' 'name2' union select 3, 'd' union select 4, 'f') as tab2 on tab.id = tab2.id2

select *
from
	(select 1 'id', 'a' 'name' union select 2, 's' union select 3, 'd') as tab
full join
	(select 1 'id2', 'a' 'name2' union select 3, 'd' union select 4, 'f') as tab2 on tab.id = tab2.id2


select *
from
	(select 1 'id', 'a' 'name' union select 2, 'a' union select 3, 's') as tab
full join
	(select 1 'id', 'a' 'name' union select 2, 'a' union select 3, 's') as tab2 on 3 = tab2.id
where tab.id <> tab2.id