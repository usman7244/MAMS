using MAMS_Models.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAMS.Controllers
{
    public class CustomerController : Controller
    {
        private BOL.CustomerBOL _objCustomerBOL;
        private Customer _customer;
        public CustomerController()
        {
            _objCustomerBOL = new BOL.CustomerBOL();
            _customer= new Customer();
        }
        public IActionResult Index()
        {
            _customer=new Customer();
            _customer.CreatedBy = Guid.Empty;
            _customer.BranchId = Guid.Empty;
            List<Customer> customers= _objCustomerBOL.GetCustomerInfo(_customer);
            return View(customers);
        }
        
        public IActionResult NewCustomerAdd( )
        {            
            return View();
        }
        [HttpPost]
        public IActionResult NewCustomerAdd(Customer customer)
        {
            int affectedRows = 0;
            customer.BranchId=Guid.Empty;
            customer.CreatedBy=Guid.Empty;
            if (customer!=null)
            {
                affectedRows= _objCustomerBOL.InsertCustomerInfo(customer);
                if (affectedRows>0)
                {
                    ModelState.Clear(); 
                }
            }
            ViewBag.CusAddStatus = affectedRows;
            return View();
        }
        
        public IActionResult CustomerEdit(Guid Id)
        {
             var customer = _objCustomerBOL.GetSpecificCustomerInfo(Id);

            return View(customer);
        }
        [HttpPost]
        public IActionResult CustomerEdit(Customer customer)
        {
            int affectedRows = 0;
            customer.ModifiedBy=Guid.Empty;

            if (customer != null)
            {
                affectedRows = _objCustomerBOL.CustomerEdit(customer);
                if (affectedRows > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            ViewBag.CusAddStatus = affectedRows;
            return View();
        }
        [HttpPost]
        public IActionResult DeleteCustomer(Guid cusId)
        {
            _customer = new Customer();
            _customer.ModifiedBy = Guid.Empty;
            _customer.UID = cusId;

            int affectedRows = _objCustomerBOL.DeleteCustomer(_customer); 
            return Ok(affectedRows);
        }
         
    }
}
