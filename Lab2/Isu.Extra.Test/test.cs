using Isu.Extra.Entities;
using Isu.Extra.Interfaces;
using Isu.Extra.Services;
using Xunit;
using Stream = Isu.Extra.Entities.Stream;

namespace Isu.Extra.Test;

public class IsuServiceTest
{
    [Fact]
    public void First()
    {
        var service = new IsuService();

        var m1 = new Megafacultet("иC");
        var group = new Group("fuck", m1);

        var student = new Student(group, "hol");
        group.AddStudent(student);

        service.AddGroup(group);
        Assert.StrictEqual(1, service.GetUnsubscribedStudents(group).Count);

        var course1 = new Course("hi", m1);
        course1.AddStream(new Stream(course1, 2));
        Assert.Throws<Exception>(() => service.RegisterStudent(student, course1.Streams[0]));

        var m2 = new Megafacultet("CиC");
        var course2 = new Course("hih", m2);
        course2.AddStream(new Stream(course2, 2));
        service.RegisterStudent(student, course2.Streams[0]);

        var m3 = new Megafacultet("CиCи");
        var course3 = new Course("hih", m3);
        course3.AddStream(new Stream(course3, 2));
        service.RegisterStudent(student, course3.Streams[0]);

        Assert.StrictEqual(0, service.GetUnsubscribedStudents(group).Count);
    }
}