using System;
using System.ComponentModel.DataAnnotations;

namespace prop_central_netcore.Dto
{
	public class BaseImageUrlDto
	{
        public Guid Id { get; set; }

        [Display(Name = "Image")]
        [Required]
        public string ImageUrl { get; set; }
    }
}

