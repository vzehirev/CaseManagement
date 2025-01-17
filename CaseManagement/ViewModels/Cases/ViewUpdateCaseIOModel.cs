﻿using CaseManagement.Models.CaseModels;
using CaseManagement.ViewModels.Tasks.Output;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CaseManagement.ViewModels.Cases
{
    public class ViewUpdateCaseIOModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Number")]
        public string Number { get; set; }

        [Display(Name = "Status")]
        public int StatusId { get; set; }

        [Display(Name = "Priority")]
        public int PriorityId { get; set; }

        [Required]
        [Display(Name = "Subject")]
        public string Subject { get; set; }

        public int? TypeId { get; set; }

        public int? PhaseId { get; set; }

        public int? ServiceId { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public IEnumerable<CaseStatus> CaseStatuses { get; set; }

        public IEnumerable<CasePriority> CasePriorities { get; set; }

        public IEnumerable<CaseType> CaseTypes { get; set; }

        public IEnumerable<Service> CaseServices { get; set; }

        public int AllTasks { get; set; }

        public int CurrentTasksPage { get; set; }

        public int LastTasksPage { get; set; }

        public TaskOutputModel[] Tasks { get; set; }
    }
}