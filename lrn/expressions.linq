<Query Kind="Statements">
  <Connection>
    <ID>937f840d-1199-41e6-931a-5d5dc0424131</ID>
    <Persist>true</Persist>
    <Server>(localdb)\v11.0</Server>
    <Database>NORTHWND</Database>
  </Connection>
</Query>

ParameterExpression p = Expression.Parameter(typeof(int), "a");
ConstantExpression five = Expression.Constant(5);
BinaryExpression comparison = Expression.GreaterThan(p, five);
Expression<Func<int, bool>> lambda
 = Expression.Lambda<Func<int, bool>>(comparison, p);
Func<int, bool> fun1 = lambda.Compile();
Console.WriteLine(fun1(6));

Expression<Func<int, bool>> expr = i => i > 5;
Func<int, bool> fun2 = expr.Compile();
Console.WriteLine(fun2(6));