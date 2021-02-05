namespace WishList.Config
{
	public class AuthenticationSettings
	{
		public Facebook Facebook { get; set; }
		public Twitter Twitter { get; set; }
		public Google Google { get; set; }
	}

	public class Facebook
	{
		public string AppId { get; set; }
		public string AppSecret { get; set; }
	}

	public class Twitter
	{
		public string ConsumerKey { get; set; }
		public string ConsumerSecret { get; set; }
	}

	public class Google
	{
		public string ClientId { get; set; }
		public string ClientSecret { get; set; }
	}
}
