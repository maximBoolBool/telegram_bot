using bot_entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace bot_entities.Repositories.Impl;

/// <inheritdoc cref="IUserRepository"/>
public class UserRepository : IUserRepository
{
    #region MyRegion

    private readonly BotTelegramContext _context;

    #endregion

    #region .ctor

    /// .ctor
    public UserRepository(BotTelegramContext context)
    {
        _context = context;
    }

    #endregion

    #region Public Methods
    
    /// <inheritdoc/>
    public async Task<UserEntity?> GetByIdAsync(long id, CancellationToken cancellationToken)
      => await _context.Users.FirstOrDefaultAsync(e => e.UserId == id, cancellationToken);

    /// <inheritdoc/>
    public async Task<UserEntity?> GetByTelegramId(string telegramId, CancellationToken cancellationToken)
        => await _context.Users.FirstOrDefaultAsync(e => e.UserTelegramID == telegramId, cancellationToken);

    /// <inheritdoc/>
    public async Task CreateUser(UserEntity newUser, CancellationToken cancellationToken)
    {
       await _context.Users.AddAsync(newUser, cancellationToken);
    }

    #endregion
}