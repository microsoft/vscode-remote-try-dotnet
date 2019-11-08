/*----------------------------------------------------------------------------------------
 * Copyright (c) Microsoft Corporation. All rights reserved.
 * Licensed under the MIT License. See LICENSE in the project root for license information.
 *---------------------------------------------------------------------------------------*/

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace aspnetapp
{
    public class Program
    {
        public static void Main(string[] args)
        {            
            var host = Host.CreateDefaultBuilder()    
                .ConfigureWebHostDefaults(webBuilder => { 
                    webBuilder.Configure(app => { 
                        app.UseHttpsRedirection()
                            .Run(async context => {
                                await context.Response.WriteAsync("Hello remote world from ASP.NET Core!");
                            });
                    });
                });
            host.Build().Run();
        }
    }
}