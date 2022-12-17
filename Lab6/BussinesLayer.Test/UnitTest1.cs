using BuisnesLayer.Frontend;
using BuisnesLayer.Services;
using BussinesLayer.Test.Services;
using DataAccessLayer.Interface;
using DataAccessLayer.Model;

namespace BussinesLayer.Test;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var admin = WorkersService.createWorker(new Worker() { Password = "1" });
        var f = WorkersService.createWorker(new Worker() { Password = "hi", Boss = admin });
        
        var m1 = MessageServiceT.createMessage();
        var m2 = MessageServiceT.createMessage();
        MessagesService.RegisterMessage(f, m1);
        
        Assert.That(AuthService.TryToAuth(f.Id, "hi"), Is.EqualTo(f));
        Assert.That(AuthService.TryToAuth(f.Id, "hih"), Is.EqualTo(null));
        Assert.That(m1, Is.EqualTo(Message.ReadMessage(f, m1.Id)));
        MessagesService.ChangeStatus(m1.Id, Starus.Complited);
        Assert.That( 1, Is.EqualTo(MessagesService.ReadMessage(f).Count()));

        var o = OtchetService.createOtchet(admin);
        Assert.That(o.Amount, Is.EqualTo(OtchetService.readOtchet(o.Id)!.Amount));
    }
}