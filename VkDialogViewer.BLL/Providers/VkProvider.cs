using System;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper.QueryableExtensions;
using LinqKit;
using VkDialogViewer.Core.Entities;
using VkDialogViewer.Core.Interfaces;
using VkDialogViewer.Core.Models.ViewModel;
using VkDialogViewer.DAL.Repository;

namespace VkDialogViewer.BLL.Providers
{
    public class VkProvider : IVkProvider
    {
        private readonly IRepository<VkMessage> vkMessRepository;

        public VkProvider(IRepository<VkMessage> vkMessRepository)
        {
            this.vkMessRepository = vkMessRepository;
        }

        public IQueryable<VkMessage> GetVkMessages(MessageFilterModel filter)
        {
            var predicate = this.GetFilters(filter);
            return this.vkMessRepository.Filter(predicate);
        }

        private Expression<Func<VkMessage, bool>> GetFilters(MessageFilterModel filter)
        {
            return PredicateBuilder.New<VkMessage>();
        }
    }
}