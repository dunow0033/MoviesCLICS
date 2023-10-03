using System;
using MoviesCLI;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using System.IO;

namespace MoviesCLI
{
	class API
	{
		private static string API_key = "e6fd8697";
		private static string url = null;
		private static Uri uri;
		private static HttpClient httpClient = new HttpClient();

		private static string title, director, writer, actors, plot, dateReleased, rating, awards;

		//public static async Task<Movies> MovieInfo(string name)
		public static async void MovieInfo(string name)
		{
			url = $"http://www.omdbapi.com/?apikey={API_key}&t={name}";

			HttpClient httpClient = new HttpClient();
			

				HttpResponseMessage response = await httpClient.GetAsync(url);

				//if (Uri.TryCreate(url, UriKind.Absolute, out uri))
				//{
				// 'uri' contains the parsed URI
				//Console.WriteLine("Parsed URI: " + uri);
				//}
				//else
				//{
				//Console.WriteLine("Invalid URI");
				//}

				//try
				//{
				//HttpResponseMessage response = await httpClient.GetAsync(uri);

				if (response.IsSuccessStatusCode)
				{

					string jsonResponse = await response.Content.ReadAsStringAsync();

					var movieData = JObject.Parse(jsonResponse);
					//Dictionary<string, string> movieData = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonResponse);

					//Console.WriteLine(movies);

					string title = movieData.ContainsKey("Title") ? (string) movieData["Title"] : string.Empty;
					string director = movieData.ContainsKey("Director") ? (string) movieData["Director"] : string.Empty;
					string writer = movieData.ContainsKey("Writer") ? (string) movieData["Writer"] : string.Empty;
					string actors = movieData.ContainsKey("Actors") ? (string) movieData["Actors"] : string.Empty;
					string plot = movieData.ContainsKey("Plot") ? (string) movieData["Plot"] : string.Empty;
					string dateReleased = movieData.ContainsKey("Released") ? (string )movieData["Released"] : string.Empty;
					string rating = movieData.ContainsKey("Rated") ? (string) movieData["Rated"] : string.Empty;
					string awards = movieData.ContainsKey("Awards") ? (string) movieData["Awards"] : string.Empty;

					//foreach (var movie1 in movies)
					//{

					//	string key = movie1.Key;
					//	string value = movie1.Value.ElementAtOrDefault(0).ToString();

					//	if (key == "Title")
					//	{
					//		title = value;
					//	}
					//	//title = (string)movieData["Title"];
					//	//director = (string)movieData["Director"];
					//	//writer = (string)movieData["Writer"];
					//	//actors = (string)movieData["Actors"];
					//	//plot = (string)movieData["Plot"];
					//	//dateReleased = (string)movieData["Released"];
					//	//rating = (string)movieData["Rated"];
					//	//awards = (string)movieData["Awards"];
					//	else if (key == "Director")
					//	{
					//		director = value;
					//	}
					//	else if (key == "Writer")
					//	{
					//		writer = value;
					//	}
					//	else if (key == "Actors")
					//	{
					//		actors = value;
					//	}
					//	else if (key == "Plot")
					//	{
					//		plot = value;
					//	}
					//	else if (key == "Released")
					//	{
					//		dateReleased = value;
					//	}
					//	else if (key == "Rated")
					//	{
					//		rating = value;
					//	}
					//	else if (key == "Awards")
					//	{
					//		awards = value;
					//	}
					//}

					new Movies(title, director, writer, actors, plot, dateReleased, rating, awards);

					//Movies.movies.Add(movies);
				}
				else
				{
					Console.WriteLine($"HTTP request failed with status code: {response.StatusCode}");
				}


			Console.WriteLine();
			Console.WriteLine($"Movie: {Movies.last().title}");
			Console.WriteLine($"Director: {Movies.last().director}");
			Console.WriteLine($"Date Released: {Movies.last().dateReleased}");
			Console.WriteLine($"Rating: {Movies.last().rating}");
			Console.WriteLine();
			Console.WriteLine();
			//}
			//catch (HttpRequestException e)
			//{
			//	Console.WriteLine($"HTTP request error: {e.Message}");
			//}

			//Movies.getMovies();

			//return null;
		}

		public static async Task<bool?> checkForInvalidMovie(string name) {

			//it grabs the API URL, just like the beginning of the trivia obtaining function

			using (var httpClient = new HttpClient())
			{
				string url = $"http://www.omdbapi.com/?apikey={API_key}&t={name}";

				try
				{
					HttpResponseMessage response = await httpClient.GetAsync(uri);

					if (response.IsSuccessStatusCode)
					{
						string jsonResponse = await response.Content.ReadAsStringAsync();

						//var movies = JsonConvert.DeserializeObject<Movies>(jsonResponse);
						var movies = JObject.Parse(jsonResponse);

						if (movies.TryGetValue("Response", out var responseValue) && responseValue.ToString() == "False")
							return null;
						else
							return true;
					}
					else
					{
						return null;
					}
				}
				catch (HttpRequestException e)
				{
					return null;
				}
			}
		}
	}
}
