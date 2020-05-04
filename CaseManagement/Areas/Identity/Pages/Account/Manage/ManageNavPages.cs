﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace CaseManagement.Areas.Identity.Pages.Account.Manage
{
    public static class ManageNavPages
    {
        public static string Index => "Index";

        public static string Email => "Email";

        public static string ChangePassword => "ChangePassword";

        public static string MyCases => "MyCases";

        public static string MyStatistics => "MyStatistics";

        public static string Announcements => "Announcements";

        public static string AddDc => "AddDc";

        public static string ExternalLogins => "ExternalLogins";

        public static string TwoFactorAuthentication => "TwoFactorAuthentication";

        public static string PersonalData => "PersonalData";

        public static string IndexNavClass(ViewContext viewContext)
        {
            return PageNavClass(viewContext, Index);
        }

        public static string EmailNavClass(ViewContext viewContext)
        {
            return PageNavClass(viewContext, Email);
        }

        public static string ChangePasswordNavClass(ViewContext viewContext)
        {
            return PageNavClass(viewContext, ChangePassword);
        }

        public static string ExternalLoginsNavClass(ViewContext viewContext)
        {
            return PageNavClass(viewContext, ExternalLogins);
        }

        public static string PersonalDataNavClass(ViewContext viewContext)
        {
            return PageNavClass(viewContext, PersonalData);
        }

        public static string TwoFactorAuthenticationNavClass(ViewContext viewContext)
        {
            return PageNavClass(viewContext, TwoFactorAuthentication);
        }

        public static string MyCasesNavClass(ViewContext viewContext)
        {
            return PageNavClass(viewContext, MyCases);
        }

        public static string MyStatisticsNavClass(ViewContext viewContext)
        {
            return PageNavClass(viewContext, MyStatistics);
        }

        public static string AnnouncementsNavClass(ViewContext viewContext)
        {
            return PageNavClass(viewContext, Announcements);
        }

        public static string AddDcNavClass(ViewContext viewContext)
        {
            return PageNavClass(viewContext, AddDc);
        }

        private static string PageNavClass(ViewContext viewContext, string page)
        {
            string activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}