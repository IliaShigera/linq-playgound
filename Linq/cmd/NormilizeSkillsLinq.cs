namespace cmd;

public static class NormilizeSkillsLinq
{

    public static string NormalizeSkills(List<string> skills)
    {
        return skills
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .Select(s => s.Trim().ToLowerInvariant())
            .Distinct()
            .OrderBy(s => s)
            .Aggregate((a, b) => $"{a}, {b}");
    }
}