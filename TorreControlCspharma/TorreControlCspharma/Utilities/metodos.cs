namespace TorreControlCspharma.Utilities
{
    public class metodos
    {
        public string ramdomString()
        {
            Guid mduid = Guid.NewGuid();
            return mduid.ToString();
        }
    }
}
