using System.ComponentModel.DataAnnotations;

namespace VkDialogViewer.Core.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public long Id;

        public override bool Equals(object obj)
        {
            var entity = obj as BaseEntity;

            var baseObj = entity;
            if (this.Id == baseObj?.Id)
            {
                return true;
            }

            return false;
        }
    }
}