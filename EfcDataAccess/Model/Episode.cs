using System.ComponentModel.DataAnnotations;

namespace EfcDataAccess.Model;

  public class Episode
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int Runtime { get; set; }
        public string SeasonEpisode { get; set; }
        public int ShowId { get; set; }
    }