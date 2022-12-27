using Shops.Models;
using Shops.Services;
using Xunit;

namespace Shops.Test;

public class TestT
{
    [Fact]
    public void TestFirst()
    {
        SomeTest(34, 10, 10, 3);
    }

    private void SomeTest(int moneyBefore, int productPrice, int productCount, int productToBuyCount)
    {
        var person = new User(new Name("name"), new Money(moneyBefore));
        var shopManager = new ShopService();
        var shop = shopManager.AddShop(new Shop(new Name("yandex"), new Name("толстого")));
        var product = shopManager.RegisterProduct(new Product(new Name("iphone"), new Money(10), Guid.NewGuid(), 10, shop.Id));

        for (int i = 0; i < productToBuyCount; i++)
        {
            shopManager.Buy(product, person);
        }

        Assert.Equal(moneyBefore - (productPrice * productToBuyCount), person.Money.Cash);
        Assert.Equal(productCount - productToBuyCount, product.Amount);
    }
}