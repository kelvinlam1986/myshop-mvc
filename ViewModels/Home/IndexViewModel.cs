namespace shop.ViewModels.Home
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {
            IndexAboutDTO = new IndexAboutDTO();
        }
        public IndexAboutDTO IndexAboutDTO { get; set; }
    }
}