using System.Collections.Generic;
public class StoreItemSendCommand : ICommand
{
    public List<StoreItem> StoreItems = new List<StoreItem>();
    public void Add(StoreItem storeItem)
    {
        StoreItems.Add(storeItem);
    }
}