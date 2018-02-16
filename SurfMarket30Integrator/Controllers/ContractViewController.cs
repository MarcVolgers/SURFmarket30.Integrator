using SURF.Surfmarket30.MockupData;
using SURF.Surfmarket30.Shared;
using SURF.Surfmarket30.Shared.Enums;
using SURF.Surfmarket30.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SURF.Surfmarket30.Integrator.Controllers
{
    /// <summary>
    /// The view of the contract controller
    /// </summary>
    public class ContractViewController : Controller
    {
        private IContractRepository _contractRepository;

        /// <summary>
        /// Instance
        /// </summary>
        public ContractViewController()
        {
            _contractRepository = new ContractRepository();
        }

        /// <summary>
        /// The index page
        /// </summary>
        /// <returns></returns>
        // GET: ContractView
        public ActionResult Index()
        {
            var contracts = _contractRepository.GetContracts(null, null);
            return View(contracts);
        }

        /// <summary>
        /// The details page
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: ContractView/Details/5
        public ActionResult Details(int id)
        {
            var contracts = _contractRepository.GetContracts(id, null);
            return View(contracts.FirstOrDefault());
        }        
    }
}
