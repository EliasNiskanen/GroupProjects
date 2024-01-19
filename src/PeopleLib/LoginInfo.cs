namespace PeopleLib
{
    public static class LoginInfo
    {
        //Käyttäjän tietojen tallennus kirjautumisen ajaksi
        public static bool LoggedIn = default;
        public static int Id;
        public static string? FirstName;
        public static string? LstName;
        public static string? NickName;
        public static string? Locality;
        public static string? Presentation;
        public static byte[]? Picture;//muutettu muoto string -> byte[]
        public static string? Email;
        public static string? Password;
    }
}
