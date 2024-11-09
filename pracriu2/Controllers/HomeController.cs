using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pracriu2.Models;
using pracriu2.Models.ViewModels;

namespace pracriu2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            MapaCurricularContext context = new MapaCurricularContext();
            var carreras=context.Carreras.OrderBy(x=>x.Id);


            return View(carreras);
        }



        [Route("info/{nombre}")]
        public IActionResult Info(string nombre)
        {
			nombre = nombre.Replace("-", " ");

			MapaCurricularContext context = new MapaCurricularContext();
            Carreras? carrera = context.Carreras.FirstOrDefault(x => x.Nombre == nombre);
            if (carrera == null)
            {
                return RedirectToAction("Index");
            }
            return View(carrera);
        }

        [Route("mapa/{nombre}")]
        public IActionResult Mapa(string nombre) {
            nombre = nombre.Replace("-", " ");
            MapaCurricularContext context = new MapaCurricularContext();
            Carreras? carrera = context.Carreras.Include(x=>x.Materias).FirstOrDefault(x => x.Nombre == nombre);

            if (carrera == null)
            {
                return RedirectToAction("Index");
            }

            MapaCurricularVM? vm = new MapaCurricularVM()

            {
                Nombre = carrera.Nombre,
                Creditos = (uint)carrera.Materias.Sum(x => x.Creditos),

                Semestres = carrera.Materias.Max(x => x.Semestre),
                Plan = carrera.Plan,
                Materias = carrera.Materias

            };


            return View(vm);
        }
    }
}
