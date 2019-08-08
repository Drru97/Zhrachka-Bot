namespace ZhrachkaBot.Abstractions
{
    public enum CommandResultKind
    {
        Unknown = 0,
        Text = 1,
        Image = 2,
        Location = 3,
        Audio = 4,
        Video = 5,
        Contact = 6,
        File = 7,
        Multipart = 8
    }
}
