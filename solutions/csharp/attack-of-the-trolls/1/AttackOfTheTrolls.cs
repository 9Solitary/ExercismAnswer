enum AccountType
{
    Guest,
    User,
    Moderator
}

[Flags]
enum Permission : byte
{
    None = 0b00000000,
    Read = 0b00000001,
    Write = 0b00000010,
    Delete = 0b00000100,
    All = Read | Write | Delete
}

static class Permissions
{
    public static Permission Default(AccountType accountType)
    {
        return accountType switch
        {
            AccountType.Guest => Permission.Read,
            AccountType.User => Permission.Write | Permission.Read,
            AccountType.Moderator => Permission.All,
            _ => Permission.None
        };
    }

    public static Permission Grant(Permission current, Permission grant)
        => current |= grant;

    public static Permission Revoke(Permission current, Permission revoke)
        => current &= ~revoke;

    public static bool Check(Permission current, Permission check)
        => current.HasFlag(check);
}
