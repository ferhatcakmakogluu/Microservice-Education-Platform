using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace OnlineCourse.Web.Models.Catalog
{
    public class CourseCreateInput
    {
        public string UserId { get; set; }
        [Required]
        public string CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Description { get; set; }
        public string Picture { get; set; }
        public IFormFile PhotoFormFile { get; set; }
        public FeatureViewModel Feature { get; set; }
    }
}
