﻿using System;
using System.Collections.Generic;
using LandauMedia.Wire;
using NLog;

namespace SqlNotifications.Demo.Scenarios.BigTable
{
    public class BigTableNotificationSetup : AbstractNotificationSetup
    {
        public BigTableNotificationSetup()
        {
            SetTable("BigTable");
            SetKeyColumn("Id");
            SetIdType<int>();
            SetTrackingType("timestamp");

        }

        public override Type Notification
        {
            get { return typeof(BigTableNotification); }
        }
    }

    public class BigTableNotification : INotification
    {
        static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public void OnInsert(INotificationSetup notificationSetup, string id, IEnumerable<string> updatedColumns)
        {
            Logger.Info(() => String.Format("INSERT On Table '{0}' With Id '{1}' (UpdatedColumns:{2})", notificationSetup.Table, id, String.Join(",", updatedColumns)));
        }

        public void OnUpdate(INotificationSetup notificationSetup, string id, IEnumerable<string> updatedColumns)
        {
            Logger.Info(() => String.Format("UPDATE On Table '{0}' With Id '{1}' (UpdatedColumns:{2})", notificationSetup.Table, id, String.Join(",", updatedColumns)));
        }

        public void OnDelete(INotificationSetup notificationSetup, string id, IEnumerable<string> updatedColumns)
        {
            Logger.Info(() => String.Format("DELETE On Table '{0}' With Id '{1}' (UpdatedColumns:{2})", notificationSetup.Table, id, String.Join(",", updatedColumns)));
        }
    }
}