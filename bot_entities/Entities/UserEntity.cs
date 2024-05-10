using System.ComponentModel.DataAnnotations.Schema;
using bot_entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace bot_entities.Entities;

/// <summary>
///    Сущность пользователя
/// </summary>
[Table("users")]
public class UserEntity
{
    /// <summary>
    ///     Id пользователя в системе
    /// </summary>
    [Column("user_id")]
    public long UserId { get; set; }
    
    /// <summary>
    ///     Id в телеграме
    /// </summary>
    [Column("user_telegram_id")]
    public string UserTelegramID { get; set; }
    
    /// <summary>
    ///     Статус пользователя
    /// </summary>
    [Column("status")]
    public UserStatusType Enum { get; set; }

    /// <summary>
    ///     Применить модель
    /// </summary>
    internal static void Setup(ModelBuilder builder)
    {
        builder.Entity<UserEntity>().HasKey(e => new {e.UserId, e.UserTelegramID } );
    }
}