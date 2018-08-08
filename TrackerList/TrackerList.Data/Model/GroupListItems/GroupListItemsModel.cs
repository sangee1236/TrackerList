using System;
using System.Collections.Generic;
using System.Linq;
using TrackerList.Data.UnitOfWork;
using TrackerList.Model;

namespace TrackerList.Data.Model
{
    public class GroupListItemsModel : IGroupListItemsModel
    {
        #region Private declartions
        public IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public GroupListItemsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        public IEnumerable<GroupListItems> GetGroupListItems(int groupId)
        {
            IEnumerable<GroupListItems> GroupListItems = Enumerable.Empty<GroupListItems>();
            try
            {
                GroupListItems = (from g in _unitOfWork.GroupRepository.FindBy(x => x.Id == groupId)
                                  join l in _unitOfWork.GroupListItemsRepository.FindBy(x => x.Id == groupId) on g.Id equals l.GroupId
                                  select new GroupListItems
                                  {
                                      Name = l.Name,
                                      Status = l.Status,
                                      Description = l.Description,
                                      GroupId = l.GroupId
                                  }
                                  ).ToList();
                return GroupListItems;
            }
            catch (Exception ex) { return GroupListItems; }
        }


        #region Crud Group 

        /// <summary>
        /// CreatedBy :sangee
        /// CreatedOn :07 Aug,2018
        /// Description: To Add a new ListItem
        /// </summary>
        /// <param name="groupListItems"></param>
        /// <returns></returns>
        public bool AddGroupListItems(GroupListItems groupListItems)
        {
            try
            {
                _unitOfWork.GroupListItemsRepository.Add(groupListItems);
                _unitOfWork.Commit();
                if (groupListItems.Id > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { return false; }
        }

        /// <summary>
        /// CreatedBy :sangee
        /// CreatedOn :07 Aug,2018
        /// Description :To update a existing ListItem details
        /// </summary>
        /// <param name="Group"></param>
        /// <returns></returns>
        public bool UpdateGroupListItems(GroupListItems groupListItems)
        {
            try
            {
                GroupListItems _groupListItems = _unitOfWork.GroupListItemsRepository.GetSingle(groupListItems.Id);
                if (_groupListItems == null)
                    return false;
                else
                {
                    if (!string.IsNullOrEmpty(groupListItems.Name))
                        _groupListItems.Name = groupListItems.Name;
                    if (!string.IsNullOrEmpty(groupListItems.Status.ToString()))
                        _groupListItems.Status = groupListItems.Status;
                    if (!string.IsNullOrEmpty(groupListItems.Description))
                        _groupListItems.Description = groupListItems.Description;
                    if (!string.IsNullOrEmpty(groupListItems.Name))
                        _groupListItems.GroupId = groupListItems.GroupId;
                    if (!string.IsNullOrEmpty(groupListItems.CreatedBy.ToString()))
                        _groupListItems.CreatedBy = groupListItems.CreatedBy;
                    if (!string.IsNullOrEmpty(groupListItems.CreatedOn.ToString()))
                        _groupListItems.CreatedOn = groupListItems.CreatedOn;
                    if (!string.IsNullOrEmpty(groupListItems.ModifiedOn.ToString()))
                        _groupListItems.ModifiedOn = groupListItems.ModifiedOn;
                    if (!string.IsNullOrEmpty(groupListItems.ModifiedBy.ToString()))
                        _groupListItems.ModifiedBy = groupListItems.ModifiedBy;

                    _unitOfWork.Commit();
                    return true;
                }
            }
            catch (Exception ex) { return false; }
        }

        /// <summary>
        /// CreatedBy :sangee
        /// CreatedOn : 07 Aug 2018
        /// Description :To delete a existing ListItem 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteGroupListItems(int id)
        {
            try
            {
                GroupListItems groupListItems = _unitOfWork.GroupListItemsRepository.GetSingle(id);
                if (groupListItems == null)
                    return false;
                else
                {
                    _unitOfWork.GroupListItemsRepository.Delete(groupListItems);
                    _unitOfWork.Commit();
                    return true;
                }
            }
            catch (Exception ex) { return false; }
        }
        #endregion
    }
}
