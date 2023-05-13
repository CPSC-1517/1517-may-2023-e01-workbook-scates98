using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ^^ Visual Studio created using statements ^^
// Greyed out because they're unnecessary

namespace OOPsReview
{
    public enum SupervisoryLevel
        // Enum is a set of names used instead of confusing numbers
    {
        // Enum names are strings represented by integer values
        // By Default: The integer values start at 0 and increment by 1
        //              You can asign their own values to each of the enum names

        Entry,              //value is 0
        TeamMember,         //value is 1
        TeamLeader,         //value is 2
        Supervisor,         //value is 3
        DepartmentHead,     //value is 4
        Owner               //value is 5
    }
}
