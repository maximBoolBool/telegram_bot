using bot_entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace bot_entities.Repositories;

/// <summary>
///     Контекст для тг бота
/// </summary>
public class BotTelegramContext : DbContext
{
    #region Tables

    public DbSet<UserEntity> Users { get; set; } = null!;

    #endregion

    #region .ctor

    /// <summary>
    ///  .ctor
    /// </summary>
    public BotTelegramContext() { }

    /// <summary>
    ///     .ctor
    /// </summary>
    public BotTelegramContext(DbContextOptions<BotTelegramContext> options) : base(options) { }

    #endregion

    #region Overrides

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        UserEntity.Setup(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql();
        base.OnConfiguring(optionsBuilder);
    }

    #endregion
}