using LaboratorioUno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaboratorioUno.Controllers
{
    public class NotasController : Controller
    {
        // GET: Notas
        public ActionResult Index()
        {
            return View();
        }

      

        public ActionResult ListadoEstudiantes()
        {
            using (EstudianteEntities estudiante = new EstudianteEntities())
            {
                var listEstudiantes = estudiante.TblNotasEstudiante.ToList();

                return View(listEstudiantes);
            }

        }





        public ActionResult Resultado(string nombre, double lab1, double lab2, double lab3, double par1, double par2, double par3)
        {

            using (EstudianteEntities estudiante = new EstudianteEntities())
            {
                TblNotasEstudiante studi = new TblNotasEstudiante();

                studi.Nombre = nombre;
                studi.lab1 = (decimal?)lab1;
                studi.lab2 = (decimal?)lab2;
                studi.lab3 = (decimal?)lab3;
                studi.par1 = (decimal?)par1;
                studi.par1 = (decimal?)par1;
                studi.par2 = (decimal?)par2;
                studi.par3 = (decimal?)par3;
                estudiante.TblNotasEstudiante.Add(studi);
                estudiante.SaveChanges();
            }

            double labp = 0.4;
            double parp = 0.6;

            ViewBag.total1 = (lab1 * labp) + (par1 * parp);
            ViewBag.total2 = (lab2 * labp) + (par2 * parp);
            ViewBag.total3 = (lab3 * labp) + (par3 * parp);

           
            ViewBag.nombre = nombre;
            ViewBag.lab1 = lab1;
            ViewBag.lab2 = lab2;
            ViewBag.lab3 = lab3;
            ViewBag.par1 = par1;
            ViewBag.par2  = par2;
            ViewBag.par3 = par3;


            return View();

        }





        //public ActionResult CalcularNotas(string nombre, decimal lab1, decimal lab2, decimal lab3, decimal par1, decimal par2, decimal par3)
        //{

        //    using (EstudianteEntities estudiante = new EstudianteEntities())
        //    {
        //        TblNotasEstudiante estudi = new TblNotasEstudiante();

        //        estudi.Nombre = nombre;
        //        estudi.lab1 = lab1;
        //        estudi.lab2 = lab2;
        //        estudi.lab3 = lab3;
        //        estudi.par1 = par1;
        //        estudi.par1 = par1;
        //        estudi.par2 = par2;
        //        estudi.par3 = par3;
        //        estudiante.TblNotasEstudiante.Add(estudi);
        //        estudiante.SaveChanges();
        //    }

        //    return Redirect("/Notas/Resultado");
        //}
    }
        }