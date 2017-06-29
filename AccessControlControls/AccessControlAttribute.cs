﻿using System;
using System.Web.Mvc;

namespace AccessControlHelper
{
    /// <summary>
    /// 权限控制
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AccessControlAttribute : ActionFilterAttribute
    {
        private static IActionResultDisplayStrategy _displayStrategy;

        public static void RegisterDisplayStrategy<TStrategy>(TStrategy strategy) where TStrategy : IActionResultDisplayStrategy
        {
            _displayStrategy = strategy;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (_displayStrategy == null)
            {
                throw new ArgumentException("ActionResult显示策略未初始化，请使用 AccessControlAttribute.RegisterDisplayStrategy(IActionResultDisplayStrategy stragety) 方法注册显示策略", nameof(_displayStrategy));
            }
            if (_displayStrategy.IsCanDisplay)
            {
                base.OnActionExecuting(filterContext);
            }
            else
            {
                //if Ajax request
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = _displayStrategy.DisallowedAjaxResult;
                }
                else
                {
                    filterContext.Result = _displayStrategy.DisallowedCommonResult;
                }
            }
        }
    }
}