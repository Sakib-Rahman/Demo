
#region Refference
using ApplicationCore.Entities;
using ApplicationCore.Message;
using ApplicationCore.Services;
using Infrastructure.Data;
using Infrastructure.Data.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
#endregion

#region Source
namespace a4Aero.Controllers
{
    public class AgentManagerController : Controller
    {
        private IAgentService _agentService;
        public AgentManagerController()
        {
            _agentService = new AgentService(this.ModelState, new AgentRepository());
        }
        public AgentManagerController(IAgentService agentService)
        {
            _agentService = agentService;
        }

        
        #region List of Agent- page
        public ActionResult Agents()
        {
            @ViewBag.PageName = "Agent List";

            return View(_agentService.AgentList());
        }
        #endregion

        #region Add an Agent- page
        public ActionResult AddAgentInfo()
        {
            @ViewBag.PageName = "Add Agent";
            return View();
        }
        #endregion

        #region Edit agent detail- page
        public ActionResult AgentDetail(string code)
        {
            @ViewBag.PageName = "Edit Agent";
            return View(_agentService.GetAgent(code));
        }
        #endregion

        #region Create agent 
        [HttpPost]
        public JsonResult AddAgent(BusinessEntities businessEntitiesObj)
        {
            var agentHash = _agentService.AddAgent(businessEntitiesObj);
            return Json(agentHash, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Update agent information
        [HttpPost]
        public JsonResult UpdateAgentInfo(BusinessEntities businessEntitiesObj)
        {
            var updatedAgentHash = _agentService.UpdateAgentInfo(businessEntitiesObj);
            return Json(updatedAgentHash, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
#endregion