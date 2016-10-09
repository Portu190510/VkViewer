using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using VkDialogViewer.Core.Entities;
using VkDialogViewer.Core.Interfaces;
using VkDialogViewer.Core.Models.Sync;
using VkDialogViewer.Core.Models.VkModel;
using VkDialogViewer.DAL.Repository;

namespace VkDialogViewer.BLL.Providers
{
    public class VkSyncProvider : IVkSyncProvider
    {
        private readonly IRepository<VkMessage> vkMessageRepository;

        private readonly IVkApiProvider vkApiProvider;

        public VkSyncProvider(IRepository<VkMessage> vkMessageRepository)
        {
            this.vkMessageRepository = vkMessageRepository;
        }
        public bool SyncMessages(SyncMessageSettingsModel model, AccessTokenResponse token)
        {
            try
            {
                for (var i = 0; i < model.SyncMessageCount; i++)
                {
                    var lastSyncedMessageCount = this.vkMessageRepository.All().Count();
                    var messagesList = this.vkApiProvider.LoadMessagesByUserId(token.AccessToken,
                        model.OwnerUserId.ToString(), 200, lastSyncedMessageCount);

                    var messagesDbList = Mapper.Map<List<DialogMessage>, List<VkMessage>>(messagesList.ToList());

                    foreach (var message in messagesDbList)
                    {
                        this.vkMessageRepository.Create(message);
                    }

                }

                this.vkMessageRepository.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}