namespace WarpKernSys
{
    using System.Timers;


    internal class Program
    {
        static void Main(string[] args)
        {

            WarpKern warpKern = new WarpKern();
            WarpKonsole warpKonsole = new();

            warpKern.WarperaturKontrollerEvent += warpKonsole.WarpTemperaturKontrolle;
            warpKern.OnWorkingProcess(warpKern);
        }
    }
}