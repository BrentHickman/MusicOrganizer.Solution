using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;

namespace MusicOrganizer.Controllers
{
  public class PlaylistsController : Controller
  {
    [HttpGet("/playlists")]
    public ActionResult Index()
    {
      List<Playlist> allPlaylists = Playlist.GetAll();
      return View(allPlaylists);
    }

    [HttpGet("/playlists/new")]
  public ActionResult New()
  {
    return View();
  }

    [HttpPost("/playlists")]
  public ActionResult Create(string playlistName)
  {
    Playlist newPlaylist = new Playlist(playlistName);
    return RedirectToAction("Index");
  }

  // This one creates new Medias within a given Playlist, not new Playlists:

    [HttpPost("/playlists/{categoryId}/medias")]
    public ActionResult Create(int categoryId, string title, string artist, string album, int year, string description, string timeStamp, string dateAdded)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Playlist foundPlaylist = Playlist.Find(categoryId);
      Media newMedia = new Media(title, artist, album, year, description, timeStamp, dateAdded);
      foundPlaylist.AddMedia(newMedia);
      List<Media> categoryMedias = foundPlaylist.Medias;
      model.Add("medias", categoryMedias);
      model.Add("playlist", foundPlaylist);
      return View("Show", model);
    }

    [HttpGet("/playlists/{id}")]
  public ActionResult Show(int id)
  {
    Dictionary<string, object> model = new Dictionary<string, object>();
    Playlist selectedPlaylist = Playlist.Find(id);
    List<Media> categoryMedias = selectedPlaylist.Medias;
    model.Add("playlist", selectedPlaylist);
    model.Add("medias", categoryMedias);
    return View(model);
  }
  }
}