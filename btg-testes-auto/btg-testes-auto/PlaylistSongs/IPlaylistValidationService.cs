using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btg_testes_auto.PlaylistSongs
{
    public interface IPlaylistValidationService
    {
        bool CanAddSongToPlaylist(Playlist playlist, Song song);
    }
}
