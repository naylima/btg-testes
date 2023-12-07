namespace btg_testes_auto.PlaylistSongs
{
    public class PlaylistService
    {
        private readonly IPlaylistValidationService _playlistValidationService;

        public PlaylistService(IPlaylistValidationService playlistValidationService)
        {
            _playlistValidationService = playlistValidationService;
        }

        public bool AddSongToPlaylist(Playlist playlist, Song song)
        {
            if (_playlistValidationService.CanAddSongToPlaylist(playlist, song))
            {
                playlist.Songs.Add(song);
                return true;
            }
            return false;
        }

        public void AddSongsToPlaylist(Playlist playlist, List<Song> songs)
        {
            foreach(Song song in songs)
            {
                if (_playlistValidationService.CanAddSongToPlaylist(playlist, song))
                {
                    playlist.Songs.Add(song);
                }
            }
        }
    }
}
