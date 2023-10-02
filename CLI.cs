﻿using System;
using MoviesCLI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesCLI
{
	class CLI
	{
		private string movie;

		public void first()
		{
			greet_user();
		}

		public void greet_user()
		{
			Console.WriteLine();
			Console.WriteLine("Welcome to the movie trivia app!!");
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("Please enter a movie title:  ");
			movie = prompt_for_answer();

			while(movie != "q")
			{
				while(API.checkForInvalidMovie(movie) == null)
				{
					Console.WriteLine();
					Console.WriteLine("Invalid movie title, please try again (or 'q' to quit)):  ");
					movie = prompt_for_answer();
				}

				API.MovieInfo(movie);

				display_movie_data();

				Console.WriteLine("Would you like to see additonal info for that movie or see trivia for another movie? ('y' or 'n'):  ");

				additional_movie_answer();

				movie = next_movie();
			}
		}

		public string prompt_for_answer()
		{
			return Console.ReadLine();
		}

		public string next_movie()
		{

			Console.WriteLine();
			Console.WriteLine("Please enter another movie title (or 'q' to quit):  ");

			return prompt_for_answer();
		}

		public static void display_movie_data()
		{
			//Console.WriteLine(Movies.last());

			//Movies movie1 = new Movies(Movies.last().title, Movies.last().director, Movies.last().dateReleased, Movies.last().rating, Movies.last().writer, Movies.last().actors, Movies.last().plot, Movies.last().awards);

			Console.WriteLine();
			Console.WriteLine($"Movie: {Movies.last()}");
			Console.WriteLine($"Director: {Movies.last()}");
			Console.WriteLine($"Date Released: {Movies.last()}");
			Console.WriteLine($"Rating: {Movies.last()}");
			Console.WriteLine();
			Console.WriteLine();
		}

		public void additional_movie_answer()
		{
			string answer = prompt_for_answer();

			if (answer.Equals("y"))
				additional_movie_data();
			else if (answer.Equals("n")) {
				Console.WriteLine();
				Console.WriteLine();
				greet_user();
			}
			else {
				Console.WriteLine("Sorry, I didn't understand that response!!  Let's go back to the beginning!!");
				Console.WriteLine();
				greet_user();
			}
		}

		public void additional_movie_data()
		{

			Console.WriteLine();
			Console.WriteLine($"Writer: {Movies.last()}");
			Console.WriteLine($"Actors: {Movies.last()}");
			Console.WriteLine($"Plot: {Movies.last()}");
			Console.WriteLine($"Awards: {Movies.last()}");
			Console.WriteLine();
			Console.WriteLine();
		}
	}
}
