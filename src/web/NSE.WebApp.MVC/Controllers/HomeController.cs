using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models;

namespace NSE.WebApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("erro/{id:length(3,3)}")]
        public IActionResult Error(int id)
        {
            var modelErro = new ErrorViewModel
            {
                ErroCode = id
            };

            switch (id)
            {
                case 500:
                    modelErro.Mensagem = "Ocorreu um erro! tente novamente mais tarde ou contate nosso suporte.";
                    modelErro.Titulo = "Ocorreu um erro!";
                    break;
                case 404:
                    modelErro.Mensagem = "A página que está procurando não existe! <br />Em caso de dúvidas entre em contato com nosso suporte.";
                    modelErro.Titulo = "Ops! página não encontrada.";
                    break;
                case 403:
                    modelErro.Mensagem = "Você não tem permissão para fazer isso.";
                    modelErro.Titulo = "Acesso Negado";
                    break;
                default:
                    return StatusCode(400);
            }

            return View(modelErro);
        }
    }
}
