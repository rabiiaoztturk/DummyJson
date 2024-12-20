﻿using System.Text.Json.Serialization;

namespace DummyJson.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
    }
    public class UserResponse
    {
        public List<User> Users { get; set; }
    }

}