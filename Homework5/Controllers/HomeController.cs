using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homework5.Models;
using System.Data.SqlClient;


namespace Homework5.Controllers
{
    public class HomeController : Controller
    {
      
        private SearchBook sbook = SearchBook.getInstance();
        
       
        public ActionResult Index()
        {
            List<Books> availablebooks = sbook.getAvailableBooks();

            return View(availablebooks);
            
        }

        public ActionResult BookDetails()
        {
            List<Borrows> borrows = sbook.getBorrows();
            return View(borrows);
        }

        public ActionResult ViewStudents()
        {
            List<Students> students = sbook.getStudents();
            return View(students);
        }

    }
}