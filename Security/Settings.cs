namespace todolist.Security
{
    public class Settings
    {
        private static string secret = "ef63aae3f035386efa9bb5b71eef2798badcf78f53b348f5145984ce5b990c9d";

        public static string Secret { get => secret; set => secret = value; }
    }
}
