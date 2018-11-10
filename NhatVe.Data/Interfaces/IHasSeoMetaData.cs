namespace NhatVe.Data.Interfaces
{
    public interface IHasSeoMetaData
    {
        string SeoPageTitle { get; set; }
        string SeoAlias { get; set; }
        string SeoKeyworks { set; get; }
        string SeoDescription { set; get; }
    }
}