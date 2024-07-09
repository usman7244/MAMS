using DAL.Sql;
using MAMS.CustomFilters;
using MAMS_Models.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAMS.Controllers
{
     
    [IdentityUser]
    public class CustomerController : BaseController
    {
        private BOL.CustomerBOL _objCustomerBOL;
        private Customer _customer;
        private readonly ISqlConnectionFactory _connectionFactory;
        public CustomerController(ISqlConnectionFactory connectionFactory)
        {
            _objCustomerBOL = new BOL.CustomerBOL();
            _customer= new Customer();
            _connectionFactory = connectionFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            _customer=new Customer();
            _customer.CreatedBy = Guid.Empty;
            _customer.BranchId = GetBranchId();
            List<Customer> customers=await _objCustomerBOL.GetCustomerInfo(_customer, _connectionFactory);
            return View(customers);
        }
        
        public IActionResult NewCustomerAdd( )
        {            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewCustomerAdd(Customer customer)
        {
            int affectedRows = 0;
            customer.BranchId = GetBranchId();
            customer.CreatedBy=Guid.Empty;
            if (customer!=null)
            {
                affectedRows=await _objCustomerBOL.InsertCustomerInfo(customer, _connectionFactory);
                if (affectedRows>0)
                {
                    ModelState.Clear(); 
                }
            }
            ViewBag.CusAddStatus = affectedRows;
            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> CustomerEdit(Guid Id)
        {
             var customer =await _objCustomerBOL.GetSpecificCustomerInfo(Id, _connectionFactory);

            return View(customer);
        }
        [HttpPost]
        public async Task<IActionResult> CustomerEdit(Customer customer)
        {
            int affectedRows = 0;
            customer.ModifiedBy=Guid.Empty;

            if (customer != null)
            {
                affectedRows =await _objCustomerBOL.CustomerEdit(customer, _connectionFactory);
                if (affectedRows > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            ViewBag.CusAddStatus = affectedRows;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteCustomer(Guid cusId)
        {
            _customer = new Customer();
            _customer.ModifiedBy = Guid.Empty;
            _customer.UID = cusId;

            int affectedRows =await _objCustomerBOL.DeleteCustomer(_customer, _connectionFactory); 
            return Ok(affectedRows);
        }
         
    }
}
