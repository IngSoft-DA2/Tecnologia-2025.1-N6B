using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using shop.IBusinessLogic;
using shop.Domain;
using System;
using System.Collections.Generic;

namespace shop.WebApi.Filters
{
    public class AuthorizationFilter : Attribute, IAuthorizationFilter
    {
        private readonly string[] _roles;

        public AuthorizationFilter(params string[] roles)
        {
            _roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var userLogic = context.HttpContext.RequestServices.GetService<IUserLogic>();
            string? token = context.HttpContext.Request.Headers["token"];

            if (string.IsNullOrEmpty(token))
            {
                context.Result = new ContentResult
                {
                    StatusCode = 401,
                    Content = "Es necesario tener un token para acceder"
                };
                return;
            }
/*
            if (!userLogic.IsLoggedIn(token))
            {
                context.Result = new ContentResult
                {
                    StatusCode = 403,
                    Content = "Rechazado, se necesita estar logueado"
                };
                return;
            }

            var userRoles = userLogic.GetUserRoles(token);
            bool hasAccess = false;

            foreach (var role in userRoles)
            {
                if (Array.Exists(_roles, r => r.Equals(role.Rol, StringComparison.OrdinalIgnoreCase)))
                {
                    hasAccess = true;
                    break;
                }
            }

            if (!hasAccess)
            {
                context.Result = new ContentResult
                {
                    StatusCode = 403,
                    Content = "Acceso denegado. No se tiene la autorización para esta funcionalidad."
                };
            }*/
        }
    }
}