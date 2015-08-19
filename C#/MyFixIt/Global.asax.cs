﻿//
// Copyright (C) Microsoft Corporation.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Web.Mvc;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using MyFixIt.App_Start;
using MyFixIt.Common;

namespace MyFixIt
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var dependencyResolver = DependenciesConfig.RegisterDependencies();

            var photoService = dependencyResolver.GetService<IPhotoService>();
            photoService.CreateAndConfigureAsync();
        }
    }
}
