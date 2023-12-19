namespace EventVideo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Video video= new Video() { Titel="Die Hard"};
            VideDecorder vd= new VideDecorder();//Publicher
            MailService mail= new MailService();//Suscriber

            //Registrierung für das event:
            vd.VideoDecoded += mail.OnVideoDecoded;
            // video Dekodieren...
            vd.Decoded(video);
        }
    }

    class Video
    {
        public string  Titel { get; set; }
    }

    class VideDecorder
    {
        //public delegate void VideoRecorderEventHandler(object sender, VideoEventArgs e);
        //public event VideoRecorderEventHandler? VideoDecoded;

        //Mit .Net build-in EventHandler kann man das Event noch kürzer schreiben
        public event EventHandler<VideoEventArgs>? VideoDecoded;

        public void Decoded(Video video)
        {
            Console.WriteLine("Video wird dekodiert...");
            Thread .Sleep(2000);
            OnVideoDecoded(video);
        }

        public void OnVideoDecoded(Video video)
        {
            if(VideoDecoded is not null)
            {
                //Das Objekt, das das Event auslöst übergibt sich selbst(this) und es wird eein neues
                //VideoEventArgs-Objekt erstellt und dem Event übergeben
                //damit die Subscriber des Events nach Informationen bekommen über das video
                VideoDecoded(this,new VideoEventArgs() { Video = video });
            }
        }
    }

    class VideoEventArgs : EventArgs
    {
        public Video Video { get; set; }
    }

    class MailService
    {
        //Methode zum Bahandeln des Events:
        public void OnVideoDecoded(object sender, VideoEventArgs e)
        {
            //Man Kann über das VideoEventArgs-Objekt auf die Daten Videos zugreifen. Dem subscriber
            Console.WriteLine($"Mailservice Email wird gesendet...  {e.Video.Titel}");
        }
    }
}