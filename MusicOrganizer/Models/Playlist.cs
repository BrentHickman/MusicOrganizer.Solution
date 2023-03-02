using System.Collections.Generic;

namespace MusicOrganizer.Models
{
  public class Playlist
  {
    private static List<Playlist> _instances = new List<Playlist> { };
    private static int _totalCount { get; set; } = 0;
    public string Name { get; set; }
    public int Id { get; }
    public List<Media> Medias { get; set; }
    public Playlist(string name)
    {
      Name = name;
      _instances.Add(this);
      Id = _totalCount++;
      Medias = new List<Media> {};
    }
    public static List<Playlist> GetAll()
    {
      return _instances;
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static Playlist Find(int searchId)
    {
      return _instances[searchId-1];
    }
    public void AddMedia(Media media)
    {
      Medias.Add(media);
    }
  }
}