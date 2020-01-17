using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Models;
using System.Collections.Generic;
using Services.Common;
using Services.CustomModels;
using Services.CustomModels.MapperSettings;
using Services.Managers.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Services.Identity.Implementations
{
	public class UserManager : IUserManager
	{
		private readonly TokenModel _tokenManagement;
		private SchoolBookContext dbContext;
		private User User;
		
		public UserManager(SchoolBookContext data, IOptions<TokenModel> tokenManagement)
		{
			this.dbContext = data;
			this._tokenManagement = tokenManagement.Value;
		}
		protected DbSet<User> DbSet { get { return dbContext.Set<User>(); } }
	
		public string LoginUser(LoginModel model)
		{
			User user = GetUser(model);
			if (user!=null)
			{
				var token = this.GenerateUserToken(new RequestTokenModel() { Email = user.Email, Role=user.Role });
				if (token.Length > 0)
				{
					var userToken = new UserToken() { Token = token, UserId=user.ID };
					dbContext.UserTokens.Add(userToken);
					dbContext.SaveChanges();

					return token;
				}
			}
			return "User not found";
		}
		public string Register(RegisterModel model)
		{
			if (this.isRegistered(model.Email) == false)
			{
				User = new User();
				
				var token = GenerateUserToken(new RequestTokenModel() { Email = model.Email, Role=Role.User });
				
				User = MapperConfigurator.Mapper.Map<User>(model);

				User.Password = HashPassword(model.Password);
				User.Role = Role.User;
				var userToken = new UserToken() { Token = token, User = User };
				
				this.dbContext.Users.Add(User);
				this.dbContext.UserTokens.Add(userToken);
				this.dbContext.SaveChanges();

				return token;

			}
			return "Problem with registration, try again";
		}
		public bool EditUser(EditPersonModel model)
		{
			var getUser = DbSet.SingleOrDefault(x => x.ID == model.ID);
			if (getUser == null)
			{
				return false;
			}
			getUser.Email = model.Email;
			getUser.FirstName = model.FirstName;
			getUser.LastName = model.LastName;
			getUser.Role = model.Role;

			var checkPasswordChange = VerifyHashedPassword(getUser.Password, model.Password);
			if (checkPasswordChange == false)
			{
				getUser.Password = HashPassword(model.Password);
			}

			dbContext.Update(getUser);
			dbContext.SaveChanges();
			return true;
		}

		public bool DeleteUser(int id)
		{
			var user = DbSet.SingleOrDefault(x => x.ID == id);
			if (user == null)
			{
				return false;
			}
			dbContext.Remove(user);
			dbContext.SaveChanges();
			return true;
		}
		public List<User> GetAll()
		{
			return DbSet.ToList();
		}
		private bool VerifyHashedPassword(string hashedPassword, string password)
		{
			byte[] buffer4;
			if (hashedPassword == null)
			{
				return false;
			}
			if (password == null)
			{
				throw new ArgumentNullException("password");
			}
			byte[] src = Convert.FromBase64String(hashedPassword);
			if ((src.Length != 0x31) || (src[0] != 0))
			{
				return false;
			}
			byte[] dst = new byte[0x10];
			Buffer.BlockCopy(src, 1, dst, 0, 0x10);
			byte[] buffer3 = new byte[0x20];
			Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
			using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
			{
				buffer4 = bytes.GetBytes(0x20);
			}
			return ByteArraysEqual(buffer3, buffer4);
		}
		private static bool ByteArraysEqual(byte[] buffer3, byte[] buffer4)
		{
			var res = StructuralComparisons.StructuralEqualityComparer.Equals(buffer3, buffer4);
			return res;
		}

		private string HashPassword(string password)
		{
			byte[] salt;
			byte[] buffer2;
			if (password == null)
			{
				throw new ArgumentNullException("Password is empty");
			}
			using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
			{
				salt = bytes.Salt;
				buffer2 = bytes.GetBytes(0x20);
			}
			byte[] dst = new byte[0x31];
			Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
			Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
			return Convert.ToBase64String(dst);
		}
		private User GetUser(LoginModel model)
		{
			var user = DbSet.SingleOrDefault(x => x.Email == model.Email);

			if (user != null && this.VerifyHashedPassword(user.Password, model.Password))
			{
				return user;
			}
			else
			{
				return null;
			}
		}
		private bool isRegistered(string email)
		{
			var check = DbSet.SingleOrDefault(x => x.Email == email);
			if (check != null)
			{
				return true;
			}
			return false;
		}
		private string GenerateUserToken(RequestTokenModel request)
		{
			string token = string.Empty;

			var claim = new List<Claim>()
			{
			  new Claim(ClaimTypes.Email, request.Email),
			  new Claim(ClaimTypes.Role, request.Role)
			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenManagement.Secret));
			var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var jwtToken = new JwtSecurityToken(
				_tokenManagement.Issuer,
				_tokenManagement.Audience,
				claim,
				expires: DateTime.Now.AddMinutes(_tokenManagement.AccessExpiration),
				signingCredentials: credentials
			);

			token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
			return token;
		}
	}
}
