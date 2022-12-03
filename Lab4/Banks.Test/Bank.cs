using Banks.Entitys;
using Banks.Interfaces;
using Xunit;
using ClientBuilder = Banks.Builders.ClientBuilder;

namespace Banks.Test;

public class IsuService
{
    [Fact]
    public void Start()
    {
        var l = new CentralBank((cb) => new Bank(cb));
        IBank bank1 = l.CreateBank();

        var clB = new ClientBuilder();
        Client cl1 = clB.AddName("hi").AddSurename("Hoo").GetResult();
        Assert.False(cl1.IsTrusted);

        cl1.Adress = "hoh";
        cl1.Pasport = "MP31";
        Assert.True(cl1.IsTrusted);

        IBillClient db1 = bank1.CreateDebet(cl1);

        ITransaction t1 = db1.AddCash(10);

        t1.Start();
        Assert.Equal(0, db1.Amount);

        t1.Complete();
        Assert.Equal(10, db1.Amount);

        ITransaction t2 = db1.AddCash(10);

        t2.Start();
        Assert.Equal(10, db1.Amount);

        t2.Abort();
        Assert.Equal(10, db1.Amount);
    }

    [Fact]
    public void SendMoney()
    {
        var l = new CentralBank((cb) => new Bank(cb));
        IBank bank1 = l.CreateBank();
        IBank bank2 = l.CreateBank();

        var clB = new ClientBuilder();
        Client cl1 = clB.AddName("hi").AddSurename("Hoo").GetResult();
        Assert.False(cl1.IsTrusted);

        cl1.Adress = "hoh";
        cl1.Pasport = "MP31";
        Assert.True(cl1.IsTrusted);

        IBillClient db1 = bank1.CreateDebet(cl1);
        IBillClient db2 = bank2.CreateDebet(cl1);

        ITransaction t1 = db1.AddCash(25);

        t1.Start();
        Assert.Equal(0, db1.Amount);

        t1.Complete();
        Assert.Equal(25, db1.Amount);

        ITransaction t2 = db1.SendMoney(db2.Uuid, 10);

        t2.Start();
        Assert.Equal(15, db1.Amount);

        t2.Complete();
        Assert.Equal(15, db1.Amount);
        Assert.Equal(10, db2.Amount);

        ITransaction t3 = db1.SendMoney(db2.Uuid, 10);

        t3.Start();
        Assert.Equal(5, db1.Amount);

        t3.Abort();
        Assert.Equal(15, db1.Amount);
        Assert.Equal(10, db2.Amount);
    }

    [Fact]
    public void CreateGroupWithInvalidName_ThrowException() { }

    [Fact]
    public void TransferStudentToAnotherGroup_GroupChanged() { }
}