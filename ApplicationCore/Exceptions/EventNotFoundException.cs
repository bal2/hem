namespace HADU.hem.ApplicationCore.Exceptions
{
    public class EventNotFoundException : HemException
    {
        public EventNotFoundException() : base(404, "Arrangementet ble ikke funnet")
        {

        }
    }
}