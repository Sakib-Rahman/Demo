using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repository
{
    public interface IAgentRepository
    {
        IEnumerable<BusinessEntities> AgentList();
        IEnumerable<BusinessEntities> GetAgent(string code);
        int AddAgent(BusinessEntities businessEntityObj);
        int UpdateAgentInfo(BusinessEntities businessEntityObj);
        bool RecordExist(string code);

    }
    public class AgentRepository : IAgentRepository
    {
        AgentContext agentContextObj = new AgentContext();

        public IEnumerable<BusinessEntities> AgentList()
        {
            return agentContextObj.BusinessEntities.ToList();
        }

        public IEnumerable<BusinessEntities> GetAgent(string code)
        {
            var agentDetail = (from agent in agentContextObj.BusinessEntities
                               where agent.Code == code
                               select agent).ToList();
            return agentDetail;
        }

        public int AddAgent(BusinessEntities businessEntityObj)
        {
            businessEntityObj.CreatedOnUtc = DateTime.Now;
            businessEntityObj.UpdatedOnUtc = DateTime.Now;

            agentContextObj.BusinessEntities.Add(businessEntityObj);

            return agentContextObj.SaveChanges();

        }

        public int UpdateAgentInfo(BusinessEntities businessEntityObj)
        {
            (from update in agentContextObj.BusinessEntities where update.Code == businessEntityObj.Code select update).ToList().ForEach(update =>
            {
                update.Code = businessEntityObj.Code;
                update.Name = businessEntityObj.Name;
                update.MarkupPlan = businessEntityObj.MarkupPlan;
                update.Email = businessEntityObj.Email;

                update.Mobile = businessEntityObj.Mobile;
                update.Phone = businessEntityObj.Phone;
                update.Street = businessEntityObj.Street;
                update.City = businessEntityObj.City;

                update.State = businessEntityObj.State;

                update.Zip = businessEntityObj.Zip;
                update.Balance = businessEntityObj.Balance;
                update.CurrentBalance = businessEntityObj.CurrentBalance;
                update.Status = businessEntityObj.Status;
            });
            return agentContextObj.SaveChanges();

        }

        public bool RecordExist(string code)
        {
            return agentContextObj.BusinessEntities.Any(agent => agent.Code == code);
        }

    }

}
