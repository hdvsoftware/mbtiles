using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MBTileProvider.mbtiles {
    [Table("tiles")]
    public class Tiles {
        [Required]
        public int zoom_level { get; set; }

        [Required]
        public int tile_column { get; set; }

        [Required]
        public int tile_row { get; set; }

        [Required]
        public byte[] tile_data { get; set; }
    }
}
