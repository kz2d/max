using DataAccessLayer.Interface;
using DataAccessLayer.Model;

namespace DataAccessLayer.Test;

public class Tests
{
    [SetUp]
    public void Setup()
    {
        using (var ctx = new DatabaseContext())
        {
            var f = new Worker(){Password = "lol"};
            var stud = new Email() { Text = "Bill", Status = Starus.Recieved, Owner = f};
        
            ctx.Email.Add(stud);
            ctx.SaveChanges();
        }
    }

    [Test]
    public void Test1()
    {
        using (var ctx = new DatabaseContext())
        {
            var z = ctx.Email.FirstOrDefault(x => x.Text == "Bill");
            Assert.NotNull(z);
        }
        Assert.Pass();
    }
    
    
    [Test]
    public void Test2()
    {
        using (var ctx = new DatabaseContext())
        {
            var f = new Worker(){Password = ""};
            var d = new Worker(){Password = ""};
            var boss = new Worker(){Password = ""};
            boss.Employee.Add(f);
            boss.Employee.Add(d);
            
            // ctx.Worker.Add(f);
            // ctx.Worker.Add(d);
            ctx.Worker.Add(boss);
            ctx.SaveChanges();

            var z = ctx.Worker.FirstOrDefault(x => x.Employee.Count() == 2);
            
            Assert.NotNull(z);
        }
        Assert.Pass();
    }
    
    [Test]
    public void Test3()
    {
        using (var ctx = new DatabaseContext())
        {
            var d = new Worker(){Password = "lol"};
            var f = new Sms(){Owner = d, Text = "lol"};

            ctx.Sms.Add(f);
            ctx.SaveChanges();

            var z = ctx.Sms.FirstOrDefault(x => x.Id == f.Id);
            
            Assert.That("lol", Is.EqualTo(z.Text));

            f.Text = "bob";
            ctx.SaveChanges();

            var zz = ctx.Sms.FirstOrDefault(x => x.Id == f.Id);
            
            Assert.That("bob", Is.EqualTo(zz.Text));
        }
        Assert.Pass();
    }
    
}