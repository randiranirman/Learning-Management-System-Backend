﻿namespace UserManagementService.Dtos
{
    public class UserDto
    {
        public string Name { get; set; } = string.Empty;
        public string Username { get; set; }
        = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string Role { get; set; }= string.Empty;
        public string Password {  get; set; } = string.Empty;
    }
}
