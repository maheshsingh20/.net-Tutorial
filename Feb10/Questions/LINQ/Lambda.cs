using System;
namespace Lambda
{
  class LambdaExp
  {
    public static void LbExpression()
    {
      Func<int,int, int> factory=(x,y)=> x+y;
      int result = factory(5, 10);
      Console.WriteLine("The result of the lambda expression is: {0}", result);
    }
  }
}