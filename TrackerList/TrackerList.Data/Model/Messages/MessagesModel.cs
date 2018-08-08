using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackerList.Data.UnitOfWork;
using TrackerList.Model;

namespace TrackerList.Data.Model
{
    public class MessagesModel : IMessagesModel
    {
        public IUnitOfWork unitOfWork;

        public MessagesModel(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public bool AddMessages(Messages message)
        {
            try
            {
                unitOfWork.MessagesRepository.Add(message);
                unitOfWork.Commit();
                if (message.Id > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { return false; }
        }

        public bool DeleteMessages(int id)
        {
            try
            {
                Messages messages = unitOfWork.MessagesRepository.GetSingle(id);
                if (messages == null)
                    return false;
                else
                {
                    unitOfWork.MessagesRepository.Delete(messages);
                    unitOfWork.Commit();
                    return true;
                }
            }
            catch (Exception ex) { return false; }
        }

        public IEnumerable<Messages> GetMessagesByListItem(int listItemId)
        {
            IEnumerable<Messages> ListItemMessgaes = Enumerable.Empty<Messages>();
            try
            {
                ListItemMessgaes = (from g in unitOfWork.MessagesRepository.FindBy(x => x.GroupListItemId == listItemId)
                                  select new Messages { }).ToList();
                return ListItemMessgaes;
            }
            catch (Exception ex) { return ListItemMessgaes; }
        }

        public bool UpdateMessages(Messages message)
        {
            try
            {
                Messages updateMessages = unitOfWork.MessagesRepository.GetSingle(message.Id);
                if (updateMessages == null)
                    return false;
                else
                {
                    if (!string.IsNullOrEmpty(message.Text))
                        updateMessages.Text = message.Text;
                    if (!string.IsNullOrEmpty(message.GroupListItemId.ToString()))
                        updateMessages.GroupListItemId = message.GroupListItemId;
                    if (!string.IsNullOrEmpty(message.CreatedBy.ToString()))
                        updateMessages.CreatedBy = message.CreatedBy;
                    if (!string.IsNullOrEmpty(message.CreatedOn.ToString()))
                        updateMessages.CreatedOn = message.CreatedOn;
                    if (!string.IsNullOrEmpty(message.ModifiedOn.ToString()))
                        updateMessages.ModifiedOn = message.ModifiedOn;
                    if (!string.IsNullOrEmpty(message.ModifiedBy.ToString()))
                        updateMessages.ModifiedBy = message.ModifiedBy;
                    unitOfWork.Commit();
                    return true;
                }
            }
            catch (Exception ex) { return false; }
        }
    }
}
