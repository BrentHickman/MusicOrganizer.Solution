using System.Collections.Generic;

namespace MusicOrganizer.Models
{
  public class Media
  {
    public string Title { get; set; }
    public string Artist { get; set; }
    public string Album { get; set; }
    public int Year { get; set; }
    public string Description { get; set; }
    public string TimeStamp { get; set; }
    public string DateAdded { get; set; }
    public int Id { get; }
    private static List<Media> _instances = new List<Media> { };

    public Media(string title, string artist, string album, int year, string description, string timeStamp, string dateAdded)
    {
      Title = title;
      Artist = artist;
      Album = album;
      Year = year;
      Description = description;
      TimeStamp = timeStamp;
      DateAdded = dateAdded;
      _instances.Add(this);
      Id = _instances.Count;
    }

    public static List<Media> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Media Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
