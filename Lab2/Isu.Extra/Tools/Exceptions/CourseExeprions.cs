namespace Isu.Extra.Tools.Exceptions;

public class CourseExeprions : Exception
{
    public CourseExeprions(string message)
        : base(message)
    {
    }

    public static CourseExeprions OutOfPlaces() =>
        throw new CourseExeprions($"No more places available in this stream.");

    public static CourseExeprions SameFacultet() =>
        throw new CourseExeprions("Student cannot enroll in OGNP for their own megafacultet.");

    public static CourseExeprions ConflictWithShedule() =>
        throw new CourseExeprions("Student's group schedule conflicts with OGNP schedule.");
}