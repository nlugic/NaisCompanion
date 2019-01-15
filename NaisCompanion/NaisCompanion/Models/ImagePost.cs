using Xamarin.Forms;

namespace NaisCompanion.Models
{
    public class ImagePost
    {
        public ImageSource Photo { get; set; }
        public string Author { get; set; }
        public string UploadedDate { get; set; }

        public ImagePost() { }
    }
}
