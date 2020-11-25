using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Projekat.Infrastructure
{
    public class MefControllerFactory : DefaultControllerFactory
    {
        private readonly CompositionContainer compositionContainer;

        public MefControllerFactory(CompositionContainer compositionContainer)
        {
            this.compositionContainer = compositionContainer;
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            var export = compositionContainer.GetExports(controllerType, null, null).SingleOrDefault();

            IController result;

            if (null != export)
            {
                result = export.Value as IController;
            }
            else
            {
                result = base.GetControllerInstance(requestContext, controllerType);
                compositionContainer.ComposeParts(result);
            }

            return result;
        }
    }
}