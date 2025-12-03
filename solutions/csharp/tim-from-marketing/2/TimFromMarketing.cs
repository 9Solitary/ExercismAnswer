static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        string idPart = id == null ? "" : $"[{id}] - ";
        string deptPart = department?.ToUpper() ?? "OWNER";

        return $"{idPart}{name} - {deptPart}";
    }
}
