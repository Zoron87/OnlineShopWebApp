namespace OnlineShopWebApp.Interfaces
{
    public interface IOrderStorage
    {
        bool Save(bool isAppend = false);
    }
}
