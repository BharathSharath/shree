namespace YourApplication.Models
{
    public class Project
    {
        public string ProjectID { get; set; }
        public string ProjectName { get; set; }
        public int KYCID { get; set; }
        public KYC KYC { get; set; }
    }
}
