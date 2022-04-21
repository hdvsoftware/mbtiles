using MBTileProvider.mbtiles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace MBTileProvider.Controllers
{
    public class TileController : Controller
    {
        private readonly IAppsettings appsettings;

        public TileController(IAppsettings appsettings)
        {
            this.appsettings = appsettings;
        }

        [HttpGet("{z}/{x}/{y}")]
        public async Task<ActionResult<byte[]>> Get(int z, int x, string y)
        {

            y = y.Replace(".png", string.Empty);

            int yInt = int.Parse(y);
            

            yInt = (1 << z) - 1 - yInt;
            Tiles tile = null;
            try
            {
                using (var database = new TileContext(appsettings.SourceFile))
                {
                    //if(database.DatabaseFileExists == true) {
                    tile = await database.Tiles.SingleAsync(t =>
                                                t.tile_column == x
                                                && t.tile_row == yInt
                                                && t.zoom_level == z);
                    //}                
                }
            } catch(Exception e)
            {
                return NotFound();
            }

            
            if (tile == null)
            {
                return NotFound();
            }
            return File(tile.tile_data, "image/png");
        }
    }
}
