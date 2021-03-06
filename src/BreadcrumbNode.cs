﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace SmartBreadcrumbs
{
    public class BreadcrumbNode
    {

        #region Properties

        public string Title { get; set; }

        public string Action { get; set; }

        public string Controller { get; set; }

        public BreadcrumbNode Parent { get; set; }

        public object RouteValues { get; set; }

        public bool CacheTitle { get; set; }

        #endregion

        public BreadcrumbNode(BreadcrumbAttribute attr)
        {
            Title = attr.Title;
            string[] tmp = attr.Action.Split('.');
            Controller = tmp[0];
            Action = tmp[1];
            CacheTitle = attr.CacheTitle;
        }

        public BreadcrumbNode(string title, string action, string controller, object routeValues = null, BreadcrumbNode parent = null)
        {
            Title = title;
            Action = action;
            Controller = controller;
            RouteValues = routeValues;
            Parent = parent;
        }

        #region Public Methods

        public BreadcrumbNode WithParent(BreadcrumbNode parent)
        {
            Parent = parent;
            return this;
        }

        public string GetUrl(UrlHelper urlHelper)
        {
            return urlHelper.Action(Action, Controller, RouteValues);
        }

        #endregion

    }
}
