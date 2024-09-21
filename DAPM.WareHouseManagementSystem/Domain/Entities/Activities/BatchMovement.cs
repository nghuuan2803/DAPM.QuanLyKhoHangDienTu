using System.ComponentModel.DataAnnotations;

namespace WMS.Domain.Entities.Activities
{
    public class BatchMovement
    {
        [Key]
        public int Id { get; set; }
        public int BatchId { get; set; }
        public int OldZone { get; set; }
        public int NewZone { get; set; }

    }
}
