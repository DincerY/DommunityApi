using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns;

public class DenemeMiddleware
{
    private readonly RequestDelegate _next;

    public DenemeMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        Console.WriteLine("Middleware giriş");
        await _next.Invoke(context);
    }
}