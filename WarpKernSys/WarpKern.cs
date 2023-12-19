namespace WarpKernSys
{
    using System.Threading;

    class WarpKern
    {
        public delegate void WarperaturKontrollerHandler(object sender, WarpEventArgs e);
        public delegate void WarpTemperaturdel(float temperatur);

        public event EventHandler<WarpEventArgs> WarperaturKontrollerEvent;
        public float WarpTemperatur { get; set; }
        public bool Kern { get; set; }

        private void WarpHeizung()
        {
            Random rnd = new Random();
            WarpTemperatur += rnd.Next(1000,2000)/10;
        }

        public  void WarpTemperaturZeiger(float temperatur)
        {
            if (temperatur != WarpTemperatur)
            {
                WarpTemperatur = temperatur;
            }

            Console.WriteLine(WarpTemperatur); 
        }

        public void OnWorkingProcess(WarpKern warpKern)
        {
            Kern = true;
            while (Kern == true)
            {
                WarpHeizung();
                if (WarpTemperatur > 500)
                {
                    AlermEvent(warpKern);              
                }              
                    WarpTemperaturZeiger(WarpTemperatur);               
                    Thread.Sleep(1000);
            }
        }

        private void AlermEvent(WarpKern warpKern)
        {
            if(WarperaturKontrollerEvent != null)
            {
                WarperaturKontrollerEvent(this, new WarpEventArgs() { WarpKern = warpKern });
            }
        }
    
    }
}