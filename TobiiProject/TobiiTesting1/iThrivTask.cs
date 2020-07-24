using System.ComponentModel;

namespace VirtualCoach
{
    public enum iThrivTask
    {
        [Description("Task A : Peg Transfer")]
        A = 0,

        [Description("Task B : Precision Cutting")]
        B = 1,

        [Description("Task C : Ligating Loop")]
        C = 2,

        [Description("Task D : Suture with Extracorporeal Knot")]
        D = 3,

        [Description("Task E : Suture with Intracorporeal Knot")]
        E = 4
    }
}
