using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Telfair_Backend.Classes.Services
{
    public class StaticData
    {
        public static readonly string ROLE_ADMINISTRATOR = "Administrator";
        public static readonly string ROLE_PARENTS = "Parents";
        public static readonly string ROLE_ADMINISTRATOR_ID = "1";
        public static readonly int ADMINISTRATOR_TO_ADMINISTRATOR = 1;
        public static readonly int ADMINISTRATOR_TO_TEACHER = 2;
        public static readonly int TEACHER_TO_TEACHER = 3;
        public static readonly int TEACHER_TO_ADMINISTRATOR = 4;
        public static readonly string NODE_DEPARTMENT = "25da3697-59f4-11e9-8ceb-fb681531b90a";
        public static readonly string NODE_GRADE = "25da3697-59f4-11e9-8ceb-fb681531b90b";
        public static readonly string FILE_UPLOAD_PATH = "uploaded_files/attachments/";
    }
}
