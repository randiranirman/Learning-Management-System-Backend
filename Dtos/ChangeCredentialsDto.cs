    namespace UserManagementService.Dtos
    {
        public class ChangeCredentialsDto
        {
            public string TemporaryPassword { get; set; }= string.Empty;
            public string NewPassword { get; set; }= string.Empty;
            public string ConfirmPassword { get; set; }= string.Empty;

        }
    }
