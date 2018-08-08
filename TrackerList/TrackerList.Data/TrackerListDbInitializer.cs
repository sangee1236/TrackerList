using System;
using System.Collections.Generic;
using System.Text;
using TrackerList.Model;

namespace TrackerList.Data
{
    /// <summary>
    /// Populates the table with predefined data
    /// </summary>
    public class TrackerListDbInitializer
    {
        private static TrackerListContext context;
        public static void Initialize(IServiceProvider serviceProvider)
        {
            context = (TrackerListContext)serviceProvider.GetService(typeof(TrackerListContext));

            InitializeResources();
        }

        private static void InitializeResources()
        {
            //if (!context.UserType.Any())
            //{
            //    UserType user_01 = new UserType { Type = "Tester" };
            //    UserType user_02 = new UserType { Type = "Developer" };
            //    UserType user_03 = new UserType { Type = "Tester" };

            //    context.UserType.Add(user_01);
            //    context.UserType.Add(user_02);
            //    context.UserType.Add(user_03);

            //    context.SaveChanges();
            //}

            context.SaveChanges();
        }
    }

}
