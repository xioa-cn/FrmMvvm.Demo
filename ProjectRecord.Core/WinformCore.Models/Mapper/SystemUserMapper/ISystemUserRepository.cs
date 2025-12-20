
using WinformCore.Common.Attribute;
using WinformCore.Models.Db;
using WinformCore.Models.Mapper.SystemUserMapper.Models;

namespace WinformCore.Models.Mapper.SystemUserMapper;

public interface ISystemUserRepository : IRepository<SystemUser>;

[AutoFrmVm(typeof(ISystemUserRepository))]
public class SystemUserRepository(SysDbContext sysDbContext) : RepositoryBase<SystemUser>(sysDbContext),
    ISystemUserRepository;