using Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    using Infrastructure.DataModel;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserRepository : IUserRepository
    {

        public UserRepository() { }


        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            try
            {
                using (var ctx = new ecopanelDBContext())
                {
                    var users = await ctx.User.Include(x => x.UsersRoles).ToListAsync();
                    foreach (var item in users)
                    {
                        if (item.UsersRoles.Any())
                        {
                            var userRoles = await ctx.UsersRoles.Where(x => x.UserId == item.Id).Include(x => x.Role).ToListAsync();
                            item.UsersRoles = new List<UsersRoles>(userRoles);
                        }
                    }
                    return users;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> GetByIdAsync(int userId)
        {
            try
            {
                using (var ctx = new ecopanelDBContext())
                {
                    var result = await ctx.User.Where(x => x.Id == userId).FirstOrDefaultAsync();

                    if (result.UsersRoles.Any() || result.UsersRoles == null)
                    {
                        var userRoles = await ctx.UsersRoles.Where(x => x.UserId == userId).Include(x => x.Role).ToListAsync();
                        result.UsersRoles = new List<UsersRoles>(userRoles);
                    }

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Insert(User user)
        {
            try
            {
                using (var ctx = new ecopanelDBContext())
                {
                    ctx.Entry<User>(user).State = EntityState.Added;

                    var resultUpdate = await ctx.SaveChangesAsync();

                    return resultUpdate;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Update(User user)
        {
            try
            {
                var resultDeleteRoles = await DeleteUserRoles(user.Id);

                if (resultDeleteRoles != 0)
                {
                    using (var ctx = new ecopanelDBContext())
                    {
                        var userEntity = await ctx.Set<User>().FindAsync(user.Id);
                        if (userEntity != null)
                        {
                            ctx.Entry<User>(userEntity).CurrentValues.SetValues(user);
                            userEntity.UsersRoles = new List<UsersRoles>();
                            userEntity.UsersRoles = user.UsersRoles;
                            ctx.Entry<User>(userEntity).State = EntityState.Modified;

                            var resultUpdate = await ctx.SaveChangesAsync();

                            return resultUpdate;
                        }
                    }
                    return 0;
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Delete(int userId)
        {
            try
            {
                using (var ctx = new ecopanelDBContext())
                {
                    var user = await ctx.User.FindAsync(userId);

                    if (user != null)
                    {
                        await DeleteUserRoles(user.Id);
                        ctx.Set<User>().Attach(user);
                        ctx.Set<User>().Remove(user);

                        return await ctx.SaveChangesAsync();
                    }
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<int> DeleteUserRoles(int userId)
        {
            try
            {
                using (var ctx = new ecopanelDBContext())
                {
                    var usersRolesToDelete = ctx.UsersRoles.Where(x => x.UserId == userId).ToList();

                    if (!usersRolesToDelete.Any()) return 0;

                    foreach (var item in usersRolesToDelete)
                    {
                        ctx.Set<UsersRoles>().Attach(item);
                    }
                    ctx.Set<UsersRoles>().RemoveRange(usersRolesToDelete);

                    return await ctx.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> GetByCredentials(string username, string password)
        {
            try
            {
                using (var ctx = new ecopanelDBContext())
                {
                    var result = await ctx.User.Where(x => x.Username == username && x.UserPassword == password).FirstOrDefaultAsync();

                    if (result.UsersRoles.Any())
                    {
                        var urs = await ctx.UsersRoles.Where(x => x.UserId == result.Id).Include(x => x.Role).ToListAsync();
                        result.UsersRoles = new List<UsersRoles>(urs);
                    }

                    return result;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
