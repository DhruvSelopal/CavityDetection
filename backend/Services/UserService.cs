using CavityDetection.models.dtos;
using Microsoft.EntityFrameworkCore;

namespace CavityDetection.Services
{
    public class UserService
    {
        private readonly DentalCheckUpContext _context;

        public UserService(DentalCheckUpContext context)
        {
            _context = context;
        }

        public bool UserExists(string username)
        {
            return _context.Users.Any(u => u.Username == username);
        }

        public UserDto CreateUser(CreateUserDto createUserDto)
        {
            var userDbo = new UserDbo
            {
                Id = Guid.NewGuid(),
                Name = createUserDto.Name,
                LastName = createUserDto.LastName,
                Username = createUserDto.Username,
                Password = createUserDto.Password,
                Age = createUserDto.Age,
                Height = createUserDto.Height
            };

            _context.Users.Add(userDbo);
            _context.SaveChanges(); // ❗ VERY IMPORTANT ❗

            return new UserDto
            {
                Id = userDbo.Id,
                Name = userDbo.Name,
                LastName = userDbo.LastName,
                Username = userDbo.Username,
                Password = userDbo.Password,
                Age = userDbo.Age,
                Height = userDbo.Height
            };
        }

        public bool Login(Login login)
        {
            var password = _context.Users
                .Where(u => u.Username == login.username)
                .Select(u => u.Password)
                .FirstOrDefault();

            if (password == null)
                return false;

            return password == login.password;
        }

        public void UpdateUser(UserUpdate userUpdated)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == userUpdated.username);
            if (user == null) return;

            user.Age = userUpdated.Age;
            user.Height = userUpdated.Height;
            user.Name = userUpdated.Name;
            user.LastName = userUpdated.LastName;

            _context.SaveChanges(); // ❗ Save
        }

        public List<RecordDto> GetAllRecord(string username)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (user == null) return new List<RecordDto>();

            return _context.Database.SqlQuery<RecordDto>($@"
            SELECT 
                r.RecordId,
                r.ConfidenceLevel,
                r.RecordDt,
                i.FilePath AS ImagePath
            FROM Records AS r
            JOIN Images AS i
                ON r.ImageId = i.ImageId
            WHERE r.UserId = {user.Id}
        ").ToList();
        }
    }

}
