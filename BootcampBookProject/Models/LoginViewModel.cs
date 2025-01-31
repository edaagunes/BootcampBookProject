﻿using System.ComponentModel.DataAnnotations;

namespace BootcampBookProject.Models
{
	public class LoginViewModel
	{
		[Required(ErrorMessage = "Lütfen Kullanıcı Adınızı Giriniz")]
		public string Username { get; set; }
		[Required(ErrorMessage = "Lütfen Şifrenizi Giriniz")]
		public string Password { get; set; }
	}
}
