namespace UserManagementService.Models
{
    public class Student:User
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string ContactNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
       
        public string? ParentContactNumber { get; set; }
        public string ? ParentName { get; set; }
    }
}
