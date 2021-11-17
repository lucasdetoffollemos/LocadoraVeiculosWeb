using LocadoraVeiculos.Dominio.Shared;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraVeiculos.WebApplication.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly INotificador _notificador;

        protected BaseController(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected bool OperacaoValida()
        {
            return _notificador.TemNotificacao() == false;
        }
    }
}
