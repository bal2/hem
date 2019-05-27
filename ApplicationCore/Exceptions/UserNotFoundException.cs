namespace HADU.hem.ApplicationCore.Exceptions
{
    public class UserNotFoundException : HemException
    {
        public UserNotFoundException() : base(404, "Brukeren ble ikke funnet")
        {

        }
    }
}