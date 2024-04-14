﻿using OldBarom.Core.Domain.Validation;
using OldBarom.Infra.Data.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OldBarom.Core.Domain.Entities.LinkList
{
    [Table("Categories", Schema = "LinkList")]

    public class Categories
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string? Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Description { get; set; }
        [Required]
        public string? ApplicationUserId { get; set; }
        public virtual ApplicationUser? ApplicationUser { get; set; }
        
        protected Categories()
        {
        }
        public Categories(string name, string description, string applicationUserId)
        {
            Name = name;
            Description = description;
            ApplicationUserId = applicationUserId;
            Validate(name, description, applicationUserId);
        }
        private void Validate(string name, string description, string applicationUserId)
        {
            if(name.Length < 3 || name.Length > 50)
            {
                throw new DomainExceptionValidation("Name must be between 3 and 50 characters");
            }
            if(description.Length > 100)
            {
                throw new DomainExceptionValidation("Description must be less than 100 characters");
            }
            
            if(string.IsNullOrWhiteSpace(applicationUserId))
            {
                throw new DomainExceptionValidation("Application User Error");
            }
        }
    }
}
