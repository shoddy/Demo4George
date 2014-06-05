using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Demo4George.Android
{
	[Activity (Label = "Demo4George.Android", MainLauncher = true)]
	public class MainActivity : Activity
	{
		BusinessLogic businessLogic = new BusinessLogic();

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Load the autocomplete text (static for now -- it could be from a web service)...
			AutoCompleteTextView autoCompleteSearch = FindViewById<AutoCompleteTextView> (Resource.Id.autoCompleteSearch);
			autoCompleteSearch.Adapter = new ArrayAdapter<String> (this, Resource.Layout.SearchResultListItem, businessLogic.GetAutoCompleteText());

			Button searchButton = FindViewById<Button> (Resource.Id.searchButton);
			TextView resultsText = FindViewById<TextView> (Resource.Id.resultsText);
			TextView searchingText = FindViewById<TextView> (Resource.Id.searchingText);

			searchButton.Click += async (sender, e) => {
				Console.WriteLine("Search clicked: {0}", autoCompleteSearch.Text);

				searchButton.Enabled = false;
				searchingText.Visibility = ViewStates.Visible;

				resultsText.Text = await businessLogic.GetSearchResults(autoCompleteSearch.Text);

				searchingText.Visibility = ViewStates.Gone;
				resultsText.Visibility = ViewStates.Visible;
				searchButton.Enabled = true;
			};

		}
	}
}


