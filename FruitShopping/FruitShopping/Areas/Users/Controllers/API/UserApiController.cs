using FruitShopping.Areas.Users.Models;
using FruitShopping.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace FruitShopping.Areas.Users.Controllers.API
{
	[EnableCors("AllowAny")]
	[Route("api/UserApi/{action}")]
	[ApiController]
	public class UserApiController : ControllerBase
	{
		private readonly FruitShoppingDbContext _db;

		public UserApiController(FruitShoppingDbContext dbContext)
		{
			_db = dbContext;
		}

		private byte[] GetSalt()
		{
			byte[] salt = new byte[32]; 
			using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
			{
				rng.GetBytes(salt);
			}
			return salt;
		}
		
		
		private byte[] CombinePassWordSalt(byte[] passWord, byte[] salt)
		{

			byte[] combine = new byte[passWord.Length + salt.Length];
			Array.Copy(passWord, combine, passWord.Length);
			Array.Copy(salt,0,passWord, passWord.Length,salt.Length);
			//var finalHash = Convert.ToBase64String(sha256.ComputeHash(passWordSaltHash));
			return combine;
		}

		[HttpPost]
		public async Task<string> CreateUser([FromBody] RegisterForm form)
		{

			if (form == null)
			{
				var user = await _db.Users.FindAsync(form.Email);
				if (user.Email == form.Email)
				{
					if (user.UserName == form.UserName)
					{
						return "此用戶名已有人使用";
					}
					return "此郵箱已註冊";
				}
				return "註冊資訊不能為空";
			}

			SHA256 sha256 = SHA256.Create();
			byte[] hashPass = sha256.ComputeHash(Encoding.UTF8.GetBytes(form.Password));
			byte[] salt = RandomNumberGenerator.GetBytes(32);
			byte[] combine = CombinePassWordSalt(hashPass, salt);
			byte[] finalPassWord = sha256.ComputeHash(combine);
			
			return "註冊成功";
		}
	}
}
