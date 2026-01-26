using CyberMonitoring.API.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

public class ExceptionLoggingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, ISecurityLogService logService)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await logService.LogAsync(
                "EXCEPTION",
                ex.Message,
                context.User?.Identity?.Name,
                context.Connection.RemoteIpAddress?.ToString()
            );
            throw;
        }
    }
}