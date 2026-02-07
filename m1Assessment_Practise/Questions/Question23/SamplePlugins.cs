namespace m1Assessment_Practise.Questions.Question23;

class SamplePlugin1 : IPlugin
{
    public string Name => "Sample Plugin 1";
    public void Execute() => Console.WriteLine("Executing Sample Plugin 1");
}

class SamplePlugin2 : IPlugin
{
    public string Name => "Sample Plugin 2";
    public void Execute() => Console.WriteLine("Executing Sample Plugin 2");
}
