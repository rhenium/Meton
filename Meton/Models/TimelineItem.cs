using Meton.Liegen.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meton.Models
{
    public class TimelineItem
    {
        private Status _Status;
        private DirectMessage _DirectMessage;

        public TimeLineItemType ItemType { get; private set; }
        public StatusBase Status
        {
            get
            {
                if (_Status != null)
                {
                    return _Status;
                }
                else
                {
                    return _DirectMessage;
                }
            }
        }

        public TimelineItem(Status status = null, DirectMessage directMessage = null)
        {
            if (status != null)
            {
                this._Status = status;
            }
            else if (directMessage != null)
            {
                this._DirectMessage = directMessage;
            }
            else
            {
                throw new InvalidOperationException("Both status and directMessage are null");
            }
        }
    }
}
