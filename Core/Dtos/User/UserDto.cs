﻿namespace Core.Dtos.User
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public Guid ProfileId { get; set; }
        public string ProfileName { get; set; }
    }
}


