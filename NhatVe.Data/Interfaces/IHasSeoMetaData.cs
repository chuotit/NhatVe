namespace NhatVe.Data.Interfaces
{
    public interface IHasSeoMetaData
    {
        string SeoPageTitle { get; set; }
        string SeoAlias { get; set; }
        string SeoKeywork { set; get; }
        string SeoDescription { set; get; }
    }
}