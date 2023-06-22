namespace Events
{
    public sealed class MyEvent1
    {
        public string Param1 { get; }

        public int Param2 { get; }

        public MyEvent1(string param1, int param2)
        {
            Param1 = param1;
            Param2 = param2;
        }
    }
}