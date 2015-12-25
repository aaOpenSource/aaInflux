using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aaMXItem;
using InfluxData.Net.Models;

namespace aaInflux
{
    public class aaMXInfluxItem : aaMXItem.MXItem
    {
        private string _influxTag = "";

        public string influxTag {

            get
            {
                if((this._influxTag == "") || (this._influxTag == null))
                {
                    this._influxTag = this.TagName.Replace('[', '_').Replace(']', '_').Replace('.', '_');
                }

                return this._influxTag;
            }

            set { this._influxTag = value; }
        }

        public Point GetInfluxPoint()
        {
            Point localPoint = new Point();

            try
            {
                localPoint.Name = this.influxTag;
                localPoint.Fields.Add("value", this.Value);
                localPoint.Timestamp = this.TimeStamp.ToUniversalTime();
                localPoint.Precision = InfluxData.Net.Enums.TimeUnit.Milliseconds;

                return localPoint;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            

        }
    }
}
