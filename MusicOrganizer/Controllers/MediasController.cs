using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;
using System.Collections.Generic;


namespace MusicOrganizer.Controllers
{
  public class MediasController : Controller
  {
    [HttpGet("/categories/{playlistId}/medias/new")]
    public ActionResult New(int playlistId)
    {
      Playlist playlist = Playlist.Find(playlistId);
      return View(playlist);
    }

    [HttpPost("/medias/delete")]
    public ActionResult DeleteAll()
    {
      Media.ClearAll();
      return View();
    }

    [HttpGet("/categories/{playlistId}/medias/{mediaId}")]
    public ActionResult Show(int playlistId, int mediaId)
    {
      Media media = Media.Find(mediaId);
      Playlist playlist = Playlist.Find(playlistId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("media", media);
      model.Add("playlist", playlist);
      return View(model);
    }
  }
}