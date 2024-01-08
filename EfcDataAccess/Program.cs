// See https://aka.ms/new-console-template for more information

using EfcDataAccess;
using EfcDataAccess.Model;

Console.WriteLine("Hello, World!");
using var context = new DnpContext();
var dao = new DAO(context);

// Create a new show
var show = new Show { Title = "New Show", Year = 2021, Genre = "Drama" };
var createdShow = await dao.CreateShowAsync(show);
Console.WriteLine($"Created show: {createdShow.Title}");

// Add an episode to the created show
var episode = new Episode { Title = "New Episode", Runtime = 60, SeasonEpisode = "S01E01", ShowId = createdShow.Id };
var createdEpisode = await dao.AddEpisodeToShowAsync(episode);
Console.WriteLine($"Added episode: {createdEpisode.Title} to show: {createdShow.Title}");

// Get all shows
var allShows = await dao.GetAllAsync();
Console.WriteLine($"All shows: {allShows.Count}");

// Get all drama shows
var dramaShows = await dao.GetAllAsync(genre: "Drama");
Console.WriteLine($"Drama shows: {dramaShows.Count}");

// Get all shows from 2021
var showsFrom2021 = await dao.GetAllAsync(year: 2021);
Console.WriteLine($"Shows from 2021: {showsFrom2021.Count}");
