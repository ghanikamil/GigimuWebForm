using Gigimu.InterfaceBLL;
using GigimuAPI.Helpers;
using GigimuAPI.ViewModels;
using GigimuDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GigimuAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasiensController : ControllerBase
    {
        private readonly IDokterBLL _dokterBLL;
        private readonly IJadwalBLL _jadwalBLL;
        private readonly IBookingBLL _bookingBLL;
        private readonly IPasienBLL _paienBLL;
        private readonly AppSettings _appSettings;
        public PasiensController(IDokterBLL dokterBLL,IJadwalBLL jadwalBLL, IBookingBLL bookingBLL, IPasienBLL paienBLL, IOptions<AppSettings> appSetting)
        {
            _dokterBLL = dokterBLL;
            _jadwalBLL = jadwalBLL;
            _bookingBLL = bookingBLL;
            _paienBLL = paienBLL;
            _appSettings = appSetting.Value;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(AddPasienDTO userCreate)
        {
            if (userCreate == null)
            {
                return BadRequest();
            }

            try
            {
                await _paienBLL.InsertAsync(userCreate);
                return Ok("Insert data success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var result = await _paienBLL.LoginAsync(loginDTO.Email,loginDTO.Password);
            if (result != null)
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, result.Email));

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var userWithToken = new UserWithToken
                {
                    Name = result.Nama,
                    Email = result.Email,
                    Token = tokenHandler.WriteToken(token)
                };
                return Ok(userWithToken);
            }
            else
            {
                return BadRequest("invalid credentials");
            }
        }
        [HttpPut("UpdateProfilPasien")]
        public async Task<IActionResult> UpdateProfilPasien(UpdateProfilePasienDTO updateProfilePasienDTO)
        {
            try
            {
                await _paienBLL.UpdateAsync(updateProfilePasienDTO);
                return Ok("Update data success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpGet("GetAllDokter")]
        public async Task<IEnumerable<DokterDTO>> GetDokter()
        {
            var results = await _dokterBLL.GetAllAsync();
            return results;
        }
        [Authorize]
        [HttpGet("GetJadwalByDokter")]
        public async Task<IEnumerable<JadwalDTO>> GetJadwalDokter(int dokterID)
        {
            var results = await _jadwalBLL.GetJadwalByDokterAsync(dokterID);
            return results;
        }
        [HttpGet("GetAllMyBook")]
        public async Task<IEnumerable<BookingDTO>> GetAllMyBook(int pasienID)
        {
            var results = await _bookingBLL.GetBookingByPasienAsync(pasienID);
            return results;
        }
        [HttpPost("AddBooking")]
        public async Task<IActionResult> AddBooking(AddBookingDTO addBooking)
        {
            if (addBooking == null)
            {
                return BadRequest();
            }

            try
            {
                await _bookingBLL.InsertAsync(addBooking);
                return Ok("Insert data success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteBooking")]
        public async Task<IActionResult> DeleteBooking(int BookingID)
        {
            try
            {
                await _bookingBLL.DeleteAsync(BookingID);
                return Ok("delete data success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
