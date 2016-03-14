update Accounts
set Amount = Accounts.Amount - (pay.Amount / 100.0)
from (select sum(Amount) Amount, Account from Payments where Date > '2015-03-18 00:00' and Canceled <> 1 group by Account) pay
where Accounts.Account = pay.Account