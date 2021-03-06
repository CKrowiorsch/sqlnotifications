﻿using System;
using LandauMedia.Wire;

namespace SqlNotifications.Demo.Scenarios
{
    public class BlogPostNotificationSetup : AbstractNotificationSetup
    {
        public BlogPostNotificationSetup()
        {
            SetIdType<int>();
            SetTrackingType("changeonlytimestamp");
            SetKeyColumn("Id");
            SetSchemaAndTable("t_blogPost", "Blog");
            SetAdditionalColumns(new[] {"RI"});
        }

        public override Type Notification
        {
            get { return typeof(LoggerNotification); }
        }
    }
}