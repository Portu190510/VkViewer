using AutoMapper;
using VkDialogViewer.Core.Entities;
using VkDialogViewer.Core.Models.VkModel;

namespace VkDialogViewer.BLL.AutoMapperConfig
{
    public static class VkEntityMapper
    {
        public static void Map()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<DialogMessage, VkMessage>().ReverseMap();
            });
        }
    }
}
