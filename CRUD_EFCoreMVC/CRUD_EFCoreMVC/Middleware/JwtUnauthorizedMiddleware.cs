namespace CRUD_EFCoreMVC.Middleware
{
    public class JwtUnauthorizedMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtUnauthorizedMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next(context);

            if (context.Response.StatusCode == 401 && !context.Request.Path.StartsWithSegments("/Account/Login"))
            {
                context.Response.Redirect("/Account/Login");
            }
        }
    }
}
