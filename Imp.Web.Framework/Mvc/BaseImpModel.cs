﻿using System.Web.Mvc;

namespace Imp.Web.Framework.Mvc
{
    public class BaseImpModel
    {
        public virtual void BindModel(ControllerContext controllerContext,ModelBindingContext bindingContext)
        {
            
        }
    }

    public class BaseImpEntityModel : BaseImpModel
    {
        public string Id { get; set; }
    }
}