using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DSCC_CW1_00013940.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public int? TagId { get; set; }

        [ForeignKey("TagId")]
        public Tag? Tag { get; set; }
    }
}
