using System;

namespace CampusFacilitiesRegister
{
    public class FacilityIssue
    {
        public int IssueID { get; set; }

        public string Location { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public DateTime DateReported { get; set; }

        public string Priority { get; set; }

        public string Status { get; set; }

        public string ReportedBy { get; set; }
    }
}