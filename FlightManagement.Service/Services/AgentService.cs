using ApplicationCore.Entities;
using ApplicationCore.Message;
using Infrastructure.Data.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ApplicationCore.Services
{
    public interface IAgentService
    {
        IEnumerable<BusinessEntities> AgentList();
        IEnumerable<BusinessEntities> GetAgent(string code);
        Hashtable AddAgent(BusinessEntities businessEntityObj);
        Hashtable UpdateAgentInfo(BusinessEntities businessEntityObj);
    }


    public class AgentService : IAgentService
    {
        UI_Message uiMessages = new UI_Message();
        ExceptionMessage exMessages = new ExceptionMessage();

        private ModelStateDictionary _modelState;
        private IAgentRepository _repository;

        public AgentService(ModelStateDictionary modelState, IAgentRepository repository)
        {
            _modelState = modelState;
            _repository = repository;
        }

        public IEnumerable<BusinessEntities> AgentList()
        {
            return _repository.AgentList();
        }

        public IEnumerable<BusinessEntities> GetAgent(string code)
        {
            return _repository.GetAgent(code);
        }

        public Hashtable AddAgent(BusinessEntities businessEntityObj)
        {
            Hashtable hashTableObj = new Hashtable();

            try
            {
                if (_modelState.IsValid)
                {
                    if (!_repository.RecordExist(businessEntityObj.Code))
                    {
                        var totalRecordSaved = _repository.AddAgent(businessEntityObj);
                        if (totalRecordSaved == 1)
                        {
                            hashTableObj.Add("Success", true);
                            hashTableObj.Add("Message", uiMessages.DataInsertionSuccess);
                        }
                        else
                        {
                            hashTableObj.Add("Success", false);
                            hashTableObj.Add("Message", uiMessages.DataInsertionFailed);
                        }
                    }
                    else
                    {
                        hashTableObj.Add("Success", false);
                        hashTableObj.Add("Message", uiMessages.RecordExist);
                    }
                }
                else
                {
                    hashTableObj.Add("Success", false);
                    hashTableObj.Add("Message", uiMessages.InvalidModel);
                }
                return hashTableObj;
            }
            catch (Exception)
            {
                hashTableObj.Add("Success", false);
                hashTableObj.Add("Message", exMessages.CommonException);
                return hashTableObj;
            }

        }

        public Hashtable UpdateAgentInfo(BusinessEntities businessEntityObj)
        {
            Hashtable hashTableObj = new Hashtable();

            try
            {
                if (_modelState.IsValid)
                {
                    var totalUpdatedRecord = _repository.UpdateAgentInfo(businessEntityObj);
                    if (totalUpdatedRecord == 1)
                    {
                        hashTableObj.Add("Success", true);
                        hashTableObj.Add("Message", uiMessages.UpdateSuccess);
                    }
                    else
                    {
                        hashTableObj.Add("Success", false);
                        hashTableObj.Add("Message", uiMessages.UpdateFailed);
                    }
                }
                else
                {
                    hashTableObj.Add("Success", false);
                    hashTableObj.Add("Message", uiMessages.InvalidModel);
                }
                return hashTableObj;
            }
            catch (Exception)
            {
                hashTableObj.Add("Success", false);
                hashTableObj.Add("Message", exMessages.CommonException);
                return hashTableObj;
            }

        }

    }
}
