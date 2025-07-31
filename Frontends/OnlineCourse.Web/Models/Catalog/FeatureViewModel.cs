using System.ComponentModel.DataAnnotations;

namespace OnlineCourse.Web.Models.Catalog
{
    public class FeatureViewModel
    {
        [Required]
        public int Duration { get; set; }
    }
}
