using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace back_end.Filtros
{
    public class MiFiltroDeAccion : IActionFilter
    {
        public ILogger<MiFiltroDeAccion> Logger { get; }

        public MiFiltroDeAccion(ILogger<MiFiltroDeAccion> logger)
        {
            Logger = logger;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Logger.LogInformation("Antes de ejecutar acción.");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Logger.LogInformation("Despues de ejecutar acción.");
        }

    }
}
