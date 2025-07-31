using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using System.ComponentModel.DataAnnotations;

namespace OnlineCourse.Web.Models.Catalog
{
    public class CourseUpdateInput
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        [Required]
        public string CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Picture { get; set; }
        [Required]
        public IFormFile PhotoFormFile { get; set; }
        public FeatureViewModel Feature { get; set; }
    }
}
