namespace Events
{
    public sealed class MyEvent2
    {
        public float Param1 { get; }

        public MyEvent2(float param1)
        {
            Param1 = param1;
        }
    }
}