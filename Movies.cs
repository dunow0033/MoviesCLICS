using System;
using MoviesCLI;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesCLI
{
	class Movies
	{
		public string title { get; private set; }
		public string director { get; private set; }
		public string writer { get; private set; }
		public string actors { get; private set; }
		public string plot { get; private set; }
		public string dateReleased { get; private set; }
		public string rating { get; private set; }
		public string awards { get; private set; }

		public static List<Movies> movies = new List<Movies>();

		/*static Movies()
		{
			
		}*/

		public Movies(string title, string director, string writer, string actors, string plot, string dateReleased, string rating, string awards) 
		{
			this.title = title;
			this.director = director;
			this.writer = writer;
			this.actors = actors;
			this.plot = plot;
			this.dateReleased = dateReleased;
			this.rating = rating;
			this.awards = awards;

			// Add the current movie instance to the collection
			//movies.Add(this);
		}

		public static List<Movies> allMovies() {
			return movies;
		}

		public static Movies last() {
			//Movies movies1 = new Movies(title, director, writer, actors, plot, dateReleased, rating, awards);
			return movies.LastOrDefault();
		}
	}
}
