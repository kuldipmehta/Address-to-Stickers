using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labely.Model
{
    public partial class GroupDetail
    {
        public string GroupName
        {
            get
            {
                string Name = "";
                if (this.GMId != null)
                {
                    Name = GroupMaster.GroupName;
                }
                else
                {
                    Name = "";
                }
                return Name;
            }
        }

        public string GName { get; set; }
        public bool IsSelect { get; set; }
        public bool IsCheck { get; set; }
        public string Index { get; set; }

    }
}
