using System.IO;
using Microsoft.EntityFrameworkCore;

namespace MBTileProvider.mbtiles {
    public class TileContext : DbContext {
        private string dbPath = null;// Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "countries-raster.mbtiles");
        public DbSet<Tiles> Tiles { get; set; }

        public TileContext(string dbpath) {
            //dbPath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, tile_filename);
            dbPath = dbpath;
        }

        public bool DatabaseFileExists {
            get {
                return File.Exists(dbPath);
            }
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite("Filename=" + dbPath);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Tiles>().HasKey(r => new { r.tile_column, r.tile_row, r.zoom_level });

        }

    }
}
