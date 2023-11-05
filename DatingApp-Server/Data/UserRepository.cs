using AutoMapper;
using AutoMapper.QueryableExtensions;
using DatingApp_Server.DTOs;
using DatingApp_Server.Entities;
using DatingApp_Server.Helpers;
using DatingApp_Server.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DatingApp_Server.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public UserRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<MemberDto> GetMemberByNameAsync(string name)
        {
            return await _context.Users
                .Where(x => x.UserName == name)
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<PagedList<MemberDto>> GetMembersAsync(UserParam userParam)
        {
            var query = _context.Users.AsQueryable();

            query = query.Where(u => u.UserName != userParam.CurrentUsername);
            query = query.Where(u => u.Gender == userParam.Gender);

            var minDob = (DateTime.Today.AddYears(-userParam.MaxAge - 1));
            var maxDob = (DateTime.Today.AddYears(-userParam.MinAge));

            query = query.Where(u => u.DateOfBirth >= minDob && u.DateOfBirth <= maxDob);

            query = userParam.OrderBy switch
            {
                "created" => query.OrderByDescending(x => x.Created),
                _ => query.OrderByDescending(u => u.LastActive)
            };

            return await PagedList<MemberDto>.CreateAsync(
                query.AsNoTracking().ProjectTo<MemberDto>(_mapper.ConfigurationProvider),
                userParam.PageNumber, userParam.PageSize);
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<AppUser> GetUserByNameAsync(string name)
        {
            return await _context.Users
                .Include(x => x.Photos)
                .FirstOrDefaultAsync(x => x.UserName == name);
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            return await _context.Users
                .Include(x => x.Photos)
                .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(AppUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}
