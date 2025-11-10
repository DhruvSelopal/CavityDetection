using CavityDetection.models.dtos;

namespace CavityDetection.Services
{
    public class UserService
    {
        private DentalCheckUpContext _context;
        public UserService(DentalCheckUpContext context)
        {
            _context = context;
        }
        
        public bool userExists(string username)
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
                Age = createUserDto.Age,
                Height = createUserDto.Height
            };

            _context.Users.Add(userDbo);

            var userDto = new UserDto
            {
                Id = userDbo.Id,
                Name = userDbo.Name,
                LastName = userDbo.LastName,
                Username = userDbo.Username,
                Age = userDbo.Age,
                Height = userDbo.Height
            };

            return userDto;
        }

        public bool Login(Login login)
        {
            var password = _context.Users
                .Where(u => u.Username == login.username)
                .Select(u => u.Password)
                .FirstOrDefault();

            if (password == login.password) return true;
            else return false;

        }

        public void  UpdateUser(UserUpdate userUpdated,string username)
        {
            var user = _context.Users
                        .Where(u => u.Username == username)
                        .FirstOrDefault();

            user.Age = userUpdated.Age;
            user.Height = userUpdated.Height;
            user.Name = userUpdated.Name;
            user.LastName = userUpdated.LastName;
        }

        public List<RecordDto> GetAllRecord(string username)
        {
            var userId = _context.Users
                                .Where(u => u.Username == username)
                                .Select(u => u.Id)
                                .FirstOrDefault();


            List<RecordDto> records = _context.Records
                                       .Where(r => r.UserId == userId)
                                       .Select(r => new RecordDto
                                       {
                                           ConfidenceLevel = r.ConfidenceLevel,
                                           RecordDt = r.RecordDt,
                                           RecordId = r.RecordId,

                                       }).ToList();
            return records;
        }
    }
}
