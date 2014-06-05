
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;
using System.Net;

namespace Demo4George.Android
{
	public class BusinessLogic
	{
		public string[] GetAutoCompleteText()
		{
			// Use a web service if that floats your boat...
			return new string[] { "the who", "the sex pistols", "the ramones" };
		}


		public async Task<string> GetSearchResults(string searchText)
		{
			// Fake a slow web service call...
			await Task.Delay (3000);

			//
			using (var webClient = new WebClient ()) {
				var url = string.Format (@"http://musicbrainz.org/ws/2/artist/?query=artist:{0}", Uri.EscapeUriString (searchText));
				Console.WriteLine ("Searching: {0}", url);
								
				return await webClient.DownloadStringTaskAsync (url);
			}
		}
	}
}

