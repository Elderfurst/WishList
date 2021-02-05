namespace WishList.Config
{
	public class AuthenticationSettings
	{
		public Facebook Facebook { get; set; }
		public Twitter Twitter { get; set; }
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
}
