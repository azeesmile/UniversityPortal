using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.UI;

namespace UniversityPortal.WebUI.HtmlHelpers
{
    public static class HtmlHelperExtensions
    {
        public static string IfActive(this HtmlHelper helper, string controller, string action)
        {
            string classValue = "";

            string currentController = helper.ViewContext.Controller.ValueProvider.GetValue("controller").RawValue.ToString();
            string currentAction = helper.ViewContext.Controller.ValueProvider.GetValue("action").RawValue.ToString();

            if (currentController == controller && currentAction == action)
            {
                classValue = "active";
            }

            return classValue;
        }
        public static string ActiveList(this HtmlHelper helper, params string[] values)
        {
            string currentController = helper.ViewContext.Controller.ValueProvider.GetValue("controller").RawValue.ToString();
            //string currentAction = helper.ViewContext.Controller.ValueProvider.GetValue("action").RawValue.ToString();

            foreach (var controller in values)
            {
                if (currentController == controller)
                {
                    return "pointer";
                }
            }

            return string.Empty;
        }

        public static string ActiveDropDown(this HtmlHelper helper, params string[] values)
        {
            string currentController = helper.ViewContext.Controller.ValueProvider.GetValue("controller").RawValue.ToString();
            //string currentAction = helper.ViewContext.Controller.ValueProvider.GetValue("action").RawValue.ToString();

            foreach (var controller in values)
            {
                if (currentController == controller)
                {
                    //StringBuilder stringBuilder = new StringBuilder();
                    //stringBuilder.Append(@"<div class=\"pointer\">");
                    //return "<div class="pointer"><div class="arrow"></div><div class="arrow_border"></div></div>";
                }
            }

            return string.Empty;
        }
    }
}