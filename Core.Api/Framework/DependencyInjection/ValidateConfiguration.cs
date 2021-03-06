﻿using Core.Api.Extensions.CustomException;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Api.Framework.DependencyInjection
{
    public static class ValidateConfiguration
    {
        public static void AddService(IServiceCollection services)
        {
            services.AddMvc(s => s.Filters.Add(new ValidateModelAttribute()));
        }
    }
}