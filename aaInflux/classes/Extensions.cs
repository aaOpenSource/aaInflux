using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aaMXItem;
using InfluxData.Net.Models;
using System.Collections;
using System.Collections.Concurrent;
using InfluxData.Net;
using InfluxData.Net.Helpers;

namespace aaInflux
{
    public static class Extensions
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static bool TryAddArray<T>(this BlockingCollection<T> collection, T[] items)
        {
            bool returnValue = true;

            try
            {
                foreach (T item in items)
                {
                    returnValue = returnValue && collection.TryAdd(item);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return returnValue;
        }

        public static void AddArray<T>(this BlockingCollection<T> collection, T[] items)
        {
            try
            {
                foreach (T item in items)
                {
                    collection.Add(item);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool IsAwake(this InfluxData.Net.InfluxDb client, int timeOut = 5000)
        {
            bool returnValue;

            try
            {
                Pong pong = new Pong();

                Task.Run(async () =>
                {
                    Task<Pong> pongTask = client.PingAsync();
                    pong = await pongTask;                    
                }
                ).Wait(timeOut);

                log.DebugFormat("Pong Returns {0}", pong.ToJson());
                returnValue = pong.Success;
            }
            catch
            {
                // Just eat the error because we don't want to log it if the server is just not responding since we have a way to manage it
                return false;
            }

            return returnValue;
        }
    }
}
