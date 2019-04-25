using Gahfour_web_shop_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gahfour_web_shop_2.Repository
{
    public interface IItemRepo
    {
        int Insert(Item item);
        int Update(Item item);
        int Delete(int itemId);
        Item GetItem(int id);
        List<Item> GetItems();
        List<Item> GetItemsPage(int page, int perPage);
    }

    public interface IMarkRepo
    {
        int Insert(Mark mark);
        int Update(Mark mark);
        int Delete(int markId);
        Mark GetMark(int id);
        List<Mark> GetMarks();
    }

    public interface IManufacturerRepo
    {
        int Insert(Manufacturer manufacturer);
        int Update(Manufacturer manufacturer);
        int Delete(int manufacturerId);
        Manufacturer GetManufacturer(int id);
        List<Manufacturer> GetManufacturers();
    }

    public interface IShippingClassRepo
    {
        int Insert(ShippingClass shippingClass);
        int Update(ShippingClass shippingClass);
        int Delete(int shippingClassId);
        ShippingClass GetShippingClass(int id);
        List<ShippingClass> GetShippingClasses();
    }

    public interface ISettingsRepo
    {
        string getCurrency();
        bool useTableGrid();
    }
}
