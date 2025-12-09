using ProjectRecord.Common.Attribute;
using ProjectRecord.Models.Db;
using ProjectRecord.Models.Mapper.SystemUserMapper.Models;

namespace ProjectRecord.Models.Mapper.SystemUserMapper;

public interface ISystemUserRepository : IRepository<SystemUser>;

[AutoFrmVm(typeof(ISystemUserRepository))]
public class SystemUserRepository(SysDbContext sysDbContext) : RepositoryBase<SystemUser>(sysDbContext),
    ISystemUserRepository;